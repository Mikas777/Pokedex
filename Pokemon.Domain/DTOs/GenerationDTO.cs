using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class GenerationDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string InformationGeneration { get; set; }

}