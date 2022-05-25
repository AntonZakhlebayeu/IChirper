using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IChirper.Data;

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
}