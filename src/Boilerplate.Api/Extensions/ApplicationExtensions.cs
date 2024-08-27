using Boilerplate.Application.BookAggregate.Service;

namespace Boilerplate.Api.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBookService, BookService>();
        }
    }
}
