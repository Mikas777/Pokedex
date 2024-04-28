using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class PokemonListItemDTO
{
    [JsonPropertyName("url")]
    public string InformationUrl { get; set; }
}

