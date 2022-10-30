using Microsoft.AspNetCore.Mvc;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;

namespace PetHelp.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IHodowlaRepositor HodowlaRepo;
    private readonly IZwierzeRepository _zwierzeRepo;

	public HomeController(IHodowlaRepositor hodowlaRepo, IZwierzeRepository zwierzeRepo)
	{
		HodowlaRepo = hodowlaRepo;
		_zwierzeRepo = zwierzeRepo;
	}

	[HttpGet("GetUserHodowla/{ID}")]
    public List<HodowlaDTO>GetUserHodowla(string ID)
    {
        var x = HodowlaRepo.GetListaHodowli(ID);
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
        Hodowla hodowla = HodowlaRepo.PostListaHodowli(x);
        return new HodowlaDTO()
        {
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
        List<Zwierze> zwierzeta = _zwierzeRepo.GetByHodowla(hodowlaId, includeAttachment:false);
        return zwierzeta.Select(z => 
            new ZwierzeDTO() 
            { 
                Gatunek = z.Gatunek,
                Imie= z.Imie,
                Rasa = z.Rasa,
                DataUrodzenia = z.DataUrodzenia
            }
        ).ToList();
    }
}
    
