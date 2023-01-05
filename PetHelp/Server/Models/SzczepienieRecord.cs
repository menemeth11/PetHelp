using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models;

public class SzczepienieRecord
{
    [Key]
    public int Id { get; set; }
    public int SzczepienieType { get; set; }
    public DateTime Data { get; set; } // 1 data orientacyjna automat

    public DateTime? DataInnyTermin { get; set; } // faktyczna data zatwierdzenia
    public bool CzyPrzeniesiona { 
        get { 
                return DataInnyTermin != null; 
            } 
        }

    public bool CzyOdbyte { get; set; } = false;

    [ForeignKey("Zwierze")]
    public int ZwierzeId { get; set; }
    public Zwierze Zwierze { get; set; }


    //public static List<SzczepienieInfo> listaDostepnychszczepien = new(){
    //    new SzczepienieInfo()
    //    {
    //        ID = 1,
    //        Name = "3w1",
    //        Description = "PArowkoza, nosowka itp",
    //        IntervalArr = new int[5] { 49, 21, 21, 365, 1095 }
    //    },
    //    new SzczepienieInfo()
    //    {
    //        ID = 2,
    //        Name = "Wscieklizna",
    //        Description = "Wscieklizna",
    //        IntervalArr = new int[2] { 105, 365 }
    //    }
    //};
}
