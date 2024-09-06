using HotelManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace HotelManager
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private readonly HotelManagerContext _context;
        public ReportWindow(HotelManagerContext context)
        {
            InitializeComponent();
            _context = context;
            LoadReportForm();
        }

        private void LoadReportForm()
        {
            List<int> ListRoomId = new List<int>();
            List<int> ListCustomerId = new List<int>();
            List<Booking> bookingsList = _context.Bookings.ToList();

            HashSet<string> uniqueBookingsRoom = new HashSet<string>();
            List<string> duplicateBookingsRoom = new List<string>();
            HashSet<string> uniqueBookingsCustomer = new HashSet<string>();
            List<string> duplicateBookingscustomer = new List<string>();

            foreach (Booking booking in bookingsList)
            {
                
                if (!uniqueBookingsRoom.Add(booking.RoomId.ToString()))
                {
                    duplicateBookingsRoom.Add(booking.RoomId.ToString());
                }
                if (!uniqueBookingsCustomer.Add(booking.CustomerId.ToString()))
                {
                    duplicateBookingscustomer.Add(booking.CustomerId.ToString());
                }
            }

            ListRoomId.AddRange(duplicateBookingsRoom.Select(int.Parse));
            ListCustomerId.AddRange(duplicateBookingscustomer.Select(int.Parse));
            lvRooms.ItemsSource = _context.Rooms.Where(room => ListRoomId.Contains(room.RoomId)).ToList();
            lvCustomer.ItemsSource = _context.Customers.Where(customer => ListCustomerId.Contains(customer.CustomerId)).ToList();
        }

        private void btnRoomMN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_context);
            mainWindow.Show();
            Close();
        }


        private void btncustomerMN_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow(_context);
            customerWindow.Show();
            Close();
        }

        private void btnBookingMN_Click_1(object sender, RoutedEventArgs e)
        {
            BookingWindow bookingWindow = new BookingWindow(_context);
            bookingWindow.Show();
            Close();
        }
    }
}
