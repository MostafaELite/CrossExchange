using CrossExchange.Business.Abstraction;
using CrossExchange.DataAccess.Repository.Abstraction;
using CrossExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CrossExchange.Business.Implementation
{
    public class BuyHandler : TradeHandler
    {
        public BuyHandler(IShareRepository shareRepository, IPortfolioRepository portfolioRepository, ITradeRepository tradeRepository) : base(shareRepository, portfolioRepository, tradeRepository)
        {
        }    

        public override bool Handle(TradeModel tradeModel)
        {
            try
            {
                if (!ShareExists(tradeModel.Symbol) || !UserExits(tradeModel.PortfolioId))
                    return false;

                var newTrade = new Trade
                {
                    Action = "BUY",
                    NoOfShares = tradeModel.NoOfShares,
                    Price = GetSharePrice(tradeModel.Symbol),
                    PortfolioId = tradeModel.PortfolioId,
                    Symbol = tradeModel.Symbol

                };
                _tradeRepository.InsertAsync(newTrade);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }      
    }
}
