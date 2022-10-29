using System.ComponentModel.DataAnnotations;

namespace PetHelp.Server.Models;

public class Specialista
{
    [Key]
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string NIP { get; set; }
    public string Email { get; set; }
    public int NrTelefonu { get; set; }
    public List<HistoriaAdres> Adresy { get; set; } = new();
}
