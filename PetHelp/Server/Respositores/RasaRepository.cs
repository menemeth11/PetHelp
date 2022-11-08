using Microsoft.EntityFrameworkCore;
using PetHelp.Server.Data;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;

namespace PetHelp.Server.Respositores;

public class RasaRepository : IRasaRepository
{

    private readonly ApplicationDbContext context;

    public RasaRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<RasaDTO[]> GetAllDogTypes()
    {
        RasaDTO[] rasy = Array.Empty<RasaDTO>();
        // load available god types from database
        rasa_psa[] _rasy = await context.rasy_psow.ToArrayAsync();
        if (_rasy.Length > 0)
        {
            rasy = _rasy.Select(x => new RasaDTO
            {
                Id = x.Id,
                Nazwa = x.Nazwa
            }).ToArray();
        }

        return rasy;
    }
}
