using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVaga
{
    public class Merilo

    {
        public long Id { get; set; }
        public Klijent Imalac { get; set; }
        public string Naziv { get; set; }
        public string Proizvodjac { get; set; }
        public string Tip { get; set; }
        public string SerijskiBroj { get; set; }
        public long GodinaProizvodnje { get; set; }
        public string SluzbenaOznaka { get; set; }
        public string OpsegMerenja { get; set; }
        public string NajmanjiPodeok { get; set; }
        public string KlasaTacnosti { get; set; }
    }
}
