using System.Collections.Generic;

namespace Xtramile.Model
{
    public class CityPopulateAPI
    {
        public string order { get; set; }
        public string orderBy { get; set; }
        public string country { get; set; }
        public int limit { get; set; }
    }

    public class CityResponseAPI
    {
        public CityResponseAPI()
        { data = new List<CityDtlResponseAPI>(); }
        public string error { get; set; }
        public string msg { get; set; }
        public List<CityDtlResponseAPI> data { get; set; }
    }

    public class CityDtlResponseAPI
    {
        public string city { get; set; }
    }
}
