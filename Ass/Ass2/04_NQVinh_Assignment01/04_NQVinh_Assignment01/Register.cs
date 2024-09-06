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
    public partial class Register : Form
    {
        DataProvider dp = new DataProvider();
        public Register()
        {
            InitializeComponent();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (checkDuplicate(txtUserName.Text) != true)
            {
                using (PRN211_Ass1Context context = new PRN211_Ass1Context())
                {

                    Models.User u = new Models.User()
                    {
                        UserName = txtUserName.Text,
                        Phone = txtPhone.Text,
                        Role = true,
                        Password = "user123",
                    };
                    context.Users.Add(u);
                    if (context.SaveChanges() > 0)
                    {
                        Member member = new Member()
                        {
                            UserId = GetUserLast().UserId,
                            Name = txtName.Text,
                            Dob = DateTime.Parse(txtDOB.Text),
                            City = txtCity.Text,
                            Country = txtCountry.Text,
                        };
                        context.Members.Add(member);
                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Add success");
                        }
                        else
                        {
                            MessageBox.Show("Add fail");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Add fail");
                    }
                }
            }
            else
            {
                MessageBox.Show("Account does exit!!!");
            }
        }
        private Models.User GetUserLast()
        {
            String strSQL = "select top 1 * from Users ORDER BY UserId DESC;";

            using (IDataReader dr = dp.executeQuery2(strSQL))
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
                    return user;
                }
            }
            return null;

        }

        private bool checkDuplicate(string text)
        {
            using (PRN211_Ass1Context context = new PRN211_Ass1Context())
            {
                Models.User user = context.Users.FirstOrDefault(user => user.UserName.Equals(text));
                if (user != null)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
