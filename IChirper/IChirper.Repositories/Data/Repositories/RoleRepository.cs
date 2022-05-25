using IChirper.Data.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IChirper.Data.Repositories;

public class RoleRepository : EntityBaseRepository<IdentityRole>, IRoleRepository
{
    public RoleRepository(IChirperDbContext context) : base(context)
    {
    }
}