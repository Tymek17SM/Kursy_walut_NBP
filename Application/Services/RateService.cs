using Application.Dto;
using Application.Exceptions;
using Application.Interfaces;
using Application.Models.Json;
using AutoMapper;
using Domain.Entitis;
using Domain.IRateRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;
        private readonly IMapper _mapper;
        private readonly INbpService _nbpservice;

        public RateService(IRateRepository rateRepository, IMapper mapper, INbpService nbpservice)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
            _nbpservice = nbpservice;
        }

        public async Task<RateDto> GetConvertPlnToUsdInDay(DateTime date, float amountOfPln)
        {
            if (date < new DateTime(2002, 1, 2) || date > DateTime.Today)
                throw new InputDataException("Data kursu musi zawierac sie w przedziale od 2 stycznia 2002 do dnia dzisiejszego");

            if (amountOfPln < 0)
                throw new InputDataException("Kwota do przeliczenia nie może być ujemna");

            var rateFromDb = await _rateRepository.GetExchangeRateInDayAsynch(date);

            if (rateFromDb == null)
            {
                var nbpRateJsonResponse = await _nbpservice.GetUsdRateInDay(date);

                var rateDto = _mapper.Map<RateDto>(nbpRateJsonResponse);

                var newRate = _mapper.Map<Rate>(rateDto);

                var rateAddedToDb = await _rateRepository.AddExchangeRateInDayAsynch(newRate);

                var resultFromNbp = _mapper.Map<RateDto>(rateAddedToDb);
                resultFromNbp.AmountOfPLN = amountOfPln;

                return resultFromNbp;
            }

            var result = _mapper.Map<RateDto>(rateFromDb);
            result.AmountOfPLN = amountOfPln;

            return result;
        }
    }
}
