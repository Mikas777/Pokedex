using Microsoft.AspNetCore.Mvc;
using Pokedex.Domain.DTOs;
using Pokedex.Domain.Models;
using Pokedex.WebAPI.Services.Interfaces;

namespace Pokedex.WebAPI.Controllers;

[Route("api/pokemon")]
[ApiController]
public class PokedexController(IPokemonService pokemonService) : Controller
{
    [HttpGet]
    public async Task<ActionResult<PaginatedDataResponse<PokemonDTO>>> GetPokemons([FromQuery] string? name, [FromQuery] string? type, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
    {
        var pokemons = await pokemonService.GetFilteredPokemons(name, type, pageSize, pageNumber).ConfigureAwait(false);

        return Ok(pokemons);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PokemonDTO>> GetPokemonById([FromRoute] int id)
    {
        var pokemon = await pokemonService.GetPokemonById(id).ConfigureAwait(false);

        return Ok(pokemon);
    }

    [HttpPost]
    public async Task<ActionResult<PokemonDTO>> CreatePokemon([FromBody] PokemonDTO pokemon)
    {
        var responsePokemon = await pokemonService.CreatePokemon(pokemon).ConfigureAwait(false);

        return Ok(responsePokemon);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteById([FromRoute] int id)
    {
        await pokemonService.DeleteById(id).ConfigureAwait(false);

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult<PokemonDTO>> UpdatePokemon([FromBody] PokemonDTO pokemon)
    {
        var responsePokemon = await pokemonService.UpdatePokemon(pokemon).ConfigureAwait(false);

        return Ok(responsePokemon);
    }
}

