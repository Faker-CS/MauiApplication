using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Domaine
{
    public class weather
    {
        public string City { get; set; }
        public double Temperature { get; set; } // In Celsius
        public double Humidity { get; set; }    // In percentage
        public string Condition { get; set; }  // e.g., "Sunny", "Rainy", "Cloudy"
    }
}
