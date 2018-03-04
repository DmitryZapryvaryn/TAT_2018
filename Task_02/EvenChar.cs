using System;
using System.Text;

namespace Task_02
{
    /// <summary>
    /// This class contains method which find substring with even characters
    /// </summary>
    class EvenCharStringBuilder
    {
        /// <summary>
        /// Method finds even char from input string.
        /// </summary>
        /// <param name="inputString">String where need to find even char.</param>
        /// <returns>
        /// StringBuilder which contains even char from input string.
        /// </returns>
        public StringBuilder GetEvenCharSequence(string inputString)
        {
            StringBuilder result = new StringBuilder();
            for(int i = 0; i < inputString.Length; i += 2)
            {
                result.Append(inputString[i]);
            }
            return result;
        }

        static void Main(string[] args)
        {
            EvenCharStringBuilder evenChar = new EvenCharStringBuilder();
            string buffer = Console.ReadLine();
            Console.WriteLine(evenChar.GetEvenCharSequence(buffer));
        }
    }    
}
