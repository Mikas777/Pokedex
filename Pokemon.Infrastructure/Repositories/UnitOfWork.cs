using Pokedex.Infrastructure.Repositories.Interfaces;

namespace Pokedex.Infrastructure.Repositories;

public class UnitOfWork(PokedexDbContext context, IPokemonRepository pokemonRepository) : IUnitOfWork, IDisposable
{
    public IPokemonRepository PokemonRepository { get; } = pokemonRepository;

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async void Dispose()
    {
        await Dispose(true).ConfigureAwait(false);
        GC.SuppressFinalize(this);
    }

    protected virtual async Task Dispose(bool disposing)
    {
        if (disposing)
        {
            await context.DisposeAsync().ConfigureAwait(false);
        }
    }
}

