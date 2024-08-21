using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PawsKindness.Domain.Models.PetControl;
using PawsKindness.Domain.Models.SpeciesControl;

namespace PawsKindness.Infrastructure;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    private const string DATABASE = "PawsKindnessDb";

    public DbSet<Volunteer> Volunteers { get; set; }

    public DbSet<Species> Species { get; set; }

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString(DATABASE));

        optionsBuilder.UseSnakeCaseNamingConvention();

        optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
    }

    private ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => { builder.AddConsole(); });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}