using PetHelp.Server.Data;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;

namespace PetHelp.Server.Respositores;

public class PosilkiRepository : IPosilkiRepository
{
    private readonly ApplicationDbContext context;

    public PosilkiRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public List<MealRecord> GetPosilki(int Id, DateTime data)
    {
        return context.Posilki
            .Where(x => x.PetId == Id && 
                        x.Date.Year == data.Year && 
                        x.Date.Month == data.Month)
            .ToList();
    }

    public List<MealRecord>? AddRange(List<MealRecord> posilki)
    {
        try
        {
            context.Posilki.AddRange(posilki);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd doadwania listy posilkow: " + ex.Message);
            return null;
        }

        return posilki;
    }

    public void UpdateRange(List<MealRecord> mealRecords)
    {
        context.UpdateRange(mealRecords);
        context.SaveChanges();
    }
}
