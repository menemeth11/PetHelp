using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;
using System.Linq;

namespace PetHelp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHodowlaRepositor HodowlaRepo;

        public HomeController(IHodowlaRepositor hodowlaRepo)
        {
            HodowlaRepo = hodowlaRepo;
        }
        [HttpGet("GetUserHodowla/{ID}")]
        public List<HodowlaDTO>GetUserHodowla(string ID)
        {
            var x = HodowlaRepo.GetListaHodowli(ID);



            return x.Select(Hodowla => new HodowlaDTO() { Nazwa = Hodowla.Nazwa }).ToList();
        }

        [HttpPost("Dodajhodowle")]
        public HodowlaDTO Dodajhodowle(HodowlaDTO x)
        {
            Hodowla hodowla = HodowlaRepo.PostListaHodowli(x);
            return new HodowlaDTO()
            {
                Nazwa = hodowla.Nazwa
            };
        }

    }
    
}
