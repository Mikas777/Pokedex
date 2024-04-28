using Pokedex.Domain.DTOs;

namespace Pokedex.WebAPI.Clients.Interfaces;

public interface IPokeApiClient
{
    Task<List<PokemonDTO>> GetAllPokemons();
}

