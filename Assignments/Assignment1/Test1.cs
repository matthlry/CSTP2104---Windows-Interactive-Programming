using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Assignment1.Vehicles;
using Assignment.Assignment1.Vehicle_Enum;
using Assignment.Assignment1.Vehicle_Enum.Car_Enum;
using Assignment.Assignment1.Vehicle_Enum.Motorcycle_Enum;
using Assignment.Assignment1.Vehicle_Enum.Truck_Enum;


namespace Assignment.Assignment1
{
    public class Test1
    {
        public static void AddCarTest()
        {
            Car a = new Car(CarEngine.Cylinders_6, CarModel.Mustang, CarTrim.Hatchback, CarMake.Ford, 2010, 40000, 2067, false);
            Inventory.AddCar(a);
            Car b = new Car(CarEngine.Cylinders_4, CarModel.Civic, CarTrim.Sedan, CarMake.Honda, 2017, 23000, 52890, true);
            Inventory.AddCar(b);
        }
        public static void CheckCarInventory()
        {
            List<Car> CarInventory = Inventory.GetCars();
            foreach(Car c in CarInventory)
            {
                Console.WriteLine(c.Year.ToString() + " " + c.Make.ToString() + " " + c.Model.ToString() + " " + c.Mileage + " $" + c.Price.ToString()) ;
            }
        }
    }
}
