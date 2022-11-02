using PetHelp.Server.Models;

namespace PetHelp.Server.Interfaces;

public interface IZwierzeRepository
{
    public List<Zwierze> GetByHodowla(int hodowlaId, bool includeAttachment);
}
