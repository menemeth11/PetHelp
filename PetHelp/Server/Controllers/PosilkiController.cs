using Microsoft.AspNetCore.Mvc;
using PetHelp.Server.Data;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;

namespace PetHelp.Server.Controllers;

[Route("Meal")]
[ApiController]
public class PosilkiController : ControllerBase
{
    private readonly IPosilkiRepository _posilkiRepo;

    public PosilkiController(IPosilkiRepository posilkiRepo)
    {
        _posilkiRepo = posilkiRepo;
    }

    [HttpGet("{year}-{month}/{petId}")]
    public List<MealRecord> ListaPosilkowZwierzaka(int year, int month, int petId) => 
        _posilkiRepo.GetPosilki(petId, new DateTime(year,month,1));

    [HttpPost("AddRange")]
    public ActionResult<List<MealRecordDTO>> DodajPosilki(List<MealRecordDTO> _posilki)
    {
        var lista = _posilkiRepo.AddRange(_posilki.Select(x =>
            new MealRecord {
                Id = x.Id,
                Date = x.Date,
                Name = x.Name,
                PetId = x.PetId,
                Weight = x.Weight,
                Type = x.Type
            }).ToList());

        if(lista == null)
        {
            return BadRequest();
        }

        return lista.Select(x =>
            new MealRecordDTO
            {
                Id = x.Id,
                Date = x.Date,
                Name = x.Name,
                PetId = x.PetId,
                Weight = x.Weight,
                Type = x.Type,
            }).ToList();
    }

    [HttpPost("UpdateRange")]
    public IActionResult Aktualizuj(List<MealRecordDTO> _posilki)
    {
        _posilkiRepo.UpdateRange(_posilki.Select(x => 
            new MealRecord {
                Id = x.Id,
                Date = x.Date,
                Name = x.Name,
                PetId = x.PetId,
                Weight = x.Weight,
                Type = x.Type
            }).ToList());

        return Ok();
    }
}