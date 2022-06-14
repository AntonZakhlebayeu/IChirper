using IChirper.Controllers.Data.Interfaces;
using IChirper.Controllers.Models;
using IChirper.Controllers.Services.Interfaces;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IChirper.Controllers.Services.Classes;

public class PageService : IPageService
{
    private readonly IPageRepository _pageRepository;

    public PageService(IPageRepository pageRepository)
    {
        _pageRepository = pageRepository;
    }

    private static PageViewModel GetPageViewModel(Page model)
    {
        return new PageViewModel { Id = model.Id, Title = model.Title, PageDescription = model.PageDescription, Tags = model.Tags, CreatedAt = model.CreatedAt, UpdatedAt = model.UpdatedAt, FileName = model.FileName, Author = model.Author};
    }
    
    private static List<PageViewModel> GetAllPages(IEnumerable<Page> models)
    {
        return models.Select(GetPageViewModel).ToList();
    }

    public async Task AddNewPage(CreatePageViewModel model)
    {
        var page = new Page
        {
            GuidId = new Guid(), Title = model.Title, CreatedAt = DateTime.Now.ToString(), UpdatedAt = DateTime.Now.ToString(),
            IsPrivate = model.IsPrivate.ToString(), PageDescription = model.PageDescription, Author = model.Author
        };

        await _pageRepository.AddAsync(page);
        await _pageRepository.CommitAsync();
    }

    public async Task<List<PageViewModel>> GetAllPages()
    {
        return await Task.Run(() => GetAllPages(_pageRepository.GetAll()).OrderByDescending(i => i.Id).ToList());
    }

    public async Task<PageViewModel> GetPageById(int id)
    {
        var page = await _pageRepository.FindWithAlternateKey(id);
        return GetPageViewModel(page);
    }
}