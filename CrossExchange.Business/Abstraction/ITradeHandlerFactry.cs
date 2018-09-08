using CrossExchange.Business.Abstraction;
using CrossExchange.Models;

namespace CrossExchange.Business.Abstraction
{
    public interface ITradeHandlerFactry
    {
        TradeHandler GetTradeHandler(string action);
    }
}