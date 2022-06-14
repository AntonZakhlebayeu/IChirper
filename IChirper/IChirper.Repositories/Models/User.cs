using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace IChirper.Controllers.Models;

public sealed class User : IdentityUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IntId { get; set; }
    public string? FirstName { get; init; }
    public string? LastName { get; set; }
    public string? NickName { get; set; }
    public int Age { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime LastLoginDate { get; set; }
    public string? Status { get; set; }
}