namespace IChirper.Controllers.ViewModels;

public class PageViewModel
{
    public int Id { get; set; }
    public string? PageDescription { get; set; }
    public string? Title { get; set; }
    public string? Tags { get; set; }
    public string? CreatedAt { get; init; }
    public string? UpdatedAt { get; init; }
    public string? FileName { get; init; }
    public string? Author { get; set; }
    
    public override bool Equals(object? obj)
    {
        var pageViewModel = obj as PageViewModel;

        return (Id == pageViewModel!.Id &&
                PageDescription == pageViewModel.PageDescription &&
                Title == pageViewModel.Title &&
                Tags == pageViewModel.Tags &&
                UpdatedAt == pageViewModel.UpdatedAt &&
                CreatedAt == pageViewModel.CreatedAt &&
                FileName == pageViewModel.FileName &&
                Author == pageViewModel.Author
            );
    }
}