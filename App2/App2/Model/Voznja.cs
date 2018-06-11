using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace App2.Model
{
    public class Voznja
    {
        public  static  int  redniBroj;
        private int rB; 
        private double cijena;
        private string tipVoza;
        private int brojLinije;
        private int brojSjedista;
        private DateTimeOffset vrijemePolaska;
        private DateTimeOffset vrijemeDolaska;
        private string mjestoPolaska;
        private string mjestoDolaska;

        public Voznja( double cijena, string tipVoza, int brojLinije, int brojSjedista, DateTimeOffset vrijemePolaska, DateTimeOffset vrijemeDolaska, string mjestoPolaska, string mjestoDolaska)
        {
            redniBroj++;
            RB = redniBroj; 
            Cijena = cijena;
            TipVoza = tipVoza;
            BrojLinije = brojLinije;
            BrojSjedista = brojSjedista;
            VrijemePolaska = vrijemePolaska;
            VrijemeDolaska = vrijemeDolaska;
            MjestoPolaska = mjestoPolaska;
            MjestoDolaska = mjestoDolaska;
        }

        public double Cijena { get => cijena; set => cijena = value; }
        public string TipVoza { get => tipVoza; set => tipVoza = value; }
        public int BrojLinije { get => brojLinije; set => brojLinije = value; }
        public int BrojSjedista { get => brojSjedista; set => brojSjedista = value; }
        public DateTimeOffset VrijemePolaska { get => vrijemePolaska; set => vrijemePolaska = value; }
        public DateTimeOffset VrijemeDolaska { get => vrijemeDolaska; set => vrijemeDolaska = value; }
        public string MjestoPolaska { get => mjestoPolaska; set => mjestoPolaska = value; }
        public string  MjestoDolaska { get => mjestoDolaska; set => mjestoDolaska = value; }
        public static int  RedniBroj { get => redniBroj; set => redniBroj = value; }
        public int RB { get => rB; set => rB = value; }

        public static double naplata(string tipv, DateTimeOffset d)
        {
            double c =100;
            if (tipv.Equals("Brzi Voz")) c = c + c * 0.3;
            if (d.Day.ToString().Equals("Saturday")) c = c + c * 0.2; 
            return c; 
        }
        public String ToString()
        {
            return "Redni broj: "+RB+ ". Tip voza: " + tipVoza + " Broj linije: " + brojLinije + " Broj sjedista: " + BrojSjedista + " Vrijeme polaska: " + VrijemePolaska + " Vrijeme dolaska: " + vrijemeDolaska + " Mjesto polaska: " + mjestoPolaska + " Mjesto dolaska: " + mjestoDolaska; 
        }
    }
    
}
