namespace _4_NQVinh_Demo87
{
    partial class InsertForm
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
            btnSave = new Button();
            txtCategoryName = new TextBox();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(97, 85);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 28);
            btnSave.TabIndex = 12;
            btnSave.Text = "Insert";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(155, 32);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(335, 27);
            txtCategoryName.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 38);
            label2.Name = "label2";
            label2.Size = new Size(102, 17);
            label2.TabIndex = 9;
            label2.Text = "Category Name";
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(288, 85);
            button1.Name = "button1";
            button1.Size = new Size(107, 28);
            button1.TabIndex = 13;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // InsertForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 154);
            Controls.Add(button1);
            Controls.Add(btnSave);
            Controls.Add(txtCategoryName);
            Controls.Add(label2);
            Name = "InsertForm";
            Text = "InsertForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtCategoryName;
        private Label label2;
        private Button button1;
    }
}