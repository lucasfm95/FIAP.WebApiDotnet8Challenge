using FIAP.WebApiDotnet8Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAP.WebApiDotnet8Challenge.Repositories.Repositories;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING_POSTGRES") ?? throw new Exception("Environment variable CONNECTION_STRING_POSTGRES not found");
    
    public DbSet<ProductEntity> Products { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}