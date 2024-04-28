
namespace Pokedex.Domain.DTOs;

public class PokedexResponse<T>
{
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public List<T> Pokemons { get; set; }
}