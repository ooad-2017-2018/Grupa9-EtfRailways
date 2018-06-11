using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace App2.Model
{
    public class Zaposlenik: Osoba
    {
        private string brojTelefona;
        private string opisRadnogMjesta;
        private List<Voznja> voznje;

        public Zaposlenik(string ime, string prezime, DateTimeOffset datumRodjenja, string username, string password, string eMail, string brojTelefona, string opisRadnogMjesta, List<Voznja> voznje):
            base(ime, prezime, datumRodjenja, username, password, eMail)
        {
            BrojTelefona = brojTelefona;
            OpisRadnogMjesta = opisRadnogMjesta;
            Voznje = voznje;
        }

        public string BrojTelefona { get => brojTelefona; set => brojTelefona = value; }
        public string OpisRadnogMjesta { get => opisRadnogMjesta; set => opisRadnogMjesta = value; }
        public List<Voznja> Voznje { get => voznje; set => voznje = value; }

       
    }
}
