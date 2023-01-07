namespace PetHelp.Shared.DTO.Requests;

public class ChangeDateRequestDTO
{
    public int ZwierzId { get; set; }
    public DateTime PierwszyTermin { get; set; }
    public DateTime NowyTermin { get; set; }
    public int SzczepienieId { get; set; }
    public int SzczepienieType { get; set; }
}
