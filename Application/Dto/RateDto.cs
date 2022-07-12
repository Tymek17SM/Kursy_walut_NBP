using Application.Mappings;
using Application.Models.Json;
using AutoMapper;
using Domain.Entitis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class RateDto : IMap
    {
        public int Id { get; set; }

        public string CurrencyCode { get; set; }

        public DateTime EffectiveDate { get; set; }

        public decimal RateValue { get; set; } 

        public float AmountOfPLN { get; set; } = 0;
        public double PlnToUsd 
        { 
            get
            {
                return Math.Round(((double)AmountOfPLN / (double)RateValue), 4);
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rate, RateDto>();

            profile.CreateMap<RateDto, Rate>();

            profile.CreateMap<RateJson, RateDto>()
                .ForMember(a => a.CurrencyCode, c => c.MapFrom(s => s.code))
                .ForMember(a => a.RateValue, c => c.MapFrom(s => s.rates.FirstOrDefault().mid))
                .ForMember(a => a.EffectiveDate, c => c.MapFrom(s => s.rates.FirstOrDefault().effectiveDate));
        }
    }
}
