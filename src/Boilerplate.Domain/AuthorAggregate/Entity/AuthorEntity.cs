using Boilerplate.Domain.BookAggregate.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boilerplate.Domain.AuthorAggregate.Entity
{
    public class AuthorEntity : AbstractEntity
    {
        [Column("id")] public int Id { get; }
        [Column("first_name")] public string FirstName { get; private set; }
        [Column("last_name")] public string LastName { get; private set; }
        [Column("birth_date")] public DateTime Birthdate { get; private set; }
        [Column("nationality")] public string Nationality { get; private set; }
        [Column("created_date")] public DateTime CreatedDate { get; private set; }
        [Column("created_by")] public string CreatedBy { get; private set; }
        private readonly List<BookEntity> _books;
        public IReadOnlyCollection<BookEntity> Books => _books.AsReadOnly();

        private AuthorEntity()
        {
            _books = [];
        }

        private AuthorEntity(string firstName, string lastName, DateTime birthdate,
                       string nationality, DateTime createdDate, string createdBy)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Nationality = nationality;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            _books = [];
        }

        public static AuthorEntity Create(string firstName, string lastName,
                                             DateTime birthdate, string nationality,
                                             DateTime createdDate, string createdBy)
        {
            return new AuthorEntity(firstName, lastName, birthdate, nationality, createdDate, createdBy);
        }

        public void AddBook(BookEntity book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            _books.Add(book);
        }
    }
}
