﻿using PetHelp.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                    Description = "Parwowiroza, nosowka itp",
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

        public static SzczepienieDTO GetNext(SzczepienieInfo szczepienie, int liczbaOdbytuchSzczepien, DateTime dataUrodzenia)
        {
            DateTime dataNastepnegoSzczepienia = default;
            int numerNastepnegoSzczepienia = liczbaOdbytuchSzczepien + 1;

            if (numerNastepnegoSzczepienia == 0)
            {
                dataNastepnegoSzczepienia = dataUrodzenia.AddDays(szczepienie.IntervalArr[0]);
                return new SzczepienieDTO(szczepienie.ID, dataNastepnegoSzczepienia);
            }
            int sumaDniDoKolejnegoSzczepienia;
            bool czyStalyOdstep = numerNastepnegoSzczepienia > szczepienie.IntervalArr.Length;
            if (czyStalyOdstep)
            {
                int numerStalegoTerminu = numerNastepnegoSzczepienia - szczepienie.IntervalArr.Length;
                sumaDniDoKolejnegoSzczepienia = szczepienie.IntervalArr.Sum() + (numerStalegoTerminu * szczepienie.IntervalArr.Last());
            }
            else
            {
                sumaDniDoKolejnegoSzczepienia = szczepienie.IntervalArr.Take(numerNastepnegoSzczepienia).Sum();
            }

            dataNastepnegoSzczepienia = dataUrodzenia.AddDays(sumaDniDoKolejnegoSzczepienia);
            return new SzczepienieDTO(szczepienie.ID, dataNastepnegoSzczepienia);

        }


        public static List<SzczepienieDTO> GetMergedSzczepeniaMultipleNext(int number, DateTime dataUrodzenia, List<SzczepienieDTO> zarejestrowaneSzczepienia, int zwierzeId, List<SzczepienieInfo> szczepieniaSettingsData = null)
        {
            if (szczepieniaSettingsData == null)
            {
                szczepieniaSettingsData = Szczepienia();
            }

            List<SzczepienieDTO> polaczonaListaSzczepien = new();
            foreach (var rodzaj in szczepieniaSettingsData)
            {
                int odbyteliczba = zarejestrowaneSzczepienia.Count(x => x.SzczepienieType == rodzaj.ID);
                for (var i = 0; i < number; i++)
                {
                    polaczonaListaSzczepien.Add(SzczepienieDetale.GetNext(rodzaj, odbyteliczba, dataUrodzenia));
                    odbyteliczba++;
                }
            }
            polaczonaListaSzczepien = polaczonaListaSzczepien.OrderBy(x => x.Data).Take(number).ToList();
            polaczonaListaSzczepien.AddRange(zarejestrowaneSzczepienia);
            polaczonaListaSzczepien.ForEach(x => x.ZwierzeId = zwierzeId);

            return polaczonaListaSzczepien.OrderBy(x => x.Data).ToList();
        }
    }
}
