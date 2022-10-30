using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;

public class Zalacznik
{
	[Key]
	public int Id { get; set; }
	public string Zdjecie_MIME { get; set; } = String.Empty;
    public string Zdjecie_Name { get; set; } = String.Empty;
    public byte[] Zdjecie_Data { get; set; } = Array.Empty<byte>();

	[ForeignKey("Zwierze")]
	public int ZwierzeId { get; set; }
	public Zwierze? Zwierze { get; set; }
}