using AuditManagement.Business;
using AuditManagement.Business.Interfaces;
using AuditManagement.Business.Managers;
using AuditManagement.DataAcces.Data;
using AuditManagement.DataAcces.Repository;
using AuditManagement.DataAcces.Repository.Interfaces;
using AuditManagement.DTOs.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace AuditManagement.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IAuditTransactionRepository, AuditTransactionRepository>();
            services.AddScoped<IAuditManager, AuditManager>();
            services.AddScoped<IRestApiManager, RestApiManager>();

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, WebApplicationBuilder builder)
        {
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new NullReferenceException(nameof(connectionString));
            }
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //NB: Updates should have change taking enabled on the individual queries. Only should be disabled for readonly queries
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), null);
                })
                .LogTo(Console.WriteLine, LogLevel.Warning)
                .EnableDetailedErrors();
            });
            return services;
        }

        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient(AuditConstants.HttpClientName, (serviceProvider, httpClient) =>
            {
                var settings = serviceProvider.GetRequiredService<IOptionsMonitor<SettingsConfigDto>>().CurrentValue;
                httpClient.BaseAddress = settings.PostmanEndpoint;
                httpClient.Timeout = new TimeSpan(0, 2, 0);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }

        public static IServiceCollection AddAppSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var settingsSection = builder.Configuration.GetSection("Settings");
            services.Configure<SettingsConfigDto>(settingsSection);

            return services;
        }



        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Audit Management API",
                    Version = "v1",
                    Description = "This document describes the API endpoints to be exposed to the audit management."
                });

                c.UseInlineDefinitionsForEnums();
                c.EnableAnnotations();
            });


            return services;
        }
    }
}
