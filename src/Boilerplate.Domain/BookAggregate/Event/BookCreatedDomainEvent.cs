using Boilerplate.Domain.BookAggregate.Entity;
using System.Text.Json.Serialization;

namespace Boilerplate.Domain.BookAggregate.Event
{
    public record BookCreatedDomainEvent([property: JsonIgnore]BookEntity book) : IDomainEvent
    {
        public int Id => book.Id;
    }
}
