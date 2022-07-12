using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRateService
    {
        public Task<RateDto> GetConvertPlnToUsdInDay(DateTime date, float amountOfPln);
    }
}
