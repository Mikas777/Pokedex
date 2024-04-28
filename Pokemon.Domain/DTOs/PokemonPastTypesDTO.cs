namespace Pokedex.Domain.DTOs;

public class PokemonPastTypesDTO
{
    public GenerationDTO Generation { get; set; }
    public List<PokemonTypeDTO> Types { get; set; }
}
