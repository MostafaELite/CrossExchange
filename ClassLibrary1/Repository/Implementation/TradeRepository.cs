using CrossExchange.Models;

namespace CrossExchange.DataAccess.Repository.Implementation
{
    public class TradeRepository : GenericRepository<Trade>, ITradeRepository
    {
        public TradeRepository(ExchangeContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}