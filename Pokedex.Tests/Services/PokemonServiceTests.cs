using Moq;
using Newtonsoft.Json;
using Pokedex.Domain.DTOs;
using Pokedex.Domain.Exceptions;
using Pokedex.Infrastructure.DAOs;
using Pokedex.Infrastructure.Repositories.Interfaces;
using Pokedex.WebAPI.Services;
using Shouldly;

namespace Pokedex.Tests.Services;

public class PokemonServiceTests
{
    private readonly Mock<IUnitOfWork> unitOfWorkMock;
    private readonly PokemonService pokemonService;

    public PokemonServiceTests()
    {
        unitOfWorkMock = new Mock<IUnitOfWork>();
        pokemonService = new PokemonService(unitOfWorkMock.Object);
    }
    // use shouldly for assertions
    [Fact]
    public async Task GetPokemonById_PokemonExists_ReturnsPokemon()
    {
        // Arrange
        var pokemonId = 1;
        var pokemonDao = GetTestPokemons().First(x => x.Id == pokemonId);
        unitOfWorkMock.Setup(x => x.PokemonRepository.GetById(pokemonId)).ReturnsAsync(pokemonDao);

        // Act
        var result = await pokemonService.GetPokemonById(pokemonId);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(pokemonId);
    }

    [Fact]
    public async Task GetPokemonById_WithNonExistingPokemon_ThrowsPokemonNotFoundException()
    {
        // Arrange
        var pokemonId = 4;
        unitOfWorkMock.Setup(x => x.PokemonRepository.GetById(pokemonId)).ReturnsAsync((PokemonDAO)null);

        // Act
        var exception = await Record.ExceptionAsync(() => pokemonService.GetPokemonById(pokemonId));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PokemonNotFoundException>();
        exception.Message.ShouldBe($"Pokemon with id {pokemonId} not found");
    }

    [Fact]
    public async Task CreatePokemon_WithValidPokemon_ReturnsCreatedPokemon()
    {
        // Arrange
        var pokemon = new PokemonDTO { Name = "Bulbasaur" };
        var createdPokemonId = 4;
        unitOfWorkMock.Setup(x => x.PokemonRepository.Add(It.IsAny<PokemonDAO>())).ReturnsAsync(new PokemonDAO { Id = createdPokemonId });

        // Act
        var result = await pokemonService.CreatePokemon(pokemon);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(createdPokemonId);
        result.Name.ShouldBe(pokemon.Name);
    }

    [Fact]
    public async Task DeleteById_WithExistingPokemon_DeletesPokemon()
    {
        // Arrange
        var pokemonId = 1;
        var pokemonDao = GetTestPokemons().First(x => x.Id == pokemonId);
        unitOfWorkMock.Setup(x => x.PokemonRepository.GetById(pokemonId)).ReturnsAsync(pokemonDao);

        // Act
        await pokemonService.DeleteById(pokemonId);

        // Assert
        unitOfWorkMock.Verify(x => x.PokemonRepository.Remove(pokemonDao), Times.Once);
        unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteById_WithNonExistingPokemon_ThrowsPokemonNotFoundException()
    {
        // Arrange
        var pokemonId = 4;
        unitOfWorkMock.Setup(x => x.PokemonRepository.GetById(pokemonId)).ReturnsAsync((PokemonDAO)null);

        // Act
        var exception = await Record.ExceptionAsync(() => pokemonService.DeleteById(pokemonId));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PokemonNotFoundException>();
        exception.Message.ShouldBe($"Pokemon with id {pokemonId} not found");
    }

    [Fact]
    public async Task UpdatePokemon_WithValidPokemon_ReturnsUpdatedPokemon()
    {
        // Arrange
        var pokemonId = 1;
        var pokemon = new PokemonDTO { Id = pokemonId, Name = "Pikachu" };
        var pokemonDao = GetTestPokemons().FirstOrDefault(x => x.Id == pokemonId);
        unitOfWorkMock.Setup(x => x.PokemonRepository.GetById(pokemonId)).ReturnsAsync(pokemonDao);
        unitOfWorkMock.Setup(x => x.PokemonRepository.Update(It.IsAny<PokemonDAO>())).Returns(pokemonDao);


        // Act
        var result = await pokemonService.UpdatePokemon(pokemon);

        // Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(pokemonId);
        result.Name.ShouldBe(pokemon.Name);
        unitOfWorkMock.Verify(x => x.PokemonRepository.GetById(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task UpdatePokemon_WithNonExistingPokemon_ThrowsPokemonNotFoundException()
    {
        // Arrange
        var pokemonId = 4;
        var pokemon = new PokemonDTO { Id = pokemonId, Name = "Bulbasaur" };
        unitOfWorkMock.Setup(x => x.PokemonRepository.GetById(pokemonId)).ReturnsAsync((PokemonDAO)null);

        // Act
        var exception = await Record.ExceptionAsync(() => pokemonService.UpdatePokemon(pokemon));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PokemonNotFoundException>();
        exception.Message.ShouldBe($"Pokemon with id {pokemonId} not found");
    }

    [Fact]
    public async Task UpdatePokemon_WithMissingId_ThrowsArgumentException()
    {
        // Arrange
        var pokemon = new PokemonDTO { Name = "Bulbasaur" };

        // Act
        var exception = await Record.ExceptionAsync(() => pokemonService.UpdatePokemon(pokemon));

        // Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ArgumentException>();
        exception.Message.ShouldBe("Pokemon id is required");
    }

    private static IEnumerable<PokemonDAO> GetTestPokemons()
    {
        var pikachu = new PokemonDAO
        {
            Id = 1,
            JsonData = JsonConvert.SerializeObject(new PokemonDTO
            {
                Id = 1,
                Name = "Pikachu",
                Types = new List<PokemonTypeDTO>
                {
                    new() { Slot = 1, Type = new TypeDTO { Name = "Electric", InformationType = "https://pokeapi.co/api/v2/type/13/" } },
                    new() { Slot = 2, Type = new TypeDTO { Name = "Flying", InformationType = "https://pokeapi.co/api/v2/type/3/" } }
                }
            })
        };

        var charmander = new PokemonDAO
        {
            Id = 2,
            JsonData = JsonConvert.SerializeObject(new PokemonDTO
            {
                Id = 2,
                Name = "Charmander",
                Types = new List<PokemonTypeDTO>
                {
                    new() { Slot = 1, Type = new TypeDTO { Name = "Fire", InformationType = "https://pokeapi.co/api/v2/type/10/" } },
                    new() { Slot = 2, Type = new TypeDTO { Name = "Flying", InformationType = "https://pokeapi.co/api/v2/type/3/" } }
                }
            })
        };

        var squirtle = new PokemonDAO
        {
            Id = 3,
            JsonData = JsonConvert.SerializeObject(new PokemonDTO
            {
                Id = 3,
                Name = "Squirtle",
                Types = new List<PokemonTypeDTO>
                {
                    new() { Slot = 1, Type = new TypeDTO { Name = "Water", InformationType = "https://pokeapi.co/api/v2/type/11/" } }
                }
            })
        };

        return new List<PokemonDAO> { pikachu, charmander, squirtle };
    }
}
