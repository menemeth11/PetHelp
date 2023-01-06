namespace PetHelp.Shared.DTO;

public class SzczepienieDTO
{
    public SzczepienieDTO()
    {

    }
    public SzczepienieDTO(int _type, DateTime _data)
    {
        SzczepienieType = _type;
        this.Data = _data;
    }

    public int Id { get; set; }
    public int SzczepienieType { get; set; }
    public DateTime Data { get; set; } // 1 data orientacyjna automat

    public DateTime? DataInnyTermin { get; set; } = null; // faktyczna data zatwierdzenia
    public bool CzyPrzeniesiona
    {
        get
        {
            return DataInnyTermin != null;
        }
    }
    public bool CzyOdbyte { get; set; } = false;
    public int ZwierzeId { get; set; }
}
