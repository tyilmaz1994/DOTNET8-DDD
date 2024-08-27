namespace Boilerplate.Application.ViewModels
{
    public record BookViewModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
    }
}
