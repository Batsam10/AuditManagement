using AuditManagement.WebAPI;
using AuditManagement.WebAPI.Extensions;
using AuditManagement.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddEnvironmentVariables();

        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile(Constants.LoggingConfigFile)
                .Build())
            .Enrich.FromLogContext()
            .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);

        builder.Services.AddAppSettings(builder);

        // Add services to the container.
        builder.Services.AddHttpClients();
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSingleton(TimeProvider.System);
        builder.Services.AddDatabase(builder);
        builder.Services.AddDependencyGroup();
        builder.Services.AddSwagger();
        builder.WebHost.UseKestrel();

        var app = builder.Build();

        // Add exception handling middleware
        app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                await ExceptionHandler.HandleException(context, app.Services.GetService<ILogger<Program>>());
            });
        });

        // Configure the HTTP request pipeline.
        app.UseHttpsRedirection();

        app.UseSwagger(options =>
        {
            options.RouteTemplate = "docs/{documentName}/docs.json";
        });
        app.UseSwaggerUI(options =>
        {
            options.DocumentTitle = "Audit Management API";
            options.SwaggerEndpoint("/docs/v1/docs.json", "Audit Management V1");
            options.RoutePrefix = "docs";
        });

        app.UseStaticFiles();
        app.MapControllers();
        app.Run();
    }
}
