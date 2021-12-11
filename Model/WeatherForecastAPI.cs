namespace Xtramile.Model
{
    public class WeatherForecastAPI
    {
        public WeatherForecastAPI()
        {
            coord = new CoordinateAPI();
            main = new MainAPI();
            wind = new WindAPI();
            clouds = new CloudsAPI();
            weather = new WeatherAPI[1];
        }

        public CoordinateAPI coord { get; set; }
        public WeatherAPI[] weather { get; set; }
        public MainAPI main { get; set; }
        public int visibility { get; set; }
        public WindAPI wind { get; set; }
        public CloudsAPI clouds { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string Name { get; set; }
        public int cod { get; set; }
    }
}
