using Microsoft.AspNetCore.Mvc;

namespace BUNKR.Primary.Controllers;

[Route("[controller]")]
public class LetsEncryptAcmeController : ControllerBase
{


    [HttpPost("StartHttpChallenge")]
    public async Task StartHttpChallenge()
    {
        
    }

    [HttpGet("ProveHttpChallenge/{*token}")]
    public async Task ProveHttpChallenge(string token)
    {
        
    }
}