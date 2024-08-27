using Boilerplate.Domain.BookAggregate.Entity;

namespace Boilerplate.Domain.BookAggregate.Interfaces.Repository
{
    public interface IBookRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task<List<BookEntity>> GetList();
        void Insert(BookEntity entity);
    }
}
