using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopScraper.Api.Interfaces;

namespace WebShopScraper.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ShopStatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public ShopStatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        [Route("/pricechange")]
        public IActionResult GetShopPriceChangeCount()
        {
            var priceChangeData = _statisticsService.GetShopPriceChangeData();
            return Ok(priceChangeData);
        }
    }
}
