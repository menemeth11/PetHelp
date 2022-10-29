using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;

public class Schorzenie
{
    [Key]
    public int Id { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public string Nazwa { get; set; } = "- nie podano -";

    [ForeignKey("Zwierze")]
    public int ZwierrzeId { get; set; }
    public Zwierze? Zwierze { get; set; }
}
