using System;
using System.Text;


namespace Task_02
{
    /// <summary>
    /// This class contains method which find substring with even characters
    /// </summary>
    class EvenChar
    {
        /// <summary>
        /// Method finds even char from input sring.
        /// </summary>
        /// <param name="inputString">Character sequance.</param>
        /// <returns>
        /// Substring contains even char from input string.
        /// </returns>
        public StringBuilder getEvenCharSequance(string inputString)
        {
            StringBuilder result = new StringBuilder();
            if (inputString.Length == 0)
            {
                throw new ArgumentNullException();
            }
            else
            {
                for(int i = 0; i < inputString.Length; i++)
                {
                    if( i % 2 == 0 )
                    {
                        result.Append(inputString[i]);
                    }
                }
            }
            return result;
        }

        //Only for test program
        //Entry point
        static void Main(string[] args)
        {
            EvenChar evenChar = new EvenChar();
            string buffer = Console.ReadLine();
            Console.WriteLine(evenChar.getEvenCharSequance(buffer));
        }
    }    
}
