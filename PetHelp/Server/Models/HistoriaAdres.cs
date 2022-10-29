using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;

public class HistoriaAdres
{
    [Key]
    public int Id { get; set; }
    public DateTime DataOd { get; set; } = DateTime.Now;
    public DateTime? DataDo { get; set; }

    [ForeignKey("Specialista")]
    public int SpecialistaId { get; set; }
    public Specialista? Specialista { get; set; }

    [ForeignKey("Adres")]
    public int AdresId { get; set; }
    public Adres? Adres { get; set; }
}
