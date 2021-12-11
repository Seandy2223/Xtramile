using System;

namespace Xtramile
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public double TemperatureC => (TemperatureF - 32) * 5 / 9;
        public double TemperatureF { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public DateTime Time { get; set; }
        public decimal Wind { get; set; }
        public decimal Visibility { get; set; }
        public string SkyConditions { get; set; }
        public double DewPoint => 243.04 * (Math.Log(RelativeHumidity / 100) + ((17.625 * TemperatureC) / (243.04 + TemperatureC))) / (17.625 - Math.Log(RelativeHumidity / 100) - ((17.625 * TemperatureC) / (243.04 + TemperatureC)));
        public double RelativeHumidity { get; set; }
        public double Pressure { get; set; }
    }
}
