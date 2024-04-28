using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class PokemonMoveVersionDTO
{
    [JsonPropertyName("move_learn_method")]
    public MoveLearnMethodDTO MoveLearnMethod { get; set; }

    [JsonPropertyName("version_group")] 
    public VersionGroupDTO VersionGroup { get; set; }

    [JsonPropertyName("level_learned_at")] 
    public int LevelLearnedAt { get; set; }
}
