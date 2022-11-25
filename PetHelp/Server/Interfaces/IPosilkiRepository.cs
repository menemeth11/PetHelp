using PetHelp.Server.Models;

namespace PetHelp.Server.Interfaces;

public interface IPosilkiRepository
{
    public List<MealRecord> GetPosilki(int Id, DateTime data);
}
