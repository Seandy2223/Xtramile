using System;

namespace Xtramile
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        //public int TemperatureF { get; set; }
        public string Summary { get; set; }
        //public string Location { get; set; }
        //public DateTime Time { get; set; }
        //public int Wind { get; set; }
        //public int Visibility { get; set; }
        //public string SkyConditions { get; set; }
        //public int DewPoint { get; set; }
        //public int RelativeHumidity { get; set; }
        //public int Pressure { get; set; }
    }
}
