namespace BUNKR.Domain.Models.Domain;

public class ManagedDomain
{
    public required int Id { get; set; }
    public required BunkrUrl Url { get; set; }
    
    public required DelimitedStringList Subdomains { get; set; }
    
    public required DateTime Created { get; set; }
    public required DateTime LastUpdated { get; set; }
}