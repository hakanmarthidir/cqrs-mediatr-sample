using MediatR;

namespace cqrs.Domain.Entities.Shared
{
    public abstract class DomainEvent : INotification
    {
        public DateTimeOffset CreatedDate { get; protected set; } = DateTimeOffset.UtcNow;
    }
}
