using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.Shared
{
    public class LKW : Vehicle
    {
        public double Capacity; // Gibt die Frachtkapazität an


        public LKW(double capacity)
        {
            this.Capacity = capacity;
        }
    }
}
