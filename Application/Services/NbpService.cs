using Application.Exceptions;
using Application.Interfaces;
using Application.Models.Json;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NbpService : INbpService
    {
        private readonly HttpClient _httpClient;

        public NbpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RateJson> GetUsdRateInDay(DateTime date)
        {
            var convertedDate = date.ToString(@"yyyy\-MM\-dd");

            var response =  await _httpClient.GetAsync($"exchangerates/rates/A/USD/{convertedDate}/");

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RateJson>(contentString);
            }
            else
                throw new NbpApiException(response);
        }
    }
}
