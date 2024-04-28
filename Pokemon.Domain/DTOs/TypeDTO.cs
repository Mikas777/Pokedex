using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class TypeDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string InformationType { get; set; }
}
