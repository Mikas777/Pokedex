using Newtonsoft.Json;
using Pokedex.Domain.DTOs;
using Pokedex.Infrastructure.DAOs;

namespace Pokedex.WebAPI.Mappers;

public static class PokemonMapper
{
    public static PokemonDAO ToDAO(this PokemonDTO pokemonDTO)
    {
        return new PokemonDAO
        {
            Id = pokemonDTO.Id ?? default,
            JsonData = JsonConvert.SerializeObject(pokemonDTO)
        };
    }

    public static PokemonDTO ToDTO(this PokemonDAO pokemonDAO)
    {
        return JsonConvert.DeserializeObject<PokemonDTO>(pokemonDAO.JsonData);
    }
}

