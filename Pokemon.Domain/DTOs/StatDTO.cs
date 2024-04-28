using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class StatDTO
{
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string InformationStat { get; set; }
}

