using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Model
{
    public class Supervizor : Osoba
    {
        private string brTel;
        private string opisRadnogMjesta;
        private List<Zaposlenik> zaposlenici;

        public Supervizor(string ime, string prezime, DateTime datumRodjenja, string username, string password, string eMail, string opisRadnogMjesta, string brTel)
        : base(ime, prezime, datumRodjenja, password, username, eMail)
        {
            Ime = "AA";
            Prezime = "BB";
            DatumRodjenja = new DateTime(1996, 2, 1);
            EMail = "AB@etf.unsa.ba";
            Username = "admin";
            Password = "123";
            OpisRadnogMjesta = "Supervizor";
            Zaposlenici = ZeljeznickaStanica.Zaposlenici;
            BrTel = "061111111";

        }
       
        public string OpisRadnogMjesta { get => opisRadnogMjesta; set => opisRadnogMjesta = value; }
        public List<Zaposlenik> Zaposlenici { get => zaposlenici; set => zaposlenici = value; }
        public string BrTel { get => brTel; set => brTel = value; }
    }
}
