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
            _Engine = engine;
            _Model = model;
            _Make = make;
            _Trim = trim;
        }
        private CarEngine _Engine;
        private CarModel _Model;
        private CarTrim _Trim;
        private CarMake _Make;
        public CarEngine Engine
        {
            get { return _Engine; }
            set { _Engine = value; }
        }
        public CarModel Model
        {
            get { return _Model; }
            set { _Model = value; }
        }
        public CarTrim Trim
        {
            get { return _Trim; }
            set { _Trim = value; }
        }
        public CarMake Make
        {
            get { return _Make; }
            set { _Make = value; }
        }
    }
}
