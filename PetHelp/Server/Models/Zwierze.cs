using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;
public class Zwierze
{
    [Key]
    public int Id { get; set; }
    public string Imie{ get; set; } = "- nie podano -";
    public string Gatunek { get; set; } = "- nie podano -";
    public string Rasa { get; set; } = "- nie podano -";
    public string Umaszczenie { get; set; } = "- nie podano -";
    public DateTime DataUrodzenia { get; set; } = DateTime.Now;
    public DateTime DataDodania { get; set; } = DateTime.Now;
	public bool Kastracja { get; set; } = false;
    public DateTime? Waga_Pomiar{ get; set; }
    public float? Waga_Wartosc { get; set; }
    public string Info_Dodatkowe{ get; set; } = String.Empty;
    public string Info_Schorzenia{ get; set; } = String.Empty;
    public string Info_Choroby { get; set; } = String.Empty;
    public bool Szczepienie_Wscieklizna_Status { get; set; } = false;
    public DateTime? Szczepienie_Wscieklizna_Data { get; set; }
    public DateTime? Szczepienie_Wscieklizna_NastepnyTermin { get; set; }
    
    public Zalacznik? Zdjecie { get; set; }

    [ForeignKey("Hodowla")]
    public int? HodowlaId { get; set; }
    public Hodowla? Hodowla { get; set; }

    [ForeignKey("Wlasciciel")]
    public string WlascicielId { get; set; }
    public ApplicationUser? Wlasciciel { get; set; }
}