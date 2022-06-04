using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IChirper.Controllers.Models;

public class Page
{
    [Key]
    public Guid GuidId { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? PageDescription { get; set; }
    public string? IsPrivate { get; set; }
    public string? CreatedAt { get; init; }
    public string? UpdatedAt { get; init; }
    public string? FileName { get; init; }
    public string? Tags { get; set; }
}