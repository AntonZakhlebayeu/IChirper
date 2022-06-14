using System.ComponentModel.DataAnnotations;

namespace IChirper.Controllers.ViewModels;

public class CreatePageViewModel
{
    public int Id { get; set; }
    [Required]
    public string? PageDescription { get; set; }
    [Required]
    public string? Title { get; set; }
    public string? Tags { get; set; }
    [Required]
    public bool? IsPrivate { get; set; }
    public string? FileName { get; init; }
    [Required]
    public string? Author { get; set; }
}