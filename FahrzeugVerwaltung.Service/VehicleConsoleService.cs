using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FahrzeugVerwaltung.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FahrzeugVerwaltung.Service
{
   

    public class VehicleConsoleService
    {
        public List<Vehicle> VehicleList = new List<Vehicle>();
       
        public Functions MyFunctions = new Functions();
        public VehicleConsoleService()
        {

        }
  
        //Soll ein Vehicle hinzufügen können
        public void Save(Vehicle vehicle) {
            VehicleList.Add(vehicle);
            MyFunctions.SuccessMessage("Neue hinzugefügt..");
        }
       
        
        
        // Soll ein Vehicle löschen können
        public void Delete(Vehicle vehicle, int index) {
            // Remove index and make it with vehicle later 
            VehicleList.RemoveAt(index);
        } 
        //Soll ein Vehicle editieren können
        public void Update(Vehicle vehicle, int index) {         
            VehicleList[index] = vehicle;
        }
        
        //Soll alle Vehicle anzeigen
        public List<Vehicle> GetAll() {
            return VehicleList;
        } 

        public void SaveVehicleListAsJson(string FileName)
        {
            string FilePath = $"C:/dev/{FileName}.json";
            string VehicleListJson =  JsonConvert.SerializeObject(VehicleList);
            File.WriteAllText(@FilePath, VehicleListJson.ToString());

        }

        public void VehicleListLoad(string FileName)
        {
            string[] test = File.ReadAllLines(@$"C:/dev/{FileName}");
            List<Vehicle> v = JsonConvert.DeserializeObject<List<Vehicle>>(test[0]);
            VehicleList = v;
           
        }

        public List<string> GetFileNames()
        {
            List<string> FileNames = new List<string>();
            string[] paths = Directory.GetFiles(@"C:/dev", "*.json");
            foreach (string path in paths)
            {
                FileNames.Add(Path.GetFileName(path));

            }
            return FileNames;
        }
    }
}
