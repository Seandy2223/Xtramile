﻿namespace Xtramile.Model
{
    public class MainAPI
    {
        public decimal temp { get; set; }
        public decimal feels_like { get; set; }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }
}
