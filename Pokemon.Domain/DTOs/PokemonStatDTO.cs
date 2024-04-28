using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class PokemonStatDTO
{
    [JsonPropertyName("stat")]
    public StatDTO Stat { get; set; }

    [JsonPropertyName("effort")]
    public int Effort { get; set; }

    [JsonPropertyName("base_stat")]
    public int BaseStat { get; set; }
}