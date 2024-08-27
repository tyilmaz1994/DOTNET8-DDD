using Boilerplate.Domain.BookAggregate.Entity;

namespace Boilerplate.Api.Contracts.Response
{
    public record GetBookResponseModel
    {
        public List<BookEntity> Books { get; set; }
    }
}
