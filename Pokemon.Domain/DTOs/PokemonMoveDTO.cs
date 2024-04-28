using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class PokemonMoveDTO
{
    [JsonPropertyName("move")]
    public MoveDTO Move { get; set; }

    [JsonPropertyName("version_group_details")]
    public List<PokemonMoveVersionDTO> VersionGroupDetails { get; set; }
}

