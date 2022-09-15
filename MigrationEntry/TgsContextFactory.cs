using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TGS.Core.DataServices.Base.Extensions;
using TGS.Core.DataServices.Tgs;

namespace MigrationEntry;

public class TgsContextFactory : IDesignTimeDbContextFactory<TgsRepository>
{
    public TgsRepository CreateDbContext(string[] args)
    {
        var configBuilder = new ConfigurationBuilder();
        _ = configBuilder
            .AddJsonFile("tgs.appsettings.json", true)
            .AddEnvironmentVariables();
        var config = configBuilder.Build();

        var services = new ServiceCollection();

        _ = services.AddRepository<TgsRepository, TgsRepository>(config, "Tgs");

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            _ = builder
                .AddConfiguration(config.GetSection("Logging"))
                .AddConsole();
        });
        _ = services.AddSingleton(loggerFactory);

        var serviceProvider = services.BuildServiceProvider();

        var dbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<TgsRepository>>();

        return dbContextFactory.CreateDbContext();
    }
}
