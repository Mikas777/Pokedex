using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Infrastructure.DAOs;

public class PokemonDAO
{
    public int Id { get; set; }

    [Column(TypeName = "jsonb")]
    public string JsonData { get; set; }
}

