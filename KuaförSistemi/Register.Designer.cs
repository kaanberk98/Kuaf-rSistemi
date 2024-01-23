namespace KuaförSistemi
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            panel1 = new Panel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel3 = new Panel();
            txtPassword = new TextBox();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            txtKAdi = new TextBox();
            pictureBox4 = new PictureBox();
            panel4 = new Panel();
            txtPhone = new TextBox();
            btnLogin = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(118, 69, 59);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(373, 104);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(347, 0);
            label3.Name = "label3";
            label3.Size = new Size(26, 27);
            label3.TabIndex = 1;
            label3.Text = "X";
            label3.Click += label3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(143, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(97, 89);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(31, 254);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(29, 26);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(118, 69, 59);
            panel3.Location = new Point(21, 287);
            panel3.Name = "panel3";
            panel3.Size = new Size(330, 1);
            panel3.TabIndex = 20;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.Control;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = SystemColors.ActiveCaptionText;
            txtPassword.Location = new Point(73, 256);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(270, 24);
            txtPassword.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user;
            pictureBox2.Location = new Point(31, 163);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 26);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(118, 69, 59);
            panel2.Location = new Point(21, 196);
            panel2.Name = "panel2";
            panel2.Size = new Size(330, 1);
            panel2.TabIndex = 17;
            // 
            // txtKAdi
            // 
            txtKAdi.BackColor = SystemColors.Control;
            txtKAdi.BorderStyle = BorderStyle.None;
            txtKAdi.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtKAdi.ForeColor = SystemColors.ActiveCaptionText;
            txtKAdi.Location = new Point(73, 165);
            txtKAdi.Multiline = true;
            txtKAdi.Name = "txtKAdi";
            txtKAdi.Size = new Size(270, 24);
            txtKAdi.TabIndex = 0;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(31, 349);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(29, 26);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 24;
            pictureBox4.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(118, 69, 59);
            panel4.Location = new Point(21, 382);
            panel4.Name = "panel4";
            panel4.Size = new Size(330, 1);
            panel4.TabIndex = 23;
            // 
            // txtPhone
            // 
            txtPhone.BackColor = SystemColors.Control;
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtPhone.ForeColor = SystemColors.ActiveCaptionText;
            txtPhone.Location = new Point(73, 351);
            txtPhone.Multiline = true;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(270, 24);
            txtPhone.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Chocolate;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(111, 400);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(157, 56);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Kayıt Ol";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 468);
            Controls.Add(btnLogin);
            Controls.Add(pictureBox4);
            Controls.Add(panel4);
            Controls.Add(txtPhone);
            Controls.Add(pictureBox3);
            Controls.Add(panel3);
            Controls.Add(txtPassword);
            Controls.Add(pictureBox2);
            Controls.Add(panel2);
            Controls.Add(txtKAdi);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminLogin";
            Load += Register_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Panel panel3;
        private TextBox txtPassword;
        private PictureBox pictureBox2;
        private Panel panel2;
        private TextBox txtKAdi;
        private PictureBox pictureBox4;
        private Panel panel4;
        private TextBox txtPhone;
        private Button btnLogin;
    }
}