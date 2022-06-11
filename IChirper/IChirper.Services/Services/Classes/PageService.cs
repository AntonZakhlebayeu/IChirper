using IChirper.Controllers.Models;
using IChirper.Controllers.Services.Interfaces;
using IChirper.Controllers.ViewModels;

namespace IChirper.Controllers.Services.Classes;

public class PageService : IPageService
{
    public PageViewModel GetPageViewModel(Page model)
    {
        return new PageViewModel { Id = model.Id, Title = model.Title, PageDescription = model.PageDescription, Tags = model.Tags, CreatedAt = model.CreatedAt, UpdatedAt = model.UpdatedAt, FileName = model.FileName};
    }
    
    public void AddNewPage(PageViewModel model)
    {
        
    }
}