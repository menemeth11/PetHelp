namespace PetHelp.Shared.DTO;
public class ZwierzeDTO
{


	public int Id { get; set; }
	public string Imie { get; set; } = "- nie podano -";
	public string Gatunek { get; set; } = "- nie podano -";
	public int GatunekID { get; set; }
	public string Umaszczenie { get; set; } = "- nie podano -";
	private DateTime _dataUrodzenia = DateTime.Now;
	

	public DateTime DataUrodzenia
	{
		get => _dataUrodzenia;
		set
		{
			if (value > DateTime.Now)
				value = DateTime.Now;
			_dataUrodzenia = value;
		}
	}
	public DateTime DataDodania { get; set; } = DateTime.Now;
	public bool Kastracja { get; set; } = false;
    private DateTime? waga_Pomiar;
    public DateTime? Waga_Pomiar 
	{ 
		get => waga_Pomiar;
        set
        {
            if (value > DateTime.Now)
                value = DateTime.Now;
            waga_Pomiar = value;
        }
    }
	public float? Waga_Wartosc { get; set; }
	public string Info_Dodatkowe { get; set; } = string.Empty;
	public string Info_Schorzenia { get; set; } = string.Empty;
	public string Info_Choroby { get; set; } = string.Empty;
	public bool Szczepienie_Wscieklizna_Status { get; set; } = false;
	public DateTime? Szczepienie_Wscieklizna_Data { get; set; }
	public DateTime? Szczepienie_Wscieklizna_NastepnyTermin { get; set; }
	public int HodowlaId { get; set; }
	public string WlascicielId { get; set; }
	public int rasaId { get; set; } = 1;
	public string rasaNazwa { get; set; } = string.Empty;
	public string Zdjecie_MIME { get; set; } = String.Empty;
	public string Zdjecie_Name { get; set; } = String.Empty;
	public byte[] Zdjecie_Data { get; set; } = Array.Empty<byte>();
}