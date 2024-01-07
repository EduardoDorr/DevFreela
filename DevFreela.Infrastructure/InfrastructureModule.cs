using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using DevFreela.Domain.Services;
using DevFreela.Domain.Repositories;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Payment;
using DevFreela.Infrastructure.Consumers;
using DevFreela.Infrastructure.MessageBus;
using DevFreela.Infrastructure.Persistence.Data;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace DevFreela.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContexts(configuration)
                .AddRepositories()
                .AddServices();

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
        services.AddTransient<IPaymentService, PaymentService>();
        services.AddTransient<IMessageBusService, MessageBusService>();
        services.AddHostedService<PaymentApprovedConsumer>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();

        return services;
    }
}