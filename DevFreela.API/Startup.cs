using System;
using System.Text.Json.Serialization;

using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using DevFreela.Application;
using DevFreela.Infrastructure;

namespace DevFreela.API;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddInfrastructure(configuration);

        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "DevFreela.API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Eduardo Dörr",
                    Email = "edudorr@hotmail.com",
                    Url = new Uri("https://github.com/EduardoDorr")
                }
            });
        });
    }
}