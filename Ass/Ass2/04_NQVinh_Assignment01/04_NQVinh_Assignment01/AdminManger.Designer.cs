namespace _04_NQVinh_Assignment01
{
    partial class AdminManger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminManger));
            dgvMember = new DataGridView();
            btnAdd = new Button();
            btnLoad = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            cbSearch = new ComboBox();
            btnFilter = new Button();
            cbFilter = new ComboBox();
            txtDOB = new TextBox();
            label2 = new Label();
            txtCountry = new TextBox();
            label6 = new Label();
            txtCity = new TextBox();
            label5 = new Label();
            txtPhone = new TextBox();
            label4 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtUserName = new TextBox();
            label1 = new Label();
            txtUserId = new TextBox();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvMember).BeginInit();
            SuspendLayout();
            // 
            // dgvMember
            // 
            dgvMember.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMember.Location = new Point(24, 12);
            dgvMember.Name = "dgvMember";
            dgvMember.RowHeadersWidth = 51;
            dgvMember.RowTemplate.Height = 29;
            dgvMember.Size = new Size(748, 217);
            dgvMember.TabIndex = 0;
            dgvMember.CellClick += dgvMember_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(97, 346);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(260, 346);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(436, 348);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(607, 346);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(24, 395);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search by";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbSearch
            // 
            cbSearch.FormattingEnabled = true;
            cbSearch.Items.AddRange(new object[] { "ID Member", "Name" });
            cbSearch.Location = new Point(124, 395);
            cbSearch.Name = "cbSearch";
            cbSearch.Size = new Size(180, 28);
            cbSearch.TabIndex = 6;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(310, 395);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 7;
            btnFilter.Text = "Filter by";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // cbFilter
            // 
            cbFilter.FormattingEnabled = true;
            cbFilter.Items.AddRange(new object[] { "City", "Country" });
            cbFilter.Location = new Point(410, 395);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(175, 28);
            cbFilter.TabIndex = 8;
            // 
            // txtDOB
            // 
            txtDOB.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtDOB.Location = new Point(364, 293);
            txtDOB.Name = "txtDOB";
            txtDOB.Size = new Size(113, 27);
            txtDOB.TabIndex = 53;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(263, 300);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 52;
            label2.Text = "Day of birth: ";
            // 
            // txtCountry
            // 
            txtCountry.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCountry.Location = new Point(570, 293);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(202, 27);
            txtCountry.TabIndex = 51;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(483, 300);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 50;
            label6.Text = "Country: ";
            // 
            // txtCity
            // 
            txtCity.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCity.Location = new Point(545, 254);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(227, 27);
            txtCity.TabIndex = 49;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(483, 257);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 48;
            label5.Text = "City: ";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtPhone.Location = new Point(326, 250);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(151, 27);
            txtPhone.TabIndex = 47;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(263, 257);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 46;
            label4.Text = "Phone: ";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(107, 293);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 27);
            txtName.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 296);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 44;
            label3.Text = "Name: ";
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtUserName.Location = new Point(107, 250);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(150, 27);
            txtUserName.TabIndex = 43;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 257);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 42;
            label1.Text = "User Name: ";
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(12, 348);
            txtUserId.Name = "txtUserId";
            txtUserId.ReadOnly = true;
            txtUserId.Size = new Size(34, 27);
            txtUserId.TabIndex = 54;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(591, 396);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(181, 27);
            txtSearch.TabIndex = 55;
            // 
            // AdminManger
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(txtSearch);
            Controls.Add(txtUserId);
            Controls.Add(txtDOB);
            Controls.Add(label2);
            Controls.Add(txtCountry);
            Controls.Add(label6);
            Controls.Add(txtCity);
            Controls.Add(label5);
            Controls.Add(txtPhone);
            Controls.Add(label4);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(txtUserName);
            Controls.Add(label1);
            Controls.Add(cbFilter);
            Controls.Add(btnFilter);
            Controls.Add(cbSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnLoad);
            Controls.Add(btnAdd);
            Controls.Add(dgvMember);
            Name = "AdminManger";
            Text = "AdminManger";
            Load += AdminManger_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvMember).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMember;
        private Button btnAdd;
        private Button btnLoad;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private ComboBox cbSearch;
        private Button btnFilter;
        private ComboBox cbFilter;
        private TextBox txtDOB;
        private Label label2;
        private TextBox txtCountry;
        private Label label6;
        private TextBox txtCity;
        private Label label5;
        private TextBox txtPhone;
        private Label label4;
        private TextBox txtName;
        private Label label3;
        private TextBox txtUserName;
        private Label label1;
        private TextBox txtUserId;
        private TextBox txtSearch;
    }
}