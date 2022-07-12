using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Wrappers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class RateController : ControllerBase
    {
        private readonly IRateService _rateService;

        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetConvertPlnToUsdInDay([FromQuery] DateTime dateTime, [FromQuery] float amountOfPln)
        {
            var rate = await _rateService.GetConvertPlnToUsdInDay(dateTime, amountOfPln);

            return Ok(new Response<RateDto>(rate));
        }
    }
}
