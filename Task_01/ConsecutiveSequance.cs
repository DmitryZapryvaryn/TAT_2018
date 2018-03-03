using System;

namespace Task_01
{
    /// <summary>
    /// This class contains method for find consecutive characters
    /// </summary>
    class ConsecutiveSequance
    {
        /// <summary>
        /// Search the largest consecutive sequance from input string
        /// </summary>
        /// <param name="inputString">Sequance of character</param>
        /// <returns>
        /// Number of characters in the largest consecutive sequance
        /// </returns>
        public int getMaxConsecutiveSequnce(string inputString)
        {
            if (inputString.Length == 0)
            {
                return 0;
            }

            int count = 1;
            int max = int.MinValue;
            char previousChar = inputString[0];

            for (int i = 1; i < inputString.Length; i++)
            {
                char currentChar = inputString[i];
                if (currentChar == previousChar)
				{
                    count++;
				}
                else
                {
                    if (max < count)
                        max = count;
                    count = 1;
                }
				
                previousChar = currentChar;
            }

            if (max < count)
            {
                max = count;
            }

            return max;
        }

        //Only for test program
        //Entry point
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Run program with one argument!");
            }
            else
            {
				ConsecutiveSequance test = new ConsecutiveSequance();
				Console.WriteLine(test.getMaxConsecutiveSequnce(args[0]));
            }
        }
    }
}
