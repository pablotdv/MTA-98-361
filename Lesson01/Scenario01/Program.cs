using System;

namespace Scenario01
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter the quantity of products you will buy (numbers only): ");
                string input = Console.ReadLine();
                try
                {
                    ushort quantity = ushort.Parse(input);
                    if (quantity == 0)
                    {
                        Console.WriteLine($"Please, enter a quantity greater than zero.");
                        PressKeyToContinue();
                        continue;
                    }

                    int discount = Discount(quantity);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                    PressKeyToContinue();
                }
                catch(OverflowException)
                {
                    Console.WriteLine($"The number {input} is too big to an integer type.");
                    Console.WriteLine($"Please type a number less than {ushort.MaxValue}.");
                    PressKeyToContinue();
                }                
            }
        }

        static void PressKeyToContinue()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static int Discount(ushort quantity)
        {
            if (quantity < 10)
                return 5;

            if (quantity < 50)
                return 10;

            if (quantity < 100)
                return 15;

            return 0;
        }
    }
}
