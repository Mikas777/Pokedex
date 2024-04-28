using Microsoft.EntityFrameworkCore;
using Pokedex.Infrastructure;
using Pokedex.Infrastructure.Repositories;
using Pokedex.Infrastructure.Repositories.Interfaces;
using Pokedex.WebAPI.Clients;
using Pokedex.WebAPI.Clients.Interfaces;
using Pokedex.WebAPI.Services;
using Pokedex.WebAPI.Services.Interfaces;

namespace Pokedex.WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDatabaseContext(this IServiceCollection serviceCollection, string? connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Connection string is empty or null.", nameof(connectionString));
        }

        serviceCollection.AddDbContext<PokedexDbContext>(options =>
            options.UseNpgsql(connectionString));
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPokemonRepository, PokemonRepository>();

        // Services
        services.AddScoped<IPokemonService, PokemonService>();
        services.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();

        services.AddHttpClient();

        // Clients
        services.AddTransient<IPokeApiClient, PokeApiClient>();
    }
}

