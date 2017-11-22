using System;

namespace Scenario02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input N: ");
            int n  = int.Parse(Console.ReadLine());
            int fact = 1;
            while (n > 1)
            {
                fact = fact * n;
                n--;
            }

            Console.WriteLine($"Factorial is: {fact}");

            Console.ReadKey();
        }
    }
}
