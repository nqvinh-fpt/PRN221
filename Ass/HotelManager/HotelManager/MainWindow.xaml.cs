using HotelManager.Models;
using HotelManager.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
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

namespace HotelManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HotelManagerContext _context;

        public MainWindow(HotelManagerContext context)
        {
            InitializeComponent();
            _context = context;
            LoadRoomList();
        }

        public void LoadRoomList()
        {
            lvRooms.ItemsSource = _context.Rooms.ToList();
        }

        private void btnBookingMN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_context);
            BookingWindow bookingWindow = new BookingWindow(_context);
            bookingWindow.Show();
            Close();
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
            var SelectedItem = (Room)(sender as ListView).SelectedItem;
            if (SelectedItem != null)
            {
                var status = SelectedItem.Status;
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
            string checkStatus = "notset";
            if (rbBooked.IsChecked == true)
            {
                checkStatus = "booked";
            }
            else if (rbBooking.IsChecked == true)
            {
                checkStatus = "booking";
            }

            try
            {
                Room room = GetRoomObject();
                Room c = GetRoomByID(room.RoomId);
                c.Status = checkStatus;
                if (c != null)
                {
                    _context.Entry<Room>(c).State = EntityState.Modified;
                    _context.SaveChanges();
                    MessageBox.Show($"{c.RoomType} updated successful", "Update Room");
                    LoadRoomList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Room");
            }
        }

        private Room GetRoomObject()
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


            Room room = null;
            try
            {
                room = new Room
                {
                    RoomId = int.Parse(txtRoomID.Text),
                    RoomType = txtRoomType.Text,
                    Status = checkStatus,
                    Price = float.Parse(txtPrice.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Room");
            }
            return room;
        }

        private Room GetRoomByID(int RoomID)
        {
            Room room = null;
            try
            {
                room = _context.Rooms.SingleOrDefault(room => room.RoomId == RoomID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Room By ID");
            }
            return room;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Room room = GetRoomObject();
                Room c = GetRoomByID(room.RoomId);
                if (c != null)
                {
                    _context.Rooms.Remove(c);
                    _context.SaveChanges();
                    LoadRoomList();
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
                Room employee = GetRoomObject();
                if (employee != null)
                {
                    employee.RoomId = 0;
                    _context.Rooms.Add(employee);
                    _context.SaveChanges();
                    LoadRoomList();
                    MessageBox.Show($"{employee.RoomType} inserted successful", "Insert Room");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add room");
            }
        }

        private void btnBookingMN_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        public List<Room> SearchRoom( string type, string text) {
            switch (type)
            {
                
                case "Room Type":

                    return _context.Rooms.ToList().FindAll(Room => Room.RoomType.Contains(text));

                case "Status":
                    return _context.Rooms.ToList().FindAll(Room => Room.Status.Contains(text));

                case "Price":
                    return _context.Rooms.ToList().FindAll(Room => Room.Price>=(int.Parse(text)));
                default:
                    break;
            }
            return _context.Rooms.ToList();


        }

        private void btncustomerMN_Click(object sender, RoutedEventArgs e)
        {
            
            CustomerWindow customerWindow = new CustomerWindow(_context);
            customerWindow.Show();
            Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbbSearch.SelectedItem;
            if (selectedItem != null)
            {
                lvRooms.ItemsSource = SearchRoom(selectedItem.Content.ToString(), txtSearch.Text);
            }
        }

        private void btnReportMN_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow(_context);
            reportWindow.Show();
            Close();
        }
    }
}