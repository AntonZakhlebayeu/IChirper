using IChirper.Controllers.ViewModels;

namespace IChirper.Controllers.Services.Interfaces;

public interface IPageService
{
    Task AddNewPage(CreatePageViewModel model);
    Task<List<PageViewModel>> GetAllPages();
}