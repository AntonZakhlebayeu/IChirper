using IChirper.Controllers.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IChirper.Controllers.Data;

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
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MSSqlConnectionString"), b => b.MigrationsAssembly("IChirper.Api"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureUser();
        modelBuilder.ConfigureIdentityRoles();
        modelBuilder.ConfigurePosts();

        base.OnModelCreating(modelBuilder);
    }
}