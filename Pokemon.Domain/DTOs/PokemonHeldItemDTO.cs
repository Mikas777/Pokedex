using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class PokemonHeldItemDTO
{
    public ItemDTO Item { get; set; }

    [JsonPropertyName("version_details")]
    public List<PokemonHeldItemVersionDTO> VersionDetails { get; set; }
}