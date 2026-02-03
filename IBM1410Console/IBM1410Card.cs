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
using System.Windows.Forms;

namespace IBM1410Console
{
    //  This class implements a card image
    internal class IBM1410Card
    {
        private IBM1402Stacker Stacker;
        public byte[] image;
        public Boolean wrongLengthRecord;
        public Boolean dataCheck;
        public Boolean lastCard;

        //  Constructor
        public IBM1410Card() {
            Stacker = null;
            image = new byte[80];
            wrongLengthRecord = false;
            dataCheck = false;
            lastCard = false;
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
        public void SelectStaker(IBM1402Stacker stacker) {
            Stacker = stacker;
        }
        
        //  Method to stack a card in a stacker

        public bool Stack() {
            if (Stacker == null) {
                return false;
            }
            return (Stacker.Stack(this));
        }


    }

    //  This class implements a stacker slot on a 1402 Card/Read Punch
    //  TODO:  Provide a method to write the contents of a stacker to a file.

    internal class IBM1402Stacker {

        private int count;
        private const int MAXCOUNT = 10000;
        // private String fileName;
        // private FileStream fd;
        private List<string> cardList;
        public int getCount() {  return count; }

        // public String GetFileName() { return fileName; }


        //  Constructor
        public IBM1402Stacker() {
            count = 0;
            // fd = null;
            // fileName = null;
            cardList = new List<string>();
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
        }

        //  Method to check if a stacker is full

        public bool StackerFull() {
            return (count > MAXCOUNT);
        }

        //  Method to stack a card
        public bool Stack(IBM1410Card card) {

            int i;

            ++count;

            if(StackerFull()) {
                return false;
            }

            for(i=0; i < card.image.Length; ++i) {
                if (card.image[i] == '\n' || card.image[i] == '\r') {
                    break;
                }
            }

            //  Add the card image to the card list.

            cardList.Add(System.Text.Encoding.ASCII.GetString(card.image,0, i-1));
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
