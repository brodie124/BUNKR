using BUNKR.Primary.ConfigurationOptions;

namespace BUNKR.Primary.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfigurationOptions(
        this IServiceCollection serviceCollection,
        IConfiguration configuration
    )
    {
        return serviceCollection
            .AddDatabaseConfigurationOptions(configuration)
            ;
    }
    

    public static IServiceCollection AddDatabaseConfigurationOptions(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration
    )
    {
        return serviceCollection.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
    }

}