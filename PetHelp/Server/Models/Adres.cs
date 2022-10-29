using System.ComponentModel.DataAnnotations;

namespace PetHelp.Server.Models;

public class Adres
{
    [Key]
    public int Id { get; set; }
    public string? Kraj { get; set; }
    public string? Powiat { get; set; }
    public string? Wojewodztwo { get; set; }
    public string? Miejscowosc { get; set; }
    public string? Poczta { get; set; }
    public string? KodPocztowy { get; set; }
    public string? Ulica { get; set; }
    public string? NrBudynku { get; set; }
    public string? NrLokalu { get; set; }
}
