using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models
{
    public class Hodowla
    {
        [Key]
        public int id { get; set; }
        public string Nazwa { get; set; }

        [ForeignKey("Wlasciciel")]
        public string WlascicielID { get; set; }
        public ApplicationUser? Wlasciciel { get; set; }

        public List<Zwierze> Zwierzeta { get; set; } = new();
    }
}
