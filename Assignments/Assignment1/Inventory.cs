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
    public class Inventory
    {
        private static List<Car> cars = new List<Car>();
        private static List<Truck> trucks = new List<Truck>();
        private static List<Motorcycle> motorcycles = new List<Motorcycle>();

        public static void AddMotorcycle(MotorcycleEngine engine, MotorcycleModel model, MotorcycleTrim trim, MotorcycleMake make, int year, decimal price, int mileage, bool USvehicle)
        {
            motorcycles.Add(new Motorcycle(engine, model, trim, make, year, price, mileage, USvehicle));
        }
        public static void AddMotorcycle(Motorcycle m)
        {
            motorcycles.Add(m);
        }
        public static void AddCar(CarEngine engine, CarModel model, CarTrim trim, CarMake make, int year, decimal price, int mileage, bool USvehicle)
        {
            cars.Add(new Car(engine, model, trim, make, year, price, mileage, USvehicle));
        }
        public static void AddCar(Car c)
        {
            cars.Add(c);
        }
        public static void AddTruck(TruckEngine engine, TruckModel model, TruckTrim trim, TruckMake make, int year, decimal price, int mileage, bool USvehicle)
        {
            trucks.Add(new Truck(engine, model, trim, make, year, price, mileage, USvehicle));
        }
        public static void AddTruck(Truck t)
        {
            trucks.Add(t);
        }

        public static List<Car> GetCars()
        {
            return cars;
        }
    }
}
