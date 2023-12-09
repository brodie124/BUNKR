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
    /// Called when a secondary has an ACME HTTP-01 token to be used for proving.
    /// </summary>
    [HttpPost("StartHttpChallenge/{urlSlug}/{*token}")]
    public async Task StartHttpChallenge(
        [FromRoute] string token, 
        [FromRoute] string urlSlug,
        [FromBody] StartLetsEncryptHttpAcmeChallengeRequestDto startChallengeRequest
    )
    {
        // TODO: store the ACME challenge data somewhere
        _ = Task.Run(() => _acmeChallengeService.ExecuteChallenge().LogExceptions(_logger));
    }

    /// <summary>
    /// Called when a secondary receives a request from LetsEncrypt to prove an ACME HTTP-01 token.
    /// </summary>
    [HttpGet("ProveHttpChallenge/{urlSlug}/{*token}")]
    public async Task ProveHttpChallenge([FromRoute] string urlSlug, [FromRoute] string token)
    {
        
    }
}