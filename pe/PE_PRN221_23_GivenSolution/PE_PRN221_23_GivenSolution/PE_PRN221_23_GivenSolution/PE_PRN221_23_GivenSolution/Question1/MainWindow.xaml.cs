using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
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

namespace Question1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private List<Director> tempDerectorList = new List<Director>();
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnSend_Click(object sender, RoutedEventArgs e)
		{
			try
			{
		


				var directorsInfo = tempDerectorList;
					string jsonData = JsonSerializer.Serialize(directorsInfo, new JsonSerializerOptions { WriteIndented = true });

					string host = "127.0.0.1";
					int port = 5000;
					string responseData;
					int bytes;
					try
					{
						TcpClient client = new TcpClient(host, port);
						NetworkStream stream = null;
						while (true)
						{

							Byte[] data = Encoding.ASCII.GetBytes($"{jsonData}");
							stream = client.GetStream();
							stream.Write(data, 0, data.Length);
							Console.WriteLine("Sent {0}", jsonData);
							data = new Byte[256];
							bytes = stream.Read(data, 0, data.Length);
							responseData = Encoding.ASCII.GetString(data, 0, bytes);
							Console.WriteLine("Reveived: {0}", responseData);
						}
						client.Close();
					}
					catch (Exception ex)
					{

						Console.WriteLine("{0}", ex.Message);
					}
					MessageBox.Show("Send ok");
				
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Director derector = GetDirector();
				tempDerectorList.Add(derector);
				lvDerectors.ItemsSource = null;
				lvDerectors.ItemsSource = tempDerectorList;
				MessageBox.Show($"Add  successfully", "Add Derector");
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "Add Derector ");
			}
		}

		private Director GetDirector()
		{
			Director director = null;
			try
			{
				director = new Director
				{
					Name = txtDirectorName.Text,
					Dob = dpDob.SelectedDate,
					Male = cbMale.IsChecked,
					Description = txtDescription.Text,
					Nationality = txtNationality.Text,
				};
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Get director");
			}
			return director;
		}
	

		//private void btnSave_Click(object sender, RoutedEventArgs e)
		//{
		//	try
		//	{
		//		SaveFileDialog saveFileDialog = new SaveFileDialog();
		//		saveFileDialog.DefaultExt = ".json";
		//		saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";

		//		var productsInfo = _context.Products
		//								  .Select(product => new
		//								  {
		//									  product.ProductId,
		//									  product.ProductName,
		//									  product.QuantityPerUnit,
		//									  product.UnitPrice,
		//									  product.UnitsInStock,
		//									  product.UnitsOnOrder,
		//									  product.ReorderLevel,
		//									  product.Discontinued,
		//									  Category = new
		//									  {
		//										  product.Category.CategoryId,
		//										  product.Category.CategoryName
		//									  },
		//									  OrderDetails = product.OrderDetails.Select(orderDetail => new
		//									  {
		//										  orderDetail.ProductId,
		//										  orderDetail.OrderId,
		//										  orderDetail.Quantity,
		//										  orderDetail.UnitPrice,
		//										  orderDetail.Discount
		//									  }).ToList()
		//								  })
		//								  .ToList();

		//		if (saveFileDialog.ShowDialog() == true)
		//		{
		//			string jsonData = JsonSerializer.Serialize(productsInfo, new JsonSerializerOptions { WriteIndented = true });
		//			File.WriteAllText(saveFileDialog.FileName, jsonData);


		//			MessageBox.Show("Save ok");
		//		}
		//	}
		//	catch (Exception ex)
		//	{

		//		MessageBox.Show(ex.Message);
		//	}
		//}

		
	}
}
