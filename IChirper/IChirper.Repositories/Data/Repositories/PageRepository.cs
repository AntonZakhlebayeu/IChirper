using IChirper.Controllers.Data.Interfaces;
using IChirper.Controllers.Models;

namespace IChirper.Controllers.Data.Repositories;

public class PageRepository : EntityBaseRepository<Page>, IPageRepository
{
    public PageRepository(IChirperDbContext context) : base(context)
    {
    }
}