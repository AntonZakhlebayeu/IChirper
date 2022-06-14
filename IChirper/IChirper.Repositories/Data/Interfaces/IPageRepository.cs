using IChirper.Controllers.Models;

namespace IChirper.Controllers.Data.Interfaces;

public interface IPageRepository : IEntityBaseRepository<Page>
{
    Task<Page> FindWithAlternateKey(int id);
}