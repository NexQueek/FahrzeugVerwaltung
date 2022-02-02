using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung.UI
{
    abstract public class Vehicle
    {
        public int Ident { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Vehicle()
        {
            this.Ident = -1;
            this.Brand = "N/A";
            this.Model = "N/A";
        }
        public Vehicle(int Ident, string Brand, string Model)
        {
            this.Ident = Ident;
            this.Brand = Brand;
            this.Model = Model;
        }

        public override string ToString()
        {
            return $"[{Ident}] {Brand} {Model}";
        }
    }
}
