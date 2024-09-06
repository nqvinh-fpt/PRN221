using _04_NQVinh_Assignment01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms_ADO;

namespace _04_NQVinh_Assignment01
{
    public partial class LoadAllMember : Form
    {
        DataProvider dp = new DataProvider();
        public LoadAllMember()
        {
            InitializeComponent();
        }

        private void LoadAllMember_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            List<Member> expenseList = new List<Member>();
            String strSQL = "SELECT * FROM Member";

            using (IDataReader dr = dp.executeQuery2(strSQL))
            {
                while (dr.Read())
                {
                    Models.User user = new Models.User();
                    Member m = new Member()
                    {
                        MemberId = dr.GetInt32(0),
                        UserId = dr.GetInt32(1),
                        Name = dr.GetString(2).ToString(),
                        Dob = DateTime.Parse(dr.GetDateTime(3).ToString()),
                        City = dr.GetString(4).ToString(),
                        Country = dr.GetString(5).ToString(),
                    };
                    expenseList.Add(m);
                }
            }
            dgvMember.DataSource = expenseList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminManger adminManger = new AdminManger();
            adminManger.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
