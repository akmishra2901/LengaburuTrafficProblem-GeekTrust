using System;
using geektrust.Enums;
using geektrust.Base;
using geektrust.Class;
using System.Collections.Generic;
using geektrust.Utility;
using System.IO;

namespace geektrust
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] fileContent = File.ReadAllLines(args[0].ToString());
            // string[] fileContent = File.ReadAllLines("E:\\input.txt");
            foreach (string line in fileContent)
            {
                string[] inputArr = line.Split(" ");
                string weather = inputArr[0];
                WeatherEnum inputWeatherType;
                int orbitOneSpeed = Convert.ToInt32(inputArr[1]);
                int orbitTwoSpeed = Convert.ToInt32(inputArr[2]);

                Enum.TryParse(weather, out inputWeatherType);
                IWeather objWeather = new Weather(weather);
                objWeather.WeatherType = inputWeatherType;

                Orbit _orbitOne = new Orbit(OrbitTypeEnum.ORBIT1, orbitOneSpeed);
                Tuple<VehicleTypeEnum, double> orbitOneResult = _orbitOne.GetTravelDurationForAllVehicleType(objWeather);

                // Get Suitable Vehicle for Orbit Two
                Orbit orbitTwo = new Orbit(OrbitTypeEnum.ORBIT2, orbitTwoSpeed);
                Tuple<VehicleTypeEnum, double> orbitTwoResult = orbitTwo.GetTravelDurationForAllVehicleType(objWeather);

                if (orbitOneResult.Item2 < orbitTwoResult.Item2)
                    Console.WriteLine(orbitOneResult.Item1.ToString() + " " + OrbitTypeEnum.ORBIT1.ToString());
                else
                    Console.WriteLine(orbitTwoResult.Item1.ToString() + " " + OrbitTypeEnum.ORBIT2.ToString());
            }           
            Console.Read();
        }
    }
}
