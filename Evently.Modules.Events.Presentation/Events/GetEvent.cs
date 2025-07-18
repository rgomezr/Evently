using Evently.Modules.Events.Application.Events;
using Evently.Modules.Events.Application.Events.GetEvent;
using Evently.Modules.Events.Domain.Abstractions;
using Evently.Modules.Events.Presentation.ApiResults;
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
                Result<EventResponse> result = await sender.Send(new GetEventQuery(id));
                
                return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Events);
    }
}
