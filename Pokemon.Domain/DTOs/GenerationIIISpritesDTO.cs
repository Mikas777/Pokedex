using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class GenerationIIISpritesDTO
{
    [JsonPropertyName("emerald")]
    public EmeraldSpritesDTO Emerald { get; set; }

    [JsonPropertyName("firered-leafgreen")]
    public FireredLeafgreenSpritesDTO FireredLeafgreen { get; set; }

    [JsonPropertyName("ruby-sapphire")]
    public RubySapphireSpritesDTO RubySapphire { get; set; }
}
