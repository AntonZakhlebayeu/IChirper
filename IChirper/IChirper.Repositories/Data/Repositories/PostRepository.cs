using IChirper.Controllers.Data.Interfaces;
using IChirper.Controllers.Models;

namespace IChirper.Controllers.Data.Repositories;

public class PostRepository : EntityBaseRepository<Post>, IPostRepository
{
    public PostRepository(IChirperDbContext context) : base(context)
    {
    }
}