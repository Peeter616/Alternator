using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alternator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Silnik s1;
        Silnik s2;
        Silnik s3;
        Alternator a1;
        Alternator a2;
        Alternator a3;

        private void rysowanie_Click(object sender, EventArgs e)
        {
            a1 = new Alternator(Convert.ToDouble(Io1.Value), Convert.ToDouble(In1.Value), Convert.ToInt32(p1.Value * 2));
            a2 = new Alternator(Convert.ToDouble(Io2.Value), Convert.ToDouble(In2.Value), Convert.ToInt32(p2.Value * 2));
            a3 = new Alternator(Convert.ToDouble(Io3.Value), Convert.ToDouble(In3.Value), Convert.ToInt32(p3.Value * 2));
            a1.rysuj(chart1, 0, Convert.ToInt32(n.Value), Convert.ToInt32(nPro.Value));
            a2.rysuj(chart1, 1, Convert.ToInt32(n.Value), Convert.ToInt32(nPro.Value));
            a3.rysuj(chart1, 2, Convert.ToInt32(n.Value), Convert.ToInt32(nPro.Value));
        }
    }
}
