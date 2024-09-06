using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms_ADO;
using _04_NQVinh_Assignment01.Models;

namespace _04_NQVinh_Assignment01
{
    public partial class ViewProfileUser : Form
    {
        DataProvider dp = new DataProvider();
        int userId;
        public ViewProfileUser(int UserId)
        {
            this.userId = UserId;
            InitializeComponent();
        }
        public ViewProfileUser()
        {
            InitializeComponent();
        }

        private void ViewProfileUser_Load(object sender, EventArgs e)
        {

            String strSQL = "select * from Users where UserId = @acc ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@acc",userId)
            };
            using (IDataReader dr = dp.executeQuery2(strSQL, parameters))
            {
                if (dr.Read())
                {
                    Models.User user = new Models.User()
                    {
                        UserId = dr.GetInt32(0),
                        UserName = dr.GetString(1).ToString(),
                        Phone = dr.GetString(4).ToString(),
                        Role = dr.GetBoolean(3),
                        Password = dr.GetString(2).ToString(),
                    };
                    txtUserName.Text = user.UserName;
                    txtPhone.Text = user.Phone;
                }
            }
            strSQL = "SELECT *  FROM Member where UserId = " + userId + "";

            using (IDataReader dr = dp.executeQuery2(strSQL))
            {
                if (dr.Read())
                {
                    Member member = new Member()
                    {
                        MemberId = dr.GetInt32(0),
                        UserId = dr.GetInt32(1),
                        Name = dr.GetString(2).ToString(),
                        Dob = DateTime.Parse(dr.GetDateTime(3).ToString()),
                        City = dr.GetString(4).ToString(),
                        Country = dr.GetString(5).ToString(),
                    };

                    txtName.Text = member.Name;
                    txtCity.Text = member.City;
                    txtCountry.Text = member.Country;
                    txtDOB.Text = member.Dob.ToString();
                }

            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateUser updateUser = new UpdateUser(userId);
            updateUser.Show();
            this.Hide();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager(userId);
            userManager.Show();
            this.Hide();
        }
    }
}
