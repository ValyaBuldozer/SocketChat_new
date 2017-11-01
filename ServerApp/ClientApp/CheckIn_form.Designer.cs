namespace ClientApp
{
    partial class CheckIn_form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckIn_form));
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.login_textBox = new System.Windows.Forms.TextBox();
            this.checkin_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.password_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_label.Location = new System.Drawing.Point(40, 8);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(57, 23);
            this.login_label.TabIndex = 0;
            this.login_label.Text = "LOG:";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_label.Location = new System.Drawing.Point(8, 53);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(89, 23);
            this.password_label.TabIndex = 1;
            this.password_label.Text = "PSWRD:";
            // 
            // login_textBox
            // 
            this.login_textBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_textBox.Location = new System.Drawing.Point(103, 8);
            this.login_textBox.Name = "login_textBox";
            this.login_textBox.Size = new System.Drawing.Size(173, 23);
            this.login_textBox.TabIndex = 3;
            // 
            // checkin_button
            // 
            this.checkin_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkin_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkin_button.Location = new System.Drawing.Point(121, 106);
            this.checkin_button.Name = "checkin_button";
            this.checkin_button.Size = new System.Drawing.Size(110, 32);
            this.checkin_button.TabIndex = 4;
            this.checkin_button.Text = "CHECK IN";
            this.checkin_button.UseVisualStyleBackColor = true;
            this.checkin_button.Click += new System.EventHandler(this.checkin_button_Click);
            // 
            // close_button
            // 
            this.close_button.BackgroundImage = global::ClientApp.Properties.Resources.close1;
            this.close_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close_button.Location = new System.Drawing.Point(0, 0);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(35, 35);
            this.close_button.TabIndex = 5;
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.DarkGray;
            this.panel.Controls.Add(this.close_button);
            this.panel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel.Location = new System.Drawing.Point(318, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(35, 150);
            this.panel.TabIndex = 1;
            // 
            // password_maskedTextBox
            // 
            this.password_maskedTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.password_maskedTextBox.Location = new System.Drawing.Point(103, 53);
            this.password_maskedTextBox.Name = "password_maskedTextBox";
            this.password_maskedTextBox.PasswordChar = '*';
            this.password_maskedTextBox.ResetOnSpace = false;
            this.password_maskedTextBox.Size = new System.Drawing.Size(173, 23);
            this.password_maskedTextBox.TabIndex = 5;
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CheckIn_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(351, 150);
            this.Controls.Add(this.password_maskedTextBox);
            this.Controls.Add(this.checkin_button);
            this.Controls.Add(this.login_textBox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_label);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CheckIn_form";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check In";
            this.Shown += new System.EventHandler(this.CheckIn_form_Shown);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox login_textBox;
        private System.Windows.Forms.Button checkin_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.MaskedTextBox password_maskedTextBox;
        private System.Windows.Forms.Timer timer;
    }
}