using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App2.Model;
using App2.ViewModel;
using Windows.UI.Popups;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
 
        private string gr;
        public String Gr { get => gr; set => gr = value; }
        
        public List<String> ONama = new List<string> {"", "Ugledni britanski list Guardian uvrstio je Bosnu i Hercegovinu među 18 zemalja u svijetu u kojima se"," može najbolje doživjeti avantura putovanja vozom.",
            "Osnovne djelatnosti društva su: ", "·          obavljanje domaćeg, međuentitetskog i međunarodnog transporta putnika i tereta uključujući","kombinovani transport;  ", "·         održavanje, rekonstrukcija, modernizacija, izgradnja objekata voznog parka (uključujući vuču) i druge","opreme neophodne za pružanje usluga prijevoza;", "·          održavanje, rekonstrukcija, modernizacija i razvoj željezničke infrastrukture; "
        , "·          organizacija  i sigurnost željezničkog saobraćaja."};
        public List<String> Zanimljivosti = new List<String> {"Pored vožnje živopisnim prugama Sicilije, Korzike, Norveške, Zambije, Meksika, Tibeta ili Perua, među", "najljepšim dionicama našla se i pruga Sarajevo-Mostar duga 129 kilometara. "};
        public List<String> buducnost = new List<string> { "Za naredni period planira aktivan odnos prema tržištu i korisnicima.", "Razvija marketinški pristup unapređenja i podizanja kvaliteta transportne usluge;" };
        public List<string> konacnaListaVoznji= new List<string>();
        public List<string> utisciK =ZeljeznickaStanica.Utisci;
        public List<string> brojevi = new List<string>() {"1", "2", "3", "4", "5" };
        public MainPage()
        {
            foreach (Voznja v in ZeljeznickaStanica.Voznje) konacnaListaVoznji.Add(v.ToString());
            utisciK = ZeljeznickaStanica.Utisci;
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Klijent kk = (Klijent)e.Parameter;
            if (kk!=null)
            {
               
                MessageDialog greska = new MessageDialog(kk.Username + kk.Password);
                greska.ShowAsync();
                foreach (Klijent k in ZeljeznickaStanica.Klijenti)
                {
                    if (k.Username.Equals(kk.Username) && k.Password.Equals(ZeljeznickaStanica.CreateMD5(kk.Password)))
                    {
                        ((Frame)Window.Current.Content).Navigate(typeof(klijent), kk);
                        break;
                    }
                }
            }
            else
            {
                Zaposlenik z = (Zaposlenik)e.Parameter;
                if(z!=null)
                foreach (Zaposlenik k in ZeljeznickaStanica.Zaposlenici)
                {
                    if (k.Username.Equals(z.Username) && k.Password.Equals(ZeljeznickaStanica.CreateMD5(z.Password)))
                    {
                        ((Frame)Window.Current.Content).Navigate(typeof(zaposlenik), k);  break;
                    }
                }
                else
                {
                    Supervizor s = (Supervizor)e.Parameter;

                   /* if (s.Username.Equals(ZeljeznickaStanica.Supervizori.Username) &&
              s.Password.Equals(ZeljeznickaStanica.Supervizori.Password))
                        ((Frame)Window.Current.Content).Navigate(typeof(supervizor), ZeljeznickaStanica.Supervizori);*/
                }
            }
           
          
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            foreach (Grad g in ZeljeznickaStanica.Gradovi)
            {
                if (g.ImeGrada == imegrada.Text)
                {
                  
                    oGradu.Text = g.InformacijeOGradu;
                    Slikagr.Source = g.SlikaGrada;
                    mapa.Source = g.MapaGrada;
                }
                else
                {
                    oGradu.Text = ""; 
                }
            }

        }

        private void unesi_Click(object sender, RoutedEventArgs e)
        {
            if(ZeljeznickaStanica.Utisci.Count!=0)            
            listaUtisaka.Items.Add(ZeljeznickaStanica.Utisci.ElementAt(ZeljeznickaStanica.Utisci.Count - 1));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ime_i_prezime.Text = "";
            Broj_licne.Text = "";
            Broj_racuna.Text = "";
            Broj_telefona.Text = "";
            jedan.IsChecked = false;
            dva.IsChecked = false;
            tri.IsChecked = false;
            E_Mail.Text = "";
            Izaberi_liniju.SelectedIndex=0;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Gost.IsChecked == true)
            {
                Ime_i_prezime.IsEnabled = true;
                E_Mail.IsEnabled = true;
                Broj_licne.IsEnabled = true;
                Broj_racuna.IsEnabled = true;
                Broj_telefona.IsEnabled = true;
                datRodj.IsEnabled = true;
                kor_ime.IsEnabled = false;
           //     rez.IsEnabled = false;

            }
            else if (Korisnik.IsChecked == true)
            {
                Ime_i_prezime.IsEnabled = false;
                E_Mail.IsEnabled = false;
                Broj_licne.IsEnabled = false;
                Broj_racuna.IsEnabled = false;
                Broj_telefona.IsEnabled = false;
                datRodj.IsEnabled = false;
                kor_ime.IsEnabled = true;
             //   rez.IsEnabled = true;
            }
            else
            {
                Ime_i_prezime.IsEnabled = false;
                E_Mail.IsEnabled = false;
                Broj_licne.IsEnabled = false;
                Broj_racuna.IsEnabled = false;
                Broj_telefona.IsEnabled = false;
                datRodj.IsEnabled = false;
                kor_ime.IsEnabled = false;
              //  rez.IsEnabled = false;
            }
        }
    }
}
