using Microsoft.EntityFrameworkCore;
using PetHelp.Server.Data;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;

namespace PetHelp.Server.Respositores;

public class SzczepieniaRepository : ISzczepieniaRepository
{
    private readonly ApplicationDbContext context;

    public static List<SzczepienieInfo> listaDostepnychszczepien = new(){
        new SzczepienieInfo()
        {
            ID = 1,
            Name = "3w1",
            Description = "PArowkoza, nosowka itp",
            IntervalArr = new int[5] { 49, 21, 21, 365, 1095 }
        },
        new SzczepienieInfo()
        {
            ID = 2,
            Name = "Wscieklizna",
            Description = "Wscieklizna",
            IntervalArr = new int[2] { 105, 365 }
        }
    };

    public SzczepieniaRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public List<SzczepienieRecord> UzupelnijOdbyteSzczepienia(DateTime dataUrodzenia)
    {
        List<SzczepienieRecord> listaOdbytychSzczepien = new();
        foreach (SzczepienieInfo _szczepienie in listaDostepnychszczepien)
        {
            int dniOdUrodzenbia = (DateTime.Now - dataUrodzenia).Days;

            if (listaOdbytychSzczepien.Any(x => x.SzczepienieType == _szczepienie.ID) == false)
            {
                while (true)
                {
                    int sum = 0;
                    int count = listaOdbytychSzczepien.Where(x => x.SzczepienieType == _szczepienie.ID).Count();
                    if (count < _szczepienie.IntervalArr.Length)
                    {
                        // suma z poprzednich
                        sum = _szczepienie.IntervalArr.Take(count + 1).Sum(x => x);
                    }
                    else
                    {
                        // repeat last 
                        int kolejneintervaly = 1 + count - _szczepienie.IntervalArr.Length;
                        sum = _szczepienie.IntervalArr.Sum(x => x) + (kolejneintervaly * _szczepienie.IntervalArr.Last());
                    }

                    if (dniOdUrodzenbia < sum) break;

                    var szczepan = new SzczepienieRecord()
                    {
                        SzczepienieType = _szczepienie.ID,
                        CzyOdbyte = true,
                        Data = dataUrodzenia.AddDays(sum)
                    };
                    listaOdbytychSzczepien.Add(szczepan);
                }
            }
        }
        return listaOdbytychSzczepien;
    }
}
