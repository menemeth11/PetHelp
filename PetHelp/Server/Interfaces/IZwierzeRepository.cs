using PetHelp.Server.Models;
using PetHelp.Shared.DTO;

namespace PetHelp.Server.Interfaces;

public interface IZwierzeRepository
{
    public void AktualizujZwierze(ZwierzeDTO x);
    public Zwierze DodajZwierze(ZwierzeDTO nowe);
    public List<Zwierze> GetByHodowla(int hodowlaId, bool includeAttachment);
    public Zwierze? GetById(int zwierzakId);
    void Usun(int idzwierzaka);
}
