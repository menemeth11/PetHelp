using Microsoft.AspNetCore.Mvc;
using PetHelp.Server.Data;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;
using PetHelp.Shared.DTO.Requests;

namespace PetHelp.Server.Controllers;

[Route("Szczepienie")]
[ApiController]
public class SzczepienieController : ControllerBase
{
    //private readonly IPosilkiRepository _posilkiRepo;

    public SzczepienieController(/*IPosilkiRepository posilkiRepo*/)
    {
        //_posilkiRepo = posilkiRepo;
    }

    [HttpPost("Move")]
    public SzczepienieDTO PrzeniesienieTerminuSzczepienia(ChangeDateRequestDTO data)
    {

        return new();
    }
  
}