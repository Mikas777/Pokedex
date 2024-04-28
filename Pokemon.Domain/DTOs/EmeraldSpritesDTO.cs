using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class EmeraldSpritesDTO
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }

    [JsonPropertyName("front_shiny")]
    public string FrontShiny { get; set; }
}
