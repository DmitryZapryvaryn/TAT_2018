using System;

namespace Task_DEV2
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            EvenCharStringCreator evenChar = new EvenCharStringCreator();
            string buffer = Console.ReadLine();
            Console.WriteLine(evenChar.GetEvenCharSequence(buffer));
        }
    }
}
