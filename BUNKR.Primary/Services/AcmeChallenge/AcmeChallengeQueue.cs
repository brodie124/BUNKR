namespace BUNKR.Primary.Services.AcmeChallenge;

public class AcmeChallengeQueue
{
    private List<IAcmeChallenge> _acmeChallenges = new List<IAcmeChallenge>();
    public IReadOnlyList<IAcmeChallenge> AcmeChallenges => _acmeChallenges;
}