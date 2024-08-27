using Boilerplate.Application.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Api.Contracts.Request
{
    public record CreateBookRequestModel
    {
        [Range(1, double.MaxValue)] public int AuthorId { get; set; }
        [Required] public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }

        public BookViewModel ToViewModel()
        {
            var viewModel = new BookViewModel
            {
                AuthorId = AuthorId,
                ISBN = ISBN,
                Language = Language,
                Pages = Pages,
                PublishedDate = PublishedDate,
                Publisher = Publisher,
                Title = Title
            };
            return viewModel;
        }
    }
}