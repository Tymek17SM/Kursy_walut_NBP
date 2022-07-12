using Application.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INbpService
    {
        public Task<RateJson> GetUsdRateInDay(DateTime date);
    }
}
