using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;

public class MealRecord
{
    [Key]
    public int Id { get; set; }

    public DateTime Date {get;set; } 
    public int Weight {get;set; } 
    public string Name {get;set; } 
    public int Type { get; set; } // [1-sniadanie, 2-obiad, 3-kolacja]
  
    [ForeignKey("Pet")]
    public int PetId {get;set; }
    public Zwierze? Pet { get; set; }
}
