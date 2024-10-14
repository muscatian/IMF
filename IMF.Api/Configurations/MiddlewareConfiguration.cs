using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Serilog;

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
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";

                        var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (errorFeature != null)
                        {
                            var error = errorFeature.Error;

                            var result = System.Text.Json.JsonSerializer.Serialize(new
                            {
                                error = "An unexpected error occurred. Please try again later.",
                                details = error.Message
                            });

                            await context.Response.WriteAsync(result);
                           // Log.Error(result);
                        }
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
