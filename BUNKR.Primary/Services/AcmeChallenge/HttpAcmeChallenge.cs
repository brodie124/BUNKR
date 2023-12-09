using BUNKR.Domain.Models.Domain;

namespace BUNKR.Primary.Services.AcmeChallenge;

public class HttpAcmeChallenge : AcmeChallenge
{
    public HttpAcmeChallenge(BunkrUrl url) : base(url)
    {
    }

    public override Task Prepare()
    {
        // TODO: contact Secondary to fetch the token
        // TODO: wait for the Secondary to complete this process, or timeout
        throw new NotImplementedException();
    }

    public override Task Execute()
    {
        // TODO: complete the ACME process
        throw new NotImplementedException();
    }
}