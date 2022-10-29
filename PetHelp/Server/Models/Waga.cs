using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;

public class Waga
{
    [Key]
    public int Id { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public float Wartosc { get; set; } = 0;

    [ForeignKey("Zwierze")] 
    public int ZwierrzeId { get; set; }
    public Zwierze? Zwierze { get; set; }
}
