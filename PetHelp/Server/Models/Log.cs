using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;

public class Log
{
    [Key]
    public int id { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public string Message { get; set; } = String.Empty;

    [ForeignKey("User")]
    public string? UserID { get; set; }
    public ApplicationUser? User { get; set; }
}
