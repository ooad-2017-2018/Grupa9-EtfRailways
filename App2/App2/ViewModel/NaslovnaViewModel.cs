using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App2.Model;
using App2.Helper;
using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;
using App2.Azure;

namespace App2.ViewModel
{
   class NaslovnaViewModel
    {
        public  List<Klijent> klijenti { get; set; }
        public  List<Zaposlenik> zaposlenici{ get; set; }
        public  Supervizor supervizori{ get; set; }
        public  List<Voznja> voznje { get; set; }
        public  List<Grad> gradovi { get; set; }
        public  List<Rezervacija> rezervacije { get; set; }
        public List<Tuple<string, Voznja>> zaGost { get; set; }
        public  List<string> utisciKorisnika { get; set; }
        // public ICommand kupovinaKarte;
        public ICommand utisci { get; set; }
        public ICommand regZaposlenika { get; set; }
        public ICommand kupi{ get; set; }
        public ICommand gost1 { get; set; }
        public ICommand pretraziZaposlene { get; set; }
        public List<string> oNama { get; set; }
        public string ut { get; set; }
        public string ocjena { get; set; }
        public string vooznja { get; set; }
        public string kor { get; set; }
        public bool jesteKorisnik { get; set;}
        public string brRacuna { get; set; }
        public string primaImeIPrezime { get; set; }

        public ICommand PrijaviSe { get; set; }
        public ICommand RegistrujSe { get; set; }
        public String Potvrda { get; set; }
        public String Adresa { get; set; }
        public String BrojTelefona { get; set; }

