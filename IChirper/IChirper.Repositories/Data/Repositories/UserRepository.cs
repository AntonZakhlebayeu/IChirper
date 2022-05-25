using IChirper.Models;
using IChirper.Data.Interfaces;

namespace IChirper.Data.Repositories;

public class UserRepository : EntityBaseRepository<User>, IUserRepository
{
    public UserRepository(IChirperDbContext context) : base(context)
    {
    }
}