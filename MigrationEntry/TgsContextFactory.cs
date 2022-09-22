using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TGS.Core.DataServices.Tgs;
using TGS.Core.Models;

namespace Tgs.Migrations;

public class TgsContextFactory : IDesignTimeDbContextFactory<TgsRepository>
{
    public TgsRepository CreateDbContext(string[] args)
    {
        var configBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

        var config = configBuilder.Build();

        var services = new ServiceCollection();

        _ = services
            .AddDbContext<TgsRepository>(
                dbOptions => dbOptions
                    .EnableSensitiveDataLogging()
                    .UseSnakeCaseNamingConvention()
                    .UseNpgsql(
                        config.GetConnectionString("Tgs"),
                        serverOption => serverOption
                            .MigrationsHistoryTable(Consts.Db.MigrationsHistoryTable, Consts.Db.Schema)
                            .MigrationsAssembly("MigrationEntry")),
                ServiceLifetime.Singleton,
                ServiceLifetime.Singleton);

        var loggerFactory = LoggerFactory.Create(builder => builder
            .AddConfiguration(config.GetSection("Logging"))
            .AddConsole());

        _ = services.AddSingleton(loggerFactory);

        var serviceProvider = services.BuildServiceProvider();

        var dbContext = serviceProvider.GetRequiredService<TgsRepository>();

        return dbContext;
    }
}
