namespace _04_NQVinh_Assignment01
{
    partial class FormForgetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForgetPassword));
            cbShowPassword = new CheckBox();
            btnLogin = new Button();
            label3 = new Label();
            txtPhone = new TextBox();
            txtUserName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtNewPassword = new TextBox();
            label4 = new Label();
            txtConfirmPassword = new TextBox();
            label5 = new Label();
            button1 = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // cbShowPassword
            // 
            cbShowPassword.AutoSize = true;
            cbShowPassword.BackColor = Color.Transparent;
            cbShowPassword.ForeColor = Color.White;
            cbShowPassword.Location = new Point(556, 304);
            cbShowPassword.Name = "cbShowPassword";
            cbShowPassword.Size = new Size(132, 24);
            cbShowPassword.TabIndex = 22;
            cbShowPassword.Text = "Show Password";
            cbShowPassword.UseVisualStyleBackColor = false;
            cbShowPassword.CheckedChanged += cbShowPassword_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.MenuHighlight;
            btnLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.Transparent;
            btnLogin.Location = new Point(532, 348);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(156, 47);
            btnLogin.TabIndex = 20;
            btnLogin.Text = "Change Password";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(161, 20);
            label3.Name = "label3";
            label3.Size = new Size(471, 51);
            label3.TabIndex = 19;
            label3.Text = "CHANGE PASSWORD";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtPhone.Location = new Point(282, 143);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(406, 38);
            txtPhone.TabIndex = 18;
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtUserName.Location = new Point(282, 88);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(406, 38);
            txtUserName.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(43, 143);
            label2.Name = "label2";
            label2.Size = new Size(94, 31);
            label2.TabIndex = 16;
            label2.Text = "Phone: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(43, 88);
            label1.Name = "label1";
            label1.Size = new Size(143, 31);
            label1.TabIndex = 15;
            label1.Text = "User Name: ";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtNewPassword.Location = new Point(282, 201);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(406, 38);
            txtNewPassword.TabIndex = 24;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(43, 201);
            label4.Name = "label4";
            label4.Size = new Size(174, 31);
            label4.TabIndex = 23;
            label4.Text = "New Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtConfirmPassword.Location = new Point(282, 260);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(406, 38);
            txtConfirmPassword.TabIndex = 26;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(43, 260);
            label5.Name = "label5";
            label5.Size = new Size(214, 31);
            label5.TabIndex = 25;
            label5.Text = "Confirm Password:";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(43, 348);
            button1.Name = "button1";
            button1.Size = new Size(229, 47);
            button1.TabIndex = 27;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = SystemColors.MenuHighlight;
            btnRegister.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.Transparent;
            btnRegister.Location = new Point(320, 348);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(170, 47);
            btnRegister.TabIndex = 28;
            btnRegister.Text = "Sign up";
            btnRegister.UseVisualStyleBackColor = false;
            // 
            // FormForgetPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(button1);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label5);
            Controls.Add(txtNewPassword);
            Controls.Add(label4);
            Controls.Add(cbShowPassword);
            Controls.Add(btnLogin);
            Controls.Add(label3);
            Controls.Add(txtPhone);
            Controls.Add(txtUserName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormForgetPassword";
            Text = "Forget Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox cbShowPassword;
        private Button btnLogin;
        private Label label3;
        private TextBox txtPhone;
        private TextBox txtUserName;
        private Label label2;
        private Label label1;
        private TextBox txtNewPassword;
        private Label label4;
        private TextBox txtConfirmPassword;
        private Label label5;
        private Button button1;
        private Button btnRegister;
    }
}