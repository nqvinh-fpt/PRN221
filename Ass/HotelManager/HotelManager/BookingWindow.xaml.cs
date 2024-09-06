using HotelManager.Models;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace HotelManager
{
    /// <summary>
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        private readonly HotelManagerContext _context;

        public BookingWindow(HotelManagerContext context)
        {
            InitializeComponent();
            _context = context;
            LoadBookingList();
        }

        public void LoadBookingList()
        {
            lvBooking.ItemsSource = _context.Bookings.ToList();
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtBookingID.Text = string.Empty;
            txtCustomerID.Text = string.Empty;
            txtRoomID.Text = string.Empty;
            dtpCheckInDate.SelectedDate = DateTime.Now;
            dtpCheckOutDate.SelectedDate = DateTime.Now;
            txtTotalPrice.Text = string.Empty;
        }
        private void lvBooking_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItem = (Booking)((ListView)sender).SelectedItem;

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Booking booking = GetBookingObject();
                Booking c = GetBookingByID(booking.BookingId);
                c.CheckinDate = dtpCheckInDate.SelectedDate;
                c.CheckoutDate = dtpCheckOutDate.SelectedDate;
                c.TotalPrice= double.Parse(txtTotalPrice.Text);
                if (c != null)
                {
                    _context.Entry<Booking>(c).State = EntityState.Modified;
                    _context.SaveChanges();
                    LoadBookingList();
                    MessageBox.Show($"{c.BookingId} updated successful", "Update Booking");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Booking");
            }
        }

        private Booking GetBookingObject()
        {

            Booking booking = null;
            try
            {
                booking = new Booking
                {
                    BookingId = int.Parse(txtBookingID.Text),
                    CustomerId = int.Parse(txtCustomerID.Text),
                    RoomId = int.Parse(txtRoomID.Text),
                    CheckinDate = dtpCheckInDate.SelectedDate,
                    CheckoutDate = dtpCheckOutDate.SelectedDate,
                    TotalPrice = float.Parse(txtTotalPrice.Text),
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Booking");
            }
            return booking;
        }



        private Booking GetBookingByID(int BookingID)
        {
            Booking booking = null;
            try
            {
                booking = _context.Bookings.SingleOrDefault(booking => booking.BookingId == BookingID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Booking By ID");
            }
            return booking;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Booking booking = GetBookingObject();
                Booking c = GetBookingByID(booking.BookingId);
                if ((c.CheckoutDate> DateTime.Now))
                {
                    c.CheckoutDate = DateTime.Now;
                }
                if ((c.CheckinDate > DateTime.Now))
                {
                    c.CheckoutDate = null;
                    c.CheckinDate = null;
                }

                if (c != null)
                {
                    _context.Entry<Booking>(c).State = EntityState.Modified;
                    _context.SaveChanges();
                    LoadBookingList();
                    MessageBox.Show($"{c.BookingId} cancel successful", "cancel Booking");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "cancel Booking");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Booking booking = GetBookingObject();
                if (booking.CheckinDate > booking.CheckoutDate)
                {
                    MessageBox.Show( "Add Booking fail");
                    return;
                }

                if (booking != null)
                {
                    booking.BookingId = 0;
                    _context.Bookings.Add(booking);
                    _context.SaveChanges();
                    LoadBookingList();
                    MessageBox.Show($"{booking.BookingId} inserted successful", "Insert Booking");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Add Booking fail");
            }
        }

        private void btncustomerMN_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow(_context);
            customerWindow.Show();
            Close();
        }

        private void btnBookingMN_Click_1(object sender, RoutedEventArgs e)
        {

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
        private void btnCalculat_Click(object sender, RoutedEventArgs e)
        {
            
            if(dtpCheckOutDate.SelectedDate!=null&& dtpCheckInDate.SelectedDate != null && txtRoomID.Text != null && dtpCheckInDate.Text != null)
            {
                Room room = GetRoomByID(int.Parse(txtRoomID.Text));
                TimeSpan stayDuration = (TimeSpan)(dtpCheckOutDate.SelectedDate - dtpCheckInDate.SelectedDate);
                float totalPrice = (float)(stayDuration.TotalDays * room.Price);
                txtTotalPrice.Text = "" + totalPrice;
            }
        }

        private void btnRoomMN_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow(_context);
            mainWindow.Show();
            Close();
        }

        private void btnReportMN_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow(_context);
            reportWindow.Show();
            Close();
        }
    }
}

