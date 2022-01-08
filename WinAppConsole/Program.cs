using System;
using WindowsAppLib.OOD;

namespace WinAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to windows Application Development!");
            Console.BackgroundColor = ConsoleColor.Black;

            Car car = new Car()
            {
                Engine = Engines.Cylinders_4,
                Make= "Mercedes",
                Year = 2021
            };

            Car car2 = new Car()
            {
                Engine = Engines.Cylinders_4,
                Make = "Mercedes",
                Year = 2021
            };
           
            Console.ReadLine();
        }
    }
}
