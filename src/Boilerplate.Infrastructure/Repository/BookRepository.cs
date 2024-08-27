using Boilerplate.Domain.BookAggregate.Entity;
using Boilerplate.Domain.BookAggregate.Interfaces.Repository;
using Boilerplate.Domain.SharedContext;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Repository
{
    public class BookRepository(LibraryContext context) : IBookRepository
    {
        public IUnitOfWork UnitOfWork => context;

        public Task<List<BookEntity>> GetList()
        {
            return context.Books.ToListAsync();
        }

        public void Insert(BookEntity entity)
        {
            context.Books.Add(entity);
        }
    }
}
