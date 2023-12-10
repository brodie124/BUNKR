using BUNKR.Domain.Enums;
using BUNKR.Domain.Models.Domain;

namespace BUNKR.Primary.Controllers.ManagedDomains;

public class ManagedDomainsService
{
    private readonly IManagedDomainsRepository _managedDomainsRepository;

    public ManagedDomainsService(IManagedDomainsRepository managedDomainsRepository)
    {
        _managedDomainsRepository = managedDomainsRepository;
    }

    public async Task<ServiceResult<ManagedDomain>> Add(ManagedDomain managedDomain)
    {
        var existingManagedDomain = await _managedDomainsRepository.FindByUrlSlugAsync(managedDomain.Url.UrlSlug);
        if(existingManagedDomain?.Id == managedDomain.Id)
            return ServiceResult<ManagedDomain>.Failure(ErrorCode.ResourceAlreadyExists);

        await _managedDomainsRepository.AddAsync(managedDomain);
        return managedDomain;
    }
}