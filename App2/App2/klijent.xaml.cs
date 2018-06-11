using App2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class klijent : Page
    {
        private klijent a;
        public klijent()
        {
           
            this.InitializeComponent();
        }
        public klijent(klijent k)
        {

        }

        public klijent A { get => a; set => a = value; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Klijent k = (Klijent)e.Parameter;
            DobroDosli.Text = "Dobro došli, " + k.Ime;
            Ime.Text = k.Ime;
            Prezime.Text = k.Prezime;
            Adresa.Text = k.Adresa;
            Email.Text = k.EMail;
            BrTel.Text = k.BrojTelefona;
            if(k.Putovanja.Count!=0)
            foreach(Voznja v in k.Putovanja)
            {
               ListaPutovanja.Items.Add(v.ToString());
            }

        }
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            MessageDialog greska = new MessageDialog("Greška pri odabiru kjkjaslike!");
            greska.ShowAsync();
            Klijent k = e.NavigationParameter as Klijent;
            Ime.Text = k.Ime;
            Prezime.Text = k.Prezime;
            Adresa.Text = k.Adresa;
            Email.Text = k.EMail;
            BrTel.Text = k.BrojTelefona;
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
