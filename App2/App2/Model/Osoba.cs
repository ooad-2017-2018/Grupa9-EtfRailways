using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Model
{
    public class Osoba
    {
        private string ime;
        private string prezime;
        private DateTimeOffset datumRodjenja;
        private string password;
        private string username;
        private string eMail;

        public Osoba(string ime, string prezime, DateTimeOffset datumRodjenja,  string username, string password, string eMail)
        {
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datumRodjenja;
            Password = password;
            Username = username;
            EMail = eMail;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTimeOffset DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
        public string EMail { get => eMail; set => eMail = value; }
    }
}
