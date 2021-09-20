using System;

namespace BlazorApp.Shared
{
    public class WeatherForecast
    {

        public string Location { get; set; }
        public DateTime Date { get; set; }

        public double Humdity { get; set; }

        public double TemperatureC { get; set; }

        public double Pressure { get; set; }

        public double H3 { get; set; }

        public double Clouds { get; set; }

        public double Sea { get; set; }

        public double Ground { get; set; }

        public double Wind_Speed { get; set; }

        public double Wind_Direction { get; set; }

        public String Wind_Direction_Str { get; set; }

        public WeatherForecast()
        { }
        public WeatherForecast(String pLocation, DateTime pDate, double pHumdity, double pTemperatureC, double pPressure, double pClouds, double pWind_Speed, double pWind_direction)
        {
            Location = pLocation;
            Date = pDate;
            Humdity = pHumdity;
            TemperatureC = pTemperatureC;
            Pressure = pPressure;
            Clouds = pClouds;
            Wind_Speed = pWind_Speed;
            Wind_Direction = pWind_direction;


        }
    }
}
