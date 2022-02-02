using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung
{

    public abstract class Vehicle
    {

        public int Ident { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public Vehicle(int Ident, string Brand, string Model)
        {
            this.Ident = Ident;
            this.Brand = Brand;
            this.Model = Model;
        }

        public static void Save(int id, List<Vehicle> myVehicles)
        {
            Console.WriteLine("Welchen Typ wollen sie anlegen?");
            Console.WriteLine("1) PKW");
            Console.WriteLine("2) LKW");
            int eingabe = Convert.ToInt32(Console.ReadLine());
           switch(eingabe)
            {
                case 1:
                    Console.WriteLine("Automatische ID: " + id);
                    Console.WriteLine("Bitte geben sie nun die Marke ein");
                    string marke = Console.ReadLine();
                    Console.WriteLine("Bitte geben sie nun das Modell an");
                    string modell = Console.ReadLine();
                    myVehicles.Add(new PKW(id, marke, modell));
                    break;

                case 2:
                    Console.WriteLine("Bitte Frachtkapazität eingeben: ");
                    double fracht = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Automatische ID: " + id);
                    Console.WriteLine("Bitte geben sie nun die Marke ein");
                    marke = Console.ReadLine();
                    Console.WriteLine("Bitte geben sie nun das Modell an");
                    modell = Console.ReadLine();
                    myVehicles.Add(new LKW(id, marke, modell, fracht));
                    break;
            }

            

            Console.WriteLine("Fahrzeug wurde erstellt");
        }

        public static void Delete(List<Vehicle> myVehicles)
        {
            Console.WriteLine("Geben sie die ID des Fahrzeugs an, welches sie löschen möchten");
            int idLoeschen = Convert.ToInt32(Console.ReadLine());
            myVehicles.RemoveAt(idLoeschen-1);
        }

        public static void Update(List<Vehicle> myVehicles)
        {
            Console.WriteLine("Geben sie ihre Identifikationsnummer ein");
            int ident = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geben sie die Marke ein: ");
            string newMarke = Console.ReadLine();
            myVehicles[ident - 1].Brand = newMarke;
            Console.WriteLine("Geben sie das Modell ein: ");
            string newModell = Console.ReadLine();
            myVehicles[ident - 1].Model = newModell;
        }

        public static void GetAll(List<Vehicle> myVehicles)
        {
            myVehicles.ForEach(e => Console.WriteLine(e.Ident + " " + e.Brand + " " + e.Model));
        }








    }
}
