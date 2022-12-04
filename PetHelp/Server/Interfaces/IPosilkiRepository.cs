using PetHelp.Server.Models;

namespace PetHelp.Server.Interfaces;

public interface IPosilkiRepository
{
    List<MealRecord> AddRange(List<MealRecord> posilki);
    List<MealRecord> GetPosilki(int Id, DateTime data);
    void UpdateRange(List<MealRecord> mealRecords);
}
