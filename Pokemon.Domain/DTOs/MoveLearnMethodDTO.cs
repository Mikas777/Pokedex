using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class MoveLearnMethodDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")] 
    public string InformationMoveLearnMethod { get; set; }
}

