using System.Linq;
using CrossExchange.DataAccess.Repository.Abstraction;
using CrossExchange.Models;
using Microsoft.EntityFrameworkCore;

namespace CrossExchange.DataAccess.Repository.Implementation
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(ExchangeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Portfolio> GetAll()
        {
            return _dbContext.Portfolios.Include(x => x.Trade).AsQueryable();
        }
    }
}