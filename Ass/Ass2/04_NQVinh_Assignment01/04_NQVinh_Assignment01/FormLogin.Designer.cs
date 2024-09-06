namespace _04_NQVinh_Assignment01
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            llbForget = new LinkLabel();
            btnLogin = new Button();
            label3 = new Label();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cbShowPassword = new CheckBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // llbForget
            // 
            llbForget.AutoSize = true;
            llbForget.BackColor = Color.Transparent;
            llbForget.LinkColor = Color.DodgerBlue;
            llbForget.Location = new Point(501, 345);
            llbForget.Name = "llbForget";
            llbForget.Size = new Size(176, 20);
            llbForget.TabIndex = 13;
            llbForget.TabStop = true;
            llbForget.Text = "Forget Password, Sign Up";
            llbForget.LinkClicked += llbForget_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.MenuHighlight;
            btnLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.Transparent;
            btnLogin.Location = new Point(498, 280);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(179, 47);
            btnLogin.TabIndex = 12;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(334, 66);
            label3.Name = "label3";
            label3.Size = new Size(168, 51);
            label3.TabIndex = 11;
            label3.Text = "LOGIN";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtPassword.Location = new Point(271, 196);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(406, 38);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtUserName.Location = new Point(271, 142);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(406, 38);
            txtUserName.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(88, 196);
            label2.Name = "label2";
            label2.Size = new Size(120, 31);
            label2.TabIndex = 8;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(88, 142);
            label1.Name = "label1";
            label1.Size = new Size(143, 31);
            label1.TabIndex = 7;
            label1.Text = "User Name: ";
            // 
            // cbShowPassword
            // 
            cbShowPassword.AutoSize = true;
            cbShowPassword.BackColor = Color.Transparent;
            cbShowPassword.ForeColor = Color.White;
            cbShowPassword.Location = new Point(545, 250);
            cbShowPassword.Name = "cbShowPassword";
            cbShowPassword.Size = new Size(132, 24);
            cbShowPassword.TabIndex = 14;
            cbShowPassword.Text = "Show Password";
            cbShowPassword.UseVisualStyleBackColor = false;
            cbShowPassword.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = SystemColors.MenuHighlight;
            btnRegister.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.ForeColor = Color.Transparent;
            btnRegister.Location = new Point(313, 280);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(179, 47);
            btnRegister.TabIndex = 15;
            btnRegister.Text = "Sign up";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(cbShowPassword);
            Controls.Add(llbForget);
            Controls.Add(btnLogin);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel llbForget;
        private Button btnLogin;
        private Label label3;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label label2;
        private Label label1;
        private CheckBox cbShowPassword;
        private Button btnRegister;
    }
}