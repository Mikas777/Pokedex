using System.Text.Json.Serialization;

namespace Pokedex.Domain.DTOs;

public class ItemDTO
{
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string InformationItem { get; set; }
}

