namespace _04_NQVinh_Assignment01
{
    partial class ViewProfileUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewProfileUser));
            txtUserName = new TextBox();
            label1 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtPhone = new TextBox();
            label4 = new Label();
            txtCity = new TextBox();
            label5 = new Label();
            txtCountry = new TextBox();
            label6 = new Label();
            btnUpdate = new Button();
            btnUserManager = new Button();
            txtDOB = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtUserName.Location = new Point(260, 56);
            txtUserName.Name = "txtUserName";
            txtUserName.ReadOnly = true;
            txtUserName.Size = new Size(406, 38);
            txtUserName.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(77, 56);
            label1.Name = "label1";
            label1.Size = new Size(143, 31);
            label1.TabIndex = 15;
            label1.Text = "User Name: ";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtName.Location = new Point(260, 100);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(406, 38);
            txtName.TabIndex = 21;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(77, 100);
            label3.Name = "label3";
            label3.Size = new Size(89, 31);
            label3.TabIndex = 20;
            label3.Text = "Name: ";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtPhone.Location = new Point(260, 144);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(406, 38);
            txtPhone.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(77, 144);
            label4.Name = "label4";
            label4.Size = new Size(94, 31);
            label4.TabIndex = 22;
            label4.Text = "Phone: ";
            // 
            // txtCity
            // 
            txtCity.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtCity.Location = new Point(260, 188);
            txtCity.Name = "txtCity";
            txtCity.ReadOnly = true;
            txtCity.Size = new Size(406, 38);
            txtCity.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(77, 188);
            label5.Name = "label5";
            label5.Size = new Size(68, 31);
            label5.TabIndex = 24;
            label5.Text = "City: ";
            // 
            // txtCountry
            // 
            txtCountry.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtCountry.Location = new Point(260, 232);
            txtCountry.Name = "txtCountry";
            txtCountry.ReadOnly = true;
            txtCountry.Size = new Size(406, 38);
            txtCountry.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(77, 232);
            label6.Name = "label6";
            label6.Size = new Size(113, 31);
            label6.TabIndex = 26;
            label6.Text = "Country: ";
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.Highlight;
            btnUpdate.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(396, 347);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(270, 49);
            btnUpdate.TabIndex = 28;
            btnUpdate.Text = "Update Profile";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnUserManager
            // 
            btnUserManager.BackColor = SystemColors.Highlight;
            btnUserManager.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnUserManager.ForeColor = Color.White;
            btnUserManager.Location = new Point(120, 347);
            btnUserManager.Name = "btnUserManager";
            btnUserManager.Size = new Size(270, 49);
            btnUserManager.TabIndex = 43;
            btnUserManager.Text = "User Manager";
            btnUserManager.UseVisualStyleBackColor = false;
            btnUserManager.Click += btnUserManager_Click;
            // 
            // txtDOB
            // 
            txtDOB.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtDOB.Location = new Point(260, 276);
            txtDOB.Name = "txtDOB";
            txtDOB.ReadOnly = true;
            txtDOB.Size = new Size(406, 38);
            txtDOB.TabIndex = 45;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(77, 276);
            label2.Name = "label2";
            label2.Size = new Size(156, 31);
            label2.TabIndex = 44;
            label2.Text = "Day of birth: ";
            // 
            // ViewProfileUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(txtDOB);
            Controls.Add(label2);
            Controls.Add(btnUserManager);
            Controls.Add(btnUpdate);
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
            Name = "ViewProfileUser";
            Text = "View Profile";
            Load += ViewProfileUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUserName;
        private Label label1;
        private TextBox txtName;
        private Label label3;
        private TextBox txtPhone;
        private Label label4;
        private TextBox txtCity;
        private Label label5;
        private TextBox txtCountry;
        private Label label6;
        private Button btnUpdate;
        private Button btnUserManager;
        private TextBox txtDOB;
        private Label label2;
    }
}