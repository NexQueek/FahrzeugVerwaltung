using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung
{
    public class LKW : Vehicle
    {

        private double Capacity { get; set; }

        public LKW(int Ident, string Brand, string Model, double Capacity) : base(Ident, Brand, Model)
        {
            this.Capacity = Capacity;  
        }
    }
}
