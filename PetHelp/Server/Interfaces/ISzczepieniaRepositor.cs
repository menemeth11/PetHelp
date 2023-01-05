using PetHelp.Server.Models;
using PetHelp.Shared.DTO;

namespace PetHelp.Server.Interfaces;

public interface ISzczepieniaRepository
{
    List<SzczepienieRecord> UzupelnijOdbyteSzczepienia(DateTime dataUrodzenia);
}

