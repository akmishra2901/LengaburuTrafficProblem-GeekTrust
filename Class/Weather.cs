using geektrust.Enums;
using System;
using System.Collections.Generic;

namespace geektrust.Class
{
    public class Weather : IWeather
    {
        private WeatherEnum _weatherType { get; set; }
        public WeatherEnum WeatherType 
        { 
            get { return _weatherType; }  set { _weatherType = value; } 
        }

        public Weather(string weatherType) {
            WeatherEnum weather;
            if (Enum.TryParse(weatherType, out weather))
            {
                switch (weather)
                {
                    case WeatherEnum.RAINY:
                        _weatherType = WeatherEnum.RAINY;
                        break;
                    case WeatherEnum.SUNNY:
                        _weatherType = WeatherEnum.SUNNY;
                        break;
                    case WeatherEnum.WINDY:
                        _weatherType = WeatherEnum.WINDY;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid Weather Type");
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid Weather Type");
            }
        }
        public double GetModifiedCratersCountBasedOnWeather(double craterCount) {
            double modifiedCraterCount;
            switch (_weatherType) {
                case WeatherEnum.RAINY:
                    modifiedCraterCount = craterCount + ((craterCount * 20) / 100);
                    break;
                case WeatherEnum.SUNNY:
                    modifiedCraterCount = craterCount - ((craterCount * 10) / 100);
                    break;
                case WeatherEnum.WINDY:
                    modifiedCraterCount = craterCount;
                    break;
                default:
                    throw new InvalidOperationException("Invalid Weather Type");
            }
            return modifiedCraterCount;
        }
    }
}
