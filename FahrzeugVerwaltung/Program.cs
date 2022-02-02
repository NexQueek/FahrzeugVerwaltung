using System;
using System.Collections.Generic;
using FahrzeugVerwaltung.Service;

namespace FahrzeugVerwaltung
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World!");
            Console.ReadLine();
            */
            VehicleConsoleService vcs = new VehicleConsoleService();
            int choice = -1;
            do
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("* Hallo herzlich willkommen!      *");
                Console.WriteLine("* Bitte wählen Sie die Aktion aus *");
                Console.WriteLine("***********************************");
                Console.WriteLine(
                    "1) Vehicle anlegen\n" +
                    "2) Vehicle löschen\n" +
                    "3) Alle Vehicles anzeigen\n" +
                    "4) Vehicle bearbeiten\n" +
                    "10) Programm beenden\n");
                try
                {
                    Console.Write(">");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            vcs.Save();
                            break;
                        case 2:
                            vcs.Delete();
                            break;
                        case 3:
                            vcs.GetAll();
                            break;
                        case 4:
                            vcs.Update();
                            break;
                        case 10:
                            Console.WriteLine("Cya!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Fehlerhafte Eingabe! ({e.Message})");
                }
            } while (choice != 10);
        }
    }
}
