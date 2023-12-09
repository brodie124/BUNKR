using BUNKR.Primary.ConfigurationOptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BUNKR.Primary.Database;

public class BunkrDatabaseContext : DbContext
{
    private readonly DatabaseOptions _databaseOptions;
    public BunkrDatabaseContext(IOptions<DatabaseOptions> databaseOptions)
    {
        _databaseOptions = databaseOptions.Value;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var mysqlVersion = ServerVersion.AutoDetect(_databaseOptions.MysqlConnectionString);
        optionsBuilder.UseMySql(_databaseOptions.MysqlConnectionString, mysqlVersion);
    }
}