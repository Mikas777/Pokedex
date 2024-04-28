namespace Pokedex.Domain.Models;

public class PaginatedDataResponse<T>(IEnumerable<T> items, int pageNumber, int pageSize, int totalItems)
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int TotalItems { get; set; } = totalItems;
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    public IEnumerable<T> Items { get; set; } = items;
}

