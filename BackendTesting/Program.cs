using System;

namespace BackendTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new ShoppingLib.TestKlasse().DatenAbrufen();
            Console.ReadLine();
        }
    }
}
