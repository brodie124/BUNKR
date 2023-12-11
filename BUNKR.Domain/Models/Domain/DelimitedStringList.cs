using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BUNKR.Domain.Models.Domain;

[Owned]
public class DelimitedStringList
{
    private const string Delimiter = ";";
    private string? _value;
    private List<string> _cachedList = new();

    public string? Value
    {
        get => _value;
        set => UpdateValue(value);
    }

    [NotMapped] 
    public List<string> List => _cachedList;

    public DelimitedStringList() : this(null)
    {
    }

    public DelimitedStringList(string? startingValue)
    {
        Value = startingValue;
    }

    private void UpdateValue(string? value)
    {
        if (value == _value)
            return;
        
        _value = value;
        _cachedList = _value?.Split(Delimiter).ToList() ?? new List<string>();
    }
}