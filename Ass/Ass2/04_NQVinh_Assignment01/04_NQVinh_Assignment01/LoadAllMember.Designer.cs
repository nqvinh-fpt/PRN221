namespace _04_NQVinh_Assignment01
{
    partial class LoadAllMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadAllMember));
            txtSearch = new TextBox();
            txtUserId = new TextBox();
            cbFilter = new ComboBox();
            btnFilter = new Button();
            cbSearch = new ComboBox();
            btnSearch = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnLoad = new Button();
            btnAdd = new Button();
            dgvMember = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMember).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(626, 390);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(181, 27);
            txtSearch.TabIndex = 78;
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(47, 342);
            txtUserId.Name = "txtUserId";
            txtUserId.ReadOnly = true;
            txtUserId.Size = new Size(34, 27);
            txtUserId.TabIndex = 77;
            // 
            // cbFilter
            // 
            cbFilter.FormattingEnabled = true;
            cbFilter.Items.AddRange(new object[] { "City", "Country" });
            cbFilter.Location = new Point(445, 389);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(175, 28);
            cbFilter.TabIndex = 64;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(345, 389);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 63;
            btnFilter.Text = "Filter by";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // cbSearch
            // 
            cbSearch.FormattingEnabled = true;
            cbSearch.Items.AddRange(new object[] { "ID Member", "Name" });
            cbSearch.Location = new Point(159, 389);
            cbSearch.Name = "cbSearch";
            cbSearch.Size = new Size(180, 28);
            cbSearch.TabIndex = 62;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(59, 389);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 61;
            btnSearch.Text = "Search by";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(642, 340);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 60;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(471, 342);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 59;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(295, 340);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 58;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(132, 340);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 57;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvMember
            // 
            dgvMember.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMember.Location = new Point(40, 119);
            dgvMember.Name = "dgvMember";
            dgvMember.RowHeadersWidth = 51;
            dgvMember.RowTemplate.Height = 29;
            dgvMember.Size = new Size(748, 217);
            dgvMember.TabIndex = 56;
            // 
            // button1
            // 
            button1.Location = new Point(653, 23);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 79;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LoadAllMember
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(txtSearch);
            Controls.Add(txtUserId);
            Controls.Add(cbFilter);
            Controls.Add(btnFilter);
            Controls.Add(cbSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnLoad);
            Controls.Add(btnAdd);
            Controls.Add(dgvMember);
            Name = "LoadAllMember";
            Text = "LoadAllMember";
            Load += LoadAllMember_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMember).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private TextBox txtUserId;
        private ComboBox cbFilter;
        private Button btnFilter;
        private ComboBox cbSearch;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnLoad;
        private Button btnAdd;
        private DataGridView dgvMember;
        private Button button1;
    }
}