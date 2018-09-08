﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrossExchange.Models;
using CrossExchange.DataAccess.Repository.Abstraction;

namespace CrossExchange.Controller
{
    [Route("api/Portfolio")]
    public class PortfolioController : ControllerBase
    {
        private IPortfolioRepository _portfolioRepository { get; set; }
        

        public PortfolioController(IShareRepository shareRepository, ITradeRepository tradeRepository, IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        [HttpGet("{portFolioid}")]
        public IActionResult GetPortfolioInfo([FromRoute]int portFolioid)
        {
            var portfolio = _portfolioRepository.Query().Where(x => x.Id.Equals(portFolioid));            
            return Ok(portfolio);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Portfolio value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _portfolioRepository.InsertAsync(value);

            return Created($"Portfolio/{value.Id}", value);
        }

    }
}
