using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.Utils
{
    public class RomanNumber
    {

        private static string[] BASIC_ROMAN_NUMBERS = { "M", "CM", "D", "CD",
         "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        private static int[] BASIC_VALUES = { 1000, 900, 500, 400, 100, 90,
         50, 40, 10, 9, 5, 4, 1 };
        private int value;
        private string romanString;

        public RomanNumber(int value)
        {
            if (1 <= value && value <= 3999)
            {
                this.value = value;
            }
            else
            {
                throw new Exception("");
            }
        }

        public RomanNumber(string s)
        {
            String r = s.ToUpper();
            int index = 0;
            for (int i = 0; i < BASIC_ROMAN_NUMBERS.Length; i++)
            {
                while (r.LastIndexOf(BASIC_ROMAN_NUMBERS[i], index) == 0)
                {
                    this.value += BASIC_VALUES[i];
                    index += BASIC_ROMAN_NUMBERS[i].Length;
                }
            }
            // Verifies whether the input string is a valid roman number or not.
            /*RomanNumber tempVerify;
            try {
               tempVerify = new RomanNumber(this.value);
            } catch (IllegalArgumentException e) {
               throw new IllegalRomanNumeralException(s);
            }
            if ((verifyString = tempVerify.toRomanValue()).equals(r)) {
               this.romanString = r;
            } else {
               throw new IllegalRomanNumeralException(s,verifyString);
            }*/
        }

        public override string ToString()
        {
            if (this.romanString == null)
            {
                this.romanString = "";
                int remainder = this.value;
                for (int i = 0; i < BASIC_VALUES.Length; i++)
                {
                    while (remainder >= BASIC_VALUES[i])
                    {
                        this.romanString += BASIC_ROMAN_NUMBERS[i];
                        remainder -= BASIC_VALUES[i];
                    }
                }
            }
            return this.romanString;
        }

        public int getValue()
        {
            return this.value;
        }
        public static string GetRomanString(int number)
        {
            if (number == 0)
                return "";
            RomanNumber roman = new RomanNumber(number);
            return roman.ToString();
        }
    }
}
