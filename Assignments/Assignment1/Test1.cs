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
using System.Threading;

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
        public static void DistanceLeft()
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            List<Motorcycle> motorcycles = new List<Motorcycle>();

            Car c1 = new Car(CarEngine.Cylinders_6, CarModel.Mustang, CarTrim.Hatchback, CarMake.Ford, 2010, 40000, 2067, false);
            c1.FuelUp(30);
            cars.Add(c1);
            Car c2 = new Car(CarEngine.Cylinders_4, CarModel.Civic, CarTrim.Sedan, CarMake.Honda, 2017, 23000, 52890, true);
            c2.FuelUp(23);
            cars.Add(c2);

            Motorcycle m1 = new Motorcycle(MotorcycleEngine.Cylinders_2, MotorcycleModel.Yamaha_R1, MotorcycleTrim.Sport_Bike, MotorcycleMake.Yamaha, 2014, 13499.00m, 3542, true);
            m1.FuelUp(12);
            motorcycles.Add(m1);
            Motorcycle m2 = new Motorcycle(MotorcycleEngine.Cylinders_4, MotorcycleModel.Gold_Eagle, MotorcycleTrim.Cruiser, MotorcycleMake.Honda, 206, 21199.00m, 6723, false);
            m2.FuelUp(8);
            motorcycles.Add(m2);

            Truck t1 = new Truck(TruckEngine.Cylinders_8, TruckModel.F150, TruckTrim.Wheels_6, TruckMake.Ford, 2013, 33699.00m, 180234, false);
            t1.FuelUp(80);
            trucks.Add(t1);
            Truck t2 = new Truck(TruckEngine.Cylinders_10, TruckModel.Titan, TruckTrim.Wheels_6, TruckMake.Nissan, 2020, 52000.00m, 48865, true);
            t2.FuelUp(97);
            trucks.Add(t2);

            foreach(Car c in cars)
            {
                Console.WriteLine($"{c.Make} {c.Model}, {c.EstimateDistance()}kms left");
            }
            foreach (Motorcycle m in motorcycles)
            {
                Console.WriteLine($"{m.Make} {m.Model}, {m.EstimateDistance()}kms left");
            }
            foreach (Truck t in trucks)
            {
                Console.WriteLine($"{t.Make} {t.Model}, {t.EstimateDistance()}kms left");
            }
                        
        }
        public static void ParallelQuery()
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            List<Motorcycle> motorcycles = new List<Motorcycle>();

            Car c1 = new Car(CarEngine.Cylinders_6, CarModel.Mustang, CarTrim.Hatchback, CarMake.Ford, 2010, 40000, 2067, false);
            c1.FuelUp(30);
            cars.Add(c1);
            Car c2 = new Car(CarEngine.Cylinders_4, CarModel.Civic, CarTrim.Sedan, CarMake.Honda, 2017, 23000, 52890, true);
            c2.FuelUp(23);
            cars.Add(c2);

            Motorcycle m1 = new Motorcycle(MotorcycleEngine.Cylinders_2, MotorcycleModel.Yamaha_R1, MotorcycleTrim.Sport_Bike, MotorcycleMake.Yamaha, 2014, 13499.00m, 3542, true);
            m1.FuelUp(12);
            motorcycles.Add(m1);
            Motorcycle m2 = new Motorcycle(MotorcycleEngine.Cylinders_4, MotorcycleModel.Gold_Eagle, MotorcycleTrim.Cruiser, MotorcycleMake.Honda, 206, 21199.00m, 6723, false);
            m2.FuelUp(8);
            motorcycles.Add(m2);

            Truck t1 = new Truck(TruckEngine.Cylinders_8, TruckModel.F150, TruckTrim.Wheels_6, TruckMake.Ford, 2013, 33699.00m, 180234, false);
            t1.FuelUp(80);
            trucks.Add(t1);
            Truck t2 = new Truck(TruckEngine.Cylinders_10, TruckModel.Titan, TruckTrim.Wheels_6, TruckMake.Nissan, 2020, 52000.00m, 48865, true);
            t2.FuelUp(97);
            trucks.Add(t2);

            cars.AsParallel().ForAll(c => Console.WriteLine($"{c.Make} {c.Model}, {c.EstimateDistance()}kms left on current fuel({c.CurrentFuel}L). Needs {c.EstimateNeededFuelForDistance(320D)}L to travel 320kms"));
            motorcycles.AsParallel().ForAll(c => Console.WriteLine($"{c.Make} {c.Model}, {c.EstimateDistance()}kms left on current fuel({c.CurrentFuel}L). Needs {c.EstimateNeededFuelForDistance(320D)}L to travel 320kms"));
            trucks.AsParallel().ForAll(c => Console.WriteLine($"{c.Make} {c.Model}, {c.EstimateDistance()}kms left on current fuel({c.CurrentFuel}L). Needs {c.EstimateNeededFuelForDistance(320D)}L to travel 320kms"));
        }
    }
}
