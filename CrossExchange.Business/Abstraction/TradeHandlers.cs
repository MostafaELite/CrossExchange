using CrossExchange.DataAccess.Repository.Abstraction;
using CrossExchange.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrossExchange.Business.Abstraction
{
    public abstract class TradeHandler
    {
        protected IShareRepository _shareRepository;
        protected IPortfolioRepository _portfolioRepository;
        protected ITradeRepository _tradeRepository;

        public TradeHandler(IShareRepository shareRepository, IPortfolioRepository portfolioRepository, ITradeRepository tradeRepository)
        {
            _shareRepository = shareRepository;
            _portfolioRepository = portfolioRepository;
            _tradeRepository = tradeRepository;
        }
        public abstract bool Handle(TradeModel tradeModel);

        protected decimal GetSharePrice(string shareSymbol)
        {
            var shareQuery = _shareRepository.Query();
            return shareQuery.Where(share => share.Symbol == shareSymbol)
                .OrderByDescending(share => share.TimeStamp)
                .FirstOrDefault().Rate;
        }
        protected bool ShareExists(string shareSymbol)
        {
            if (shareSymbol.Length > 3)
                return false;
            return _shareRepository.Query().FirstOrDefault(share => share.Symbol == shareSymbol) != null;
        }

        protected bool UserExits(int protofolioId) => _portfolioRepository.Query().FirstOrDefault(p => p.Id == protofolioId) != null;


    }
}