        public String Username { get; set; }
        public String Password { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Email { get; set; }
        public DateTimeOffset DatumRodjenja { get; set; }
        public String UsernameRegistracija { get; set; }
        public String PasswordRegistracija { get; set; }
      
        public ICommand OdaberiSliku { get; set; }
        public ICommand Login { get => login1; set => login1 = value; }
        public string ImeZap { get => imeZap; set => imeZap = value; }
        public string PrezimeZap { get => prezimeZap; set => prezimeZap = value; }
        public string BrTelZap { get => brTelZap; set => brTelZap = value; }
        public string OpisRadnogMjestaZap { get => opisRadnogMjestaZap; set => opisRadnogMjestaZap = value; }
        public DateTimeOffset DatumRodjZap1 { get => DatumRodjZap; set => DatumRodjZap = value; }
        public string ImeZaPretraziti { get => imeZaPretraziti; set => imeZaPretraziti = value; }
        public ICommand otvo { get ; set; }
        public ICommand RegistrujVoznju { get => registrujVoznju; set => registrujVoznju = value; }
        public string BrojLinijeVoznje { get => brojLinijeVoznje; set => brojLinijeVoznje = value; }
        public string BrojSjedistaVoznje { get => brojSjedistaVoznje; set => brojSjedistaVoznje = value; }
        public DateTimeOffset VrijemePolaskaVoznje { get => vrijemePolaskaVoznje; set => vrijemePolaskaVoznje = value; }
        public DateTimeOffset VrijemeDolaskaVoznje { get => vrijemeDolaskaVoznje; set => vrijemeDolaskaVoznje = value; }
        public string MjestoPolaskaVoznje { get => mjestoPolaskaVoznje; set => mjestoPolaskaVoznje = value; }
        public string MjestoDolaskaVoznje { get => mjestoDolaskaVoznje; set => mjestoDolaskaVoznje = value; }
        public string TipVoza { get => tipVoza; set => tipVoza = value; }
        public string SelektovanaVoznja { get => selektovanaVoznja; set => selektovanaVoznja = value; }
        public ICommand ObrisiLiniju { get => obrisiLiniju; set => obrisiLiniju = value; }
        public ICommand Kl { get => kl; set => kl = value; }
        public ICommand Zz { get => zz; set => zz = value; }
        public ICommand Ad { get => ad; set => ad = value; }
        public ICommand OtvoriPraviProfil { get => otvoriPraviProfil; set => otvoriPraviProfil = value; }

        private ICommand otvoriPraviProfil;
        private string imeZap;
        private string prezimeZap; 
        private string brTelZap; 
        private string opisRadnogMjestaZap;
        private DateTimeOffset DatumRodjZap;
        private ICommand registrujVoznju;
        private string brojLinijeVoznje;
        private string brojSjedistaVoznje;
        private DateTimeOffset vrijemePolaskaVoznje;
        private DateTimeOffset vrijemeDolaskaVoznje;
        private string mjestoPolaskaVoznje;
        private string mjestoDolaskaVoznje;
        private string tipVoza; 
        private ICommand login1;
        private ICommand obrisiLiniju;
        private String selektovanaVoznja;
        private ICommand kl;
        private ICommand zz;
        private ICommand ad;
        public NaslovnaViewModel()
        {
            zaGost = ZeljeznickaStanica.zaGoste; 
            klijenti = ZeljeznickaStanica.Klijenti;
            zaposlenici = ZeljeznickaStanica.Zaposlenici;
            supervizori = ZeljeznickaStanica.Supervizori;
            voznje = ZeljeznickaStanica.Voznje;
            gradovi = ZeljeznickaStanica.Gradovi;
            utisciKorisnika = ZeljeznickaStanica.Utisci;
            rezervacije = ZeljeznickaStanica.Rezervacije;
            oNama = ZeljeznickaStanica.ONama;
            utisci = new RelayCommand<object>(dodajKomentar, mozeLiSeDodati);
            kupi = new RelayCommand<object>(kupiKartu, mozeLiSeKupiti);
            RegistrujSe = new RelayCommand<object>(registracijaAsync, mogucaRegistracija);
            PrijaviSe = new RelayCommand<object>(prijavaAsync, mogucaPrijava);
            gost1 = new RelayCommand<object>(gost, mozeLiSelogovat);
            otvo = new RelayCommand<object>(otvori, mogucaPrijava);
            Login = new RelayCommand<object>(login, mogucaPrijava);
            regZaposlenika = new RelayCommand<object>(reg, mogucaPrijava);
            RegistrujVoznju = new RelayCommand<object>(regvoz, mogucaPrijava);
            ObrisiLiniju = new RelayCommand<object>(obrisiLinijuu, mogucaPrijava);
            Kl = new RelayCommand<object>(zaKlijenta, mogucaPrijava);
            Zz = new RelayCommand<object>(zaZap, mozeLiSeDodati);
            Ad = new RelayCommand<object>(zaAdmin, mozeLiSeDodati);
        
        }
        public void obrisiLinijuu(object parametar)
        {
            for (int i= 0; i<ZeljeznickaStanica.Voznje.Count; i++)
            {
                if (ZeljeznickaStanica.Voznje[i].ToString().Equals(selektovanaVoznja))
                {
                    ZeljeznickaStanica.Voznje.RemoveAt(i);
                    MessageDialog msgDialogError = new MessageDialog("Vožnja je uspješno obrisana!");
                    msgDialogError.ShowAsync();
                }
               
            }

        }
        public void regvoz(object parametar)
        {
                   IMobileServiceTable<Voznje> userTableObj = App.MobileService.GetTable<Voznje>();


            if (!String.IsNullOrWhiteSpace(TipVoza) && !String.IsNullOrWhiteSpace(BrojSjedistaVoznje) && !String.IsNullOrWhiteSpace(brojLinijeVoznje) && !String.IsNullOrWhiteSpace(mjestoDolaskaVoznje) && !String.IsNullOrWhiteSpace(mjestoPolaskaVoznje))
            {
                Voznja vv = new Voznja(Voznja.naplata(TipVoza, VrijemePolaskaVoznje), TipVoza, Convert.ToInt32(BrojLinijeVoznje), Convert.ToInt32(BrojSjedistaVoznje), VrijemePolaskaVoznje, VrijemeDolaskaVoznje, MjestoPolaskaVoznje, mjestoDolaskaVoznje);
                ZeljeznickaStanica.Voznje.Add(vv);
                try
                {
                    Voznje obj = new Voznje();

                    obj.BrojLinije = Convert.ToInt32(BrojLinijeVoznje);
                    obj.BrojSjedista =Convert.ToInt32(BrojSjedistaVoznje);
                    obj.MjestoDolaska = MjestoDolaskaVoznje;
                    // obj.obrisan = false;
                    obj.MjestoPolaska = mjestoPolaskaVoznje;
                    obj.VrijemeDolaska = VrijemeDolaskaVoznje.Date;
                    obj.VrijemePolaska = VrijemePolaskaVoznje.Date;
                    obj.TipVoza = TipVoza;
                    userTableObj.InsertAsync(obj);
                    MessageDialog msgDialogError = new MessageDialog("Vožnja je uspješno dodana!");
                    msgDialogError.ShowAsync();
                }
                catch(Exception e)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error: " + e.ToString());
                    msgDialogError.ShowAsync();

                }
            }
            else
            {
                MessageDialog msgDialogError = new MessageDialog("Nije moguće dodati vožnju bez svih popunjenih polja");
                msgDialogError.ShowAsync();
            }

        }
        public bool mozeLiSeKupiti(object parametar)
        {
            if (jesteKorisnik == true)
            {
                if (kor != "" && vooznja != "") return true;
                else return false; 
            }
            else
            {
                if (brRacuna != "" && vooznja != "") return true;
                else return false;
            }
        }


       
        public bool mozeLiSelogovat(object parametar)
        {
            return true; 
        }
        public void kupiKartu(object parametar)
        {
            IMobileServiceTable<Rezervacije> userTableObj = App.MobileService.GetTable<Rezervacije>();
            string pom="";
            String mm = vooznja.Substring(12, 6); 
            foreach( char s in mm)
            {
                if (s >= '0' && s <= '9') pom += s;
                else break; 
            }
            Voznja v=null;
            if (jesteKorisnik)
            {
                Klijent jk = null;
                foreach (Voznja h in ZeljeznickaStanica.Voznje)
                {
                    if (h.RB.ToString() == pom) { v = h;
                    }
                }
                foreach (Klijent k in ZeljeznickaStanica.Klijenti)
                {
                    if (k.Username == kor) { jk = k; k.Putovanja.Add(v);  }
                }
                ZeljeznickaStanica.Rezervacije.Add(new Rezervacija(v, jk));
                try
                {

                }
                catch(Exception e)
                {

                }
                MessageDialog msgDialogError = new MessageDialog("Rezervacija je uspješna");
                msgDialogError.ShowAsync();
            }
            else
            {
                ZeljeznickaStanica.zaGoste.Add(new Tuple<string, Voznja>(brRacuna, v));
                MessageDialog msgDialogError = new MessageDialog("Rezervacija je uspješna");
                msgDialogError.ShowAsync();
            }
         
        }
       /* private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Navigate(typeof(MainPage)); 
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Frame rootFrame = MainPage.Conte
                MainPage OP = new MainPage();
            rootFrame=OP as Frame; 
            Frame.Navigate(typeof(MainPage));
            var host = new Window
            {
                Content = OP
            };
            host.Show();
        }*/
        public void gost(object parametar)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
        }
        public void zaKlijenta(object parametar)
        {
            Klijent kor = ZeljeznickaStanica.NadjiKorisnika(Username, Password);
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage), kor);
        }
        public void zaAdmin(object parametar)
        {
            Supervizor s = ZeljeznickaStanica.Supervizori;
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage), s);
        }
        public void zaZap(object parametar)
        {
            Zaposlenik kor = ZeljeznickaStanica.NAdjiZaposlenika(Username, Password);

            ((Frame)Window.Current.Content).Navigate(typeof(MainPage), kor);
        }
        public void login(object parametar)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(LoginRegistracija));
        }

        public void dodajKomentar(object parametar)
        {
            string komentar = ut + " Ocjena: " + ocjena;
            ZeljeznickaStanica.Utisci.Add(komentar);

        }
        public bool mozeLiSeDodati(object parametar)
        {
             if (ut != "") return true;
              return false;
           
        }
        public async void registracijaAsync(object parametar)
        {

            IMobileServiceTable<Klijenti> userTableObj = App.MobileService.GetTable<Klijenti>();

            if (!String.IsNullOrWhiteSpace(UsernameRegistracija)&& !String.IsNullOrWhiteSpace(Adresa) && !String.IsNullOrWhiteSpace(BrojTelefona)&&!String.IsNullOrWhiteSpace(Potvrda)&& !String.IsNullOrWhiteSpace(PasswordRegistracija) && !String.IsNullOrWhiteSpace(Ime) && !String.IsNullOrWhiteSpace(Email) && !String.IsNullOrWhiteSpace(Prezime))
            {
                if (PasswordRegistracija.Equals(Potvrda))
                {  
                    try
                    {
                        Klijent obicni = new Klijent(Ime, Prezime, DatumRodjenja, UsernameRegistracija, ZeljeznickaStanica.CreateMD5(PasswordRegistracija), Email, BrojTelefona, Adresa);
                        ZeljeznickaStanica.Klijenti.Add(obicni);

                        ((Frame)Window.Current.Content).Navigate(typeof(LoginRegistracija));

                         Klijenti obj = new Klijenti();

                         obj.Email = Email;
                         obj.Username = UsernameRegistracija;
                         obj.Password = ZeljeznickaStanica.CreateMD5(PasswordRegistracija);
                        // obj.obrisan = false;
                         obj.Ime = Ime;
                        obj.Prezime = Prezime; 
                         obj.DatumRodjenja = DatumRodjenja.Date;
                        obj.Adresa = Adresa;
                        obj.BrojTelefona = BrojTelefona; 
                         userTableObj.InsertAsync(obj);

                         MessageDialog msgDialog = new MessageDialog("Registracija uspjesna. Dobrodosli u EtfRailways :)");

                         msgDialog.ShowAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageDialog msgDialogError = new MessageDialog("Error: " + ex.ToString());
                         msgDialogError.ShowAsync();
                    }
                }
                else
                {
                    MessageDialog greskaSifra = new MessageDialog("Potvrda šifre mora se slagati sa unesenom šifrom!");
                     greskaSifra.ShowAsync();
                }
            }
            else
            {
                MessageDialog greska = new MessageDialog("Nije moguća registracija bez popunjavanja svih polja!");
                 greska.ShowAsync();
            }
        }
        private String imeZaPretraziti;

       
        public async void otvori(object parametar)
        {
           
            for (int i = 0; i < ZeljeznickaStanica.Zaposlenici.Count; i++)
            {
                if ((ZeljeznickaStanica.Zaposlenici[i].Ime+" "+ZeljeznickaStanica.Zaposlenici[i].Prezime).Equals(ImeZaPretraziti))
                {
                    ((Frame)Window.Current.Content).Navigate(typeof(zaposlenik),ZeljeznickaStanica.Zaposlenici[i]);
                }
            }
        }

        public async void reg(object parametar)
        {

            //            IMobileServiceTable<Korisnici> userTableObj = App.MobileService.GetTable<Korisnici>();

            if (!String.IsNullOrWhiteSpace(ImeZap) && !String.IsNullOrWhiteSpace(PrezimeZap)  && !String.IsNullOrWhiteSpace(OpisRadnogMjestaZap) && !String.IsNullOrWhiteSpace(BrTelZap))
            {
                IMobileServiceTable<Zaposlenici> userTableObj = App.MobileService.GetTable<Zaposlenici>();
                Zaposlenik z = new Zaposlenik(imeZap, prezimeZap, DatumRodjZap, imeZap + PrezimeZap, ZeljeznickaStanica.CreateMD5(prezimeZap+ "aaa"), imeZap + prezimeZap + "@etf.unsa.ba", BrTelZap, OpisRadnogMjestaZap, ZeljeznickaStanica.Voznje);

                ZeljeznickaStanica.Zaposlenici.Add(z);

                try
                {
                    Zaposlenici obj = new Zaposlenici();

                    obj.Email = imeZap + prezimeZap + "@etf.unsa.ba"; 
                    obj.Username = imeZap+prezimeZap;
                    obj.Password = ZeljeznickaStanica.CreateMD5(prezimeZap+"aaa");
                    // obj.obrisan = false;
                    obj.Ime = imeZap;
                    obj.Prezime = prezimeZap;
                    obj.DatumRodjenja = DatumRodjZap.Date;
                    obj.OpisRadnogMjesta = OpisRadnogMjestaZap; 
                    obj.BrojTelefona = BrTelZap;
                    userTableObj.InsertAsync(obj);
                    MessageDialog greska = new MessageDialog("Uspješno registrovan zaposlenik!");
                    greska.ShowAsync();
                }
                catch (Exception ex)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error: " + ex.ToString());
                    msgDialogError.ShowAsync();
                }




            }
            else
            {
                MessageDialog greska = new MessageDialog("Nije moguća registracija bez popunjavanja svih polja!");
                greska.ShowAsync();
            }
        }
        


        public bool mogucaRegistracija(object parameter)
        {
            return true;
        }

        public async void prijavaAsync(object parametar)
        {

            if (Username == null)
            {
                MessageDialog messageDialog = new MessageDialog("Unesite username");
                messageDialog.ShowAsync();
            }
            else if (Password == null)
            {
                MessageDialog messageDialog = new MessageDialog("Unesite password");
                messageDialog.ShowAsync();
            }
            else
            {
                Password = ZeljeznickaStanica.CreateMD5(Password);
                Klijent kor = ZeljeznickaStanica.NadjiKorisnika(Username, Password);
           
                if (kor == null)
                {
                    Zaposlenik zap = ZeljeznickaStanica.NAdjiZaposlenika(Username, Password);
                    if (zap != null)
                    {
                        ((Frame)Window.Current.Content).Navigate(typeof(zaposlenik), zap);

                    }
                    else if (Username.Equals("admin") && Password.Equals(ZeljeznickaStanica.CreateMD5("123"))){
                        ((Frame)Window.Current.Content).Navigate(typeof(supervizor), supervizori);
                    }
                    else
                    {
                        MessageDialog Poruka = new MessageDialog("Korisnik sa unesenim podacima ne postoji.");
                        Poruka.ShowAsync();
                    }
                }
                else if (kor != null && !kor.Username.Equals("admin"))
                {
                    ((Frame)Window.Current.Content).Navigate(typeof(klijent), kor);
                }
                else
                {
                    ((Frame)Window.Current.Content).Navigate(typeof(supervizor), supervizori);
                }
            }
            Username = "";
            Password = "";
        }

        public bool mogucaPrijava(object parameter)
        {
            return true;
        }




    }
}
