/* 
 *  COPYRIGHT 2026 Jay R. Jaeger
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  (file COPYING.txt) along with this program.  
 *  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace IBM1410Console
{
    //  This class implements a card image
    public  class IBM1410Card

    {
        private IBM1402Stacker stacker;
        public byte[] image;
        public int currentByte;
        public Boolean wrongLengthRecord;
        public Boolean dataCheck;
        public Boolean lastCard;

        //  Constructor
        public IBM1410Card() {
            stacker = null;
            image = new byte[80];
            currentByte = 0;
            wrongLengthRecord = false;
            dataCheck = false;
            lastCard = false;

            //  We need a special code page provider to output characters as I expect to.
            // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        //  Make the card image, wrong length and data check flags accessible
        public byte[] getCard() {
            return image;
        }
        public Boolean getWrongLengthRecord() { return wrongLengthRecord; }
        public Boolean getDataCheck() { return dataCheck; }
        public Boolean getLastCard() { return lastCard; }
    
        public void setWrongLengthRecord(Boolean b) { wrongLengthRecord = b; }
        public void setDataCheck(Boolean b) { dataCheck = b; }
        public void setLastCard(Boolean b) { lastCard = b; }

        //  Method to select a particular stacker for a card
        public void selectStacker(IBM1402Stacker stacker) {
            this.stacker = stacker;
        }

        //  Method to add a byte to the card image

        public Boolean addByte(byte c) {
            if (currentByte < image.Length) {
                image[currentByte++] = c;
                return true;
            }
            else {
                return false;
            }
        }
        
        //  Method to stack a card in a stacker

        public bool Stack(IBM1402Form form) {
            if (stacker == null) {
                return false;
            }
            return (stacker.Stack(form,this));
        }


    }

    //  This class implements a stacker slot on a 1402 Card/Read Punch
    //  TODO:  Provide a method to write the contents of a stacker to a file.

    public class IBM1402Stacker {

        private int count;
        private const int MAXCOUNT = 10000;
        private string stackerName;
        private string stackerShortName;
        private System.Windows.Forms.Button button;

        // private String fileName;
        // private FileStream fd;
        private List<string> cardList;
        public int getCount() {  return count; }
        public List<string> getCardList() { return cardList; }
        public string getStackerName() { return stackerName; }

        // public String GetFileName() { return fileName; }


        //  Constructor
        public IBM1402Stacker(string stackerName, string stackerShortName, System.Windows.Forms.Button button) {
            count = 0;
            // fd = null;
            // fileName = null;
            cardList = new List<string>();
            this.stackerName = stackerName;
            this.stackerShortName = stackerShortName;
            this.button = button;
        }

        /*

        //  Constructor with file name

        public IBM1402Stacker(String s) {
            count = 0;
            fd = null;
            fileName = s;
        }
        */

        /* public bool SetFileName(String s) {

        //  Method to point a stacker at a new file.
        //  This resets the stacker count too.

            count = 0;

            if (s == null) {
                return false;
            }

            fileName = s;

            //  If this stacker is writing to a file already, close it out.

            if (fd != null) {
                fd.Close();
                fd = null;
            }

            count = 0;

            //  Unlike the Borland/Embarcadero Simulator, this time we
            //  open on the first stack command.

            return true;
        }
        */

        //  Method to empty a stacker without writing it out

        public void reset() { 
            count = 0; 
            cardList.Clear();
            button.Text = stackerShortName + ": #####";
        }

        //  Method to check if a stacker is full

        public bool StackerFull() {
            return (count > MAXCOUNT);
        }

        //  Method to stack a card
        public bool Stack(IBM1402Form form, IBM1410Card card) {

            int i;
            string s;
            Action safeButtonUpdate;

            ++count;

            if(StackerFull()) {
                return false;
            }

            for(i=0; i < card.image.Length; ++i) {
                if (card.image[i] == '\n' || card.image[i] == '\r') {
                    break;
                }
            }

            s = System.Text.Encoding.UTF8.GetString(card.image, 0, i) + "\n";

            // s = System.Text.Encoding.GetEncoding(1252).GetString(card.image,0,i) + "\n";

            //  Add the card image to the card list.

            Debug.Write("Card Being Stacked: ");
            for (i = 0; i < card.image.Length; ++i) {
                Debug.Write(card.image[i].ToString("X2") + " ");
            }
            Debug.WriteLine("");

            Debug.WriteLine("Adding string to cardlist: ");
            Debug.WriteLine(s);
            // Debug.WriteLine("   " + string.Join(" ", System.Text.Encoding.GetEncoding(1252).GetBytes(s)));
            
            cardList.Add(s);


            //  Because this code is running on the UDP publisher thread, to update the UI we need to use Invoke.
            safeButtonUpdate = delegate { button.Text = stackerShortName + ": " + count.ToString("D5"); };
            form.Invoke(safeButtonUpdate);

            return true;

            /*
            byte[] cardToStack;
            byte[] stackedCard;

            //  If there is no file and no file name, return false

            if (fd == null && fileName == null) {
                return false;
            }

            ++count;

            //  If we haven't opened the file yet, do that now

            if(fd == null) {

                try {
                    fd = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                }
                catch (IOException e) {
                    Debug.WriteLine("Error: 1410Card:Stacker.Stack: New Filestream failed");
                    Debug.WriteLine(e.ToString());
                    MessageBox.Show("Error: 1410Card:Stacker.Stack: New Filestream failed:" +
                        e.ToString());
                    return false;
                }
            }

            //  The card is already in ASCII by this time, so just write it out, but firsr
            //  remove any trailing blanks.

            cardToStack = card.getCard();
            for (i = cardToStack.Length - 1; i >= 0; i--) {
                if (cardToStack[i] != ' ') {
                    break;
                }
            }
            
            //  If the card is all spaces (i < 0), create one with just \r\n
            //  Otherwise create one by adding \r\n 

            if(i < 0) {
                stackedCard = new byte[2];
                stackedCard[0] = (byte) '\r';
                stackedCard[1] = (byte) '\n';
            }
            else {
                stackedCard = new byte[i + 3];
                stackedCard = cardToStack[0..i];
                stackedCard[i+1] = (byte) '\r';
                stackedCard[i+2] = (byte) '\n';
            }

            //  Write out the card...

            try {
                fd.Write(stackedCard, 0, stackedCard.Length);
            }
            catch (IOException e) {
                Debug.WriteLine("Error: 1402Card:Stacker.Stack: Write error " +
                    e.ToString());
                MessageBox.Show("Error: 1402Card:Stacker.Stack: Write error " +
                    e.ToString());
                fd.Close();
                count = 0;
                return (false);
            }

            return (true);
        */
        }


    }

}
