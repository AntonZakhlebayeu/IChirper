using IChirper.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IChirper.Data;

public class IChirperDbContext : IdentityDbContext<User>
{
    private readonly IConfiguration _configuration;

    public IChirperDbContext(DbContextOptions<IChirperDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MSSqlConnectionString"), b => b.MigrationsAssembly("IChirper.Repositories"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureIdentityRoles();

        base.OnModelCreating(modelBuilder);
    }
}