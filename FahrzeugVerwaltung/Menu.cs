using System;
using System.Collections.Generic;
using FahrzeugVerwaltung.Shared;
using FahrzeugVerwaltung.Service;
using System.Threading;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung
{
    public class Menu
    {
        public bool MenuIsOn;

       
        public List<Vehicle> VehicleList2 = new List<Vehicle>();
        public VehicleConsoleService VehicleConsoleService = new VehicleConsoleService();
        public Functions MyFunctions = new Functions();


        public Menu()
        {
            bool MenuIsOn = false;
        }

        public void ShowMenu()
        {
            
            MenuIsOn = true;
            Console.WriteLine("******************************************");
            Console.WriteLine("  Hallo und herzlich willkommen!\r\n   " +
                "Bitten wählen Sie die Aktion aus\r\n" +
                "1) Vehicle anlegen\r\n" +
                "2) Vehicle löschen \r\n" +
                "3) Alle Vehicle anzeigen\r\n" +
                "4) Vehicle bearbeiten\r\n" +
                "5) Speichern\r\n" +
                "10) Programm beenden");
            Console.WriteLine("******************************************");

        }

        

        public void ChooseProgram()
        {
            int chosen = MyFunctions.IntInput();

            switch (chosen)
            {
                case 1:
                    VehicleAnlegen();
                    break;
                case 2:
                    VehicleLöschen();
                    break;
                case 3:
                    AlleVehicleAnzeigen();
                    break;
                case 4:
                    VehicleBearbeiten();
                    break;
                case 5:
                    VehicleListSaveAsJson();
                    break;
                case 10:
                    ProgrammBeenden();
                    break;
                default:
                    break;
            }
        }

        public Vehicle createVehicle(int choice)
        {
            string Type = choice == 2 ? "LKW" : "PKW";

            VehicleType VehicleType = new VehicleType(Type);

            double capacity = 0;
            if (Type == "LKW")
            {
                Console.WriteLine("Bitte geben Sie die Frachtkapazität in kg an");
                capacity = double.Parse(Console.ReadLine());
            }


            Console.WriteLine("Bitten Geben sie nun die Id ein");
            int Ident = MyFunctions.IntInput();
            Console.WriteLine("Bitten Geben sie nun die Marke ein");
            string Marke = MyFunctions.StringInput();
            Console.WriteLine("Bitten Geben sie nun das Modell ein");
            string Model = MyFunctions.StringInput();
            if (Type == "LKW")
            {
                LKW newVehicle = new LKW(capacity);
                newVehicle.Ident = Ident;
                newVehicle.Brandt = Marke;
                newVehicle.Model = Model;
                newVehicle.VehicleType = VehicleType;
                return newVehicle;
            }

            PKW NewVehicle = new PKW();
            NewVehicle.Ident = Ident;
            NewVehicle.Brandt = Marke;
            NewVehicle.Model = Model;
            NewVehicle.VehicleType = VehicleType;
            return NewVehicle;
        }


        public int chooseTypeOfVehicle()
        {
            Console.WriteLine("Welchen Typ wollen Sie anlegen");
            Console.WriteLine("1) PKW");
            Console.WriteLine("2) LKW");
            int choice = MyFunctions.IntInput();
            // choice is not 1 or 2 ?? exception
            if (choice < 1 & choice > 2)
            {
                Console.WriteLine("Bitte geben Sie eine gültige Option");
                choice = chooseTypeOfVehicle();
            }
            else
            {
                return choice;
            }
            return choice;
        }
        public void VehicleAnlegen()
        {
            Console.WriteLine("------------------------------------------");
            int choice = chooseTypeOfVehicle();
            Vehicle newVehicle = createVehicle(choice);
            ThreadMethode(newVehicle);
           


            Console.WriteLine("------------------------------------------");
        }
        public void VehicleLöschen()
        {
            Console.WriteLine("------------------------------------------");
            AlleVehicleAnzeigen();
            Console.WriteLine("Bitten Geben sie nun die Id von Vehicle ein, " +
                "die Sie löschen will");

            Functions MyFunctions = new Functions();
            int Ident = MyFunctions.IntInput();
            List<Vehicle> VehicleList = VehicleConsoleService.GetAll();
            int index = VehicleList.FindIndex(a => a.Ident == Ident);

            Vehicle vehicle = VehicleList[index];
            VehicleConsoleService.Delete(vehicle, index);
            MyFunctions.SuccessMessage("Vehicle ist gelöscht.");

            Console.WriteLine("------------------------------------------");
        }

        public void AlleVehicleAnzeigen()
        {
            Console.WriteLine("------------------Vehicle List Start------------------------");
            Console.WriteLine("Alle gespeicherte Vehicle: ");
           List<Vehicle> VehicleList = VehicleConsoleService.GetAll();

            foreach(Vehicle v in VehicleList)
            {
                Console.WriteLine("Ident: " + v.Ident);
                Console.WriteLine("Model: " + v.Model);
                Console.WriteLine("Brandt: " + v.Brandt);
                Console.WriteLine("Type: " + v.VehicleType.Type);
                


            }
            Console.WriteLine("---------------------Vehicle List End---------------------");
        }
        public void VehicleBearbeiten()
        {
            Functions MyFunctions = new Functions();
            Console.WriteLine("------------------------------------------");
            AlleVehicleAnzeigen();
            Console.WriteLine("Geben Sie die Vehicle Ident um zu bearbeiten: ");
            int Ident = MyFunctions.IntInput();
            
            List<Vehicle> VehicleList = VehicleConsoleService.GetAll();
           
            int index = VehicleList.FindIndex(a => a.Ident == Ident);
            int choice = chooseTypeOfVehicle();
            Vehicle NewVehicle = createVehicle(choice);
          
            VehicleConsoleService.Update(NewVehicle, index);
            MyFunctions.SuccessMessage("Vehicle ist aktualisiert.");
            Console.WriteLine("------------------------------------------");
        }

        public void VehicleListSaveAsJson() {
            Console.WriteLine("Bitte geben Sie die Name von Datei an; ");
            string FileName = MyFunctions.StringInput();
            VehicleConsoleService.SaveVehicleListAsJson(FileName);
            MyFunctions.SuccessMessage("VehicleList ist gespeichert.");

        }
        public void VehicleListLoad(string FileName)
        {
            VehicleConsoleService.VehicleListLoad(FileName);
        }
        // Gets all file names and show it to user
        public void FileNamesShow()
        {
            List<string> FileNames = VehicleConsoleService.GetFileNames();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Bitte wählen Sie einen Datei aus: ");
            Console.ResetColor();
            int i = 1;
            foreach (string FileName in FileNames)
            {

                Console.WriteLine($"{i}) {FileName}");
                i++;
            }

            int choice = MyFunctions.IntInput();
            int indexOfFileName = choice - 1;
            VehicleListLoad(FileNames[indexOfFileName]);

        }

   

        public async void ThreadMethode(Vehicle vehicle)
        {
            var task1 = Task.Run(() => MyFunctions.Animation());
            var task2 = Task.Run(() => CheckForDouble(vehicle));
            await Task.WhenAll(new[] { task1, task2 });
            
            bool isDouble = task2.Result;

            if (isDouble)
            {
                MyFunctions.FailMessage("Doppeltes Element!!");

            }
            else
            {
                VehicleConsoleService.Save(vehicle);
            }

        }

        public bool CheckForDouble(Vehicle newVehicle)
        {
            bool isDouble = false;

            List<Vehicle> VehicleList =  VehicleConsoleService.GetAll();

            foreach (Vehicle vehicle in VehicleList)
            {
                if(vehicle.Model == newVehicle.Model &&
                    vehicle.Brandt == newVehicle.Brandt &&
                    vehicle.VehicleType.Type == newVehicle.VehicleType.Type
                    )
                {
                    isDouble = true;
                    return isDouble;
                   
                }
            }
            return isDouble;
        }


        public void ProgrammBeenden()
        {
            MenuIsOn = false;
        }
    }
}