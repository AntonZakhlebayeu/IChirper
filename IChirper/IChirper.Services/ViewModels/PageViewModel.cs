namespace IChirper.Controllers.ViewModels;

public class PageViewModel
{
    public int Id { get; set; }
    public string? PageDescription { get; set; }
    public bool? IsPrivate { get; set; }
    public string? Title { get; set; }
    public string? Tags { get; set; }
    public string? CreatedAt { get; init; }
    public string? UpdatedAt { get; init; }
    public string? FileName { get; init; }
}