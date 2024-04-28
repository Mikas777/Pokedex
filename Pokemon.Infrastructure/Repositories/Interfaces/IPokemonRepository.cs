using Pokedex.Infrastructure.DAOs;

namespace Pokedex.Infrastructure.Repositories.Interfaces;

public interface IPokemonRepository
{
    Task<PokemonDAO> Add(PokemonDAO pokemon);
    Task<PokemonDAO?> GetById(int id);
    Task AddRange(IEnumerable<PokemonDAO> pokemons);
    void Remove(PokemonDAO pokemon);
    PokemonDAO Update(PokemonDAO pokemon);
    Task<(List<PokemonDAO> Items, int TotalCount)> GetPokemonsFilterAndPaginated(
        string? name,
        string? type,
        int pageSize,
        int pageNumber);
}

