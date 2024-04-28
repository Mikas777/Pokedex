namespace Pokedex.Infrastructure.Repositories.Interfaces;

public interface IUnitOfWork
{
    IPokemonRepository PokemonRepository { get; }
    Task SaveChangesAsync();
}

