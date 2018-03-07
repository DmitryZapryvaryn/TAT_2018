using System;
using System.Text;

namespace Task_03
{
    /// <summary>
    /// Provide a method for converts number's base
    /// </summary>
    class NumberBaseConverter
    {
        //If base of new number > 10 we need to use char A,B,C... in number.
        //65 in ASCII is 'A'.
        //Char code = 65 + (remainder - 10) => char code = 55 + remainder.  
        private const ushort AsciiStartChar = 55;

        /// <summary>
        /// The method converts number from decimal base to new base. 
        /// </summary>
        /// <param name="sourceNumber">A number which need to convert to other base.</param>
        /// <param name="newBase">New numeric system.</param>
        /// <returns>Number in new numeric system as StringBuilder.</returns>
        public StringBuilder GetChangedNumber(uint sourceNumber, uint newBase)
        {
            StringBuilder resultNumber = new StringBuilder();
            if (sourceNumber == 0)
            {
                return resultNumber.Append(0);
            }

            uint remainder;
            while(sourceNumber > 0)
            {
                remainder = sourceNumber % newBase;
                if(remainder > 9)
                {
                    resultNumber.Insert(0, (char)(remainder + AsciiStartChar));
                }
                else
                {
                    resultNumber.Insert(0, remainder);
                }
                sourceNumber /= newBase;
            }

            return resultNumber;
        }

        static void Main(string[] args)
        {
            try
            {
                NumberBaseConverter radixChanger = new NumberBaseConverter();
                uint inputNumber = UInt32.Parse(args[0]);
                uint newBase = UInt32.Parse(args[1]);
                if(newBase < 2 || newBase > 20)
                {
                    throw new BaseOutOfRangeException();
                }
                Console.WriteLine(radixChanger.GetChangedNumber(inputNumber, newBase));
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
