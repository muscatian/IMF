using Microsoft.AspNetCore.Builder;
using System;
using Serilog;
using IMF.Api.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace IMF.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                ConfigurationSetup.ConfigureLogging(builder);

                builder.Services.AddCustomServices(builder);

                var app = builder.Build();
                
                app.ConfigureMiddleware();

                // Seed roles
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    await SeedData.SeedRoles(services);
                }
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}
