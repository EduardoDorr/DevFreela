using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using DevFreela.Domain.Repositories;
using DevFreela.Infrastructure.Persistence.Data;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace DevFreela.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContexts(configuration)
                .AddRepositories();

        return services;
    }

    private static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DevFreela");

        services.AddDbContext<DevFreelaDbContext>(opts =>
        {
            opts.UseSqlServer(connectionString);
        });

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ISkillRepository, SkillRepository>();

        return services;
    }
}