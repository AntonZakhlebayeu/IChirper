using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IChirper.Models;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? CreatedAt { get; init; }
    public string? UpdatedAt { get; init; }
    public string? FileName { get; init; }
    public string? TagsCollection { get; init; }
    // public List<Like> Likes { get; init; }
}