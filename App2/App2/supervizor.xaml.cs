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
    public sealed partial class supervizor : Page
    {
        public supervizor()
        {
            this.InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {

        }
       
        private void Button_Click123(object sender, RoutedEventArgs e)
        {
            NovaLista.Items.Clear();
            for (int i = 0; i < ZeljeznickaStanica.Zaposlenici.Count; i++)
            {
                if ((ZeljeznickaStanica.Zaposlenici[i].Ime+" " + ZeljeznickaStanica.Zaposlenici[i].Prezime).Equals(pret.Text))
                {
                    NovaLista.Items.Add(ZeljeznickaStanica.Zaposlenici[i].Ime + " " + ZeljeznickaStanica.Zaposlenici[i].Prezime);
                }
            }

        }
        private void Button_Click12(object sender, RoutedEventArgs e)
        {
            Zaposleni.Items.Clear();
            for (int i = 0; i < ZeljeznickaStanica.Zaposlenici.Count; i++)
            {
                if (ZeljeznickaStanica.Zaposlenici[i].Ime.Equals(ZaPretragu.Text))
                {
                    Zaposleni.Items.Add(ZeljeznickaStanica.Zaposlenici[i].Ime + " " + ZeljeznickaStanica.Zaposlenici[i].Prezime);
                }
            }

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Supervizor k = (Supervizor)e.Parameter;
            DobroDosli.Text = "Dobro došli, " + k.Ime;
            Ime.Text = k.Ime;
            DatumRodjenja.Text = k.DatumRodjenja.ToString();
            Prezime.Text = k.Prezime;
            Email.Text = k.EMail;
            BrojTelefona.Text = k.BrTel;
        }
        private void ObrisiZaposlenika()
        {
         

        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_111(object sender, RoutedEventArgs e)
        {
            bool ima = false;
            for (int i = 0; i < ZeljeznickaStanica.Zaposlenici.Count; i++)
            {
                if (Zaposleni.SelectedItem != null)
                {
                    if ((ZeljeznickaStanica.Zaposlenici[i].Ime + " " + ZeljeznickaStanica.Zaposlenici[i].Prezime).Equals(Zaposleni.SelectedItem.ToString()))
                    {
                        ima = true;
                        ZeljeznickaStanica.Zaposlenici.RemoveAt(i);
                        MessageDialog greska1 = new MessageDialog("Zaposlenik je uspješno obrisan!");
                        greska1.ShowAsync();
                    }
                }
            
               
            }
            if (!ima)
            {
                MessageDialog greska = new MessageDialog("Molimo izaberite zaposlenika!");
                greska.ShowAsync();

            }
            Zaposleni.Items.Clear();

        }

       


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

     

     


        private void PivotItem_Loading(FrameworkElement sender, object args)
        {
            ZaPretragu.Text = "";
            b.Text = "";
            c.Text = "";
            d.Text = "";
            ef.Text = "";
            Zaposleni.Items.Clear();
        }

        private void PivotItem_Loading_1(FrameworkElement sender, object args)
        {
            pret.Text = "";
            b.Text = "";
            c.Text = "";
            d.Text = "";
            ef.Text = "";
            NovaLista.Items.Clear();
        }

        private void PivotItem_Loading_2(FrameworkElement sender, object args)
        {
            ZaPretragu.Text = "";
            NovaLista.Items.Clear();
            pret.Text = "";
            Zaposleni.Items.Clear();

        }
    }
}
