using Fahrzeugverwaltung.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.Service
{
    public class VehicleConsoleService
    {
        List<Vehicle> vehicleList = new List<Vehicle>();
        public void Save()
        {
            Console.WriteLine("Welchen Typ wollen Sie anlegen" +
                              "\n1) PKW" +
                              "\n2) LKW");
            int type = int.Parse(Console.ReadLine());

            Console.WriteLine("Bitte geben Sie nun die Id ein");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie nun die Marke ein");
            string marke = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie nun das Modell ein");
            string model = Console.ReadLine(); ;

            switch (type)
            {
                case 1:
                    vehicleList.Add(new PKW(id, marke, model));
                    Console.WriteLine("PKW wurde angelegt");
                    break;
                case 2:
                    Console.WriteLine("Bitte geben Sie die Frachtkapazität an");
                    int cap = int.Parse(Console.ReadLine());
                    vehicleList.Add(new LKW(id, marke, model, cap));
                    Console.WriteLine("LKW wurde angelegt");
                    break;
                default:
                    Console.WriteLine("Fahrzeug wurde angelegt");
                    break;
            }
        }
        public void Delete()
        {
            int id = int.Parse(Console.ReadLine());
            foreach (Vehicle vehicle in vehicleList)
                if (vehicle.Ident == id)
                    vehicleList.Remove(vehicle);
            Console.WriteLine("Fahrzeug wurde gelöscht");
        }
        public void Update()
        {
            Console.WriteLine("Geben Sie bitte nun den Ident ein");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie nun die Marke ein");
            string marke = Console.ReadLine();
            Console.WriteLine("Bitte geben Sie nun das Modell ein");
            string model = Console.ReadLine();
            foreach (Vehicle vehicle in vehicleList)
                if (vehicle.Ident == id)
                {
                    vehicle.Brand = marke;
                    vehicle.Model = model;
                }
            Console.WriteLine($"Fahrzeug mit dem Ident {id} wurde bearbeitet");
        }
        public void GetAll()
        {
            Console.WriteLine("----------------------");
            foreach (Vehicle v in vehicleList)
            {
                Console.WriteLine(v.ToString());
            }
            Console.WriteLine("----------------------");
        }
    }
}
