using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IChirper.Data;

public class IChirperDbContext : IdentityDbContext
{
    private readonly IConfiguration _configuration;
    
    public IChirperDbContext(DbContextOptions<IChirperDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;

        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MSSqlConnectionString"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }
}