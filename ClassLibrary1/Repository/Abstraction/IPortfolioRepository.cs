using CrossExchange.Models;
using System.Linq;

namespace CrossExchange.DataAccess.Repository.Abstraction
{
    public interface IPortfolioRepository : IGenericRepository<Portfolio>
    {
        IQueryable<Portfolio> GetAll();
    }
}