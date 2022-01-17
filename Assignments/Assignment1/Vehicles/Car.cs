using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Assignment1.Vehicle_Enum;
using Assignment.Assignment1.Vehicle_Enum.Car_Enum;

namespace Assignment.Assignment1.Vehicles
{
    public class Car : Vehicle, IDistanceCalculator
    {
        public Car(CarEngine engine, CarModel model, CarTrim trim, CarMake make, int year, decimal price, int mileage, bool USvehicle, bool damaged = false) : base(year, price, mileage, USvehicle)
        {
            if (damaged)
            {
                _IsDamaged = damaged;
            }
            _Type = VehicleType.Car;
            _Engine = engine;
            _Model = model;
            _Make = make;
            _Trim = trim;
            _CurrentFuel = 0D;
            _CurrentBattery = 0;
            if (_Engine == CarEngine.Unknown)
            {
                _FuelTankMax = 0D;
                _BatteryMax = 0;
                _PowerSourceMileage = 0;
            }
            else if (_Engine == CarEngine.Cylinders_4)
            {
                _FuelTankMax = 50D;
                _PowerSourceMileage = 9.1;
                _BatteryMax = 0;
            }
            else if (_Engine == CarEngine.Cylinders_6)
            {
                _FuelTankMax = 70D;
                _PowerSourceMileage = 6.4;
                _BatteryMax = 0;
            }
            else if (_Engine == CarEngine.Cylinders_8)
            {
                _FuelTankMax = 90D;
                _PowerSourceMileage = 4.8;
                _BatteryMax = 0;

            }
            else if (_Engine == CarEngine.Electric)
            {
                _FuelTankMax = 0D;
                _BatteryMax = 100;
                _PowerSourceMileage = 4.9;           
            }   
        }
        private CarEngine _Engine;
        private CarModel _Model;
        private CarTrim _Trim;
        private CarMake _Make;
        private double _FuelTankMax;
        private double _CurrentFuel;
        private double _PowerSourceMileage;
        private int _BatteryMax;
        private int _CurrentBattery;        

        public CarEngine Engine
        {
            get { return _Engine; }
            set { 
                _Engine = value;
                if (_Engine == CarEngine.Unknown)
                {
                    _FuelTankMax = 0D;
                    _BatteryMax = 0;
                    _PowerSourceMileage = 0;
                }
                else if (_Engine == CarEngine.Cylinders_4)
                {
                    _FuelTankMax = 50D;
                    _PowerSourceMileage = 9.1;
                    _BatteryMax = 0;
                }
                else if (_Engine == CarEngine.Cylinders_6)
                {
                    _FuelTankMax = 70D;
                    _PowerSourceMileage = 6.4;
                    _BatteryMax = 0;
                }
                else if (_Engine == CarEngine.Cylinders_8)
                {
                    _FuelTankMax = 90D;
                    _PowerSourceMileage = 4.8;
                    _BatteryMax = 0;

                }
                else if (_Engine == CarEngine.Electric)
                {
                    _FuelTankMax = 0D;
                    _BatteryMax = 100;
                    _PowerSourceMileage = 4.9;
                }
            }
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
        public void FuelUp(double fuel)
        {
            if (fuel <= 0)
            {
                return;
            }
            if (_Engine == CarEngine.Unknown || _Engine == CarEngine.Electric)
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
        public void ChargeUp(bool isUsingSuperCharger, double mins)
        {
            if (mins <= 0)
            {
                return;
            }
            if (_Engine != CarEngine.Electric)
            {
                return;
            }
            double PercentagePerMinute = 0.48;
            double AddedPercentage;
            if (isUsingSuperCharger)
            {
                PercentagePerMinute = 5.03;
            }
            AddedPercentage = PercentagePerMinute * mins;
            if ((int)AddedPercentage > _BatteryMax)
            {
                _CurrentBattery = _BatteryMax;
                return;
            }
            _CurrentBattery += (int)AddedPercentage;
            return;
            }
        public double EstimateDistance()
        {
            if (_Engine == CarEngine.Unknown)
            {
                return 0;
            }
            else if (_Engine == CarEngine.Electric)
            {
                return Math.Round(_PowerSourceMileage * _CurrentBattery, 2);
            }
            return Math.Round(_PowerSourceMileage * _CurrentFuel, 2);
        }
    }
}

