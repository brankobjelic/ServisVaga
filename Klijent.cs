using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVaga
{
    public class Klijent
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Mesto { get; set; }
        public string UlicaIBroj { get; set; }

        public override string? ToString()
        {
            if (Naziv == null || Naziv == "") return "";
            else if (Mesto == null || Mesto == "") return Naziv;
            else if (UlicaIBroj == null || UlicaIBroj == "") return Naziv + ", " + Mesto;
            else return Naziv + ", " + Mesto + ", " + UlicaIBroj;
        }
    }
}
