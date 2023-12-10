using BUNKR.Primary.ConfigurationOptions;
using BUNKR.Primary.Controllers.ManagedDomains;

namespace BUNKR.Primary.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBunkrServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
                .AddScoped<IManagedDomainsRepository, ManagedDomainsRepository>()
                .AddScoped<IManagedDomainsRepository, ManagedDomainsRepository>()
            ;
    }
    
    public static IServiceCollection AddBunkrConfigurationOptions(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
    )
    {
        return serviceCollection
            .AddDatabaseConfigurationOptions(configuration)
            ;
    }
    

    private static IServiceCollection AddDatabaseConfigurationOptions(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration
    )
    {
        return serviceCollection.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
    }

}