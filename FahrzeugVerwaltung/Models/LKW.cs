using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung.UI
{
    public class LKW : Vehicle
    {
        public double Capacity { get; set; }
        public LKW(int Ident, string Brand, string Model, double Capacity ) : base(Ident, Brand, Model)
        {
            this.Capacity = Capacity;
        }
        public override string ToString()
        {
            return $"[{Ident}] {Brand} {Model}, Capacity: {Capacity}";
        }
    }
}
