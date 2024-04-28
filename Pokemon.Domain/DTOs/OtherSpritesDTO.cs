using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class OtherSpritesDTO
{
    [JsonPropertyName("dream_world")] public DreamWorldSpritesDTO DreamWorld { get; set; }

    public HomeSpritesDTO Home { get; set; }

    [JsonPropertyName("official-artwork")] public OfficialArtworkSpritesDTO OfficialArtwork { get; set; }
}
