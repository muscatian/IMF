using IMF.Api.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace IMF.Api.Configurations
{
    public static class ConfigurationSetup
    {
        public static void ConfigureLogging(WebApplicationBuilder builder)
        {
            const string logPath = "apilog/apilog-.log";
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Extensions.Hosting", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.Hosting", LogEventLevel.Information)
                .Enrich.WithEnvironmentName()
                .Enrich.WithMachineName()
                .Enrich.WithClientIp()
                .WriteTo.Console()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            builder.Host.UseSerilog();
        }

        public static CorsSettings GetCorsSettings(WebApplicationBuilder builder)
        {
            return builder.Configuration.GetSection("CorsSettings").Get<CorsSettings>();
        }

        public static string GetConnectionString(WebApplicationBuilder builder)
        {
            return builder.Configuration.GetConnectionString("APIConnection") ?? throw new InvalidOperationException("Connection string 'APIConnection' not found.");
        }
    }

}
