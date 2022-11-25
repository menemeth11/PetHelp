using Microsoft.EntityFrameworkCore;
using PetHelp.Server.Data;
using PetHelp.Server.Interfaces;
using PetHelp.Server.Models;
using PetHelp.Shared.DTO;
using System.Linq;

namespace PetHelp.Server.Respositores
{
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
    }
}
