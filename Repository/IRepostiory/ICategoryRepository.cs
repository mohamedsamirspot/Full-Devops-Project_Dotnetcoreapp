using NewsSite.Models;
using System.Linq.Expressions;

namespace NewsSite.Repository.IRepostiory
{
    public interface ICategoryRepository : IRepository<Category>
    {
      
        Task<Category> UpdateAsync(Category entity);
  
    }
}
