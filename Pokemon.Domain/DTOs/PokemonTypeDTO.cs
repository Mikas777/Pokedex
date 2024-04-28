using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class PokemonTypeDTO
{
    [JsonPropertyName("slot")]
    public int Slot { get; set; }

    [JsonPropertyName("type")]
    public TypeDTO Type { get; set; }
}

