using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Azure
{
    class Voznje
    {
        public string id
        {
            get; set;
        }
        public double Cijena
        {
            get; set;
        }
        public string TipVoza
        {
            get; set;
        }
        public int BrojLinije
        {
            get; set;
        }
        public int BrojSjedista
        {
            get; set;
        }
        public DateTime VrijemePolaska
        {
            get; set;
        }
        public DateTime VrijemeDolaska
        {
            get; set;
        }
        public string MjestoPolaska
        {
            get; set;
        }
        public string MjestoDolaska
        {
            get; set;
        }
    }
}
