namespace Evently.Modules.Events.Domain.Events;

public sealed class Event : Entity
{
    private Event()
    {
        
    }
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public DateTime StartsAtUtc { get; private set; }
    public DateTime? EndsAtUtc { get; private set; }
    public EventStatus Status { get; private set; }

    public static Event Create(
        string title,
        string description,
        string location,
        DateTime startsAtUtc,
        DateTime? endsAtUtc)
    {
        var @event = new Event
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Location = location,
            StartsAtUtc = startsAtUtc,
            EndsAtUtc = endsAtUtc
        };
        @event.Raise(new EventCreatedDomainEvent(@event.Id));
        
        return @event;
    }
}

public sealed class EventCreatedDomainEvent(Guid eventId) : IDomainEvent
{
    public Guid EventId { get; init; } = eventId;
}

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    protected Entity()
    {
        
    }
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();
    
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}

public interface IDomainEvent
{
    Guid Id { get; }
    DateTime OccurredOnUtc { get; }
}
