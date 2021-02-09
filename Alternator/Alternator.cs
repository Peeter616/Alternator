using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternator
{
    class Alternator : UkładDostarczaniaEnergiiElektrycznej
    {
        Silnik s1;
        double prądObciążenia;
        double prądZnamionowy;
        double dv = 0;

        public Alternator() : base() { }
        public Alternator(double prądObciążenia, double prądZnamionowy, int ilośćCewek) : this()
        {
            PrądObciążenia = prądObciążenia;
            PrądZnamionowy = prądZnamionowy;
            s1 = new Silnik(ilośćCewek);
        }

        public double PrądObciążenia
        {
            get
            {
                return prądObciążenia;
            }
            set
            {
                prądObciążenia = value;
            }
        }

        public double PrądZnamionowy
        {
            get
            {
                return prądZnamionowy;
            }
            set
            {
                prądZnamionowy = value;
            }
        }

        override public double policzNapięcie(int x, int n, int i)
        {
            return strumień * 0.01 * x * krok(n) * i * prądObciążenia / prądZnamionowy * 0.1; // 0.01 * x * krok(n) = chwilowa predkosc
        }
        override public void policzStrumień()
        {
            strumień = 5 * s1.KątRozłożeniaCewek / 360; // 5 - ilość zwoi
        }
        public double krok(int n)
        {
            return s1.PrędkośćMaksymalna / n; // wzór na krok
        }

        public void rysuj(System.Windows.Forms.DataVisualization.Charting.Chart wykres, int nrAlternatora, int n, int x)
        {
            policzStrumień();
            napięcie = new double[n];
            wykres.Series[nrAlternatora].Points.Clear();
            wykres.Series[nrAlternatora].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            for (int i = 0; i < n; i++)
                napięcie[i] = dv;
            for (int i = 0; i < n; i ++)
            {
                wykres.Series[nrAlternatora].Points.AddXY(dv, Convert.ToInt32(policzNapięcie(x, n, i)));
                dv += krok(n);
            }
            dv = 0;
        }

        public void czyść(System.Windows.Forms.DataVisualization.Charting.Chart wykres, int nrAlternatora)
        {
            wykres.Series[nrAlternatora].Points.Clear();
        }
    }
}
