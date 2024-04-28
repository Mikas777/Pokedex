using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class VersionSpritesDTO
{
    [JsonPropertyName("generation-i")]
    public GenerationISpritesDTO GenerationI { get; set; }

    [JsonPropertyName("generation-ii")]
    public GenerationIISpritesDTO GenerationII { get; set; }

    [JsonPropertyName("generation-iii")]
    public GenerationIIISpritesDTO GenerationIII { get; set; }

    [JsonPropertyName("generation-iv")]
    public GenerationIVSpritesDTO GenerationIV { get; set; }

    [JsonPropertyName("generation-v")]
    public GenerationVSpritesDTO GenerationV { get; set; }

    [JsonPropertyName("generation-vi")]
    public GenerationVISpritesDTO GenerationVI { get; set; }

    [JsonPropertyName("generation-vii")]
    public GenerationVIISpritesDTO GenerationVII { get; set; }

    [JsonPropertyName("generation-viii")]
    public GenerationVIIISpritesDTO GenerationVIII { get; set; }
}

