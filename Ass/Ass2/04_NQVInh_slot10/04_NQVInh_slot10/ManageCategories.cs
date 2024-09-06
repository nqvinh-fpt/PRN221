using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_NQVInh_slot10
{
    public record Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
    public class ManageCategories
    {
        SqlConnection connection;
        SqlCommand command;
        string ConnectionString = "server=LAPTOP-H8LUNFAT\\MAYAO;database=MyStore;uid=sa;pwd=123;TrustServerCertificate=True";



    }
}
