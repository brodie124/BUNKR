using BUNKR.Domain.Models.Domain;

namespace BUNKR.Primary.Services.AcmeChallenge;

public abstract class AcmeChallenge : IAcmeChallenge
{
    public Guid Identifier { get; }
    public BunkrUrl Url { get; }

    public AcmeChallenge(BunkrUrl url)
    {
        Identifier = Guid.NewGuid();
        Url = url;
    }

    public abstract Task Prepare();
    public abstract Task Execute();
}