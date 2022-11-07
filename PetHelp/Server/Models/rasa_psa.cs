using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHelp.Server.Models
{
    public class rasa_psa
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; } = String.Empty;

    }
}
