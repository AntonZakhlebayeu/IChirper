namespace IChirper.Controllers.ViewModels;

public class CreatePageViewModel
{
    public int Id { get; set; }
    public string? PageDescription { get; set; }
    public string? Title { get; set; }
    public string? Tags { get; set; }
    public bool? IsPrivate { get; set; }
    public string? FileName { get; init; }
    public string? Author { get; set; }
}