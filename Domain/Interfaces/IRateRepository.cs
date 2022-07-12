using Domain.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRateRepository
{
    public interface IRateRepository
    {
        public Task<Rate> GetExchangeRateInDayAsynch(DateTime date);
        public Task<Rate> AddExchangeRateInDayAsynch(Rate rate);
    }
}
