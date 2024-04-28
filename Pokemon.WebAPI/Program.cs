using Microsoft.EntityFrameworkCore;
using Pokedex.Infrastructure;
using Pokedex.WebAPI.Extensions;
using Pokedex.WebAPI.Middleware;
using Pokedex.WebAPI.Services.Interfaces;

namespace Pokedex.WebAPI;

public static class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dependency injection configuration
            builder.Services.AddDatabaseContext(builder.Configuration.GetConnectionString("DefaultConnection"));
            builder.Services.RegisterServices();

            // Configure Cross-Origin Resource Sharing (CORS)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("mainPolicy", policyBuilder =>
                {
                    policyBuilder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Add MVC controllers
            builder.Services.AddControllers();

            // Configure UI interface for API testing
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            
            using (var services = app.Services.CreateScope())
            {
                var context = services.ServiceProvider.GetRequiredService<PokedexDbContext>();
                await context.Database.EnsureDeletedAsync().ConfigureAwait(false);
                await context.Database.MigrateAsync().ConfigureAwait(false);

                var databaseInitializerService = services.ServiceProvider.GetRequiredService<IDatabaseInitializerService>();

                Console.WriteLine("Loading data...");
                await databaseInitializerService.InitializeDatabase().ConfigureAwait(false);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Enable CORS using the configured policy
            app.UseCors("mainPolicy");

            app.MapControllers();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            await app.RunAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // Log and handle any exceptions that occur during application startup
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}

