using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.TicketTypes;

public class TicketTypePriceChangedDomainEvent(Guid ticketTypeId, decimal price) : DomainEvent
{
    public Guid TicketTypeId { get; init; } = ticketTypeId;
    public decimal Price { get; init; } = price;
}
