using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IChirper.Controllers.Models;

public class Page
{
    [Key]
    public Guid GuidId { get; init; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Title { get; init; }
    public string? PageDescription { get; init; }
    public string? IsPrivate { get; init; }
    public string? CreatedAt { get; init; }
    public string? UpdatedAt { get; init; }
    public string? FileName { get; init; }
    public string? Tags { get; set; }
    public string? Author { get; set; }
}