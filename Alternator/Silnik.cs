using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternator
{
    class Silnik
    {
        private int ilośćCewek;
        private double kątRozłożeniaCewek;
        private double prędkośćMaksymalna; // pola silnika
        public Silnik(int ilośćCewek = 2) // konstruktor silnika z domyślnymi danymi
        {
            IlośćCewek = ilośćCewek;
        }
        public int IlośćCewek
        {
            get
            {
                return ilośćCewek;
            }
            private set
            {
                if (IlośćCewek % 2 == 0) // warunek dzielenia przez 2 bez reszty settera
                {
                    ilośćCewek = value;
                    policzUstawienieCewek();
                    MaksymalnaPrędkość();
                }
            }
        }
        public double PrędkośćMaksymalna
        {
            get
            {
                return prędkośćMaksymalna;
            }
            set
            {
                prędkośćMaksymalna = value;
            }
        }
        public double KątRozłożeniaCewek
        {
            get
            {
                return kątRozłożeniaCewek;
            }
        }
        private void policzUstawienieCewek()
        {
            kątRozłożeniaCewek = 720 / IlośćCewek; // wzór na rozłożenie cewek na stojanie
        }
        private void MaksymalnaPrędkość()
        {
            PrędkośćMaksymalna = 6000 / IlośćCewek; // wzór na maksymalną predkość na podstawie ilości biegunów
        }
    }
}
