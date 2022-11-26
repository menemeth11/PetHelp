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

    [HttpPost("Add")]
    public ActionResult<List<MealRecord>> DodajPosilki(List<MealRecord> _posilki)
    {
        var lista = _posilkiRepo.AddRange(_posilki);

        if(lista == null)
        {
            return BadRequest();
        }

        return lista;
    }
}