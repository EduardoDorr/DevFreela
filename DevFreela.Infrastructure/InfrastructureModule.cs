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
                .AddMigrations()
                .AddRepositories()
                .AddUnitOfWork()
                .AddServices()
                .AddMessageBus()
                .AddAuthorization()
                .AddHostedServices();

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

    private static IServiceCollection AddMigrations(this IServiceCollection services)
    {
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DevFreelaDbContext>();
            db.Database.Migrate();
        }

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ISkillRepository, SkillRepository>();
        services.AddTransient<IProjectRepository, ProjectRepository>();

        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPaymentService, PaymentService>();

        return services;
    }

    private static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();

        return services;
    }

    private static IServiceCollection AddMessageBus(this IServiceCollection services)
    {
        services.AddTransient<IMessageBusService, MessageBusService>();

        return services;
    }

    private static IServiceCollection AddHostedServices(this IServiceCollection services)
    {
        services.AddHostedService<PaymentApprovedConsumer>();

        return services;
    }
}