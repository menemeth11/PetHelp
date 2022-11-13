using Microsoft.AspNetCore.Mvc;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;



namespace PetHelp.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IHodowlaRepositor _hodowlaRepo;
    private readonly IZwierzeRepository _zwierzeRepo;

    public HomeController(IHodowlaRepositor hodowlaRepo, IZwierzeRepository zwierzeRepo)
    {
        _hodowlaRepo = hodowlaRepo;
        _zwierzeRepo = zwierzeRepo;
    }

    [HttpGet("GetUserHodowla/{ID}")]
    public List<HodowlaDTO> GetUserHodowla(string ID)
    {
        var x = _hodowlaRepo.GetListaHodowli(ID);
        return x.Select(Hodowla => new HodowlaDTO()
        {
            Id = Hodowla.id,
            Nazwa = Hodowla.Nazwa
        })
        .ToList();
    }

    [HttpPost("Dodajhodowle")]
    public HodowlaDTO Dodajhodowle(HodowlaRequestDTO x)
    {
        Hodowla hodowla = _hodowlaRepo.PostListaHodowli(x);
        return new HodowlaDTO()
        {
            Id = hodowla.id,
            Nazwa = hodowla.Nazwa
        };
    }

    /// <summary>
    /// Zapytanie HttpGET zwracajacy tylko liste zwierzac z ogolnymi infomacjami [ bez właściwośći tj. obrazek, waga info horoby itp ]
    /// </summary>
    /// <param name="hodowlaId">klucz glowny 'Id' wybranego rekordu tabeli Hodowla</param>
    /// <returns>Lista zwierząt przypisanych do hodowli</returns>
    [HttpGet("GetZwierzetaByHodowla/{hodowlaId}")]
    public List<ZwierzeDTO> SimplifiedListByHodowla(int hodowlaId)
    {
        List<Zwierze> zwierzeta = _zwierzeRepo.GetByHodowla(hodowlaId, includeAttachment: false);
        return zwierzeta.Select(z =>
            new ZwierzeDTO()
            {
                HodowlaId = (int)z.HodowlaId,
                Id = z.Id,
                Gatunek = z.Gatunek,
                Imie = z.Imie,
                DataUrodzenia = z.DataUrodzenia,
                DataDodania = z.DataDodania
            }
        ).ToList();
    }


    [HttpGet("GetZwierzakDetails/{zwierzakId}")]
    public ZwierzeDTO GetZwierzakDetails(int zwierzakId)
    {
        Zwierze? zwierz = _zwierzeRepo.GetById(zwierzakId);
        if (zwierz is null) return new();

        return new ZwierzeDTO()
        {
            Id = zwierz.Id,
            Imie = zwierz.Imie,
            Gatunek = zwierz.Gatunek,
            Umaszczenie = zwierz.Umaszczenie,
            DataUrodzenia = zwierz.DataUrodzenia,
            DataDodania = zwierz.DataDodania,
            Kastracja = zwierz.Kastracja,
            Waga_Pomiar = zwierz.Waga_Pomiar,
            Waga_Wartosc = zwierz.Waga_Wartosc,
            Info_Dodatkowe = zwierz.Info_Dodatkowe,
            Info_Schorzenia = zwierz.Info_Schorzenia,
            Info_Choroby = zwierz.Info_Choroby,
            Szczepienie_Wscieklizna_Status = zwierz.Szczepienie_Wscieklizna_Status,
            Szczepienie_Wscieklizna_Data = zwierz.Szczepienie_Wscieklizna_Data,
            Szczepienie_Wscieklizna_NastepnyTermin = zwierz.Szczepienie_Wscieklizna_NastepnyTermin,
            HodowlaId = (int)zwierz.HodowlaId,
            WlascicielId = zwierz.WlascicielId,
            rasaId = zwierz.Id,
            rasaNazwa = zwierz.rasa.Nazwa,
            Zdjecie_MIME = zwierz.Zdjecie_MIME,
            Zdjecie_Name = zwierz.Zdjecie_Name,
            Zdjecie_Data = zwierz.Zdjecie_Data,
        };
    }

    [HttpPost("DodajZwierze")]
    public ZwierzeDTO DodajZwierze(ZwierzeDTO x)
    {
        Zwierze zwierze = _zwierzeRepo.DodajZwierze(x);
        return new ZwierzeDTO()
        {
            Id = zwierze.Id ,
            Imie= zwierze.Imie,
            Gatunek= zwierze.Gatunek,
            Umaszczenie = zwierze.Umaszczenie,
            DataUrodzenia = zwierze.DataUrodzenia,
            DataDodania = zwierze.DataDodania,
            Kastracja = zwierze.Kastracja,
            Waga_Pomiar = zwierze.Waga_Pomiar,
            Waga_Wartosc = zwierze.Waga_Wartosc,
            Info_Dodatkowe= zwierze.Info_Dodatkowe,
            Info_Schorzenia= zwierze.Info_Schorzenia,
            Info_Choroby = zwierze.Info_Choroby,
            Szczepienie_Wscieklizna_Status = zwierze.Szczepienie_Wscieklizna_Status,
            Szczepienie_Wscieklizna_Data = zwierze.Szczepienie_Wscieklizna_Data,
            Szczepienie_Wscieklizna_NastepnyTermin = zwierze.Szczepienie_Wscieklizna_NastepnyTermin,
            HodowlaId = (int)zwierze.HodowlaId,
            WlascicielId = zwierze.WlascicielId,
            Zdjecie_MIME = zwierze.Zdjecie_MIME,
            Zdjecie_Name = zwierze.Zdjecie_Name,
            Zdjecie_Data = zwierze.Zdjecie_Data,
            rasaId = (int)zwierze.rasy_psowId,

        };
    }

    [HttpPost("AktualizujZwierze")]
    public void AktualizujZwierze(ZwierzeDTO x)
    {
        _zwierzeRepo.AktualizujZwierze(x);
    }

    [HttpDelete("Usun/{idzwierzaka}")]
    public void UsunZwierze(int idzwierzaka)
    {
        _zwierzeRepo.Usun(idzwierzaka);
    }

    [HttpDelete("UsunHodowle/{idhodowli}")]
    public void UsunHodowle(int idhodowli)
    {
        _hodowlaRepo.Usun(idhodowli);
    }
}

