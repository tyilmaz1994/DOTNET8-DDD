using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Application.ViewModels
{
    public record TestViewModel : PageViewModel
    {
        public TestViewModel(long Page, long PageSize) : base(Page, PageSize)
        {
        }

        [Range(1, 100)]
        public long Id { get; init; }
        public string? Filter { get; init; }
    }
}
