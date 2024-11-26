using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Domaine
{
    internal interface IWeatherWebService
    {
        public Task<weather> GetCurrentWeatherAsync(string city);
        public weather GetWeathers(string weatherId);
    }
}
