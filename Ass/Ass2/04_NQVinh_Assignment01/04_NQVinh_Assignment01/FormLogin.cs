using _04_NQVinh_Assignment01.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms_ADO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _04_NQVinh_Assignment01
{
    public partial class FormLogin : Form
    {
        string useNameSave;
        string passwordSave;
        public FormLogin(string useName, string password)
        {
            this.useNameSave = useName;
            this.passwordSave = password;
            InitializeComponent();
        }
        public FormLogin()
        {
            InitializeComponent();
        }
        DataProvider dp = new DataProvider();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == null || txtPassword.Text == null)
            {
                MessageBox.Show("User Name and Password not null");
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Hide();
            }
            else
            {
                try
                {
                    String strSQL = "select * from Users " +
                        "where UserName = @acc " +
                        "and Password = @pass ";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@acc",txtUserName.Text),
                        new SqlParameter("@pass",txtPassword.Text)
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
                            MessageBox.Show("Login failed");
                            FormLogin formLogin = new FormLogin();
                            formLogin.Show();
                            this.Hide();
                        }
                    }
                    if (check)
                    {
                        MessageBox.Show("Login suceesfully");
                        if (GetUserByUserName().Role == true)
                        {
                            int useID = GetUserByUserName().UserId;
                            String memberName = GetUMemberByUserId(useID).Name;
                            if (memberName != null)
                            {
                                UserManager userManager = new UserManager(useID);
                                userManager.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            AdminManger adminManger = new AdminManger();
                            adminManger.Show();
                            this.Hide();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login failed ! " + ex.Message);
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                    this.Hide();
                }
            }
        }

        private Member GetUMemberByUserId(int userId)
        {
            String strSQL = "SELECT *  FROM Member where UserId = @userID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                        new SqlParameter("@userID",userId)
            };
            using (IDataReader dr = dp.executeQuery2(strSQL, parameters))
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
                    return member;


                }
                dr.Close();
            }
            return null;
        }

        private User GetUserByUserName()
        {
            String strSQL = "select * from Users where UserName = @acc ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@acc",txtUserName.Text)
            };
            using (IDataReader dr = dp.executeQuery2(strSQL, parameters))
            {
                if (dr.Read())
                {
                    User user = new User()
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

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (useNameSave != null && passwordSave != null && useNameSave.ToString().Length > 0 && passwordSave.ToString().Length > 0)
            {
                txtUserName.Text = useNameSave.ToString();
                txtPassword.Text = passwordSave.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                // Nếu người dùng chọn checkbox, hiển thị mật khẩu
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Nếu người dùng không chọn checkbox, ẩn mật khẩu
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void llbForget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormForgetPassword formForgetPassword = new FormForgetPassword();
            formForgetPassword.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
