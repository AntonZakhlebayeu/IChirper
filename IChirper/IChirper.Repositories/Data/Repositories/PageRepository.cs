using IChirper.Controllers.Data.Interfaces;
using IChirper.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace IChirper.Controllers.Data.Repositories;

public class PageRepository : EntityBaseRepository<Page>, IPageRepository
{
    private readonly IChirperDbContext _context;
    public PageRepository(IChirperDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Page> FindWithAlternateKey(int id)
    {
        return (await _context.Set<Page>().FirstOrDefaultAsync(p => p.Id == id))!;
    }
}