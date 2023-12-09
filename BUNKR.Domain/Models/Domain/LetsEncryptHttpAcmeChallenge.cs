namespace BUNKR.Domain.Models.Domain;

public class LetsEncryptHttpAcmeChallenge
{
    public int Id { get; set; } = default!;
    public string Token { get; set; } = default!;
    public string UrlSlug { get; set; } = default!;

    public DateTime Created { get; set; } = default!;
    public DateTime LastUpdated { get; set; } = default!;
}