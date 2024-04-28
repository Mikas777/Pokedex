using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class GenerationVIISpritesDTO
{
    public IconsSpritesDTO Icons { get; set; }

    [JsonPropertyName("ultra-sun-ultra-moon")]
    public UltraSunUltraMoonSpritesDTO UltraSunUltraMoon { get; set; }
}

