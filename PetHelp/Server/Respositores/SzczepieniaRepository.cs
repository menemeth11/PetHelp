using MessagePack;
using Microsoft.EntityFrameworkCore;
using PetHelp.Server.Data;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared;
using PetHelp.Shared.DTO;
using PetHelp.Shared.DTO.Requests;
using static PetHelp.Shared.SzczepienieDetale;

namespace PetHelp.Server.Respositores;

public class SzczepieniaRepository : ISzczepieniaRepository
{
    private readonly ApplicationDbContext _context;

    public static List<SzczepienieInfo> listaDostepnychszczepien = new();

    public SzczepieniaRepository(ApplicationDbContext context)
    {
        this._context = context;
        listaDostepnychszczepien = SzczepienieDetale.Szczepienia();
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

    public SzczepienieRecord AktualizujTermin(int ZwierzId, DateTime PierwszyTermin, DateTime NowyTermin, int SzczepienieId, int SzczepienieType)
    {
        SzczepienieRecord? item;
        if (SzczepienieId == 0)
        {
            // dodawanie nowego recordu do bazy
            item = new()
            {
                SzczepienieType = SzczepienieType,
                ZwierzeId = ZwierzId,
                Data = PierwszyTermin,
                DataInnyTermin = NowyTermin
            };

            _context.Szczepienia.Add(item);
        }
        else
        {
            // aktualizacja istniejacego
            item = _context.Szczepienia.Find(SzczepienieId);
            if(item == null)
            {
                throw new NullReferenceException($"szczepienie o id {SzczepienieId} nie został znaleziony.");
            }
            item.DataInnyTermin = NowyTermin;
            _context.Update(item);
        }

        _context.SaveChanges();
        return item;
    }

    public List<SzczepienieRecord> GetAll(int zwierzeId)
    {
        return _context.Szczepienia
            .Where(x => x.ZwierzeId == zwierzeId)
            .AsNoTracking()
            .ToList();
    }

    public SzczepienieRecord? Zatwierdz(int zwierzeId, int szczepienieId)
    {
        SzczepienieRecord? item = _context.Szczepienia.Find(szczepienieId);

        if(item != null)
        {
            item.CzyOdbyte = true;
            _context.Update(item);
            _context.SaveChanges();
        }

        return item;

    }
}
