using System;
using System.Numerics;

namespace task_DEV3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                NumberBaseConverter radixChanger = new NumberBaseConverter();
                BigInteger inputNumber = BigInteger.Parse(args[0]);
                int newBase = Int16.Parse(args[1]);
                Console.WriteLine(radixChanger.GetNewNumberPresentation(inputNumber, newBase));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
