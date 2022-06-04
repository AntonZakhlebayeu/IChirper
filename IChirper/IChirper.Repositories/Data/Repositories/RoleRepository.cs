using IChirper.Controllers.Data.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IChirper.Controllers.Data.Repositories;

public class RoleRepository : EntityBaseRepository<IdentityRole>, IRoleRepository
{
    public RoleRepository(IChirperDbContext context) : base(context)
    {
    }
}