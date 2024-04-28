using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class DreamWorldSpritesDTO
{
    [JsonPropertyName("front_default")] public string FrontDefault { get; set; }

    [JsonPropertyName("front_female")] public string FrontFemale { get; set; }
}

