using PetHelp.Server.Models;
using PetHelp.Shared.DTO;

namespace PetHelp.Server.Interfaces;

public interface IZwierzeRepository
{
    public Zwierze DodajZwierze(ZwierzeDTO nowe);
    public List<Zwierze> GetByHodowla(int hodowlaId, bool includeAttachment);
}
