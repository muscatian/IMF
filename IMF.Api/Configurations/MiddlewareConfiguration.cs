using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;

namespace IMF.Api.Configurations
{
    public static class MiddlewareConfiguration
    {
        public static void ConfigureMiddleware(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {

                        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                        var statusCode = exception switch
                        {
                            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                            ForbiddenAccessException => StatusCodes.Status403Forbidden,
                            _ => StatusCodes.Status500InternalServerError,
                        };

                        context.Response.StatusCode = statusCode;

                        var problemDetails = new ProblemDetails
                        {
                            Type = "https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/" + statusCode,
                            Title = exception?.Message ?? "An unexpected error occurred.",
                            Detail = exception?.StackTrace,
                        };

                        await context.Response.WriteAsJsonAsync(problemDetails);
                    });
                });
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("CustomCorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
        }
    }

}
