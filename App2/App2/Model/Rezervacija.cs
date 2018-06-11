using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Model
{
    public class Rezervacija
    {
        private Voznja voznja;
        private Klijent klijenti;

        public Rezervacija(Voznja voznja,  Klijent klijenti)
        {
            Voznja = voznja;
            Klijenti = klijenti;
        }

        public Voznja Voznja { get => voznja; set => voznja = value; }
        internal Klijent Klijenti { get => klijenti; set => klijenti = value; }
    }
}
