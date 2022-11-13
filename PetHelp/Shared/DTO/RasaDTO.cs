using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelp.Shared.DTO
{
    public class RasaDTO
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = String.Empty;
        public int gatunekID { get; set; }
    }
}
