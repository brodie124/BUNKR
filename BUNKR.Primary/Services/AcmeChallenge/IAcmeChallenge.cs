using BUNKR.Domain.Models.Domain;

namespace BUNKR.Primary.Services.AcmeChallenge;

public interface IAcmeChallenge
{
    Guid Identifier { get; }
    BunkrUrl Url { get; }
    Task Prepare();
    Task Execute();
}