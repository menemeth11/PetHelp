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
}
