using Boilerplate.Api.Objects;
using Boilerplate.Domain.BookAggregate.Entity;
using Boilerplate.Domain.SharedContext;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Boilerplate.Infrastructure
{
    public class LibraryContext(DbContextOptions<LibraryContext> options, ICapPublisher capPublisher, IOptions<Api.Objects.KafkaOptions> kafkaOptions) : DbContext(options), IUnitOfWork
    {
        public DbSet<BookEntity> Books { get; set; }
        public Api.Objects.KafkaOptions KafkaTopicOptions => kafkaOptions.Value;

        public async Task<int> SaveChangesAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
        {
            using var transaction = await Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadUncommitted, capPublisher);
            var nOfWrittenEntities = await base.SaveChangesAsync(cancellationToken);
            foreach (var domainEvent in domainEvents)
            {
                var topicKey = domainEvent.GetType().Name;
                var topic = KafkaTopicOptions.Topics.FirstOrDefault(x => x.Name == topicKey);
                if (topic is null)
                {
                    throw new InvalidOperationException();
                }
                await capPublisher.PublishAsync(topic.Value, domainEvent);
            }
            await transaction.CommitAsync();
            return nOfWrittenEntities;
        }
    }
}
