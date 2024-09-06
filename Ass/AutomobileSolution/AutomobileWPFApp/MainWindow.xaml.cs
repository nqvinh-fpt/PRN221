using AutomobileLibrary.Repository;
using AutomobileLibrary.DataAcces;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomobileWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICarRepository CarRepository;
        public MainWindow(ICarRepository repository)
        {
            InitializeComponent();
            CarRepository=repository;
        }

        private Car GetCarObject()
        {
            Car car = null;
            try {
                car = new Car {
                CarId = int.Parse(txtCarId.Text),
                CarName = txtCarName.Text,
                Manufacturer = txtManufacturer.Text,
                Price=decimal.Parse(txtPrice.Text),
                ReleasedYear=int.Parse(txtReleasedYear.Text),
                };
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Car");
            }
            return car;
        }

        public void LoadCarList()
        {
            lvCars.ItemsSource = CarRepository.GetCars();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCarList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Car List");
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                CarRepository.InsertCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} inserted successfully", "Insert car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert car");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                CarRepository.UpdateCar(car);
                LoadCarList();
                MessageBox.Show($"{car.CarName} updated successfully ", "Update car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update car");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Car car = GetCarObject();
                CarRepository.DeleteCar(car);
                LoadCarList();
                MessageBox.Show($" {car.CarName} deleted successfully ", "Delete car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete car");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}