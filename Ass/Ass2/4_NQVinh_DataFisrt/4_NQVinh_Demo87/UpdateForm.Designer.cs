namespace _4_NQVinh_Demo87
{
    partial class UpdateForm
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
            button1 = new Button();
            btnSave = new Button();
            txtCategoryName = new TextBox();
            label2 = new Label();
            txtCategoryID = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(291, 106);
            button1.Name = "button1";
            button1.Size = new Size(107, 28);
            button1.TabIndex = 17;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(100, 106);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 28);
            btnSave.TabIndex = 16;
            btnSave.Text = "Update";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(161, 64);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(335, 27);
            txtCategoryName.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(38, 70);
            label2.Name = "label2";
            label2.Size = new Size(102, 17);
            label2.TabIndex = 14;
            label2.Text = "Category Name";
            // 
            // txtCategoryID
            // 
            txtCategoryID.Location = new Point(161, 31);
            txtCategoryID.Name = "txtCategoryID";
            txtCategoryID.ReadOnly = true;
            txtCategoryID.Size = new Size(335, 27);
            txtCategoryID.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(38, 37);
            label1.Name = "label1";
            label1.Size = new Size(82, 17);
            label1.TabIndex = 18;
            label1.Text = "Category ID";
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 158);
            Controls.Add(txtCategoryID);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(btnSave);
            Controls.Add(txtCategoryName);
            Controls.Add(label2);
            Name = "UpdateForm";
            Text = "UpdateForm";
            Load += UpdateForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnSave;
        private TextBox txtCategoryName;
        private Label label2;
        private TextBox txtCategoryID;
        private Label label1;
    }
}