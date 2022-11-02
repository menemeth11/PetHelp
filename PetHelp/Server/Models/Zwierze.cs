using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;
public class Zwierze
{
    [Key]
    public int Id { get; set; }
    public string Imie { get; set; } = "- nie podano -";
    public string Gatunek { get; set; } = "- nie podano -";
    public string Rasa { get; set; } = "- nie podano -";
    public string Umaszczenie { get; set; } = "- nie podano -";
    public DateTime DataUrodzenia { get; set; }
    public DateTime DataDodania { get; set; }
    public bool Kastracja { get; set; } = false;
    public DateTime? Waga_Pomiar { get; set; }
    public float? Waga_Wartosc { get; set; }
    public string Info_Dodatkowe { get; set; } = String.Empty;
    public string Info_Schorzenia { get; set; } = String.Empty;
    public string Info_Choroby { get; set; } = String.Empty;
    public bool Szczepienie_Wscieklizna_Status { get; set; } = false;
    public DateTime? Szczepienie_Wscieklizna_Data { get; set; }
    public DateTime? Szczepienie_Wscieklizna_NastepnyTermin { get; set; }


    public Zalacznik? Zdjecie { get; set; } // TODO: zrobic liste
    //public List<Zalacznik> Zalaczniki { get; set; } = new();


    [ForeignKey("Hodowla")]
    public int? HodowlaId { get; set; }
    public Hodowla? Hodowla { get; set; }

    [ForeignKey("Wlasciciel")]
    public string WlascicielId { get; set; }
    public ApplicationUser? Wlasciciel { get; set; }
    public string Zdjecie_MIME { get; internal set; }
    public string Zdjecie_Name { get; internal set; }
    public byte[] Zdjecie_Data { get; internal set; }
}