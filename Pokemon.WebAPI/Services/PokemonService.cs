using Newtonsoft.Json;
using Pokedex.Domain.DTOs;
using Pokedex.Domain.Exceptions;
using Pokedex.Domain.Models;
using Pokedex.Infrastructure.DAOs;
using Pokedex.Infrastructure.Repositories.Interfaces;
using Pokedex.WebAPI.Mappers;
using Pokedex.WebAPI.Services.Interfaces;

namespace Pokedex.WebAPI.Services;

public class PokemonService(IUnitOfWork unitOfWork) : IPokemonService
{
    public async Task<PaginatedDataResponse<PokemonDTO>> GetFilteredPokemons(string? name, string? type, int pageSize, int pageNumber)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new ArgumentException("Page number and page size must be greater than zero.");
        }

        var lowerCaseName = name?.ToLowerInvariant();
        var lowerCaseType = type?.ToLowerInvariant();

        var pokemons = await unitOfWork.PokemonRepository.GetPokemonsFilterAndPaginated(lowerCaseName, lowerCaseType, pageSize, pageNumber).ConfigureAwait(false);
        var pokemonDtos = pokemons.Items.Select(x => x.ToDTO());
        var response = new PaginatedDataResponse<PokemonDTO>(pokemonDtos, pageNumber, pageSize, pokemons.TotalCount);

        return response;
    }


    public async Task<PokemonDTO> GetPokemonById(int id)
    {
        var pokemonDao = await unitOfWork.PokemonRepository.GetById(id).ConfigureAwait(false);

        if (pokemonDao is null)
        {
            throw new PokemonNotFoundException($"Pokemon with id {id} not found");
        }

        var pokemonDto = pokemonDao.ToDTO();

        return pokemonDto;
    }

    public async Task<PokemonDTO> CreatePokemon(PokemonDTO pokemon)
    {
        var createdPokemonIdDao = await unitOfWork.PokemonRepository.Add(new PokemonDAO()).ConfigureAwait(false);
        await unitOfWork.SaveChangesAsync().ConfigureAwait(false);

        pokemon.Id = createdPokemonIdDao.Id;
        createdPokemonIdDao.JsonData = JsonConvert.SerializeObject(pokemon);
        await unitOfWork.SaveChangesAsync().ConfigureAwait(false);

        return createdPokemonIdDao.ToDTO();
    }

    public async Task DeleteById(int id)
    {
        var pokemonDao = await unitOfWork.PokemonRepository.GetById(id).ConfigureAwait(false);

        if (pokemonDao is null)
        {
            throw new PokemonNotFoundException($"Pokemon with id {id} not found");
        }

        unitOfWork.PokemonRepository.Remove(pokemonDao);
        await unitOfWork.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task<PokemonDTO> UpdatePokemon(PokemonDTO pokemonDto)
    {
        if (!pokemonDto.Id.HasValue)
        {
            throw new ArgumentException("Pokemon id is required");
        }

        var pokemonDao = await unitOfWork.PokemonRepository.GetById(pokemonDto.Id.Value).ConfigureAwait(false);

        if (pokemonDao is null)
        {
            throw new PokemonNotFoundException($"Pokemon with id {pokemonDto.Id.Value} not found");
        }

        if (pokemonDao.JsonData is null)
        {
            throw new ArgumentException("Pokemon data is required");
        }

        var updatedPokemon = unitOfWork.PokemonRepository.Update(pokemonDto.ToDAO());
        await unitOfWork.SaveChangesAsync().ConfigureAwait(false);

        return updatedPokemon.ToDTO();
    }
}
