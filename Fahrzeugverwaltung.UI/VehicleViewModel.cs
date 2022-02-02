using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;

namespace Fahrzeugverwaltung.UI
{
    public class VehicleViewModel : VehicleViewModelBase
    {
        #region Fields
        private Vehicle vehicle;
        private ICommand saveCommand;
        private ICommand replaceCommand;
        private ICommand ctxNewCommand;
        private ICommand ctxEditCommand;
        private ICommand ctxDeleteCommand;
        private ObservableCollection<Vehicle> vehicleCollection;
        private Dictionary<string, List<string>> vehicleBrands;
        private Dictionary<string, List<string>> vehicleModels;
        private List<string> vehicleTypes;
        private Vehicle selectedVehicle;
        private int selectedIndex;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets a type of a <see cref="Vehicle"/>.
        /// </summary>
        public string Type { get => vehicle.Type; set => vehicle.Type = value; }

        /// <summary>
        /// Gets or sets a model of a <see cref="Vehicle"/>.
        /// </summary>
        public string Model { get => vehicle.Model; set => vehicle.Model = value; }

        /// <summary>
        /// Gets or sets a model of a <see cref="Vehicle"/>.
        /// </summary>
        public string Brand { get => vehicle.Brand; set => vehicle.Brand = value; }

        public ObservableCollection<Vehicle> VehicleCollection { get => vehicleCollection; set => vehicleCollection = value; }
        public Vehicle Vehicle
        {
            get => vehicle;
            set
            {
                if (value == null) return;
                vehicle = value;
                OnPropertyChanged();
            }
        }
        public Vehicle SelectedVehicle
        {
            get => selectedVehicle;
            set
            {
                if (value == null) return;
                selectedVehicle = value;
                Type = selectedVehicle.Type;
                Model = selectedVehicle.Model;
                Brand = selectedVehicle.Brand;
                OnPropertyChanged(nameof(Type));
                OnPropertyChanged(nameof(Model));
                OnPropertyChanged(nameof(Brand));
            }
        }
        public int SelectedIndex
        {
            get => selectedIndex;
            set => selectedIndex = value;
        }
        #endregion
        #region Commands
        /// <summary>
        /// Gets or sets a save command
        /// </summary>
        public ICommand SaveCommand { get => saveCommand; set => saveCommand = value; }
        public ICommand ReplaceCommand { get => replaceCommand; set => replaceCommand = value; }
        public ICommand CtxNewCommand { get => ctxNewCommand; set => ctxNewCommand = value; }
        public ICommand CtxEditCommand { get => ctxEditCommand; set => ctxEditCommand = value; }
        public ICommand CtxDeleteCommand { get => ctxDeleteCommand; set => ctxDeleteCommand = value; }
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleViewModel()
        {
            saveCommand = new RelayCommand(Save);
            replaceCommand = new RelayCommand(Replace);
            CtxNewCommand = new RelayCommand(() => { });
            CtxEditCommand = new RelayCommand(() => { });
            CtxDeleteCommand = new RelayCommand(Delete);
            vehicle = new Vehicle();
            VehicleCollection = new ObservableCollection<Vehicle>();

            vehicleBrands = new Dictionary<string, List<string>>()
            {
                { "PKW", new List<string>(){ "BMW", "Lamborghini", "Audi" } },
                { "LKW", new List<string>(){ "Daimler", "FAW", "Volvo Trucks" } }
            };

            vehicleModels = new Dictionary<string, List<string>>()
            {
                { "Audi", new List<string>(){"A1", "A2", "A3", "A4"} },
                { "BMW", new List<string>(){"M1", "M2", "M3", "M4"} },
                { "Lamborghini", new List<string>(){"Gallardo", "Murcielago", "Aventador"} },
                { "Daimler", new List<string>(){"A", "B", "C", "D"} },
                { "FAW", new List<string>(){"A", "B", "C", "D"} },
                { "Volvo Trucks", new List<string>(){"A", "B", "C", "D"} },
            };

            vehicleTypes = new List<string>() { "PKW", "LKW" };

            initRandCollection();

        }

        private void initRandCollection()
        {
            var rnd = new Random();
            int len = Math.Max(rnd.Next() % 5, 3);
            for (int i = 0; i < len; i++)
            {
                string rType = vehicleTypes[rnd.Next() % 2];
                string rBrand = vehicleBrands[rType][rnd.Next() % vehicleBrands[rType].Count];
                string rModel = vehicleModels[rBrand][rnd.Next() % vehicleModels[rBrand].Count];
                vehicleCollection.Add(new Vehicle { Brand = rBrand, Model = rModel, Type = rType });
            }
        }


        private void Save()
        {
            //foreach (var v in vehicleCollection)
            //{
            //    if (v == Vehicle) vehicleCollection.Remove(v);
            //}
            VehicleCollection.Add(new Vehicle { Brand = vehicle.Brand, Model = vehicle.Model, Type = vehicle.Type });
            MessageBox.Show($"Es wurde folgendes Fahrzeug angelegt: Typ: {Type}, Marke: {Brand}, Modell: {Model}");
        }

        private void Replace()
        {
            VehicleCollection[SelectedIndex].Type = Type;
            VehicleCollection[SelectedIndex].Brand = Brand;
            VehicleCollection[SelectedIndex].Model = Model;
            VehicleCollection = new ObservableCollection<Vehicle>(VehicleCollection);
            //SelectedVehicle.Type = Type;
            //SelectedVehicle.Brand = Brand;
            //SelectedVehicle.Model = Model;
            //OnPropertyChanged(nameof(SelectedVehicle));
            OnPropertyChanged(nameof(VehicleCollection));
        }
        private void Delete()
        {
            //VehicleCollection.RemoveAt(SelectedIndex);
            VehicleCollection.Remove(SelectedVehicle);
            VehicleCollection = new ObservableCollection<Vehicle>(VehicleCollection);
            OnPropertyChanged(nameof(VehicleCollection));
        }
    }
}