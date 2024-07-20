using ChatWave.Api.Extensions;
using ChatWave.Application.Exceptions;
using ChatWave.Application.Extensions;
using ChatWave.Infrastructure.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices(builder.Configuration)
                .AddInfrastructureServices(builder.Configuration)
                .AddApplicationServices();


var app = builder.Build();


app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        context.Response.ContentType = "application/json";
        var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();

        if (exceptionObject != null)
        {
            context.Response.StatusCode = exceptionObject.Error switch
            {
                BadRequestException ex => StatusCodes.Status400BadRequest,
                NotFoundException ex => StatusCodes.Status404NotFound,
                HttpRequestException ex => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
            var errorMessage = $"{exceptionObject.Error.Message}";

            await context.Response
                .WriteAsync(JsonSerializer.Serialize(new
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = errorMessage

                }))
                .ConfigureAwait(false);
        }
    });
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
