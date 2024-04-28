using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class GenerationIVSpritesDTO
{
    [JsonPropertyName("diamond-pearl")]
    public DiamondPearlSpritesDTO DiamondPearl { get; set; }

    [JsonPropertyName("heartgold-soulsilver")]
    public HeartGoldSoulSilverSpritesDTO HeartGoldSoulSilver { get; set; }

    public PlatinumSpritesDTO Platinum { get; set; }
}
