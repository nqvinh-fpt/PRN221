
using AutomobileLibrary.Model;
using HotelManagement.Model;
using Microsoft.EntityFrameworkCore;
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

namespace Assingment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyStockContext _context;

        public MainWindow(MyStockContext context)
        {
            InitializeComponent();
            _context = context;
            LoadRoomList();
        }

        public void LoadRoomList()
        {
            lvRooms.ItemsSource = _context.Rooms.ToList();
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtRoomID.Text = string.Empty;
            txtRoomType.Text = string.Empty;
            rbNotSet.IsChecked = true;
            txtPrice.Text = string.Empty;
        }
        private void lvRoom_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItem = (Rooms)(sender as ListView).SelectedItem;
            if (SelectedItem != null)
            {
                var status = SelectedItem.status;
                if (status.ToLower() == "notset")
                {
                    rbNotSet.IsChecked = true;
                }
                else if (status.ToLower() == "booked")
                {
                    rbBooked.IsChecked = true;
                }
                else
                {
                    rbBooking.IsChecked = true;
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rooms room = GetRoomObject();
                Rooms c = GetRoomByID(room.room_id);
                if (c != null)
                {
                    _context.Entry<Rooms>(c).State = EntityState.Modified;
                    _context.SaveChanges();
                    LoadEmployeeList();
                    MessageBox.Show($"{c.GetType} updated successful", "Update Room");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Room");
            }
        }

        private void LoadEmployeeList()
        {
            throw new NotImplementedException();
        }

        private Rooms GetRoomObject()
        {
            string checkStatus = "notset";
            if (rbBooked.IsChecked == true)
            {
                checkStatus = "booked";
            }
            else if (rbBooking.IsChecked == true)
            {
                checkStatus = "booking";
            }
            Rooms employee = null;
            try
            {
                employee = new Rooms
                {
                    room_id = int.Parse(txtRoomID.Text),
                    room_type = txtRoomType.Text,

                    status = checkStatus,
                    price = float.Parse(txtPrice.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Room");
            }
            return employee;
        }

        private Rooms GetRoomByID(int RoomID)
        {
            Rooms rooms = null;
            try
            {
                rooms = _context.Rooms.SingleOrDefault(room => room.room_id == RoomID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Room By ID");
            }
            return rooms;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rooms room = GetRoomObject();
                Rooms c = GetRoomByID(room.room_id);
                if (c != null)
                {
                    _context.Rooms.Remove(c);
                    _context.SaveChanges();
                    LoadEmployeeList();
                    MessageBox.Show($"{c.GetType} deleted successful", "Delete Room");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Room");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rooms employee = GetRoomObject();
                if (employee != null)
                {
                    employee.room_id = 0;
                    _context.Rooms.Add(employee);
                    _context.SaveChanges();
                    LoadEmployeeList();
                    MessageBox.Show($"{employee.room_type} inserted successful", "Insert Room");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add room");
            }
        }
    }
}