using BUNKR.Domain.Models.Transfer;
using BUNKR.Primary.Extensions;
using BUNKR.Primary.Services.AcmeChallenge;
using Microsoft.AspNetCore.Mvc;

namespace BUNKR.Primary.Controllers;

[Route("[controller]")]
public class LetsEncryptAcmeController : ControllerBase
{
    private readonly ILogger<LetsEncryptAcmeController> _logger;
    private readonly AcmeChallengeService _acmeChallengeService;

    public LetsEncryptAcmeController(
        ILogger<LetsEncryptAcmeController> logger,
        AcmeChallengeService acmeChallengeService
    )
    {
        _logger = logger;
        _acmeChallengeService = acmeChallengeService;
    }

    /// <summary>
    /// Called when a Secondary receives a request from LetsEncrypt to prove an ACME HTTP-01 token.
    /// </summary>
    [HttpPost("ProveHttpChallenge/{urlSlug}/{*token}")]
    public async Task ProveHttpChallenge(
        [FromRoute] string urlSlug, 
        [FromRoute] string token
    )
    {
        // TODO: store the ACME challenge data somewhere
        _ = Task.Run(() => _acmeChallengeService.ExecuteChallenge().LogExceptions(_logger));
    }
}