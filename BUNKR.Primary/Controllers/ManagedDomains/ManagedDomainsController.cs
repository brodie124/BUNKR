using BUNKR.Domain.Models.Domain;
using BUNKR.Domain.Models.Transfer;
using Microsoft.AspNetCore.Mvc;

namespace BUNKR.Primary.Controllers.ManagedDomains;

public class ManagedDomainsController : ControllerBase
{
    private readonly IManagedDomainsService _managedDomainsService;

    public ManagedDomainsController(IManagedDomainsService managedDomainsService)
    {
        _managedDomainsService = managedDomainsService;
    }

    public async Task<ApiResult<ManagedDomain>> CreateManagedDomain(ManagedDomainDto managedDomainDto)
    {
        var managedDomain = managedDomainDto.ToDomain();
        var result = await _managedDomainsService.AddAsync(managedDomain);
        return result;
    }
}