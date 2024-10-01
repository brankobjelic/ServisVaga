using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVaga
{
    class Uverenje
    {
        public int Id { get; set; }
        public Merilo Merilo { get; set; }
        public string VaznostPregleda { get; set; }
        public string Tekst { get; set; }
        public DateOnly DatumIzdavanja { get; set; }
    }
}
