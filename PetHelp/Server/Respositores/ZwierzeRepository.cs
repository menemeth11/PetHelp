using Microsoft.EntityFrameworkCore;
using PetHelp.Server.Data;
using PetHelp.Server.Data.Migrations;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;
using System.Linq;

namespace PetHelp.Server.Respositores;

public class ZwierzeRepository : IZwierzeRepository
{
    private readonly ApplicationDbContext context;

    public ZwierzeRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public List<Zwierze> GetByHodowla(int hodowlaId, bool includeAttachment = true)
    {
        if(includeAttachment == false)
		{
            return context.Zwierzeta
                .AsNoTracking()
                .Where(x => x.HodowlaId == hodowlaId)
                .ToList();
		}

        return context.Zwierzeta
        .AsNoTracking()
        .Where(x => x.HodowlaId == hodowlaId)
        .Include(x=>x.Zdjecie)
        .ToList();
    }


    public Zwierze DodajZwierze(ZwierzeDTO nowe)
    {
        Zwierze zwierze = new Zwierze()
        {
            Id = nowe.Id,
            Imie = nowe.Imie,
            Gatunek = nowe.Gatunek,
            Rasa = nowe.Rasa,
            Umaszczenie = nowe.Umaszczenie,
            DataUrodzenia = nowe.DataUrodzenia,
            DataDodania = nowe.DataDodania,
            Kastracja = nowe.Kastracja,
            Waga_Pomiar = nowe.Waga_Pomiar,
            Waga_Wartosc = nowe.Waga_Wartosc,
            Info_Dodatkowe = nowe.Info_Dodatkowe,
            Info_Schorzenia = nowe.Info_Schorzenia,
            Info_Choroby = nowe.Info_Choroby,
            Szczepienie_Wscieklizna_Status = nowe.Szczepienie_Wscieklizna_Status,
            Szczepienie_Wscieklizna_Data = nowe.Szczepienie_Wscieklizna_Data,
            Szczepienie_Wscieklizna_NastepnyTermin = nowe.Szczepienie_Wscieklizna_NastepnyTermin,
            HodowlaId = (int)nowe.HodowlaId,
            WlascicielId = nowe.WlascicielId,
            Zdjecie_MIME = nowe.Zdjecie_MIME,
            Zdjecie_Name = nowe.Zdjecie_Name,
            Zdjecie_Data = nowe.Zdjecie_Data,

        };
        context.Zwierzeta.Add(zwierze);
        context.SaveChanges();
        return zwierze;
    }

}
