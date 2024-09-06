using Microsoft.Data.SqlClient;
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
    public partial class UserManager : Form
    {
        DataProvider dp = new DataProvider();
        int userId;
        string memberName;
        public UserManager(int userID)
        {
            this.userId = userID;
            InitializeComponent();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            ViewProfileUser viewProfileUser = new ViewProfileUser(userId);
            viewProfileUser.Show();
            this.Hide();
        }

        private void btnViewUpdate_Click(object sender, EventArgs e)
        {
            
            UpdateUser updateUser = new UpdateUser(userId);
            updateUser.Show();
            this.Hide();
        }
    }
}
