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
                Make= Makes.BMW,
                Year = 2021,
                Model = "X3"
            };

            Car car2 = new Car()
            {
                Engine = Engines.Cylinders_4,
                Make = Makes.Toyota,
                Year = 2020,
                Model = "Corolla"
            };

            Program.Display(car);
            Program.Display(car2);

            Vehicle v = car; // upcasting
            Car car3 = (Car)v; // downcasting

            /*Vehicle b = new Vehicle();
            Car car5 = (Car)b;*/ // downcasting error

            // as operator
            // is operator


            //Console.ReadLine();
        }
        public static void Display(Vehicle vehicle)
        {
            Console.WriteLine(vehicle.Make);
            Console.WriteLine(vehicle.Model);
            Console.WriteLine(vehicle.Year);
        }
    }

}
