/* 
 *  COPYRIGHT 2020, 2021, 2022 Jay R. Jaeger
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
using System.Text;

namespace IBM1410Console
{
    static class IBM1410BCD
    {
        public const byte BITWM = 0x40;
        public const byte BIT1 = 1;
        public const byte BIT2 = 2;
        public const byte BIT4 = 4;
        public const byte BIT8 = 8;
        public const byte BITA = 0x10;
        public const byte BITB = 0x20;
        public const byte BITC = 0x80;

        public const byte BIT_NUM = 0x0f;
        public const byte BIT_ZONE = 0x30;

        public const byte BCD_0 = (10 | BITC);
        public const byte BCD_1 = (1);
        public const byte BCD_9 = (9 | BITC);

        public const byte BCD_AMPERSAND =   (48 | BITC);
        public const byte BCD_SPACE =       (0 | BITC);
        public const byte BCD_COMMA =       (27 | BITC);
        public const byte BCD_DOLLAR =      (43 | BITC);
        public const byte BCD_ASTERISK =    44;
        public const byte BCD_MINUS =       (32 | BITC);
        public const byte BCD_PERIOD =      59;
        public const byte BCD_WS =          29;
        public const byte BCD_TM =          15;

		//	The following table is for BCD to ASCII general use - in particular for
		//	card output - it needs to match the ASCII to BCD table used for card input.
		//	It DOES NOT MATCH the IBM 1415 golf ball font.  (I might use this table for
		//	printing, too...)

		static char[] bcd_ascii = {
			' ',	/* 0           - space */
			'1',	/* 1        1  - 1 */
			'2',	/* 2       2   - 2 */
			'3',	/* 3       21  - 3 */
			'4',	/* 4      4    - 4 */
			'5',	/* 5      4 1  - 5 */
			'6',    /* 6      42   - 6 */
			'7',	/* 7	  421  - 7 */
			'8',	/* 8     8     - 8 */
			'9',	/* 9     8  1  - 9 */
			'0',	/* 10    8 2   - 0 */
			'=',    /* 11    8 21  - number sign (#) or equal*/
			'\'',	/* 12    84    - at sign @ or quote */
			':',    /* 13    84 1  - colon */
			'>',	/* 14    842   - greater than */
			(char) 0xFB,	/* 15    8421  - radical */
			'b',    /* 16   A      - substitute blank -- b -- */
			'/',	/* 17   A   1  - slash */
			'S',	/* 18   A  2   - S */
			'T',	/* 19   A  21  - T */
			'U',	/* 20   A 4    - U */
			'V',	/* 21   A 4 1  - V */
			'W',	/* 22   A 42   - W */
			'X',	/* 23   A 421  - X */
			'Y',	/* 24   A8     - Y */
			'Z',	/* 25   A8  1  - Z */
			'|',	/* 26   A8 2   - record mark */
			',',	/* 27   A8 21  - comma */
			'(',	/* 28   A84    - percent % or paren */
			'^',	/* 29   A84 1  - word separator -- ^ -- */
			'\\',	/* 30   A842   - left oblique */
			(char) 0xD7,    /* 31   A8421  - segment mark */
			'-',	/* 32  B       - hyphen */
			'J',	/* 33  B    1  - J */
			'K',	/* 34  B   2   - K */
			'L',	/* 35  B   21  - L */
			'M',	/* 36  B  4    - M */
			'N',	/* 37  B  4 1  - N */
			'O',	/* 38  B  42   - O */
			'P',	/* 39  B  421  - P */
			'Q',	/* 40  B 8     - Q */
			'R',	/* 41  B 8  1  - R */
			'!',	/* 42  B 8 2   - exclamation (-0) */
			'$',	/* 43  B 8 21  - dollar sign */
			'*',	/* 44  B 84    - asterisk */
			']',	/* 45  B 84 1  - right bracket */
			';',    /* 46  B 842   - semicolon */
			(char) 0x7F, /* 47  B 8421  - delta */
			'+',    /* 48  BA      - ampersand or plus */
			'A',	/* 49  BA   1  - A */
			'B',    /* 50  BA  2   - B */
			'C',	/* 51  BA  21  - C */
			'D',	/* 52  BA 4    - D */
			'E',	/* 53  BA 4 1  - E */
			'F',	/* 54  BA 42   - F */
			'G',	/* 55  BA 421  - G */
			'H',	/* 56  BA8     - H */
			'I',	/* 57  BA8  1  - I */
			'?',	/* 58  BA8 2   - question mark */
			'.',	/* 59  BA8 21  - period */
			')',	/* 60  BA84    - lozenge or paren */
			'[',	/* 61  BA84 1  - left bracket */
			'<',	/* 62  BA842   - less than */
			(char) 0xCE		/* 63  BA8421  - group mark -- { -- */
		};


		//	BCD to ASCII translation table.  Only used to generate characters
		//	for my special fonts for console ouput and printing - DO NOT USE IN FILES.


		/*****************************************************************************
		The following table is used to convert ASCII characters to BCD for things like
		cards, console input, etc.

		Note that it currently is not complete.

		The following substitutions or alternate mappings are made:

				ASCII code	BCD		Notes
				----------  ---     -----
				"			N/A		illegal
				%			(		'H' character set representation
				&			+		'H' character set representation
				@			'		'H' character set representation
				#			=		'H' character set representation
				_			N/A		illegal
				^			^		substitute graphic for word-separator
				`			N/A		illegal
				a,c-z		A,C-Z	case folded
				b			b		substitute blank
				{			N/A		illegal
				}           N/A     illegal
				~			N/A		illegal
				|			Ø		substitute for record mark

				CTRL+d		47		delta
				CTRL+g		63		group mark
				CTRL+r		15		radical
				CTRL+S		31		segment mark
				CTRL+w		N/A		Word mark key

		*****************************************************************************/

		static byte[] ascii_bcd = {
			0xff,0xff,0xff,0xff,		/* 00 - 03 illegal */
			47,0xff,0xff,63,			/* 04 - detla, 05, 06 illegal, 07 group mark */
			0x00,0x00,0xff,0xff,0xff,0xff,0xff,0xff,	/* 010 Backspace -> Index , 011 Word mark, 012 - 017 illegal */
			0xff,0xff,15,31,			/* 020, 021 illegal, ctrl-r radical, ctrl-s segment mark */
			0xff,0xff,0xff,0x00,		/* 024 - 026 illegal (027 is also ctrl-w - word mark) */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 030 - 037 illegal */

			0,				/* 040 space */
			42,				/* 041 ! */
			0xff,			/* 042 " illegal */
			11,				/* 043 # */
			43,				/* 044 $ */
			28,				/* 045 % also ( */
			48,				/* 046 & also + */
			12,				/* 047 ' also @ */

			28,				/* 050 ( also % */
			60,				/* 051 ) also lozenge */
			44,				/* 052 * */
			48,				/* 053 + also & */
			27,				/* 055 , */
			32,				/* 055 - */
			59,				/* 056 . */
			17,				/* 057 / */

			10,				/* 060 0 */
			1,				/* 061 1 */
			2,				/* 062 2 */
			3,				/* 063 3 */
			4,				/* 064 4 */
			5,				/* 065 5 */
			6,				/* 066 6 */
			7,				/* 067 7 */

			8,				/* 070 8 */
			9,				/* 071 9 */
			13,				/* 072 : */
			46,				/* 073 ; */
			62,				/* 074 < */
			11,				/* 075 = also # */
			14,				/* 076 > */
			58,				/* 077 ? */

			12,				/* 0100 @ */
			49,				/* 0101 A */
			50,				/* 0102 B */
			51,				/* 0103 C */
			52,				/* 0104 D */
			53,				/* 0105 E */
			54,				/* 0106 F */
			55,				/* 0107 G */

			56,				/* 0110 H */
			57,				/* 0111 I */
			33,				/* 0112 J */
			34,				/* 0113 K */
			35,				/* 0114 L */
			36,				/* 0115 M */
			37,				/* 0116 N */
			38,				/* 0117 O */

			39,				/* 0120 P */
			40,				/* 0121 Q */
			41,				/* 0122 R */
			18,				/* 0123 S */
			19,				/* 0124 T */
			20,				/* 0125 U */
			21,				/* 0126 V */
			22,				/* 0127 W */

			23,				/* 0130 X */
			24,				/* 0131 Y */
			25,				/* 0132 Z */
			61,				/* 0133 [ */
			30,				/* 0134 \ */
			45,				/* 0135 ] */
			29,				/* 0136 ^ word separator */
			0xff,			/* 0137 _ illegal */

			0xff,			/* 0140 ` illegal */
			49,				/* 0141 a is A */
			16,				/* 0142 b is substitute blank */
			51,				/* 0143 c is C */
			52,				/* 0144 d is D */
			53,				/* 0145 e is E */
			54,				/* 0146 f is F */
			55,				/* 0147 g is G */

			56,				/* 0150 h is H */
			57,				/* 0151 i is I */
			33,				/* 0152 j is J */
			34,				/* 0153 k is K */
			35,				/* 0154 l is L */
			36,				/* 0155 m is M */
			37,				/* 0156 n is N */
			38,				/* 0157 o is O */

			39,				/* 0160 p is P */
			40,				/* 0161 q is Q */
			41,				/* 0162 r is R */
			18,				/* 0163 s is S */
			19,				/* 0164 t is T */
			20,				/* 0165 u is U */
			21,				/* 0166 v is V */
			22,				/* 0167 w is W */

			23,				/* 0170 x is X */
			24,				/* 0171 y is Y */
			25,				/* 0172 z is Z */
			0xff,			/* 0173 { illegal */
			26,				/* 0174 | substitute record mark */
			0xff,			/* 0175	} illegal */
			0xff,			/* 0176 ~ illegal */
			47,				/* 0177  delta */

			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0200-0207 illegal */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0210-0217 illegal */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0220-0227 illegal */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0230-0237 illegal */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0240-0247 illegal */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0250-0257 illegal */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0260-0267 illegal */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0270-0277 illegal */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0300-0307 illegal */

			0xff,0xff,0xff,0xff,0xff,0xff,				/* 0310-0315 illegal */
			63,				/* 0316 group mark   */
			0xff,			/* 0317 illegal */

			0xff,0xff,0xff,0xff,0xff,0xff,0xff,			/* 0320-0326 illegal */
			31,				/* 0327 segment mark */

			26,				/* 0330 record mark  */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,			/* 0331-0337 illegal */

			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0340-0347 illegal */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0350-0357 illegal */
			0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,	/* 0360-0367 illegal */
			0xff,0xff,0xff,								/* 0370-0372 illegal */
			15,				/* 373 radical */
			0xff,0xff,0xff,0xff};						/* 0374-0377 illegal */

		//	The following table is ONLY for translating CONSOLE output using
		//	its specials set of glyphs.  (Currently not being used, as that
		//	translation currently occurs in the FPGA)

		static char[] bcd_ascii_glyphs = {
			' ',	/* 0           - space */
			'1',	/* 1        1  - 1 */
			'2',	/* 2       2   - 2 */
			'3',	/* 3       21  - 3 */
			'4',	/* 4      4    - 4 */
			'5',	/* 5      4 1  - 5 */
			'6',    /* 6      42   - 6 */
			'7',	/* 7	  421  - 7 */
			'8',	/* 8     8     - 8 */
			'9',	/* 9     8  1  - 9 */
			'0',	/* 10    8 2   - 0 */
			'=',    /* 11    8 21  - number sign (#) or equal*/
			'\'',	/* 12    84    - at sign @ or quote */
			':',    /* 13    84 1  - colon */
			'>',	/* 14    842   - greater than */
			(char) 0x7D,	/* 15    8421  - radical -- } -- */
			(char) 0x73,    /* 16   A      - substitute blank -- c -- */
			'/',	/* 17   A   1  - slash */
			'S',	/* 18   A  2   - S */
			'T',	/* 19   A  21  - T */
			'U',	/* 20   A 4    - U */
			'V',	/* 21   A 4 1  - V */
			'W',	/* 22   A 42   - W */
			'X',	/* 23   A 421  - X */
			'Y',	/* 24   A8     - Y */
			'Z',	/* 25   A8  1  - Z */
			(char) 0x7c,	/* 26   A8 2   - record mark -- | --*/
			',',	/* 27   A8 21  - comma */
			'(',	/* 28   A84    - percent % or paren */
			'^',	/* 29   A84 1  - word separator -- ^ -- */
			'\\',	/* 30   A842   - left oblique */
			'~',    /* 31   A8421  - segment mark -- ~ -- */
			'-',	/* 32  B       - hyphen */
			'J',	/* 33  B    1  - J */
			'K',	/* 34  B   2   - K */
			'L',	/* 35  B   21  - L */
			'M',	/* 36  B  4    - M */
			'N',	/* 37  B  4 1  - N */
			'O',	/* 38  B  42   - O */
			'P',	/* 39  B  421  - P */
			'Q',	/* 40  B 8     - Q */
			'R',	/* 41  B 8  1  - R */
			'!',	/* 42  B 8 2   - exclamation (-0) */
			'$',	/* 43  B 8 21  - dollar sign */
			'*',	/* 44  B 84    - asterisk */
			']',	/* 45  B 84 1  - right bracket */
			';',    /* 46  B 842   - semicolon */
			(char) 0x64, /* 47  B 8421  - delta -- d -- */
			'+',    /* 48  BA      - ampersand or plus */
			'A',	/* 49  BA   1  - A */
			'B',    /* 50  BA  2   - B */
			'C',	/* 51  BA  21  - C */
			'D',	/* 52  BA 4    - D */
			'E',	/* 53  BA 4 1  - E */
			'F',	/* 54  BA 42   - F */
			'G',	/* 55  BA 421  - G */
			'H',	/* 56  BA8     - H */
			'I',	/* 57  BA8  1  - I */
			'?',	/* 58  BA8 2   - question mark */
			'.',	/* 59  BA8 21  - period */
			')',	/* 60  BA84    - lozenge or paren */
			'[',	/* 61  BA84 1  - left bracket */
			'<',	/* 62  BA842   - less than */
			(char) 0x7B		/* 63  BA8421  - group mark -- { -- */
		};

		//	The following table indicates which characters require a UPPER CASE SHIFT
		//	for the console when sending BC

		static bool[] bcd_shifted = {
			false,	/* 0           - space (also used for special keys like WM) */
			false,	/* 1        1  - 1 */
			false,	/* 2       2   - 2 */
			false,	/* 3       21  - 3 */
			false,	/* 4      4    - 4 */
			false,	/* 5      4 1  - 5 */
			false,  /* 6      42   - 6 */
			false,	/* 7	  421  - 7 */
			false,	/* 8     8     - 8 */
			false,	/* 9     8  1  - 9 */
			false,	/* 10    8 2   - 0 */
			false,  /* 11    8 21  - number sign (#) or equal*/
			true,	/* 12    84    - at sign @ or quote */
			true,   /* 13    84 1  - colon */
			true,	/* 14    842   - greater than */
			true,	/* 15    8421  - radical -- } -- */
			true,   /* 16   A      - substitute blank -- c -- */
			false,	/* 17   A   1  - slash */
			false,	/* 18   A  2   - S */
			false,	/* 19   A  21  - T */
			false,	/* 20   A 4    - U */
			false,	/* 21   A 4 1  - V */
			false,	/* 22   A 42   - W */
			false,	/* 23   A 421  - X */
			false,	/* 24   A8     - Y */
			false,	/* 25   A8  1  - Z */
			false,	/* 26   A8 2   - record mark -- | --*/
			false,	/* 27   A8 21  - comma */
			true,	/* 28   A84    - percent % or paren */
			true,	/* 29   A84 1  - word separator -- ^ -- */
			true,	/* 30   A842   - left oblique */
			true,   /* 31   A8421  - segment mark -- ~ -- */
			true,	/* 32  B       - hyphen */
			false,	/* 33  B    1  - J */
			false,	/* 34  B   2   - K */
			false,	/* 35  B   21  - L */
			false,	/* 36  B  4    - M */
			false,	/* 37  B  4 1  - N */
			false,	/* 38  B  42   - O */
			false,	/* 39  B  421  - P */
			false,	/* 40  B 8     - Q */
			false,	/* 41  B 8  1  - R */
			false,	/* 42  B 8 2   - exclamation (-0) */
			false,	/* 43  B 8 21  - dollar sign */
			true,	/* 44  B 84    - asterisk */
			true,	/* 45  B 84 1  - right bracket */
			true,	/* 46  B 842   - semicolon */
			true,	/* 47  B 8421  - delta -- d -- */
			true,	/* 48  BA      - ampersand or plus */
			false,	/* 49  BA   1  - A */
			false,	/* 50  BA  2   - B */
			false,	/* 51  BA  21  - C */
			false,	/* 52  BA 4    - D */
			false,	/* 53  BA 4 1  - E */
			false,	/* 54  BA 42   - F */
			false,	/* 55  BA 421  - G */
			false,	/* 56  BA8     - H */
			false,	/* 57  BA8  1  - I */
			false,	/* 58  BA8 2   - question mark */
			false,	/* 59  BA8 21  - period */
			true,	/* 60  BA84    - lozenge or paren */
			true,	/* 61  BA84 1  - left bracket */
			true,	/* 62  BA842   - less than */
			true	/* 63  BA8421  - group mark -- { -- */
		};


		public static char BCDtoASCII(byte bcdChar) {
			return (bcd_ascii[bcdChar]);
        }

		public static byte ASCIItoBCD(char asciiChar) {
			return (ascii_bcd[asciiChar]);
        }

		public static bool BCDShifted(byte bcdByte) {
			return (bcd_shifted[bcdByte]);
        }

	}
}
