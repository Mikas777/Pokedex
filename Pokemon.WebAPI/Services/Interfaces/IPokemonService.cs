using Pokedex.Domain.DTOs;
using Pokedex.Domain.Models;

namespace Pokedex.WebAPI.Services.Interfaces;

public interface IPokemonService
{
    Task<PokemonDTO> GetPokemonById(int id);
    Task<PokemonDTO> CreatePokemon(PokemonDTO pokemon);
    Task DeleteById(int id);
    Task<PokemonDTO> UpdatePokemon(PokemonDTO pokemonDto);
    Task<PaginatedDataResponse<PokemonDTO>> GetFilteredPokemons(
        string? name,
        string? type,
        int pageSize,
        int pageNumber);
}
