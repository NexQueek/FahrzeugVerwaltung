using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fahrzeugverwaltung.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class VehicleWindow : Window
    {
        private NewVehicleView newVehicleView;
        private EditVehicleView editVehicleView;
        public VehicleWindow()
        {
            InitializeComponent();
            DataContext = new VehicleViewModel();
        }
        private void New_OnClick(object sender, RoutedEventArgs e)
        {
            newVehicleView = new NewVehicleView(DataContext);
            newVehicleView.Show();
        }
        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            editVehicleView = new EditVehicleView(DataContext);
            editVehicleView.Show();
        }
        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            //do stuff
        }
    }
}
