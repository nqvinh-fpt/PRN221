using System.Windows.Forms;

namespace _4_NQVinh_Demo87
{
    public partial class FormCategory : Form
    {
        public FormCategory()
        {
            InitializeComponent();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            dgvData.Width = this.Width - 80-10;
            dgvData.Height = this.Height - 200-100;
            dgvData.Location = new Point(30 , 164);
        }
        private void LoadCategories()
        {
            var categories = ManagerCategories.Instance.GetCategories();
            txtCategoryID.DataBindings.Clear();
            txtCategoryName.DataBindings.Clear();
            txtCategoryID.DataBindings.Add("Text", categories, "CategoryID");
            txtCategoryName.DataBindings.Add("Text", categories, "CategoryName");
            dgvData.DataSource = categories;
        }

        private void Form1_Load(object sender, EventArgs e) => LoadCategories();

        private void btnSave_Click(object sender, EventArgs e)
        {

            using (InsertForm inputDialog = new InsertForm())
            {
                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    string dataFromDialog = inputDialog.UserData;
                    LoadCategories();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (UpdateForm updateDialog = new UpdateForm(int.Parse(txtCategoryID.Text),txtCategoryName.Text))
            {

                if (updateDialog.ShowDialog() == DialogResult.OK)
                {
                    string dataFromDialog = updateDialog.UserData;
                    LoadCategories();
                }

            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            
            if (result == DialogResult.Yes)
            {
                try
                {
                    var category = new Category
                    {
                        CategoryID = int.Parse(txtCategoryID.Text),
                    };
                    ManagerCategories.Instance.DeleteCategory(category);
                    LoadCategories();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete Category");
                }
            }
            
        }
        
    }
}
