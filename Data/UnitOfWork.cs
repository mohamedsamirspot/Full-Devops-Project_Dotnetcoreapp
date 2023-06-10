using NewsSite.Models;
using NewsSite.Repository;
using NewsSite.Repository.IRepostiory;

namespace NewsSite.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICategoryRepository Categories { get; private set; }
        public IRepository<News> News { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Categories = new CategoryRepository(_context);
            News = new Repository<News>(_context);
        }

        public async Task< int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
