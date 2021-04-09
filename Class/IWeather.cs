using System;
using System.Collections.Generic;
using System.Text;
using geektrust.Enums;

namespace geektrust.Class
{
    public interface IWeather
    {
        WeatherEnum WeatherType { get; set; }
        double GetModifiedCratersCountBasedOnWeather(double craterCount);
    }
}
