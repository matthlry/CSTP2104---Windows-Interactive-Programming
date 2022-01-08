using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Assignment1.Vehicle_Enum;
using Assignment.Assignment1.Vehicle_Enum.Truck_Enum;

namespace Assignment.Assignment1.Vehicles
{
    class Truck : Vehicle
    {
        public Truck(TruckEngine engine, TruckModel model, TruckTrim trim, TruckMake make, int year, decimal price, int mileage, bool USvehicle, VehicleType type = VehicleType.Car) : base(type, year, price, mileage, USvehicle)
        {
            Engine = engine;
            Model = model;
            Make = make;
            Trim = trim;
        }
        public TruckEngine Engine
        {
            get { return Engine; }
            set { Engine = value; }
        }
        public TruckModel Model
        {
            get { return Model; }
            set { Model = value; }
        }
        public TruckTrim Trim
        {
            get { return Trim; }
            set { Trim = value; }
        }
        public TruckMake Make
        {
            get { return Make; }
            set { Make = value; }
        }
    }
}
}
