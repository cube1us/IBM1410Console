#define TAPEDEBUG

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.IO.Ports;
using System.Threading;
using System.Net.Sockets;

namespace IBM1410Console
{
    internal class IBM1410TapeUnit {

        public const int TAPE_IRG = 0x80;
        public const int TAPE_TM = 0x0f;

        public const byte CHANNEL1FLAG = 0x84;
        public const byte CHANNEL2FLAG = 0x83;

        public const byte READYREADSTATUS = 0x01;
        public const byte READYWRITESTATUS = 0x02;
        public const byte LOADPOINTSTATUS = 0x04;
        public const byte TAPEINDICATESTATUS = 0x08;
        public const byte REWINDINGSTATUS = 0x10;
        public const byte TAPEUNITREADYSTATUS = 0x20;

        public const int TAPEUNITIRG = -1;
        public const int TAPEUNITNOTREADY = -3;

        private int unit;
        private int channel;
        private SerialPort serialPort;
        private SemaphoreSlim serialOutputSemaphore;

        private UdpClient udpClient = null;
        private SemaphoreSlim udpOutputSemaphore;

        private String _fileName;
        private long _recordNumber;
        private Boolean _loaded;
        private Boolean _fileProtect;
        private Boolean _ready;
        private Boolean _selected;
        private Boolean _tapeIndicate;
        private Boolean _highDensity;
        private Boolean _bot;
        private Boolean _rewinding;

        private FileStream fd;
        private int tape_buffer;

        private Boolean irgRead;          // True if tape_buffer is full
        private Boolean writeIRG;         // Write IRG on next write
        private Boolean modified;

        //  Set up many of the fields as properties...

        internal String FileName { get { return _fileName; } }
        internal long RecordNumber { get { return _recordNumber; } }
        internal Boolean Loaded { get { return _loaded; } }
        internal Boolean FileProtect { get { return _fileProtect; } }
        internal Boolean Ready { get { return _ready; } }
        internal Boolean Selected { get { return _selected; } }
        internal Boolean TapeIndicate { get { return _tapeIndicate; } set { _tapeIndicate = value; } }
        internal Boolean HighDensity { get { return _highDensity; } }
        internal Boolean Bot { get { return _bot; } }
        internal int ChannelNumber { get { return channel;  } }
        internal int UnitNumber { get { return unit; } }


        // Constructor.  Defers most of the work to Init - which can also be invoked later
        // if a new tape is mounted.

        public IBM1410TapeUnit(SerialPort serialPort, SemaphoreSlim serialOutputSemaphore,
            UdpClient udpClient, SemaphoreSlim udpOutputSemaphore, int channel, int unit) {
            fd = null;
            this.serialPort = serialPort;
            this.serialOutputSemaphore = serialOutputSemaphore;
            this.udpClient = udpClient;
            this.udpOutputSemaphore = udpOutputSemaphore;
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
            UpdateFPGATape("Init");
        }

        //  Methods to respond to calls from the user interface and elsewhere


        internal void Reset() { 
            _ready = _tapeIndicate = false;
            UpdateFPGATape("Reset");
        }


        //  Load the tape (file) (if not already loaded), and rewind.

        internal Boolean LoadRewind() {
            
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
                    UpdateFPGATape("Load Rewind Seek");
                    return (true);
                }
                catch(Exception e) {
                    Debug.WriteLine("TapeUnit: LoadRewind: Seek failed on tape unit " + channel.ToString() + 
                       unit.ToString());
                    ResetFile();
                    _bot = _loaded = _ready = false;
                    UpdateFPGATape("Load Rewind Seek Error");
                    return (false);
                }
            }

