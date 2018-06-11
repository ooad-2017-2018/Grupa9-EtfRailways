using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Model
{
    public class Klijent: Osoba
    {
        private string brojTelefona;
        private List<Voznja> putovanja=new List<Voznja>();
        private string adresa;

        public Klijent(string ime, string prezime, DateTimeOffset datumRodjenja, string username, string password, string eMail, string brojTelefona, List<Voznja> putovanja, string adresa)
        :base(ime, prezime, datumRodjenja, username, password, eMail){
            BrojTelefona = brojTelefona;
            Putovanja = putovanja;
            Adresa = adresa;
        }
        public Klijent(string ime, string prezime, DateTimeOffset datumRodjenja, string username, string password, string eMail, string brojTelefona,  string adresa)
       : base(ime, prezime, datumRodjenja, username, password, eMail)
        {
            BrojTelefona = brojTelefona;
            Adresa = adresa;
        }
        public Klijent(string ime, string prezime, DateTimeOffset datumRodjenja, string username, string password, string eMail) : base(ime, prezime, datumRodjenja, username, password, eMail){ } 


        public string BrojTelefona { get => brojTelefona; set => brojTelefona = value; }
        public List<Voznja> Putovanja { get => putovanja; set => putovanja = value; }
        public string Adresa { get => adresa; set => adresa = value; }
    }
}
