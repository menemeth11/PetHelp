using Microsoft.AspNetCore.Mvc;
using PetHelp.Server.Interfaces;
using PetHelp.Shared.DTO;

namespace PetHelp.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class CommonController : ControllerBase
{
    private readonly IRasaRepository _rasyRepo;
    public CommonController(IRasaRepository rasyRepo)
    {
        _rasyRepo = rasyRepo;
    }

    // Common/Rasy/Pies
    /// <summary>
    ///  Metoda służąca do otrzymania listy wszystkich ras psa
    /// </summary>
    /// <returns> tablice typu RasaDTO przechowującą klucz Id i nazwe rasy </returns>
    [HttpGet("Rasy/Pies")]
    public async Task<RasaDTO[]> RasyPsow() => await _rasyRepo.GetAllDogTypes();
}