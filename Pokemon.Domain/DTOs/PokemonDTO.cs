using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class PokemonDTO
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("base_experience")] 
    public int? BaseExperience { get; set; }
    
    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("is_default")] 
    public bool IsDefault { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("abilities")]
    public List<PokemonAbilityDTO> Abilities { get; set; }

    [JsonPropertyName("forms")]
    public List<PokemonFormDTO> Forms { get; set; }

    [JsonPropertyName("game_indices")] 
    public List<VersionGameIndexDTO> GameIndicies { get; set; }

    [JsonPropertyName("held_items")] 
    public List<PokemonHeldItemDTO> HeldItems { get; set; }

    [JsonPropertyName("location_area_encounters")]
    public string LocationAreaEncounters { get; set; }

    [JsonPropertyName("moves")]
    public List<PokemonMoveDTO> Moves { get; set; }

    [JsonPropertyName("past_types")] 
    public List<PokemonPastTypesDTO> PastTypes { get; set; }

    [JsonPropertyName("sprites")]
    public PokemonSpritesDTO Sprites { get; set; }

    [JsonPropertyName("species")]
    public PokemonSpeciesDTO Species { get; set; }

    [JsonPropertyName("stats")]
    public List<PokemonStatDTO> Stats { get; set; }

    [JsonPropertyName("types")]
    public List<PokemonTypeDTO> Types { get; set; }
}

