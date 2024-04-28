using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class GenerationVISpritesDTO
{
    [JsonPropertyName("omegaruby-alphasapphire")]
    public OmegaRubyAlphaSapphireSpritesDTO OmegaRubyAlphaSapphire { get; set; }

    [JsonPropertyName("x-y")]
    public XYSpritesDTO XY { get; set; }
}
