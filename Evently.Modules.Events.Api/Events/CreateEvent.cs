using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Api.Events;

public static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", () =>
        {
            
        });
    }
}

internal sealed class Request
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartsAtUtc { get; set; }
    public DateTime? EndsAtUtc { get; set; }
}
