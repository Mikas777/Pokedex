using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class AbilityDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string InformationAbility { get; set; }
}

