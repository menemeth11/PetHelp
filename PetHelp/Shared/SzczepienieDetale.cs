using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelp.Shared
{
    public static class SzczepienieDetale
    {
        public static List<SzczepienieInfo> Szczepienia()
        {
            return new List<SzczepienieInfo>() {
                new SzczepienieInfo()
                {
                    ID = 1,
                    Name = "Szczepienie zasadnicze",
                    Description = "PArowkoza, nosowka itp",
                    IntervalArr = new int[5] { 49, 21, 21, 365, 1095 }
                },
                new SzczepienieInfo()
                {
                    ID = 2,
                    Name = "Wscieklizna",
                    Description = "Wscieklizna",
                    IntervalArr = new int[2] { 105, 365 }
                }
            };
        }   
        

        public class SzczepienieInfo
        {
            public int ID { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public int StartAfter { get; set; }
            public int[] IntervalArr { get; set; } = Array.Empty<int>();
        }
    }
}
