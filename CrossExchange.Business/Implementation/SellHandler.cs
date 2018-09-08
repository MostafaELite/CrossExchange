using CrossExchange.Business.Abstraction;
using CrossExchange.DataAccess.Repository.Abstraction;
using CrossExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CrossExchange.Business.Implementation
{
    public class SellHandler : TradeHandler
    {
        public SellHandler(IShareRepository shareRepository, IPortfolioRepository portfolioRepository, ITradeRepository tradeRepository) :
            base(shareRepository, portfolioRepository, tradeRepository)
        {
        }

        public override bool Handle(TradeModel tradeModel)
        {
            try
            {
                if (GetAvalialbeShares(tradeModel.PortfolioId, tradeModel.Symbol) < tradeModel.NoOfShares)
                    return false;

                var newTrade = new Trade
                {
                    Action = "SELL",
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

        int GetAvalialbeShares(int protfolioId, string shareSymbol)
        {
            var protfolioTrades = _tradeRepository.Query().Where(trad => trad.PortfolioId == protfolioId);

            if (protfolioTrades?.Count() == 0)
                return 0;

            var avaliableShares =
                protfolioTrades.Where(trade => trade.Action == "SELL")?.Sum(trade => trade.Price)
                - protfolioTrades.Where(trade => trade.Action == "BUY")?.Sum(trade => trade.Price);
            return avaliableShares.HasValue ?  Convert.ToInt32(avaliableShares.Value) : 0;




        }

    }
}
