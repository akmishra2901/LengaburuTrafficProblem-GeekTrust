using System;
using System.Collections.Generic;
using System.Text;
using geektrust.Enums;
using geektrust.Vehicle;
using geektrust.Base;

namespace geektrust.Class
{
    public class Orbit
    {
        private double _distance { get; set; }
        private double _noOfCraters { get; set; }
        private double _speed { get; set; }
        private OrbitTypeEnum _orbitTypeEnum { get; set; }
        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }
        public double NoOfCraters
        {
            get { return _noOfCraters; }
            set { _noOfCraters = value; }
        }
        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public OrbitTypeEnum OrbitType {
            get { return _orbitTypeEnum; }
            set { _orbitTypeEnum = value; }
        }
        public Orbit(OrbitTypeEnum orbitType, double speed) {
            _orbitTypeEnum = orbitType;
            _speed = speed;
            SetOrbitCraters(orbitType);
        }
        private void SetOrbitCraters(OrbitTypeEnum orbitType) {
            switch (orbitType) {
                case OrbitTypeEnum.ORBIT1:
                    _noOfCraters = 20;
                    _distance = 18;
                    break;
                case OrbitTypeEnum.ORBIT2:
                    _noOfCraters = 10;
                    _distance = 20;
                    break;
                default:
                    throw new InvalidOperationException("Invalit Orbit Type");
            }
        }
        private double GetTravelDurationOnOrbit(IWeather weather, VehicleTypeEnum vehicleTypeEnum) {
            double CraterCountForInputWeather = weather.GetModifiedCratersCountBasedOnWeather(NoOfCraters);
            double timeToCrossCrater;
            double timeToCrossOrbit;
            switch (vehicleTypeEnum) {
                case VehicleTypeEnum.BIKE:
                    Bike objbike = ObjectFactory.GetBikeInstance;
                    timeToCrossCrater = (objbike.TimeToCrossCrater * CraterCountForInputWeather);
                    timeToCrossOrbit = ((_distance / (_speed > objbike.Speed ? objbike.Speed : _speed)) * 60);
                    break;
                case VehicleTypeEnum.CAR:
                    Car objcar = ObjectFactory.GetCarInstance;
                    timeToCrossCrater = (objcar.TimeToCrossCrater * CraterCountForInputWeather);
                    timeToCrossOrbit = ((_distance / (_speed > objcar.Speed ? objcar.Speed : _speed)) * 60);
                    break;
                case VehicleTypeEnum.TUKTUK:
                    Tuktuk objtuktuk = ObjectFactory.GetTuktukInstance;
                    timeToCrossCrater = (objtuktuk.TimeToCrossCrater * CraterCountForInputWeather);
                    timeToCrossOrbit = ((_distance / (_speed > objtuktuk.Speed ? objtuktuk.Speed : _speed)) * 60);
                    break;
                default:
                    throw new InvalidOperationException("Invalid Vehicle Type");
            }
            return (timeToCrossCrater + timeToCrossOrbit);
        }
        public Tuple<VehicleTypeEnum, double> GetTravelDurationForAllVehicleType(IWeather objWeather) {
            
            Dictionary<VehicleTypeEnum, double> OrbitVehicleTravelTimeDic = new Dictionary<VehicleTypeEnum, double>();
            if (ObjectFactory.GetCarInstance.CanTravel(objWeather.WeatherType)) 
            {
                double timeForCar = GetTravelDurationOnOrbit(objWeather, VehicleTypeEnum.CAR);
                OrbitVehicleTravelTimeDic.Add(VehicleTypeEnum.CAR, timeForCar);
            }
            if (ObjectFactory.GetBikeInstance.CanTravel(objWeather.WeatherType))
            {
                double timeForBike = GetTravelDurationOnOrbit(objWeather, VehicleTypeEnum.BIKE);
                OrbitVehicleTravelTimeDic.Add(VehicleTypeEnum.BIKE, timeForBike);
            }
            if (ObjectFactory.GetTuktukInstance.CanTravel(objWeather.WeatherType))
            {
                double timeForTuktuk = GetTravelDurationOnOrbit(objWeather, VehicleTypeEnum.TUKTUK);
                OrbitVehicleTravelTimeDic.Add(VehicleTypeEnum.TUKTUK, timeForTuktuk);
            }
            Tuple<VehicleTypeEnum, double> orbitResult = Utility.Utility.GetMinKeyValueFromDictionary(OrbitVehicleTravelTimeDic);

            return orbitResult;
        }
    }
}
