using BUNKR.Domain.Models.Domain;
using BUNKR.Primary.Database;
using BUNKR.Primary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BUNKR.Primary.Controllers.ManagedDomains;

public interface IManagedDomainsRepository : IGenericRepository<ManagedDomain>
{
    Task<ManagedDomain?> FindByUrlSlugAsync(string urlSlug);
}

public class ManagedDomainsRepository : GenericRepository<ManagedDomain>, IManagedDomainsRepository
{
    public ManagedDomainsRepository(BunkrDatabaseContext context) : base(context)
    {
    }

    public async Task<ManagedDomain?> FindByUrlSlugAsync(string urlSlug)
    {
        return await GetBaseQueryable()
            .FirstOrDefaultAsync(x => x.Url.UrlSlug.Equals(urlSlug, StringComparison.OrdinalIgnoreCase));
    }
}