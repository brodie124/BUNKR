using Microsoft.EntityFrameworkCore;

namespace BUNKR.Domain.Models.Domain;

[Owned]
public class BunkrUrl
{
    public string Url { get; }
    public string UrlSlug { get; }
    
    public BunkrUrl(string url)
    {
        Url = url;
        UrlSlug = url; // TODO: turn this one into a slug
    }
}