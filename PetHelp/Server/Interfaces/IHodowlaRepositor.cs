using PetHelp.Server.Data.Migrations;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;

namespace PetHelp.Server.Interfaces
{
    public interface IHodowlaRepositor
    {
        public List<Hodowla> GetListaHodowli(string ID);
        public Hodowla PostListaHodowli(HodowlaDTO data);
    }
}
