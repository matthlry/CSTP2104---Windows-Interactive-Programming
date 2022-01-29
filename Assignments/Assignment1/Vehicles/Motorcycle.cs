using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Assignment1.Vehicle_Enum;
using Assignment.Assignment1.Vehicle_Enum.Motorcycle_Enum;

namespace Assignment.Assignment1.Vehicles
{
    public class Motorcycle : Vehicle, IDistanceCalculator
    {
        public Motorcycle(MotorcycleEngine engine, MotorcycleModel model, MotorcycleTrim trim, MotorcycleMake make, int year, decimal price, int mileage, bool USvehicle, bool damaged = false) : base(year, price, mileage, USvehicle)
        {
            if (damaged)
            {
                _IsDamaged = damaged;
            }
            _Type = VehicleType.Motorcycle;
            _Engine = engine;
            _Model = model;
            _Make = make;
            _Trim = trim;
            _CurrentFuel = 0D;
            if (_Engine == MotorcycleEngine.Unknown)
            {
                _FuelTankMax = 0D;
                _FuelMileage = 0;
            }
            else if (_Engine == MotorcycleEngine.Cylinders_1)
            {
                _FuelTankMax = 7.6D;
                _FuelMileage = 22.34;
            }
            else if (_Engine == MotorcycleEngine.Cylinders_2)
            {
                _FuelTankMax = 17D;
                _FuelMileage = 26.8;
            }
            else if (_Engine == MotorcycleEngine.Cylinders_4)
            {
                _FuelTankMax = 19D;
                _FuelMileage = 24.8;
            }
        }
        private MotorcycleEngine _Engine;
        private MotorcycleModel _Model;
        private MotorcycleTrim _Trim;
        private MotorcycleMake _Make;
        private double _FuelTankMax;
        private double _CurrentFuel;
        private double _FuelMileage;
        public MotorcycleEngine Engine
        {
            get { return _Engine; }
            set { 
                _Engine = value;
                if (_Engine == MotorcycleEngine.Unknown)
                {
                    _FuelTankMax = 0D;
                    _FuelMileage = 0;
                }
                else if (_Engine == MotorcycleEngine.Cylinders_1)
                {
                    _FuelTankMax = 7.6D;
                    _FuelMileage = 22.34;
                }
                else if (_Engine == MotorcycleEngine.Cylinders_2)
                {
                    _FuelTankMax = 17D;
                    _FuelMileage = 26.8;
                }
                else if (_Engine == MotorcycleEngine.Cylinders_4)
                {
                    _FuelTankMax = 19D;
                    _FuelMileage = 24.8;
                }
            }
        }
        public MotorcycleModel Model
        {
            get { return _Model; }
            set { _Model = value; }
        }
        public MotorcycleTrim Trim
        {
            get { return _Trim; }
            set { _Trim = value; }
        }
        public MotorcycleMake Make
        {
            get { return _Make; }
            set { _Make = value; }
        }
        public double CurrentFuel
        {
            get
            {
                if (_Engine == MotorcycleEngine.Unknown)
                {
                    return 0;
                }
                return Math.Round(_CurrentFuel, 2);
            }
        }
        public void FuelUp(double fuel)
        {
            if (fuel <= 0 || _Engine == MotorcycleEngine.Unknown)
            {
                return;
            }
            if (_CurrentFuel + fuel >= _FuelTankMax)
            {
                _CurrentFuel = _FuelTankMax;
                return;
            }
            _CurrentFuel += fuel;
        }
        public double EstimateRemainingDistance()
        {
            if (_Engine == MotorcycleEngine.Unknown)
            {
                return 0;
            }
            else
            {
                return Math.Round(_FuelMileage * _CurrentFuel, 2);
            }
        }

        public double EstimateNeededFuelForDistance(double distance)
        {
            if (_Engine == MotorcycleEngine.Unknown)
            {
                return 0;
            }
            return Math.Round(distance / _FuelMileage, 2);
        }
    }
}

