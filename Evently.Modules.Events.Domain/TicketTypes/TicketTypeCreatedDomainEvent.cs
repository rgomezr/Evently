using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.TicketTypes;

public class TicketTypeCreatedDomainEvent(Guid ticketTypeId): DomainEvent
{
    public Guid TicketTypeId { get; init; } = ticketTypeId;
}
