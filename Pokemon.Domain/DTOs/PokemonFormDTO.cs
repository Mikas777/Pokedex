using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class PokemonFormDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")] 
    public string Url { get; set; }
}
