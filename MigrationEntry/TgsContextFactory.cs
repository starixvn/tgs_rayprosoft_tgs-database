using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TGS.Core.DataServices.Base.Extensions;
using TGS.Core.DataServices.Tgs;
using TGS.Core.Models;

namespace MigrationEntry;

public class TgsContextFactory : IDesignTimeDbContextFactory<TgsRepository>
{
    public TgsRepository CreateDbContext(string[] args)
    {
        var configBuilder = new ConfigurationBuilder();
        _ = configBuilder
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();
        var config = configBuilder.Build();

        var services = new ServiceCollection();

        _ = services
            .AddDbContext<TgsRepository>(
                dbOptions => dbOptions
                    .EnableSensitiveDataLogging()
                    .UseSnakeCaseNamingConvention()
                    .UseNpgsql(config.GetConnectionString("Tgs"), serverOption => serverOption
                        .MigrationsHistoryTable(Consts.Db.MigrationsHistoryTable, Consts.Db.Schema)),
                ServiceLifetime.Singleton,
                ServiceLifetime.Singleton);

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            _ = builder
                .AddConfiguration(config.GetSection("Logging"))
                .AddConsole();
        });
        _ = services.AddSingleton(loggerFactory);

        var serviceProvider = services.BuildServiceProvider();

        var dbContext = serviceProvider.GetRequiredService<TgsRepository>();

        return dbContext;
    }
}
