using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class GenerationVSpritesDTO
{
    [JsonPropertyName("black-white")]
    public BlackWhiteSpritesDTO BlackWhite { get; set; }
}
