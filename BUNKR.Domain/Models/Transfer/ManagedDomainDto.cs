using BUNKR.Domain.Models.Domain;

namespace BUNKR.Domain.Models.Transfer;

public class ManagedDomainDto
{
    public required int Id { get; set; }
    public required string Url { get; set; }
    
    public required List<string> Subdomains { get; set; }
    
    public required DateTime Created { get; set; }
    public required DateTime LastUpdated { get; set; }

    public ManagedDomain ToDomain()
    {
        return new ManagedDomain()
        {
            Id = Id,
            Url = new BunkrUrl(Url),
            Subdomains = new DelimitedStringList(string.Join(";", Subdomains)),
            Created = Created,
            LastUpdated = LastUpdated
        };
    }
    
    public static ManagedDomainDto FromDomain(ManagedDomain managedDomain)
    {
        return new ManagedDomainDto()
        {
            Id = managedDomain.Id,
            Url = managedDomain.Url.Url,
            Subdomains = managedDomain.Subdomains.List,
            Created = managedDomain.Created,
            LastUpdated = managedDomain.LastUpdated
        };
    }
}