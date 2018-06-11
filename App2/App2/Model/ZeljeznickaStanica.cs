using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace App2.Model
{
    public    class ZeljeznickaStanica
    {
        private static List<Zaposlenik> zaposlenici=new List<Zaposlenik>();
        private static List<Klijent> klijenti=new List<Klijent>();
        private static Supervizor supervizori=new Supervizor("a", "b", DateTime.Now, "a", "b", "ds", "ds", "aaa");
        private  string opis;
        private  string lokacija;
        private  string brojTelefona;
        private static List<Rezervacija> rezervacije=new List<Rezervacija>();
        private static List<string> utisci=new List<string>();
        private static List<Voznja> voznje=new List<Voznja>();
        private static List<Grad> gradovi=new List<Grad>();
        private static List<string>oNama;
        public static List<Tuple<string, Voznja>> zaGoste = new List<Tuple<string, Voznja>>(); 
          public ZeljeznickaStanica() { oNama = new List<string> { "Amina ", "Salcin" };
              gradovi = new List<Grad>() { new Grad("kdjsask", "sarajevo") };
          }
        public ZeljeznickaStanica(string opis, string lokacija, string brojTelefona, List<Rezervacija> rezervacije, List<string> utisci, List<Zaposlenik> zaposlenici, List<Klijent> klijenti, Supervizor supervizori, List<Voznja> voznje, List<Grad> gradovi)
        {
            Opis = opis;
            Lokacija = lokacija;
            BrojTelefona = brojTelefona;
            Rezervacije = rezervacije;
            Utisci = utisci;
            Zaposlenici = zaposlenici;
            Klijenti = klijenti;
            Supervizori = supervizori;
            Voznje = voznje;
            Gradovi = gradovi;
        }
        public static Klijent NadjiKorisnika(String user, String pass)
        {
            foreach (Klijent kor in Klijenti)
            {
                if (kor.Username.Equals(user)) System.Diagnostics.Debug.Write("Nadje username");
                if (kor.Username.Equals(user) && kor.Password.Equals(pass))
                {
                    System.Diagnostics.Debug.Write("Nadje sve lel");
                    return kor;
                }
            }

            return null;
        }


        public static Zaposlenik  NAdjiZaposlenika(String user, String pass)
        {
            foreach (Zaposlenik kor in Zaposlenici)
            {
                if (kor.Username.Equals(user)) System.Diagnostics.Debug.Write("Nadje username");
                if (kor.Username.Equals(user) && kor.Password.Equals(pass))
                {
                    System.Diagnostics.Debug.Write("Nadje sve lel");
                    return kor;
                }
            }

            return null;
        } 

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public   string Opis { get => opis; set => opis = value; }
        public  string Lokacija { get => lokacija; set => lokacija = value; }
        public   string BrojTelefona { get => brojTelefona; set => brojTelefona = value; }
        public static List<Rezervacija> Rezervacije { get => rezervacije; set => rezervacije = value; }
        public static List<string> Utisci { get => utisci; set => utisci = value; }
        public  static List<Zaposlenik> Zaposlenici { get => zaposlenici; set => zaposlenici = value; }
        public static List<Klijent> Klijenti { get => klijenti; set => klijenti = value; }
        public static Supervizor Supervizori { get => supervizori; set => supervizori = value; }
        public static List<Voznja> Voznje { get => voznje; set => voznje = value; }
        public static List<Grad> Gradovi { get => gradovi; set => gradovi = value; }
        public static List<string> ONama { get => oNama; set => oNama = value; }
    }
}
