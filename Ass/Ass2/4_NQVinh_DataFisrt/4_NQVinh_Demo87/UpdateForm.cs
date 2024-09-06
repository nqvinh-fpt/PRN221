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
    public partial class UpdateForm : Form
    {
        public string UserData { get; private set; }
        int categoryId; string categoryName;

        public UpdateForm(int CategoryId, string CategoryName)
        {

            this.categoryName = CategoryName;
            this.categoryId = CategoryId;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserData = txtCategoryName.Text;
            DialogResult = DialogResult.OK;
            try
            {
                var category = new Category
                {
                    CategoryID = int.Parse(txtCategoryID.Text),
                    CategoryName = txtCategoryName.Text,
                };
                ManagerCategories.Instance.UpdateCategory(category);
                MessageBox.Show("Update " + txtCategoryID.Text + " succes");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Category");
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            txtCategoryID.Text = categoryId.ToString();
            txtCategoryName.Text = categoryName.ToString();
        }
    }
}
