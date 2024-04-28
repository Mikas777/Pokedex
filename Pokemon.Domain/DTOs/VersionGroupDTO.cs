using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class VersionGroupDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")] 
    public string InformationVersionGroup { get; set; }
}
