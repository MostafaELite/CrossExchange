using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrossExchange.DataAccess.Repository.Abstraction
{
    public interface IGenericRepository<T>
    {
        Task<T> GetAsync(string id);

        IQueryable<T> GetAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> Query();

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);
    }
}