using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_NQVinh_Demo87
{
    public partial class InsertForm : Form
    {
        public string UserData { get; private set; }
        public InsertForm()
        {
            InitializeComponent();
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UserData = txtCategoryName.Text;
            DialogResult = DialogResult.OK;
            try
            {
                var category = new Category { CategoryName = txtCategoryName.Text };
                ManagerCategories.Instance.InsertCategory(category);
                MessageBox.Show( "Insert "+txtCategoryName.Text+" succes");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Category");
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
