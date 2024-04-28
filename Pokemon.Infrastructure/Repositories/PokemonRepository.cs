using Microsoft.EntityFrameworkCore;
using Pokedex.Infrastructure.DAOs;
using Pokedex.Infrastructure.Repositories.Interfaces;
using System;

namespace Pokedex.Infrastructure.Repositories;

public class PokemonRepository(PokedexDbContext context) : IPokemonRepository
{
    public async Task<PokemonDAO> Add(PokemonDAO pokemon)
    {
        await context.Pokemons.AddAsync(pokemon).ConfigureAwait(false);

        return pokemon;
    }

    public async Task AddRange(IEnumerable<PokemonDAO> pokemons)
    {
        await context.Pokemons.AddRangeAsync(pokemons).ConfigureAwait(false);
    }

    public async Task<PokemonDAO?> GetById(int id)
    {
        var pokemon = await context.Pokemons.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

        return pokemon;
    }

    public async Task<(List<PokemonDAO> Items, int TotalCount)> GetPokemonsFilterAndPaginated(string? name, string? type, int pageSize, int pageNumber)
    {
        var query = context.Pokemons.AsQueryable().AsNoTracking();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(p => EF.Functions.JsonContains(p.JsonData, $"{{\"Name\": \"{name}\"}}"));
        }

        if (!string.IsNullOrEmpty(type))
        {
            query = query.Where(p => EF.Functions.JsonContains(p.JsonData, $"{{\"Types\": [{{\"Type\": {{\"Name\": \"{type}\"}}}}]}}"));
        }

        var totalCount = await query.CountAsync().ConfigureAwait(false);

        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        var pokemonDaos = await query.ToListAsync().ConfigureAwait(false);

        return (pokemonDaos, totalCount);
    }

    public PokemonDAO Update(PokemonDAO pokemon)
    {
        context.Pokemons.Update(pokemon);

        return pokemon;
    }

    public void Remove(PokemonDAO pokemon)
    {
        context.Pokemons.Remove(pokemon);
    }
}
