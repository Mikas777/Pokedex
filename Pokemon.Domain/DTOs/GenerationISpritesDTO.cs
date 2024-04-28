using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class GenerationISpritesDTO
{
    [JsonPropertyName("red-blue")]
    public RedBlueSpritesDTO RedBlue { get; set; }

    public YellowSpritesDTO Yellow { get; set; }
}