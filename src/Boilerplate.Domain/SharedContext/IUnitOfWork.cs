namespace Boilerplate.Domain.SharedContext
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(IReadOnlyCollection<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
    }
}
