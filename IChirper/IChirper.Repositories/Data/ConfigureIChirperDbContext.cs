using IChirper.Controllers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IChirper.Controllers.Data;

public static class ConfigureIChirperDbContext
{
    public static void ConfigureIdentityRoles(this ModelBuilder modelBuilder)
    {
        var adminRole = new IdentityRole("admin")
        {
            NormalizedName = "admin".ToUpper()
        };
        var userRole = new IdentityRole("user")
        {
            NormalizedName = "user".ToUpper()
        };
        var moderator = new IdentityRole("moderator")
        {
            NormalizedName = "moderator".ToUpper()
        };

        modelBuilder.Entity<IdentityRole>(r =>
        {
            r.HasData(moderator, adminRole, userRole);
        });
    }

    public static void ConfigureUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasAlternateKey(u => u.IntId);
    }

    public static void ConfigurePage(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Page>(m =>
        {
            m.ToTable("Page");
            m.HasKey(p => p.GuidId);
            m.HasAlternateKey(p => p.Id);
            m.Property(p => p.Title).IsRequired();
            m.Property(p => p.PageDescription).IsRequired();
            m.Property(p => p.CreatedAt).IsRequired();
            m.Property(p => p.IsPrivate).IsRequired();
            m.Property(p => p.UpdatedAt);
            m.Property(p => p.Tags);
            m.Property(p => p.FileName);
        });
    }

    public static void ConfigurePosts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(m =>
        {
            m.ToTable("Post");
            m.HasKey(p => p.GuidId);
            m.HasAlternateKey(p => p.Id);
            m.Property(p => p.Title).IsRequired();
            m.Property(p => p.Description).IsRequired();
            m.Property(p => p.CreatedAt).IsRequired();
            m.Property(p => p.UpdatedAt);
            m.Property(p => p.TagsCollection);
            m.Property(p => p.FileName);
        });
    }
}