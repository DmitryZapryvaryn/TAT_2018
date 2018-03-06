using System;
using System.Text;

namespace Task_03
{
    /// <summary>
    /// Provide a method for converts number's base
    /// </summary>
    class NumberBaseConverter
    {
        /// <summary>
        /// The method converts number from decimal base to new base. 
        /// </summary>
        /// <param name="sourceNumber">A number which need to convert to other base.</param>
        /// <param name="newBase">New numeric system.</param>
        /// <returns>Number in new numeric system as StringBuilder.</returns>
        public StringBuilder ChangeNumberBase(uint sourceNumber, uint newBase)
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
                    resultNumber.Insert(0, (char)(remainder + 55));
                }
                else
                {
                    resultNumber.Insert(0, remainder);
                }
                sourceNumber /= newBase;
            }

            return resultNumber;
        }

        private bool IsValidBase(string stringBase, out uint result)
        {
            return UInt32.TryParse(stringBase, out result) && (result <= 20 && result >= 2);
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Run program with two arguments: number, base.");
            }
            else
            {
                NumberBaseConverter radixChanger = new NumberBaseConverter();
                uint inputNumber;
                uint newBase;
                bool isDecimalNumber = UInt32.TryParse(args[0], out inputNumber);
                bool isValidBase = radixChanger.IsValidBase(args[1], out newBase);
                if (isDecimalNumber && isValidBase)
                {
                    Console.WriteLine(radixChanger.ChangeNumberBase(inputNumber, newBase));
                }
                else
                {
                    Console.WriteLine("Invalid inputs!");
                    Console.WriteLine("Please, input decimal unsigned number and base!");
                }
            }
        }
    }
}
