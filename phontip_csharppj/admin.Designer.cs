
namespace phontip_csharppj
{
    partial class admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin));
            this.passw_textBox = new System.Windows.Forms.TextBox();
            this.login_Button = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cancel = new System.Windows.Forms.Label();
            this.ShowPassword_checkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // passw_textBox
            // 
            this.passw_textBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passw_textBox.Location = new System.Drawing.Point(385, 337);
            this.passw_textBox.Multiline = true;
            this.passw_textBox.Name = "passw_textBox";
            this.passw_textBox.PasswordChar = '*';
            this.passw_textBox.Size = new System.Drawing.Size(308, 37);
            this.passw_textBox.TabIndex = 27;
            // 
            // login_Button
            // 
            this.login_Button.ActiveBorderThickness = 1;
            this.login_Button.ActiveCornerRadius = 20;
            this.login_Button.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.login_Button.ActiveForecolor = System.Drawing.Color.White;
            this.login_Button.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.login_Button.BackColor = System.Drawing.Color.RosyBrown;
            this.login_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("login_Button.BackgroundImage")));
            this.login_Button.ButtonText = "Login";
            this.login_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_Button.ForeColor = System.Drawing.Color.Black;
            this.login_Button.IdleBorderThickness = 1;
            this.login_Button.IdleCornerRadius = 20;
            this.login_Button.IdleFillColor = System.Drawing.Color.White;
            this.login_Button.IdleForecolor = System.Drawing.Color.Black;
            this.login_Button.IdleLineColor = System.Drawing.Color.RosyBrown;
            this.login_Button.Location = new System.Drawing.Point(458, 459);
            this.login_Button.Margin = new System.Windows.Forms.Padding(5);
            this.login_Button.Name = "login_Button";
            this.login_Button.Size = new System.Drawing.Size(164, 49);
            this.login_Button.TabIndex = 24;
            this.login_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.login_Button.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(381, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(442, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 34);
            this.label2.TabIndex = 21;
            this.label2.Text = "Admin login";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(419, 89);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(218, 94);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, -9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 629);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // cancel
            // 
            this.cancel.AutoSize = true;
            this.cancel.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancel.Location = new System.Drawing.Point(500, 513);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(83, 23);
            this.cancel.TabIndex = 28;
            this.cancel.Text = "Cancel";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ShowPassword_checkBox
            // 
            this.ShowPassword_checkBox.AutoSize = true;
            this.ShowPassword_checkBox.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPassword_checkBox.Location = new System.Drawing.Point(543, 380);
            this.ShowPassword_checkBox.Name = "ShowPassword_checkBox";
            this.ShowPassword_checkBox.Size = new System.Drawing.Size(150, 25);
            this.ShowPassword_checkBox.TabIndex = 36;
            this.ShowPassword_checkBox.Text = "ShowPassword";
            this.ShowPassword_checkBox.UseVisualStyleBackColor = true;
            this.ShowPassword_checkBox.CheckedChanged += new System.EventHandler(this.ShowPassword_checkBox_CheckedChanged);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(711, 619);
            this.Controls.Add(this.ShowPassword_checkBox);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.passw_textBox);
            this.Controls.Add(this.login_Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADMIN LOGIN";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passw_textBox;
        private Bunifu.Framework.UI.BunifuThinButton2 login_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label cancel;
        private System.Windows.Forms.CheckBox ShowPassword_checkBox;
    }
}