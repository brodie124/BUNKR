using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BUNKR.Domain.Models.Domain;

[Owned]
public class DelimitedStringList
{
    private readonly string _delimiter;
    private string? _value;
    private List<string> _cachedList = new();

    public required string? Value
    {
        get => _value;
        set => UpdateValue(value);
    }

    [NotMapped] 
    public List<string> List => _cachedList;

    public DelimitedStringList() : this(";")
    {
    }

    public DelimitedStringList(string delimiter)
    {
        _delimiter = delimiter;
    }

    private void UpdateValue(string? value)
    {
        if (value == _value)
            return;
        
        _value = value;
        _cachedList = _value?.Split(_delimiter).ToList() ?? new List<string>();
    }
}