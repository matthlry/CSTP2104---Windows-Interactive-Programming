using System;
using WindowsAppLib.OOD;

namespace WinAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {           
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

            var values = new int[] { 2, 4, 5, 8 };
            var result = Program.Calculate(values, new Squarer());
            Program.Display(result);

            // Extension Method
            string s = "123";
            var isCapitalized = s.IsCapitalized();
            Console.WriteLine($"{s} isCapitalized:{isCapitalized}");
            
            s = "Ace";
            isCapitalized = s.IsCapitalized();
            Console.WriteLine($"{s} isCapitalized:{isCapitalized}");
            
            s = "base";
            isCapitalized = s.IsCapitalized();
            Console.WriteLine($"{s} isCapitalized:{isCapitalized}");

            s = "";
            isCapitalized = s.IsCapitalized();
            Console.WriteLine($"{s} isCapitalized:{isCapitalized}");
            //Console.ReadLine();
        }

        
        public static int[] Calculate(int[] values, ICalculator calculator)
        {
            int[] result = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                var r = calculator.Calculate(values[i]);
                result[i] = r;
            }
            return result;
        }
        public static void Display(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                Console.WriteLine($"i={i} {values[i]}");
            }
        }
        public static void Display(Vehicle vehicle)
        {
            Console.WriteLine(vehicle.Make);
            Console.WriteLine(vehicle.Model);
            Console.WriteLine(vehicle.Year);
        }
        public static void Display2(Truck turck)
        {

        }
    }

    public static class StringHelper 
    {
        // Extension method
        public static bool IsCapitalized(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            return char.IsUpper(s[0]);
        }
    }

}