            if(_fileName == null || _fileName.Length == 0) {
                _ready = false;
                UpdateFPGATape("Load Rewind No File");
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
                    Debug.WriteLine("TapeUnit: LoadRewind: new FileStream failed on tape unit " + 
                        channel.ToString() + unit.ToString());
                    Debug.WriteLine(e2.ToString());
                    ResetFile();
                    _loaded = _ready = _bot = false;
                    UpdateFPGATape("Load Rewind Open Error");
                    return false;
                }
            }

            irgRead = modified = false;
            writeIRG = true;
            _recordNumber = 0;
            _bot = _loaded = true;
            UpdateFPGATape("Load Rewind Complete");
            return true;
        }

        //  Unload the tape (file)
        internal Boolean Unload() {
            
            //  If the drive is ready or not loaded, ignore...

            if(_ready || !_loaded) {
                return false;
            }

            ResetFile();
            _tapeIndicate = false;
            _loaded = false;
            _ready = false;
            UpdateFPGATape("Unload");
            return true;
        }

        //  Mount a tape (file) on the drive

        internal Boolean Mount(String fileName) {

            //  Can't mount a tape if the drive is ready or already loaded

            if (_ready || _loaded || fileName == null || fileName.Length == 0) {
                return false;
            }

            Debug.Assert(fd == null);
            _fileName = fileName;
            irgRead = writeIRG = _fileProtect = _tapeIndicate = modified = _bot = false;
            UpdateFPGATape("Mount");
            return true;
        }

        //  Handle the Start button

        internal Boolean Start() {

            //  If the drive is already ready, is is not loaded, can't comply.

            if (_ready || !_loaded) {
                return false;
            }

            Debug.Assert(fd != null);
            _ready = true;
            UpdateFPGATape("Start");
            return true;
        }

        //  Handle the Density change button

        internal Boolean ChangeDensity() {

            //  Can't change density on a ready drive.

            if (_ready) {
                return false;
            }
            _highDensity = !_highDensity;
            UpdateFPGATape("Change Density");
            return true;
        }

        //  Select a tape drive - really just used for reporting and error checking
        //  in this implementation.  The actual selection process happens bundled with
        //  the unit control, read or write instruction in the Tape Adapter Unit in the FPGA
        internal Boolean Select(Boolean b) {
            _selected = b;
            #if TAPEDEBUG
            if(fd != null && !_rewinding) {
                Debug.WriteLine("TapeUnit unit " + channel.ToString() + unit.ToString() + " selected");
                Debug.WriteLine("TapeUnit current file offset is " + fd.Position);
            }
            #endif
            return true;
        }

        //  Rewind to the beginning of the tape (file)

        internal Boolean Rewind() {
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
                UpdateFPGATape("Rewind Seek Error");
                return false;
            }

            irgRead = modified = false;
            writeIRG = true;
            _rewinding = true;
            // _ready = false;
            RewindBusy(5 * _recordNumber);  // Currently hardcoded in Rewindbusy as 500ms.
            _recordNumber = 0;
            _rewinding = false;
            _ready = true;
            _bot = true;
            return true;
        }

        //  Rewind and Unload

        internal Boolean RewindUnload() {

            //  Do the rewind.  If it fails, reset.

            if(!Rewind()) {
                ResetFile();
                UpdateFPGATape("Unload Rewind Failed") ;
                return false;
            }

            ResetFile();
            _tapeIndicate = false;
            _ready = false;
            UpdateFPGATape("Unload");
            return true;
        }

        //  (Erase / Skip and blank tape -- does nothing unless we someday have measured tape)

        internal Boolean Skip() {
            #if TAPEDEBUG
                Debug.WriteLine("TapeUnit Erase on unit " + channel.ToString() + unit.ToString());
            #endif 

            if(!_selected || !_loaded || !_ready) {
                return false;
            }
            writeIRG = true;
            return true;
        }

        //  Space forward: read until an IRG is hit.  (D Character "A", NOT in the 1410 Principles
        //  of operation?

        internal int Space() {

            int rc;

            #if TAPEDEBUG
                Debug.WriteLine("TapeUnit Space unit " + channel.ToString() + unit.ToString());
            #endif

            while ((rc = Read()) >= 0) {
                // Do nothing
            }

            // SetBusy(2);
            return rc;
        }

        //  Backspace.  This is a pain.  To do it, we have to take TWO steps (CHARACTERS!) back, and then
        //  one step forward to search for an IRG

        internal Boolean Backspace() {

            //  Drive must be selected, ready and loaded.

            if (!_selected || !_ready || !_loaded) {
                Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                    " not loaded, selected and ready");
                return false;
            }

            Debug.Assert(fd != null);

            #if TAPEDEBUG
                Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                    " position: " + fd.Position.ToString());
            #endif

            //  If we are already a bot (really should not happen) just Seek to 
            //  the beginning of the file.

            if(_bot) {
                _recordNumber = 0;
                try {
                    fd.Seek(0, SeekOrigin.Begin);
                }
                catch (IOException e) {
                    Debug.WriteLine("TapeUnit Backspace unit " +
                        channel.ToString() + unit.ToString() + " at BOT 1 " +                         
                        " seek failed: " + e.ToString());
                    ResetFile();
                    UpdateFPGATape("Backspace Seek Failed");
                    return false;
                }

                return true;
            }

            //  If we just ended a record, write out its IRG, then back up before it...

            if (modified && writeIRG) {
                if (!Write(0)) {
                    ResetFile();
                    // UpdateFPGATape("Backspace Write IRG Failed");
                    return false;
                }
                modified = writeIRG = irgRead = false;
                #if TAPEDEBUG
                    Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                        " Write EOR after previous operation, at position " + fd.Position.ToString());
                #endif

                /*
                try {
                    fd.Seek(-1, SeekOrigin.Current);
                    #if TAPEDEBUG
                        Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                            " Seek back over EOR after previous operation, at position " + fd.Position.ToString());
                    #endif
                }
                catch (IOException e) {
                    Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                        " Seek back over EOR failed: " + e.ToString());
                    ResetFile();
                    UpdateFPGATape("Backspace Seek Error after Writing IRG");
                    return false;
                }
                */
            }

            //  Now, go into the two steps back, one step forward routine

            while(true) {

                //  If the position is 2 or less, we will be done

                if(fd.Position <= 2) {
                    irgRead = false;
                    _bot = writeIRG = true;
                    _recordNumber = 0;
                    Debug.WriteLine("TapeUnit Backspace unit " + 
                        channel.ToString() + unit.ToString() + " at position < 2 " + 
                         " ended at BOT.");
                    try {
                        fd.Seek(0, SeekOrigin.Begin);
                    }
                    catch (IOException e) {
                        Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                            " seek failed: " + e.ToString());
                        ResetFile();
                        UpdateFPGATape("Bakcspace to Load Point Seek Failed");
                        return false;
                    }

                    UpdateFPGATape("Backspace at BOT") ;  // Tell the FPGA we are now at BOT.
                    return true;
                }

                //  Seek back 2 characters

                try {
                    fd.Seek(-2, SeekOrigin.Current);
                    /*
                    #if TAPEDEBUG
                        Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                            " Back up 2 characters, at position " + fd.Position.ToString());
                    #endif
                    */
                }
                catch (IOException e) {
                    Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                        " seek failed: " + e.ToString());
                    ResetFile();
                    UpdateFPGATape("Backspace Seek Error");
                    return false;
                }

                //  Read forward 1 character to see if it is an IRG.

                if((tape_buffer = fd.ReadByte()) < 0) {
                    Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                        " Read failed: unexpected error or EOF");
                    return false;
                }

                #if TAPEDEBUG
                    /*
                    Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                    " read next character is " + tape_buffer.ToString("X2") + ", at position " + 
                    fd.Position.ToString());
                    */
                #endif


                //  If we find the IRG bit on, we are done!

                if ((tape_buffer & TAPE_IRG) != 0) {
                    irgRead = writeIRG = true;
                    --_recordNumber;
                    #if TAPEDEBUG
                        Debug.WriteLine("TapeUnit Backspace unit " + channel.ToString() + unit.ToString() +
                            " ended, position: " + fd.Position.ToString());
                    #endif
                    UpdateFPGATape("Backspace Complete");
                    return true;
                }

                //  Otherwise lather, rinse, repeat until we return.
            }
        }

        
        //  Reset file info -- after an unload or an error.
        protected void ResetFile() {
            if(fd != null) {
                fd.Close();
            }
            fd = null;
            _fileName = null;
            _ready = _loaded = _fileProtect = _bot = false;
            irgRead = writeIRG = modified = false;
            _recordNumber = 0;
        }

        //  Method to write a byte.  Doesn't need to worry about load mode, word separators, 
        //  parity or anything like that.

        internal Boolean Write(int c) {

            // Debug.WriteLine("TapeUnit Write unit " + channel.ToString() + unit.ToString());

            if (!_loaded || !_ready || !_selected || fd == null) {
                Debug.WriteLine("TapeUnit write unit " + channel.ToString() + unit.ToString() +
                    " not ready, selected, loaded or fd is null");
                Debug.WriteLine("Loaded: " + _loaded.ToString() + ", Ready: " + _ready.ToString() +
                    ", Selected: " + _selected.ToString() + ", fd is " + (fd == null ? "null" : "not null"));
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
                    UpdateFPGATape("Write Seek back over last EOR Failed");
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
                // Debug.WriteLine("TapeUnit Writing to file tape unit " + channel.ToString() + unit.ToString() +
                //    ", character " + c.ToString("X2"));
                fd.WriteByte(Convert.ToByte(c));
            }
            catch(IOException e) {
                Debug.WriteLine("TapeUnit Write unit " + channel.ToString() + unit.ToString() +
                    " Failed, I/O Error: " + e.ToString());
                ResetFile();
                _tapeIndicate = true;
                UpdateFPGATape("Write IO Error");
                return false;
            }

            // Debug.WriteLine("TapeUnit Write final position " + fd.Position.ToString());
            irgRead = writeIRG = false;
            return true;
        }


        //  Mark the end of a record.  Called at the end of a trnsfer - sets the IRG flag
        //  for the start of the next record

        internal void WriteIRG() {
            writeIRG = modified = true;
            _bot = irgRead = false;
            ++_recordNumber;
            // UpdateFPGATape();
        }


        //  Write a tape mark.  Just calls write to do the dirty work.  Note that
        //  tape marks are ALWAYS even parity.

        internal Boolean WriteTM() {
            Boolean status = true;

            #if TAPEDEBUG
                Debug.WriteLine("TapeUnit WTM unit " + channel.ToString() + unit.ToString());
            #endif

            ++_recordNumber;
            if(!Write(TAPE_TM | TAPE_IRG)) {
                return(false);
            }
            
            irgRead = modified = _bot = false;
            // status = Write(TAPE_TM);
            writeIRG = modified = true;

            #if TAPEDEBUG
                Debug.WriteLine("TapeUnit WTM unit " + channel.ToString() + unit.ToString() +
                    " Position at end: " + fd.Position.ToString());
            #endif

            // SetBusy(2);
            // UpdateFPGATape("Write TM Complete);
            return status;
        }


        //  Read a byte of a record and send it off to the FPGA
        internal int Read() {

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
            else {
                Debug.WriteLine("TapeUnit unit " + channel.ToString() + unit.ToString() +
                    " character already in buffer, position " + fd.Position.ToString());
            }

            //  If we are at BOT or an IRG, strip the IRG bit from the character and 
            //  return the character.

            //  A Tape Mark is only a Tape Mark as the first character.  The FPGA is also
            //  paying attention to that, be we do here as well to properly set Tape Indicate

            if (_bot || irgRead) {
                tape_buffer &= ~TAPE_IRG;  // Strip off the IRG from pprevious read
                if ((tape_buffer & 0x3f) == TAPE_TM) {
                    _tapeIndicate = true;
                    Debug.WriteLine("TapeUnit unit " + channel.ToString() + unit.ToString() +
                        " Tape Mark sensed, position " + fd.Position.ToString());
                }
                _bot = irgRead = false;
            }

            //  If we hit the end of the record, then set IRG now, and return that

            if ((tape_buffer & TAPE_IRG) != 0) {
                #if TAPEDEBUG
                    Debug.WriteLine("TapeUnit Read " + channel.ToString() + unit.ToString() +
                        " found IRG character at position: " + fd.Position.ToString());
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

        internal int ReadNextChar() {

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

        internal void UpdateFPGATape(string origin) {

            byte[] serialBuffer = new byte[3];
            byte unitStatus = 0;
            byte flagByte = 0;

            if (_ready) {
                unitStatus |= (TAPEUNITREADYSTATUS | READYREADSTATUS);
                if (!_fileProtect) {
                    unitStatus |= READYWRITESTATUS;
                }
            }
            if (_tapeIndicate) {
                unitStatus |= TAPEINDICATESTATUS;
            }
            if(_rewinding) {
                unitStatus |= REWINDINGSTATUS;
            }
            if(_bot) {
                unitStatus |= LOADPOINTSTATUS;
            }

            flagByte = channel == 1 ? CHANNEL1FLAG : CHANNEL2FLAG;

            serialBuffer[0] = flagByte;
            serialBuffer[1] = (byte) unit;
            serialBuffer[2] = unitStatus;

            //  Wait for access to the serial port...

            serialOutputSemaphore.Wait();
            udpOutputSemaphore.Wait();
            serialPort.Write(serialBuffer, 0, serialBuffer.Length);
            udpClient.Send(serialBuffer,serialBuffer.Length);
            Debug.WriteLine("Sent UDP TAU Status update packet /" +
                serialBuffer[0].ToString("X2") + serialBuffer[1].ToString("X2") +
                serialBuffer[2].ToString("X2") + "/");
            udpOutputSemaphore.Release();
            serialOutputSemaphore.Release();

            Debug.WriteLine("TapeUnit: Sent updated status to FPGA for unit " +
                channel.ToString() + unit.ToString() + 
                ", Operation: " + origin + ", status: " + unitStatus.ToString("X2"));

         }


        //  Reset the Tape Indicate
        internal void ResetTapeIndicate() {
            _tapeIndicate = false;
            UpdateFPGATape("Reset Tape Indicate");
            return;
        }

        //  TODO:  Need to have a "busy list" of some sort that will keep a drive busy
        //  for a period of time, and process to clear the busy and update the drive status.

        internal void RewindBusy(long n) {
            // TODO

            // _ready = false;
            _rewinding = true;
            UpdateFPGATape("Rewind go Busy");
            System.Threading.Thread.Sleep(500); // Crude: sleep for 500 ms.
            _rewinding = false;
            _ready = true;
            _bot = true;
            UpdateFPGATape("Rewind end Busy");

        }

    }
}
