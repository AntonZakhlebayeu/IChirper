using IChirper.Controllers.Models;
using IChirper.Controllers.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IChirper.Controllers.Services.Interfaces;

public interface IPageService
{
    Task AddNewPage(CreatePageViewModel model);
    Task<List<PageViewModel>> GetAllPages();
    Task<PageViewModel> GetPageById(int id);
}