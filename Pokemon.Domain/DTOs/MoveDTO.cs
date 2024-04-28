using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class MoveDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string InformationMove { get; set; }
}

