namespace _04_NQVinh_Assignment01
{
    partial class UserManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManager));
            btnViewUser = new Button();
            btnViewUpdate = new Button();
            SuspendLayout();
            // 
            // btnViewUser
            // 
            btnViewUser.BackColor = SystemColors.Highlight;
            btnViewUser.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnViewUser.ForeColor = Color.White;
            btnViewUser.Location = new Point(169, 73);
            btnViewUser.Name = "btnViewUser";
            btnViewUser.Size = new Size(427, 119);
            btnViewUser.TabIndex = 0;
            btnViewUser.Text = "View Profile";
            btnViewUser.UseVisualStyleBackColor = false;
            btnViewUser.Click += btnViewUser_Click;
            // 
            // btnViewUpdate
            // 
            btnViewUpdate.BackColor = SystemColors.Highlight;
            btnViewUpdate.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnViewUpdate.ForeColor = Color.White;
            btnViewUpdate.Location = new Point(169, 223);
            btnViewUpdate.Name = "btnViewUpdate";
            btnViewUpdate.Size = new Size(427, 119);
            btnViewUpdate.TabIndex = 1;
            btnViewUpdate.Text = "Update Profile";
            btnViewUpdate.UseVisualStyleBackColor = false;
            btnViewUpdate.Click += btnViewUpdate_Click;
            // 
            // UserManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnViewUpdate);
            Controls.Add(btnViewUser);
            Name = "UserManager";
            Text = "Normal User";
            ResumeLayout(false);
        }

        #endregion

        private Button btnViewUser;
        private Button btnViewUpdate;
    }
}