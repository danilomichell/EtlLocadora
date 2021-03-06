using EtlLocadora.Data;
using EtlLocadora.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EtlLocadora.Processamento
{
    public static class Configurations
    {
        public static ServiceProvider Inject()
        {
            var serviceCollection = new ServiceCollection();

            var configuration = SetGeneralConfiguration(serviceCollection);

            SetDbContexts(serviceCollection, configuration);
            SetScopedServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }

        private static IConfiguration SetGeneralConfiguration(IServiceCollection serviceCollection)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            return configuration;
        }

        private static void SetDbContexts(IServiceCollection serviceCollection, IConfiguration configuration)
        {

            var connectionLocadora = configuration.GetConnectionString("LocadoraContext");
            serviceCollection.AddDbContextPool<LocadoraContext>(opts => opts.UseOracle(connectionLocadora));

            var connectionLocadoraDw = configuration.GetConnectionString("LocadoraDwContext");
            serviceCollection.AddDbContextPool<LocadoraDwContext>(opts => opts.UseOracle(connectionLocadoraDw, options => options
                                                                                .UseOracleSQLCompatibility("11")));
        }

        private static void SetScopedServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProcessoEtl, ProcessoEtl>();
        }
    }
}
