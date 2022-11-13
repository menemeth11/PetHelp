using Microsoft.EntityFrameworkCore;
using PetHelp.Server.Data;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;
using System.Linq;

namespace PetHelp.Server.Respositores
{
    public class HodowlaRepository : IHodowlaRepositor
    {

        private readonly ApplicationDbContext context;

        public HodowlaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Hodowla> GetListaHodowli(string ID)
        {
            return context.ListaHodowli.Where(Hodowla => Hodowla.WlascicielID == ID).ToList();
        }

        public Hodowla PostListaHodowli(HodowlaRequestDTO data)
        {
            Hodowla _hodowla = new Hodowla()
            {
                Nazwa = data.Nazwa,
                WlascicielID = data.UserID
            };
            context.ListaHodowli.Add(_hodowla);
            context.SaveChanges();
            return _hodowla;
        }

        public void Usun(int idhodowli)
        {
            var h = context.ListaHodowli.Where(_hodowla => _hodowla.id == idhodowli).Include(x => x.Zwierzeta).FirstOrDefault();
            if(h != null)
            {
                context.ListaHodowli.Remove(h);
                context.SaveChanges();
            }
        }
    }
}
