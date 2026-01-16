using application.Presentation.Extesions;
using application.application;
using application.Infrastructure;
using application.Presentation;

namespace application.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Register layers
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddPresentation();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Map endpoints from Presentation
            app.MapPresentationEndpoints();

            app.Run();
        }
    }
}
