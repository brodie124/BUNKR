namespace BUNKR.Primary.Services.AcmeChallenge;

public class AcmeChallengeService
{
    private readonly AcmeChallengeQueue _acmeChallengeQueue;

    public AcmeChallengeService()
    {
        _acmeChallengeQueue = new AcmeChallengeQueue();
    }

    public async Task ExecuteChallenge()
    {
        
    }
}