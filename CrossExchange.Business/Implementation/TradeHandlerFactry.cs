using CrossExchange.Business.Abstraction;
using CrossExchange.Business.Implementation;
using CrossExchange.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossExchange.Business.Implementation
{
    public class TradeHandlerFactry : ITradeHandlerFactry
    {
        private readonly BuyHandler _buyHandler;
        private readonly SellHandler _sellHandler;

        public TradeHandlerFactry(BuyHandler buyHandler , SellHandler sellHandler)
        {
            _buyHandler = buyHandler;
            _sellHandler = sellHandler;
        }
        public  TradeHandler GetTradeHandler(string action)
        {
            var tradeHandlers = new Dictionary<string, TradeHandler>()
            {
                { "BUY"  ,_buyHandler},
                { "SELL" , _sellHandler}
            };
            return tradeHandlers[action];
        }
    }
}
