using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class PokemonAbilityDTO
{
    [JsonPropertyName("is_hidden")]
    public bool IsHidden { get; set; }

    [JsonPropertyName("slot")]
    public int Slot { get; set; }

    [JsonPropertyName("ability")]
    public AbilityDTO Ability { get; set; }
}

