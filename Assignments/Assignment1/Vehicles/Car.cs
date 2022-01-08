using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Assignment1.Vehicle_Enum;
using Assignment.Assignment1.Vehicle_Enum.Car_Enum;

namespace Assignment.Assignment1.Vehicles
{
    public class Car : Vehicle
    {
        public Car(CarEngine engine, CarModel model, CarTrim trim, CarMake make, int year, decimal price, int mileage, bool USvehicle, VehicleType type = VehicleType.Car) : base(type, year, price, mileage, USvehicle)
        {
            Engine = engine;
            Model = model;
            Make = make;
            Trim = trim;
        }
        public CarEngine Engine
        {
            get { return Engine; }
            set { Engine = value; }
        }
        public CarModel Model
        {
            get { return Model; }
            set { Model = value; }
        }
        public CarTrim Trim
        {
            get { return Trim; }
            set { Trim = value; }
        }
        public CarMake Make
        {
            get { return Make; }
            set { Make = value; }
        }
    }
}
