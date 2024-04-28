using Pokedex.WebAPI.Clients.Interfaces;
using System.Text.Json;
using Pokedex.Domain.DTOs;
using Pokedex.WebAPI.Extensions;

namespace Pokedex.WebAPI.Clients;

public class PokeApiClient(HttpClient httpClient) : IPokeApiClient
{
    public async Task<List<PokemonDTO>> GetAllPokemons()
    {
        var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0").ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to fetch data from API");
        }

        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var getPokemonsResponse = JsonSerializer.Deserialize<GetPokemonsResponse>(content);
        var pokemonUrls = getPokemonsResponse!.Results.Select(pokemonItem => pokemonItem.InformationUrl).ToList();
        var pokemons = await GetPokemons(pokemonUrls).ConfigureAwait(false);

        return pokemons;
    }

    private async Task<List<PokemonDTO>> GetPokemons(List<string> urls)
    {
        var tasks = urls.Select(GetPokemon).ToList();
        var pokemons = await tasks.RunTasksInParallel(4).ConfigureAwait(false);

        return pokemons.ToList();
    }

    private async Task<PokemonDTO> GetPokemon(string url)
    {
        var response = await httpClient.GetAsync(url).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to fetch pokemon data from URL: {url}");
        }

        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var pokemon = JsonSerializer.Deserialize<PokemonDTO>(content);

        return pokemon;
    }
}