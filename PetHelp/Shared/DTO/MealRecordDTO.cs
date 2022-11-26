namespace PetHelp.Shared.DTO;

public class MealRecordDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Weight { get; set; }
    public string Name { get; set; }
    public int Type { get; set; }
    public int PetId { get; set; }
}
