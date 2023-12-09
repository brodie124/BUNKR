namespace BUNKR.Primary.ConfigurationOptions;

public class DatabaseOptions
{
    public const string SectionName = "Database";
    public string MysqlConnectionString { get; set; } = default!;
}