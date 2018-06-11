using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace App2.Model
{
    public class Grad
    {
        private string informacijeOGradu;
        private string imeGrada;
        private ImageSource slikaGrada;
        private ImageSource mapaGrada;

       public Grad(string informacijeOGradu, string imeGrada)
        {
            InformacijeOGradu = informacijeOGradu;
            ImeGrada = imeGrada;
        }

        public Grad(string informacijeOGradu, string imeGrada, ImageSource slikaGrada, ImageSource mapagr )
        {
            InformacijeOGradu = informacijeOGradu;
            ImeGrada = imeGrada;
            SlikaGrada = slikaGrada;
            MapaGrada = mapagr; 
        }

        public string InformacijeOGradu { get => informacijeOGradu; set => informacijeOGradu = value; }
        public string ImeGrada { get => imeGrada; set => imeGrada = value; }
        public ImageSource SlikaGrada { get => slikaGrada; set => slikaGrada = value; }
        public ImageSource MapaGrada { get => mapaGrada; set => mapaGrada = value; }
    }
}
