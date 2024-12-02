using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class JaratKezelo
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Jarat Menu");
                Console.WriteLine("1. Function 1");
                Console.WriteLine("2. Function 2");
                Console.WriteLine("3. Function 3");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Function1();
                        break;
                    case "2":
                        Function2();
                        break;
                    case "3":
                        Function3();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void Function1()
        {
            Console.WriteLine("Function 1 executed.");
            // Add functionality here
        }

        private void Function2()
        {
            Console.WriteLine("Function 2 executed.");
            // Add functionality here
        }

        private void Function3()
        {
            Console.WriteLine("Function 3 executed.");
            // Add functionality here
        }
    }
}
