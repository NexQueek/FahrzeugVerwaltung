using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Fahrzeugverwaltung.UI
{
    public class VehicleViewModel : VehicleViewModelBase
    {
        private Vehicle vehicle;
        private ICommand saveCommand;
        private ICommand neuClick;
        private ICommand bearbeitenClick;
        private ICommand loeschenClick;
        private ICommand vehicleLoeschen;
        private ObservableCollection<Vehicle> vehicles;
        private List<string> vehicleTypes;
        private Dictionary<string, List<string>> vehicleBrands;
        private Dictionary<string, List<string>> vehicleModels;
        private Vehicle vehicleAusge;





        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleViewModel()
        {
            saveCommand = new RelayCommand(Save);
            neuClick = new RelayCommand(NeuV);
            loeschenClick = new RelayCommand(BearbeitenV);
            bearbeitenClick = new RelayCommand(LoeschenV);
            loeschenClick = new RelayCommand(AutoLoeschen);
            vehicle = new Vehicle();
            vehicles = new ObservableCollection<Vehicle>();


            vehicleBrands = new Dictionary<string, List<string>>()
            {
                {"PKW", new List<string>() {"Mercedes", "BMW", "Audi"} },
                {"LKW", new List<string>() {"MAN", "Scania", "Renault"} }

            };

            vehicleModels = new Dictionary<string, List<string>>()
            {
                { "Mercedes", new List<string>(){"A", "B", "C", "D"} },
                { "BMW", new List<string>(){"1er", "3er", "5er", "7er"} },
                { "Audi", new List<string>(){"A1", "A2", "A3", "A4"} },
                { "MAN", new List<string>(){"M1", "M2", "M3", "M4"} },
                { "Scania", new List<string>(){"S1", "S2", "S3", "S4"} },
                { "Renault", new List<string>(){"R1", "R2", "R4", "R5"} },

            };

            vehicleTypes = new List<string>() { "PKW", "LKW" };
            randVehicle();



        }

        public void randVehicle()
        {
            var rnd = new Random();
            int len = Math.Max(rnd.Next() % 5, 3);
            for (int i = 0; i < len; i++)
            {
                string rType = vehicleTypes[rnd.Next() % 2];
                string rBrand = vehicleBrands[rType][rnd.Next() % vehicleBrands[rType].Count];
                string rModel = vehicleModels[rBrand][rnd.Next() % vehicleModels[rBrand].Count];
                vehicles.Add(new Vehicle { Brand = rBrand, Model = rModel, Type = rType });
            }

        }


        private void Save()
        {
            vehicles.Add(vehicle);
        }

        /// <summary>
        /// Gets or sets a type of a <see cref="Vehicle"/>.
        /// </summary>
        public string Type { get => vehicle.Type; set => vehicle.Type = value; }

        /// <summary>
        /// Gets or sets a model of a <see cref="Vehicle"/>.
        /// </summary>
        public string Model { get => vehicle.Model; set => vehicle.Model = value; }


        public string Brand { get => vehicle.Brand; set => vehicle.Brand = value; }



        /// <summary>
        /// Gets or sets a save command
        /// </summary>
        public ICommand SaveCommand { get => saveCommand; set => saveCommand = value; }

        public ICommand VehicleLoeschen { get => vehicleLoeschen; set => vehicleLoeschen = value; }

        private void AutoLoeschen()
        {
            vehicles.Clear();
        }

        public ObservableCollection<Vehicle> Vehicles { get => vehicles; set => vehicles = value; }

        public Vehicle VehicleChose
        {
            get => vehicleAusge; 
            set
            {
                if(value != null)
                {
                    vehicleAusge = value;
                    Type = vehicleAusge.Type;
                    Model = vehicleAusge.Model;
                    Brand = vehicleAusge.Brand;
                    OnPropertyChanged(nameof(Type));
                    OnPropertyChanged(nameof(Model));
                    OnPropertyChanged(nameof(Brand));

                }
            }
        }

        public ICommand NeuClick { get => neuClick; set => neuClick = value; }
        private void NeuV()
        {
            var window = new Anlegen();
            window.Show();

        }

        public ICommand BearbeitenClick { get => bearbeitenClick; set => bearbeitenClick = value; }
        private void BearbeitenV()
        {
            MessageBox.Show("Auto bearbeiten");
        }

        public ICommand LoeschenClick { get => loeschenClick; set => loeschenClick = value; }
        private void LoeschenV()
        {
            MessageBox.Show("Auto Löschen");
        }



    }


}