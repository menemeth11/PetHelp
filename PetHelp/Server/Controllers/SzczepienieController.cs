using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Crmf;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;
using PetHelp.Shared.DTO.Requests;

namespace PetHelp.Server.Controllers;

[Route("Szczepienie")]
[ApiController]
public class SzczepienieController : ControllerBase
{
    private readonly ISzczepieniaRepository _szczepienieRepo;

    public SzczepienieController(ISzczepieniaRepository posilkiRepo)
    {
        _szczepienieRepo = posilkiRepo;
    }

    [HttpPost("Move")]
    public SzczepienieDTO PrzeniesienieTerminuSzczepienia(ChangeDateRequestDTO data)
    {
        SzczepienieRecord x = _szczepienieRepo.AktualizujTermin(data.ZwierzId, data.PierwszyTermin, data.NowyTermin, data.SzczepienieId, data.SzczepienieType);

        return new SzczepienieDTO()
        {
            Id = x.Id,
            SzczepienieType = x.SzczepienieType,
            Data = x.Data,
            DataInnyTermin = x.DataInnyTermin,
            CzyOdbyte = x.CzyOdbyte,
            ZwierzeId = x.ZwierzeId
        };
    }

    [HttpGet("GetAll/{zwierzeId}")]
    public List<SzczepienieDTO> GetRegisteredSzczepienia(int zwierzeId)
    {
        List<SzczepienieRecord> y = _szczepienieRepo.GetAll(zwierzeId);

        return y.Select(x => 
            new SzczepienieDTO()
            {
                Id = x.Id,
                SzczepienieType = x.SzczepienieType,
                Data = x.Data,
                DataInnyTermin = x.DataInnyTermin,
                CzyOdbyte = x.CzyOdbyte,
                ZwierzeId = x.ZwierzeId
            }).ToList();
    }

    [HttpPost("Zatwierdz")]
    public SzczepienieDTO Zatwierdz(SzczepienieDTO model)
    {  
        SzczepienieRecord? item = _szczepienieRepo.Zatwierdz(model);

        if(item != null)
        {
            return new SzczepienieDTO() {
                Id = item.Id,
                SzczepienieType = item.SzczepienieType,
                Data = item.Data,
                DataInnyTermin = item.DataInnyTermin,
                CzyOdbyte = item.CzyOdbyte,
                ZwierzeId = item.ZwierzeId
            };
        }

        throw new NullReferenceException($"Błąd zatwierdzania szczepienia");
    }

}

