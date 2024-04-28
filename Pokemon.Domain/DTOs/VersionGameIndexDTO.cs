using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class VersionGameIndexDTO
{
    [JsonPropertyName("game_index")]
    public int GameIndex { get; set; }

    [JsonPropertyName("version")]
    public VersionDTO Version { get; set; }
}
