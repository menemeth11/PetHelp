﻿using Microsoft.EntityFrameworkCore;
using PetHelp.Server.Data;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;
// ctrl R,G

namespace PetHelp.Server.Respositores;

public class ZwierzeRepository : IZwierzeRepository
{
    private readonly ApplicationDbContext context;
    private readonly ILoggerRepository _loggerRepo;
    private readonly ISzczepieniaRepository _szczepienieRepo;


    public ZwierzeRepository(ApplicationDbContext context, ILoggerRepository loggerRepo, ISzczepieniaRepository szczepienieRepo)
    {
        this.context = context;
        _loggerRepo = loggerRepo;
        _szczepienieRepo = szczepienieRepo;
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
        List<SzczepienieRecord> listaOdbytychSzczepien = _szczepienieRepo.UzupelnijOdbyteSzczepienia(nowe.DataUrodzenia);

        Zwierze zwierze = new Zwierze()
        {
            Id = nowe.Id,
            Imie = nowe.Imie,
            Gatunek = nowe.Gatunek,
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
            rasy_psowId = nowe.rasaId,
            ListaSzczepien = listaOdbytychSzczepien
        };
        context.Zwierzeta.Add(zwierze);
        context.SaveChanges();
        return zwierze;
    }

    public Zwierze? GetById(int zwierzakId)
    {
        return context.Zwierzeta
            .Where(x => x.Id == zwierzakId).Include(x => x.Zdjecie)
            .Include(x => x.rasa)
            .Include(x => x.ListaSzczepien.OrderBy(Szczepienie => Szczepienie.Data))
            .FirstOrDefault();

        /*
         * Select Top 1 * from Zwierzeta _zwierz
         * Join Zalaczniki _zalacznik 
         *  on _zalacznik.ZwierzeId = _zwierz.Id
         * Where _zwierz.Id = {zwierzakId}
         */
    }

    public void AktualizujZwierze(ZwierzeDTO edited)
    {
        if (edited is null) return;

        Zwierze? orginal = context.Zwierzeta.Find(edited.Id);
        _loggerRepo.LogToDb($"Zaktualizono zwierze {orginal?.Imie}");

        if (orginal is null) return;

        orginal.Imie = edited.Imie;
        orginal.Gatunek = edited.Gatunek;
        orginal.Umaszczenie = edited.Umaszczenie;
        orginal.DataUrodzenia = edited.DataUrodzenia;
        orginal.Kastracja = edited.Kastracja;
        orginal.Waga_Wartosc = edited.Waga_Wartosc;
        orginal.Info_Dodatkowe = edited.Info_Dodatkowe;
        orginal.Info_Schorzenia = edited.Info_Schorzenia;
        orginal.Info_Choroby = edited.Info_Choroby;
        orginal.Szczepienie_Wscieklizna_Status = edited.Szczepienie_Wscieklizna_Status;
        orginal.Szczepienie_Wscieklizna_Data = edited.Szczepienie_Wscieklizna_Data;
        orginal.Szczepienie_Wscieklizna_NastepnyTermin = edited.Szczepienie_Wscieklizna_NastepnyTermin;
        orginal.Zdjecie_Name = edited.Zdjecie_Name;
        orginal.Zdjecie_Data = edited.Zdjecie_Data;

        context.SaveChanges();
    }

    public void Usun(int idzwierzaka)
    {
        var bąbel = context.Zwierzeta.Find(idzwierzaka);
        Console.WriteLine($"Usuniecie zwierze {bąbel.Imie}");

        context.Zwierzeta.Remove(bąbel);
        context.SaveChanges();
    }
}
