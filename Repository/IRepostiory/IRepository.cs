using NewsSite.Models;
using System.Linq.Expressions;

namespace NewsSite.Repository.IRepostiory
{
    public interface IRepository<T> where T : class 
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        //List<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        IQueryable<T> GetAllAsyncIQueryable(Expression<Func<T, bool>>? filter = null, string? includeProperties = null); // for the create method (on dealing with images)
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
