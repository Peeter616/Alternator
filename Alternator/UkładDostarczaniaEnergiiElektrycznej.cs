using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alternator
{
    abstract class UkładDostarczaniaEnergiiElektrycznej
    {
        protected double[] napięcie;
        protected double strumień;
        public UkładDostarczaniaEnergiiElektrycznej(){}
        abstract public double policzNapięcie(int x, int n, int i); // informacja aby w dzidziczących klasach zawrzeć wzór na napięcie
        abstract public void policzStrumień(); // informacja aby w dzidziczących klasach zawrzeć wzór na strumień
    }
}
