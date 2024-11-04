using Evently.Modules.Events.Application.Events;
using Microsoft.AspNetCore.Routing;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Evently.Modules.Events.Presentation.Events;

public static class GetEvent
{
    // simple example of vertical slice architecture for GetEvent use case
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/events/{id}", async (Guid id, ISender sender) =>
        {
            EventResponse? @event = await sender.Send(new GetEventQuery(id));
            
            return @event is null ? Results.NotFound() : Results.Ok(@event);
        })
        .WithTags(Tags.Events);
    }
}
