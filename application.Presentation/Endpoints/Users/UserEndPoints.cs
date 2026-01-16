using application.application.Features.Users.Commands.CreateUser;
using application.application.Features.Users.Queries;
using application.Presentation.Contracts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace application.Presentation.Endpoints.Users
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUserEndpoints(
            this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("/api/users")
                .WithTags("Users");

            group.MapPost("/", async (
                CreateUserRequest request,
                ISender sender,
                CancellationToken ct) =>
            {
                var command = new CreateUserCommand(
                    request.Email,
                    request.Name);

                var result = await sender.Send(command, ct);

                return Results.Created(
                    $"/api/customers/{result}",
                    null);
            });

            group.MapGet("/{id:guid}", async (
            Guid id,
            ISender sender,
            CancellationToken ct) =>
            {
                var dto = await sender.Send(new GetUserByIdQuery(id), ct);

                return Results.Ok(new UserResponse(
                    dto.Id,
                    dto.Email));
            });

            group.MapGet("/", async (
            ISender sender,
            CancellationToken ct) =>
            {
                var users = await sender.Send(new GetUsersQuery(), ct);

                var response = users
                    .Select(u => new UserResponse(u.Id, u.Email));

                return Results.Ok(response);
            });


            return endpoints;
        }
    }
}
