using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugverwaltung.UI
{
    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        /*
        public Vehicle()
        {
            
        }
        
        public Vehicle(string Type, string Model, string Brand)
        {
            this.Type = Type;
            this.Model = Model;
            this.Brand = Brand;
        }
        */
        public override string ToString()
        {
            return $"{Type}, {Brand}, {Model}";
        }
    }
}
