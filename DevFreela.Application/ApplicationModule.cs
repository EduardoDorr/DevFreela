using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Services.Implementations;

namespace DevFreela.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices()
                .AddMediator();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISkillService, SkillService>();
        services.AddScoped<IProjectService, ProjectService>();

        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}