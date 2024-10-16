using IMF.Api.Services;
using IMF.DAL.Data;
using IMF.DAL.Identity;
using IMF.DAL.Repository.IRepository;
using IMF.DAL.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.AspNetCore.Http;


namespace IMF.Api.Configurations
{
    public static class ServiceRegistration
    {
        public static void AddCustomServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAutoMapper(typeof(Program));
            var connectionString = ConfigurationSetup.GetConnectionString(builder);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddControllers();
            services.AddScoped<JWTService>();
            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddRoles<ApplicationRole>()
            .AddRoleManager<RoleManager<ApplicationRole>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddUserManager<UserManager<ApplicationUser>>()
            .AddDefaultTokenProviders();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"] ?? throw new InvalidOperationException("JWT Key not found."))),
                    };
                });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            var corsSettings = ConfigurationSetup.GetCorsSettings(builder);
            services.AddCors(options =>
            {
                options.AddPolicy("CustomCorsPolicy", policy =>
                {
                    policy.WithOrigins(corsSettings.AllowedOrigins)
                        .WithHeaders(corsSettings.AllowedHeaders);

                    if (corsSettings.AllowAnyMethod)
                    {
                        policy.AllowAnyMethod();
                    }
                    else
                    {
                        policy.WithMethods(corsSettings.AllowedMethods);
                    }

                    if (corsSettings.AllowCredentials)
                    {
                        policy.AllowCredentials();
                    }
                    else
                    {
                        policy.DisallowCredentials();
                    }
                });
            });
        }
    }
}
