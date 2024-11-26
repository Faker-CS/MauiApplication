using MauiApp1.Domaine;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Infrastructure
{
    internal class WeatherWebService : IWeatherWebService
    {
        private HttpClient _httpClient;
        private readonly string _ApiKey = "359899bf1daf4b1da89131925242111";

        public WeatherWebService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<weather> GetCurrentWeatherAsync(string city)
        {
            var response = await _httpClient.GetStringAsync($"https://api.weatherapi.com/v1/current.json?key={_ApiKey}&q={city}");
            return JsonConvert.DeserializeObject<weather>(response);
        }

        public weather GetWeathers(string weatherId)
        {
            throw new NotImplementedException();
        }
    }
}
