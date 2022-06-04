namespace IChirper.Controllers.ViewModels;

public class PostViewModel
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? CreatedAt { get; init; }
    public string? UpdatedAt { get; init; }
    public string? FileName { get; init; }
    public string? TagsCollection { get; init; }
}