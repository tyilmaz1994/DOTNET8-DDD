using Boilerplate.Domain.BookAggregate.Event;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boilerplate.Domain.BookAggregate.Entity
{
    [Table("book")]
    public class BookEntity : AbstractEntity
    {
        [Column("id")] public int Id { get; private set; }
        [NotMapped] public int AuthorId { get; private set; }
        [Column("title")] public string Title { get; private set; }
        [Column("published_date")] public DateTime PublishedDate { get; private set; }
        [Column("isbn")] public string ISBN { get; private set; }
        [Column("pages")] public int Pages { get; private set; }
        [Column("language")] public string Language { get; private set; }
        [Column("publisher")] public string Publisher { get; private set; }

        private BookEntity()
        {
        }

        private BookEntity(int authorId, string title, DateTime publishedDate,
              string isbn, int pages, string language, string publisher)
        {
            Title = title;
            AuthorId = authorId;
            PublishedDate = publishedDate;
            ISBN = isbn;
            Pages = pages;
            Language = language;
            Publisher = publisher;
            Add(new BookCreatedDomainEvent(this));
        }

        public static BookEntity Create(int authorId, string title, DateTime publishedDate,
                                         string isbn, int pages, string language, string publisher)
        {
            return new BookEntity(authorId, title, publishedDate, isbn, pages, language, publisher);
        }
    }
}
