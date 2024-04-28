using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class VersionDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")] 
    public string InformationVersion { get; set; }
}

