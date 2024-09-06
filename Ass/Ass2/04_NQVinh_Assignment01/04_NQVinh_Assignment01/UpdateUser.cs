using _04_NQVinh_Assignment01.Models;
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

namespace _04_NQVinh_Assignment01
{
    public partial class UpdateUser : Form
    {
        DataProvider dp = new DataProvider();
        int userId;
        public UpdateUser(int UserId)
        {
            this.userId = UserId;
            InitializeComponent();
        }
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            using (PRN211_Ass1Context context = new PRN211_Ass1Context())
            {
                Models.User user = context.Users.FirstOrDefault(user => user.UserId == userId);
                if (user != null)
                {
                    user.UserName = txtUserName.Text;
                    user.Phone = txtPhone.Text;
                    context.SaveChanges();

                }
                else
                {
                    MessageBox.Show("Not found");
                }
                Member member = context.Members.FirstOrDefault(member => member.UserId == userId);
                if (member != null)
                {
                    member.Name = txtName.Text;
                    member.City = txtCity.Text;
                    member.Country = txtCountry.Text;
                    member.Dob = DateTime.Parse(txtDOB.Text);
                    context.SaveChanges();

                }
                else
                {
                    MessageBox.Show("Not found");
                }
                UpdateUser updateUser = new UpdateUser(userId);
                updateUser.Show();
                this.Hide();

            }
        }

        private void UpdateUser_Load(object sender, EventArgs e)
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

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager(userId);
            userManager.Show();
            this.Hide();
        }
    }
}
