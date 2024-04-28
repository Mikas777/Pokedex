using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class GetPokemonsResponse
{
    [JsonPropertyName("results")]
    public List<PokemonListItemDTO> Results { get; set; }
}

