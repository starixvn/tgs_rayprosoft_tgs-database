using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TGS.Core.DataServices.Tgs;
using TGS.Core.Models;

namespace Tgs.Migrations;

public class TgsContextFactory : IDesignTimeDbContextFactory<TgsRepository>
{
    public TgsRepository CreateDbContext(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(builder => builder
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables())
            .ConfigureServices(services => services
                .AddDbContext<TgsRepository>(
                dbOptions => dbOptions
                    .EnableSensitiveDataLogging()
                    .UseSnakeCaseNamingConvention()
                    .UseNpgsql(
                        "Name=Tgs",
                        serverOption => serverOption
                            .MigrationsHistoryTable(Consts.Db.MigrationsHistoryTable, Consts.Db.Schema)
                            .MigrationsAssembly("MigrationEntry")),
                ServiceLifetime.Singleton,
                ServiceLifetime.Singleton))
            .Build();

        var dbContext = host.Services.GetRequiredService<TgsRepository>();

        return dbContext;
    }
}
