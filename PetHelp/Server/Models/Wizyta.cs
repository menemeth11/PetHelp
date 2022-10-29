using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;

public class Wizyta
{
    [Key]
    public int Id { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public string Cel { get; set; } = "- nie podano -";
    public DateTime? NastepnyTermin { get; set; } = null;

    [ForeignKey("Specialista")]
    public int SpecialistaId { get; set; }
    public Specialista? Specialista { get; set; }

    [ForeignKey("Zwierze")]
    public int ZwierrzeId { get; set; }
    public Zwierze? Zwierze { get; set; }
}
