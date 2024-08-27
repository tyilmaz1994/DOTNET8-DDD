using Boilerplate.Application.ViewModels;
using Boilerplate.Domain.BookAggregate.Entity;
using Boilerplate.Domain.BookAggregate.Interfaces.Repository;

namespace Boilerplate.Application.BookAggregate.Service
{
    public interface IBookService
    {
        Task<List<BookEntity>> GetList();
        Task Insert(BookViewModel bookViewModel);
    }

    public class BookService(IBookRepository bookRepository) : IBookService
    {
        public async Task<List<BookEntity>> GetList()
        {
            return await bookRepository.GetList();
        }

        public async Task Insert(BookViewModel bookViewModel)
        {
            var bookEntity = BookEntity.Create(bookViewModel.AuthorId, bookViewModel.Title, bookViewModel.PublishedDate, bookViewModel.ISBN, bookViewModel.Pages, bookViewModel.Language, bookViewModel.Publisher);
            bookRepository.Insert(bookEntity);
            await bookRepository.UnitOfWork.SaveChangesAsync(bookEntity.DomainEvents);
        }
    }
}
