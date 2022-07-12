using Domain.Entitis;
using Domain.IRateRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly KursyWalutDbContext _context;

        public RateRepository(KursyWalutDbContext context)
        {
            _context = context;
        }

        public async Task<Rate> GetExchangeRateInDayAsynch(DateTime date)
        {
            return await _context.Rates.FirstOrDefaultAsync(r => r.EffectiveDate == date);
        }

        public async Task<Rate> AddExchangeRateInDayAsynch(Rate rate)
        {
            var addedRate = await  _context.Rates.AddAsync(rate);
            await _context.SaveChangesAsync();
            return addedRate.Entity;
        }
    }
}
