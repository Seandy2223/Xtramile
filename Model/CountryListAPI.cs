using System.Collections.Generic;

namespace Xtramile.Model
{
    public class CountryListAPI
    {
        public CountryListAPI()
        {
            result = new List<Country>();
        }

        public int Code { get; set; }
        public List<Country> result { get; set; }
    }

    public class Country
    {
        public Country()
        {
            states = new List<States>();
        }

        public string name { get; set; }
        public string code { get; set; }
        public List<States> states { get; set; }
    }

    public class States
    {
        public string code { get; set; }
        public string name { get; set; }
    }
}
