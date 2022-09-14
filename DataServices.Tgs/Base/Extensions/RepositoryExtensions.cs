using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TGS.Core.Models;

namespace TGS.Core.DataServices.Base.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepository<TInterface, TRepository>(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionName,
        int commandTimeout = 180)
        where TInterface : class
        where TRepository : DbContext, TInterface
    {
        const int poolSize = 64;
        var connectionString = configuration.GetConnectionString(connectionName);

        _ = services.AddDbContextPool<TRepository>(option =>
        {
            AddLogger(option);

            _ = option.UseLazyLoadingProxies();

            _ = option.UseNpgsql(connectionString, serverOption =>
            {
                _ = serverOption.CommandTimeout(commandTimeout);
                _ = serverOption.MigrationsHistoryTable(Consts.Db.MigrationsHistoryTable, Consts.Db.Schema);
            });

            _ = option.UseSnakeCaseNamingConvention();
        }, poolSize);

        _ = services.AddDbContextFactory<TRepository>(option =>
        {
            AddLogger(option);

            _ = option
                .UseNpgsql(connectionString, serverOption =>
                {
                    _ = serverOption.CommandTimeout(commandTimeout);
                    _ = serverOption.MigrationsHistoryTable(Consts.Db.MigrationsHistoryTable, Consts.Db.Schema);
                })
                .UseSnakeCaseNamingConvention();
        });

        _ = services.AddScoped<TInterface>(c => c.GetRequiredService<TRepository>());
        _ = services.AddTransient<Func<TInterface>>(c => () =>
        {
            var factory = c.GetRequiredService<IDbContextFactory<TRepository>>();
            return factory.CreateDbContext();
        });

        return services;
    }

    private static void AddLogger(DbContextOptionsBuilder option)
    {
#if DEBUG
        option.EnableSensitiveDataLogging();
#endif
    }
}
