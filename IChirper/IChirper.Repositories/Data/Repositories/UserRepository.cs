using IChirper.Controllers.Data.Interfaces;
using IChirper.Controllers.Models;

namespace IChirper.Controllers.Data.Repositories;

public class UserRepository : EntityBaseRepository<User>, IUserRepository
{
    public UserRepository(IChirperDbContext context) : base(context)
    {
    }
}