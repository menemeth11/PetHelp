using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;
public class Zwierze
{
    [Key]
    public int Id { get; set; }
    public string Gatunek { get; set; } = "- nie podano -";
    public string Rasa { get; set; } = "- nie podano -";
    public string Umaszczenie { get; set; } = "- nie podano -";
    public DateTime? DataUrodzenia { get; set; } = null;
    public bool Kastracja { get; set; } = false;
    public List<Waga> HistoriaWagi { get; set; } = new();
    public List<Schorzenie> HistoriaSchorzen { get; set; } = new();
    public List<Szczepienie> HistoriaSzczepien { get; set; } = new();
    public List<Wizyta> HistoriaWizyt { get; set; } = new();

    [ForeignKey("Hodowla")]
    public int HodowlaId { get; set; }
    public Hodowla? Hodowla { get; set; }
}