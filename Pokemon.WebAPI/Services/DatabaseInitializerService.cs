using Pokedex.Infrastructure.Repositories.Interfaces;
using Pokedex.WebAPI.Clients.Interfaces;
using Pokedex.WebAPI.Mappers;
using Pokedex.WebAPI.Services.Interfaces;

namespace Pokedex.WebAPI.Services;

public class DatabaseInitializerService(IPokeApiClient pokeApiClient, IUnitOfWork unitOfWork) : IDatabaseInitializerService
{
    public async Task InitializeDatabase()
    {
        var pokemonDtos = await pokeApiClient.GetAllPokemons().ConfigureAwait(false);
        var pokemonDaos = pokemonDtos.Select(x => x.ToDAO());

        await unitOfWork.PokemonRepository.AddRange(pokemonDaos).ConfigureAwait(false);
        await unitOfWork.SaveChangesAsync().ConfigureAwait(false);
    }
}

