using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class PokemonSpeciesDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string InformationSpecies { get; set; }
}