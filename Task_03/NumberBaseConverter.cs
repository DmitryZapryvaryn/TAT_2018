using System;
using System.Text;
using System.Numerics;

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
        private const byte AsciiStartChar = 55;

        /// <summary>
        /// The method converts number from decimal base to new base. 
        /// </summary>
        /// <param name="sourceNumber">A number which need to convert to other base.</param>
        /// <param name="newBase">New numeric system.</param>
        /// <returns>Number's presentation in new numeric system as StringBuilder.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If new numeric system have illegal value( new base less then 2 or more than 20).</exception>
        /// <exception cref="ArgumentException">Source number must be positive</exception>
        public StringBuilder GetNewNumberPresentation(BigInteger sourceNumber, int newBase)
        {
            if (newBase < 2 || newBase > 20)
            {
                throw new ArgumentOutOfRangeException("newBase");
            }

            if(sourceNumber < 0)
            {
                throw new ArgumentException("Source number must be positive", "sourceNumber");
            }

            StringBuilder resultNumber = new StringBuilder();
            if (sourceNumber.IsZero)
            {
                return resultNumber.Append(0);
            }

            while(sourceNumber > 0)
            {
                int remainder = (int)(sourceNumber % newBase);
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
                BigInteger inputNumber = BigInteger.Parse(args[0]);
                int newBase = Int16.Parse(args[1]);
                Console.WriteLine(radixChanger.GetNewNumberPresentation(inputNumber, newBase));
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
