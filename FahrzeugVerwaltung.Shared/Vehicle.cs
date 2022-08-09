using System;

namespace FahrzeugVerwaltung.Shared
{
    public class Vehicle
    {
        public int Ident;
        public string Brandt;
        public string Model;
        public VehicleType VehicleType { get; set; }
        public Vehicle(int newIdent, string BrandtName, string ModelName, VehicleType vehicleType)
        {
            Ident = newIdent;
            Brandt = BrandtName;
            Model = ModelName;
            VehicleType = vehicleType;
        }

        public Vehicle()
        {

        }
        public Vehicle(int id, string BrandtName, string ModelName)
        {
            Ident = id;
            Brandt = BrandtName;
            Model = ModelName;
        }

    }

}
