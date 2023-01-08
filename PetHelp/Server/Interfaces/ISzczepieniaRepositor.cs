using PetHelp.Server.Models;
namespace PetHelp.Server.Interfaces;

public interface ISzczepieniaRepository
{
    List<SzczepienieRecord> UzupelnijOdbyteSzczepienia(DateTime dataUrodzenia);
    SzczepienieRecord AktualizujTermin(int zwierzId, DateTime pierwszyTermin, DateTime nowyTermin, int szczepienieId, int szczepienieType);
    List<SzczepienieRecord> GetAll(int zwierzeId);
    SzczepienieRecord? Zatwierdz(int zwierzeId, int szczepienieId);

}

