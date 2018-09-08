using CrossExchange.DataAccess.Repository.Abstraction;
using CrossExchange.Models;

namespace CrossExchange.DataAccess.Repository.Implementation
{
    public class ShareRepository : GenericRepository<HourlyShareRate>, IShareRepository
    {
        public ShareRepository(ExchangeContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}