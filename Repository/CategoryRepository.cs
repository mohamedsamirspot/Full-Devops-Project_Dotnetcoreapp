using NewsSite.Data;
using NewsSite.Models;
using NewsSite.Repository.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NewsSite.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

  
        public async Task<Category> UpdateAsync(Category entity)
        {
            _db.Category.Update(entity);
            return entity;
        }
    }
}
