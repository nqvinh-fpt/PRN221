using _04_NQVinh_Assignment01.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms_ADO;

namespace _04_NQVinh_Assignment01
{
    public partial class AdminManger : Form
    {

        DataProvider dp = new DataProvider();
        public AdminManger()
        {
            InitializeComponent();
        }
        Models.User user1 = new Models.User();

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAllMember loadAllMember = new LoadAllMember();
            loadAllMember.Show();
            this.Hide();


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
        private void LoadDataByUserId(int? userId)
        {
            List<Member> expenseList = new List<Member>();
            String strSQL = "SELECT * FROM Member where UserId = @acc ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@acc",userId)
            };
            using (IDataReader dr = dp.executeQuery2(strSQL, parameters))
            {
                while (dr.Read())
                {
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

        private void dgvMember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            txtName.Text = dgvMember.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            txtDOB.Text = dgvMember.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            txtCity.Text = dgvMember.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            txtCountry.Text = dgvMember.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
            txtUserId.Text = dgvMember.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();

            String strSQL = "select * from Users where UserId = @acc ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@acc",dgvMember.Rows[e.RowIndex].Cells[1].FormattedValue.ToString())
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


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (PRN211_Ass1Context context = new PRN211_Ass1Context())
            {

                Models.User u = new Models.User()
                {
                    UserName = txtUserName.Text,
                    Phone = txtPhone.Text,
                    Role = true,
                    Password = "admin123",
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
                        LoadData();
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
        private Models.User GetUserByUserName()
        {
            String strSQL = "select * from Users where UserId = @acc ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@acc",txtUserId.Text)
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
                    user1 = user;
                    return user;
                }
            }
            return null;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (PRN211_Ass1Context context = new PRN211_Ass1Context())
            {
                Member member = context.Members.FirstOrDefault(member => member.UserId == int.Parse(txtUserId.Text));
                if (member != null)
                {
                    member.Name = txtName.Text;
                    member.City = txtCity.Text;
                    member.Country = txtCountry.Text;
                    member.Dob = DateTime.Parse(txtDOB.Text);
                    context.SaveChanges();
                    MessageBox.Show("Edit sucees");

                }
                else
                {
                    MessageBox.Show("Edit fail");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text != null && GetUserByUserName() != null)
            {
                string srtSQL = "delete from Member where UserId = @id";
                SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter("@id",txtUserId.Text)
            };
                if (dp.executeNonQuery(srtSQL, parameters))
                {
                    srtSQL = "delete from Users where UserId = @id";
                    parameters = new SqlParameter[] {
             new SqlParameter("@id",txtUserId.Text) };
                    if (dp.executeNonQuery(srtSQL, parameters))
                    {
                        MessageBox.Show("Delete success");
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Delete fail");
                }
            }
            else
            {
                MessageBox.Show("Delete fail");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            LoadDataByUserId(SearchMember(cbSearch.Text, cbFilter.Text).UserId);
        }

        private Member SearchMember(string option, string filter)
        {
            String strSQL = null;
            if (option == "ID Member")
            {
                strSQL = "SELECT * FROM Member where MemberID =@acc ";
            }
            else
            if (option == "Name")
            {
                strSQL = "SELECT * FROM Member where Name =@acc ";
            }
            else
            if (filter == "City")
            {
                strSQL = "SELECT * FROM Member where City =@acc ";
            }
            else
            if (filter == "Country")
            {
                strSQL = "SELECT * FROM Member where Country =@acc ";
            }
            List<Member> expenseList = new List<Member>();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@acc",txtSearch.Text)
            };
            if (strSQL != null)
            {
                using (IDataReader dr = dp.executeQuery2(strSQL, parameters))
                {
                    while (dr.Read())
                    {
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
                        dgvMember.DataSource = expenseList;
                        return m;
                    }
                }
            }


            return null;
        }

        private void AdminManger_Load(object sender, EventArgs e)
        {

        }

        private void AdminManger_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
