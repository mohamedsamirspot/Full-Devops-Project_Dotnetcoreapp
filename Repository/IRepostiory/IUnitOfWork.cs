using NewsSite.Models;

namespace NewsSite.Repository.IRepostiory
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IRepository<News> News { get; }

        Task <int> Complete();
    }
}
