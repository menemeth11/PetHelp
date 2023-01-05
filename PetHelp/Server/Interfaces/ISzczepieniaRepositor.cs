using PetHelp.Server.Models;
using PetHelp.Shared.DTO;

namespace PetHelp.Server.Interfaces;

public interface ISzczepieniaRepository
{
    List<SzczepienieRecord> UzupelnijOdbyteSzczepienia(DateTime dataUrodzenia);
}

public class SzczepienieInfo
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int StartAfter { get; set; }
    public int[] IntervalArr { get; set; } = Array.Empty<int>();
}