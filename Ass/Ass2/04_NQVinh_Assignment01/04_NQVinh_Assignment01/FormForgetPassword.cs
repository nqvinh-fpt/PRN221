using _04_NQVinh_Assignment01.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
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
using System.Xml.Linq;
using WinForms_ADO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _04_NQVinh_Assignment01
{
    public partial class FormForgetPassword : Form
    {
        public FormForgetPassword()
        {
            InitializeComponent();
        }
        DataProvider dp = new DataProvider();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == null || txtPhone.Text == null || txtNewPassword.Text == null || txtConfirmPassword.Text == null)
            {
                MessageBox.Show("User Name, Phone and Password not null");
                FormForgetPassword formForgetPassword = new FormForgetPassword();
                formForgetPassword.Show();
                this.Hide();
            }
            else
            {
                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("New Password and Confirm Password not emty");
                    FormForgetPassword formForgetPassword = new FormForgetPassword();
                    formForgetPassword.Show();
                    this.Hide();
                }
                else
                {
                    try
                    {
                        String strSQL = "select * from Users " +
                        "where UserName = @acc " +
                        "and Phone = @phone ";
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                        new SqlParameter("@acc",txtUserName.Text),
                        new SqlParameter("@phone",txtPhone.Text)
                        };
                        Boolean check = false;
                        using (IDataReader dr = dp.executeQuery2(strSQL, parameters))
                        {
                            if (dr.Read())
                            {
                                
                                check = true;
                                dr.Close();
                            }
                            else
                            {
                                MessageBox.Show("Account does not exist");
                                FormForgetPassword formForgetPassword = new FormForgetPassword();
                                formForgetPassword.Show();
                                this.Hide();
                            }
                        }
                        if (check)
                        {
                            ChangePassword();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Change failed ! " + ex.Message);
                        FormForgetPassword formForgetPassword = new FormForgetPassword();
                        formForgetPassword.Show();
                        this.Hide();
                    }
                }

            }
        }

        private void ChangePassword()
        {
            using (PRN211_Ass1Context context = new PRN211_Ass1Context())
            {
                
                Models.User u = context.Users.FirstOrDefault(u => u.UserName == txtUserName.Text);
                if (u != null)
                {
                    u.UserName = txtUserName.Text;
                    u.Password = txtNewPassword.Text;

                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Change success");
                    }
                    else
                    {
                        MessageBox.Show("Change fail");
                    }
                }
                else
                {
                    MessageBox.Show("Not found");
                }
                FormForgetPassword formForgetPassword = new FormForgetPassword();
                formForgetPassword.Show();
                this.Hide();

            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                // Nếu người dùng chọn checkbox, hiển thị mật khẩu
                txtNewPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Nếu người dùng không chọn checkbox, ẩn mật khẩu
                txtConfirmPassword.UseSystemPasswordChar = true;
                txtNewPassword.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }
    }
}
