using System;


namespace FahrzeugVerwaltung
{
    public class Program
    {
        static void Main(string[] args)
        {
            // public Vehicle[] vehicleList = new Vehicle[10]; 

            
         
            Menu menu = new Menu();
            menu.FileNamesShow();
           
           
            do
	        {
            menu.ShowMenu();
            menu.ChooseProgram();
	        } while (menu.MenuIsOn);
        }
    }


    
}
