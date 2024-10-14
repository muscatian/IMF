using Microsoft.AspNetCore.Builder;
using System;
using Serilog;
using IMF.Api.Configurations;

namespace IMF.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                ConfigurationSetup.ConfigureLogging(builder);

                builder.Services.AddCustomServices(builder);

                var app = builder.Build();

                app.ConfigureMiddleware();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}
