using System;
using System.Collections.Generic;

namespace FahrzeugVerwaltung
{
    public class Program
    {

        private static List<Vehicle> myVehicles = new List<Vehicle>();
        private static int id = 0;

        static void Main(string[] args)
        {
            bool schleife = true;
                do
            {
                    Console.WriteLine("Hallo herzlich willkommen!");
                    Console.WriteLine("1) Vehicle anlegen");
                    Console.WriteLine("2) Vehicle löschen ");
                    Console.WriteLine("3) Alle Vehicle anzeigen");
                    Console.WriteLine("4) Vehicle bearbeiten");
                    Console.WriteLine("10) Programm beenden");
                

                    try
                {
                    int eingabe = Convert.ToInt32(Console.ReadLine());
                    switch (eingabe)
                    {
                        case 1:
                            id += 1;
                            Vehicle.Save(id, myVehicles);
                            break;

                        case 2:
                            Vehicle.Delete(myVehicles);
                            break;

                        case 3:
                            Vehicle.GetAll(myVehicles);
                            break;

                        case 4:
                            Vehicle.Update(myVehicles);
                            break;

                        case 10:
                            schleife = false;
                            break;
                        default:
                            schleife = false;
                            break;
                    }



                } catch (System.FormatException)
                {
                    Console.WriteLine("Zahl eingeben");
                    
                }
                    

                

 
            } while (schleife);


            
        }
    }
}
