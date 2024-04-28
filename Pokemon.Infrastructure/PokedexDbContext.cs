using Microsoft.EntityFrameworkCore;
using Pokedex.Infrastructure.DAOs;
using Pokedex.Infrastructure.Repositories;

namespace Pokedex.Infrastructure;

public class PokedexDbContext : DbContext
{
    public virtual DbSet<PokemonDAO> Pokemons { get; set; }

    public PokedexDbContext(DbContextOptions<PokedexDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Pokemons
        modelBuilder.Entity<PokemonDAO>(entity =>
        {
            entity.ToTable("Pokemons").HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .HasIdentityOptions(startValue: 20000);
        });
    }
}
