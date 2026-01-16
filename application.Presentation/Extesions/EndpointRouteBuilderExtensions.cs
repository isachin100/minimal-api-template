using application.Presentation.Endpoints.Users;
using Microsoft.AspNetCore.Routing;

namespace application.Presentation.Extesions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapPresentationEndpoints(
            this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapUserEndpoints();
            return endpoints;
        }
    }
}
