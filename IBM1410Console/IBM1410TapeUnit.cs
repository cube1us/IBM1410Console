using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace IBM1410Console
{
    internal class IBM1410TapeUnit {

        public const int TAPE_IRG = 0x80;
        public const int TAPE_TM = 0x0f;

        public const int TAPEUNITIRG = -1;
        public const int TAPEUNITNOTREADY = -3;

        private int unit;
        private int channel;

        private String _fileName;
        private long _recordNumber;
        private Boolean _loaded;
        private Boolean _fileProtect;
        private Boolean _ready;
        private Boolean _selected;
        private Boolean _tapeIndicate;
        private Boolean _highDensity;
        private Boolean _bot;
        private Boolean _busy;

        private FileStream fd;
        private int tape_buffer;

        private Boolean irgRead;          // True if tape_buffer is full
        private Boolean writeIRG;         // Write IRG on next write
        private Boolean modified;

        //  Set up many of the fields as properties...

        protected String FileName { get { return _fileName; } }
        protected long RecordNumber { get { return _recordNumber; } }
        protected Boolean Loaded { get { return _loaded; } }
        protected Boolean FileProtect { get { return _fileProtect; } }
        protected Boolean Ready { get { return _ready; } }
        protected Boolean Selected { get { return _selected; } }
        protected Boolean TapeIndicate { get { return _tapeIndicate; } }
        protected Boolean HighDensity { get { return _highDensity; } }
        protected Boolean Bot { get { return _bot; } }

        // Constructor.  Defers most of the work to Init - which can also be invoked later
        // if a new tape is mounted.

        public IBM1410TapeUnit(int channel, int unit) {
            fd = null;
            Init(channel,unit);
        }

        //  Initializer - used by the constructor, and externally.
        public void Init(int channel, int unit) {

            //  If there is some existing file associated with this tape unit,
            //  Forget about it...

            if(fd != null) {
                fd = null;
            }

            this.unit = unit;
            this.channel = channel;

            _loaded = _fileProtect = _tapeIndicate = _ready = _selected = _bot = false;
            _highDensity = true;
            _fileName = null;
            _recordNumber = 0;
            UpdateFPGATape();
        }

        //  Methods to respond to calls from the user interface and elsewhere


        protected void Reset() { 
            _ready = false;
            UpdateFPGATape();
        }


        //  Load the tape (file) (if not already loaded), and rewind.

        protected Boolean LoadRewind() {
            
            //  If the drive is currently in ready state, you can't load or rewind it.

            if(_ready) {
                return false;
            }

            //  If the tape had already been written, write a closing 0 and IRG

            if(modified && writeIRG) {
                Debug.Assert(fd != null);
                Write(0);
                modified = false;
            }

            //  If the tape is loaded, just rewind...

            if(fd != null) {
                try {
                    fd.Seek(0, SeekOrigin.Begin);
                    irgRead = modified = false;
                    _recordNumber = 0;
                    _bot = _loaded = true;
                    UpdateFPGATape();
                    return (true);
                }
                catch(Exception e) {
                    Debug.WriteLine("LoadRewind: Seek failed on tape unit " + channel.ToString() + 
                       unit.ToString());
                    ResetFile();
                    _bot = _loaded = _ready = false;
                    UpdateFPGATape();
                    return (false);
                }
            }

            if(_fileName == null || _fileName.Length == 0) {
                _ready = false;
                UpdateFPGATape();
                return false;
            }

            //  Open the file.  First try read/write.  If that failes, try read only, and set file protect

            try {
                fd = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                _fileProtect = false;
            }
            catch (Exception e) {
                try {
                    fd = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                    _fileProtect = true;
                }
                catch (Exception e2) {
                    Debug.WriteLine("LoadRewind: new FileStream failed on tape unit " + 
                        channel.ToString() + unit.ToString());
                    Debug.WriteLine(e2.ToString());
                    ResetFile();
                    _loaded = _ready = _bot = false;
                    UpdateFPGATape();
                    return false;
                }
            }

            irgRead = modified = false;
            writeIRG = true;
            _recordNumber = 0;
            _bot = _loaded = true;
            UpdateFPGATape();
            return true;
        }

        //  Unload the tape (file)
        protected Boolean Unload() {
            
            //  If the drive is ready or not loaded, ignore...

            if(_ready || !_loaded) {
                return false;
            }

            ResetFile();
            _tapeIndicate = false;
            UpdateFPGATape();
            return true;
        }

        //  Mount a tape (file) on the drive

        protected Boolean Mount(String fileName) {

            //  Can't mount a tape if the drive is ready or already loaded

            if (_ready || _loaded || fileName == null || fileName.Length == 0) {
                return false;
            }

            Debug.Assert(fd == null);
            _fileName = fileName;
            irgRead = writeIRG = _fileProtect = _tapeIndicate = modified = _bot = false;
            UpdateFPGATape();
            return true;
        }

        //  Handle the Start button

        protected Boolean Start() {

            //  If the drive is already ready, is is not loaded, can't comply.

            if (_ready || !_loaded) {
                return false;
            }

            Debug.Assert(fd == null);
            _ready = true;
            UpdateFPGATape();
            return true;
        }

        //  Handle the Density change button

        protected Boolean ChangeDensity() {

            //  Can't change density on a ready drive.

            if (_ready) {
                return false;
            }
            _highDensity = !_highDensity;
            UpdateFPGATape();
            return true;
        }
        
        //  Select a tape drive - really just used for reporting and error checking
        //  in this implementation.  The actual selection process happens bundled with
        //  the unit control, read or write instruction in the Tape Adapter Unit in the FPGA
        protected Boolean Select(Boolean b) {
            _selected = b;
            #if TAPEDEBUG
            if(fd != null && !_busy) {
                Debug.WriteLine("TapeUnit unit " + channel.ToString() + unit.ToString() + " selected");
                Debug.WriteLine("TapeUInit current file offset is " + fd.Position);
            }
            #endif
            return true;
        }

        //  Rewind to the beginning of the tape (file)

        protected Boolean Rewind() {
            if (!_selected || !_loaded || !_ready) {
                Debug.WriteLine("TapeUnit Rewind unit " + channel.ToString() + unit.ToString() +
                    " not selected, loaded and ready.");
                return false;
            }

            Debug.WriteLine("TapeUnit Rewind unit " + channel.ToString() + unit.ToString());

            Debug.Assert(fd != null);

            //  If the tape has been written to, end the file properly (a kind of implicit 
            //  tape mark, I suppose)

            if (modified && writeIRG) {
                if (!Write(0)) {
                    return false;
                }
                writeIRG = modified = false;
            }

            try {
                fd.Seek(0, SeekOrigin.Begin);
            }
            catch (Exception e) {
                Debug.WriteLine("TapeUnit Rewind failed with exception " + e.ToString());
                ResetFile();
                UpdateFPGATape();
                return false;
            }

            irgRead = modified = false;
            writeIRG = true;
            SetBusy(5 * _recordNumber);
            _recordNumber = 0;
            _bot = true;
            return true;
        }

        //  Rewind and Unload

        protected Boolean RewindUnload() {

            //  Do the rewind.  If it fails, reset.

            if(!Rewind()) {
                ResetFile();
                UpdateFPGATape() ;
                return false;
            }

            ResetFile();
            _tapeIndicate = false;
            return true;
        }

        //  (Erase / Skip and blank tape -- does nothing unless we someday have measured tape)

        protected Boolean Skip() {
            #if TAPEDEBUG
                Debug.WriteLine("TapeUnit Skip on unit " + channel.ToString() + unit.ToString());
            #endif 

            if(!_selected || !_loaded || !_ready) {
                return false;
            }
            writeIRG = true;
            return true;
        }

        //  Space forward: read until an IRG is hit.  (D Character "A", NOT in the 1410 Principles
        //  of operation?

        protected int Space() {

            int rc;

            #if TAPEDEBUG
                Debug.WriteLine("TapeUnit Space unit " + channel.ToString() + unit.ToString());
            #endif

            while ((rc = Read()) >= 0) {
                // Do nothing
            }

            SetBusy(2);
            return rc;
        }

        //  Backspace.  This is a pain.  To do it, we have to take TWO steps (CHARACTERS!) back, and then
        //  one step forward to search for an IRG

        protected Boolean Backspace() {

            //  Drive must be selected, ready and loaded.

            if (!_selected || !_ready || !_loaded) {
                Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                    " not loaded, selected and ready");
                return false;
            }

            Debug.Assert(fd != null);

            #if TAPEDEBUG
                Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                    " position: " + fd.Position().ToString());
            #endif

            //  If we are already a bot, this is a NOP

            if(_bot) {
                _recordNumber = 0;
                return true;
            }

            //  If we just ended a record, write out its IRG, then back up before it...

            if (modified && writeIRG) {
                if (!Write(0)) {
                    ResetFile();
                    UpdateFPGATape();
                    return false;
                }
                modified = writeIRG = irgRead = false;

                try {
                    fd.Seek(-1, SeekOrigin.Current);
                }
                catch (IOException e) {
                    Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                        " Seek back over EOR failed: " + e.ToString());
                    ResetFile();
                    UpdateFPGATape();
                    return false;
                }
            }

            //  Now, go into the two steps back, one step forward routine

            while(true) {

                //  If the position is 2 or less, we will be done

                if(fd.Position <= 2) {
                    irgRead = false;
                    _bot = writeIRG = true;
                    _recordNumber = 0;
                    Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                        " ended at BOT.");
                    return true;
                }

                //  Seek back 2 characters

                try {
                    fd.Seek(-2, SeekOrigin.Current);
                }
                catch (IOException e) {
                    Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                        " seek failed: " + e.ToString());
                    ResetFile();
                    UpdateFPGATape();
                    return false;
                }

                //  Read forward 1 character to see if it is an IRG.

                if((tape_buffer = fd.ReadByte()) < 0) {
                    Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                        " Read failed: unexpected error or EOF");
                    return false;
                }

                //  If we find the IRG bit on, we are done!

                if ((tape_buffer & TAPE_IRG) != 0) {
                    irgRead = writeIRG = true;
                    --_recordNumber;
                    #if TAPEDEBUG
                        Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                            " ENDED, position: " + fd.Position().ToString());
                    #endif
                    return true;
                }

                //  Otherwise later, rinse, repeat until we return.
            }
        }
        protected void ResetFile() {

        }

        //  Method to write a byte.  Doesn't need to worry about load mode, word separators, 
        //  parity or anything like that.

        protected Boolean Write(int c) {

            Debug.WriteLine("TapeUnit Write unit " + channel.ToString() + unit.ToString());

            if (!_loaded || !_ready || !_selected || fd == null) {
                Debug.WriteLine("TapeUnit write unit " + channel.ToString() + unit.ToString() +
                    " not ready, selected, loaded or fd is null");
                return false;
            }

            if (_fileProtect) {
                Debug.WriteLine("TapeUnit Write unit " + channel.ToString() + unit.ToString() +
                    " unit is file protected.");
                return false;
            }

            //  If we have an IRG left over from a previous read, back up over it.

            if (irgRead) {
                try {
                    Debug.WriteLine("TapeUnit unit " + channel.ToString() + unit.ToString() +
                        " seeking back over EOR from: " + fd.Position.ToString());
                    fd.Seek(-1, SeekOrigin.Current);
                    Debug.WriteLine("TapeUnit unit " + channel.ToString() + unit.ToString() +
                        " seeked back over EOR to: " + fd.Position.ToString());
                    irgRead = false;
                    writeIRG = modified = true;     // Set to write IRG later
                }
                catch(Exception e) {
                    Debug.WriteLine("TapeUnit unit " + channel.ToString() + unit.ToString() +
                        " seeking back over EOR failed: " + e.ToString());
                    ResetFile();
                    UpdateFPGATape();
                    return false;
                }

            }

            //  If we have an IRG left over to do from a previous write, or if the last
            //  operation was a read, set the IRG bit.

            if (writeIRG) {
                c |= TAPE_IRG;
            }

            //  Finally, we actually write out the character

            try {
                fd.WriteByte(Convert.ToByte(c));
            }
            catch(IOException e) {
                Debug.WriteLine("TapeUnit Write unit " + channel.ToString() + unit.ToString() +
                    " Failed, I/O Error: " + e.ToString());
                ResetFile();
                _tapeIndicate = true;
                UpdateFPGATape();
                return false;
            }

            irgRead = writeIRG = false;
            return true;
        }


        //  Mark the end of a record.  Called at the end of a trnsfer - sets the IRG flag
        //  for the start of the next record

        void WriteIRG() {
            writeIRG = modified = true;
            _bot = irgRead = false;
            ++_recordNumber;
        }


        //  Write a tape mark.  Just calls write to do the dirty work.  Note that
        //  tape marks are ALWAYS even parity.

        Boolean WriteTM() {
            Boolean status;

            #if TAPEDEBUG
                Debug.WriteLine("TapeUnit WTM unit " + channel.ToString() + unit.ToString());
            #endif

            ++_recordNumber;
            if(!Write(TAPE_TM | TAPE_IRG)) {
                return(false);
            }
            
            irgRead = modified = _bot = false;
            status = Write(TAPE_TM);
            writeIRG = modified = true;

            #if TAPEDEBUG
                Debug.WriteLine("TapeUnit WTM unit " + channel.ToString() + unit.ToString() +
                    " Position at end: " + fd.Position().ToString());
            #endif

            SetBusy(2);
            return status;
        }


        //  Read a byte of a record and send it off to the FPGA
        protected int Read() {

            int rc;

            if (!_loaded || !_ready || !_selected || fd == null) {
                Debug.WriteLine("TapeUnit Read unit " + channel.ToString() + unit.ToString() +
                    " not ready, selected, loaded or fd is null");
                return TAPEUNITNOTREADY;
            }

            //  Read a character, unless the last read resulted in an IRG, in which
            //  case it is already in the buffer.

            if (!irgRead) {
                if ((rc = ReadNextChar()) < 0) {
                    return rc;
                }
                tape_buffer = rc;
            }

            //  If we are at BOT or an IRG, strip the IRG bit from the character and 
            //  return the character.

            //  A Tape Mark is only a Tape Mark as the first character.  The FPGA is also
            //  paying attention to that, be we do here as well to properly set Tape Indicate

            if(_bot || irgRead) {
                tape_buffer &= ~TAPE_IRG;
                if ((tape_buffer & 0x3f) == TAPE_TM) {
                    _tapeIndicate = true;
                }
                _bot = irgRead = false;
            }

            //  If we hit the end of the record, then set IRG now, and return that

            if ((tape_buffer & TAPE_IRG) != 0) {
                #if TAPEDEBUG
                    Debug.WriteLine("TapeUnit Read " + channel.ToString() + unit.ToString() +
                        " found IRG character at position: " + fd.Position().ToString());
                #endif
                irgRead = true;
                _bot = false;
                ++_recordNumber;
                return (TAPEUNITIRG);
            }

            //  OK, just return the blinking' character already.  ;)

            //  Clear the IRG at this point, too, because if we had an IRG bit,
            //  it got handled in the preceeding if.  If we hit EOF on the file,
            //  the value in the character is already a tape mark wit the IRG set.

            irgRead = false;
            return (tape_buffer);
        }


        //  Utility method to read a character from the file, and handle a few odds and ends.
        //  Keeps us from having to do it all more than once, though right now it is only
        //  called from one place?

        protected int ReadNextChar() {

            int c;

            writeIRG = true;
            if ((c = fd.ReadByte()) < 0) {
                Debug.WriteLine("TapeUnit ReadNextChar unit " + channel.ToString() + unit.ToString() +
                    " Error or EOF.");
                return (TAPE_TM | TAPE_IRG);
            }
            return (c);
        }

         //  TODO: When a tape drive status changes in any way, we need to send a message to the
         //  FPGA so it can update its  local status.

         protected void UpdateFPGATape() {

         }

        //  TODO:  Need to have a "busy list" of some sort that will keep a drive busy
        //  for a period of time, and process to clear the busy and update the drive status.

        protected void SetBusy(long n) {
            // TODO
            _busy = true;
        }

    }
}
