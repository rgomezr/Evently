using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Events;

public sealed class CategoryArchivedDomainEvent(Guid categoryId) : DomainEvent
{
    public Guid CategoryId { get; init; } = categoryId;
}