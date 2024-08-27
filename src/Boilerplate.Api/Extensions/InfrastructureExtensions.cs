using Boilerplate.Domain.BookAggregate.Interfaces.Repository;
using Boilerplate.Infrastructure;
using Boilerplate.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Api.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void AddExternalServices(this IServiceCollection services, string dbConfig, string kafkaConfig)
        {
            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseNpgsql(dbConfig);
            });

            services.AddCap(x =>
            {
                x.UseKafka(kafkaConfig);
                x.UsePostgreSql(dbConfig);
            });

        }

        public static void AddInfraServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
