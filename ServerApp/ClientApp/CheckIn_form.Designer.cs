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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckIn_form));
            this.login_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.login_textBox = new System.Windows.Forms.TextBox();
            this.checkin_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_label.Location = new System.Drawing.Point(29, 28);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(52, 16);
            this.login_label.TabIndex = 0;
            this.login_label.Text = "Логин:";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_label.Location = new System.Drawing.Point(29, 77);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(63, 16);
            this.password_label.TabIndex = 1;
            this.password_label.Text = "Пароль:";
            // 
            // password_textBox
            // 
            this.password_textBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_textBox.Location = new System.Drawing.Point(116, 70);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(173, 23);
            this.password_textBox.TabIndex = 2;
            // 
            // login_textBox
            // 
            this.login_textBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_textBox.Location = new System.Drawing.Point(116, 25);
            this.login_textBox.Name = "login_textBox";
            this.login_textBox.Size = new System.Drawing.Size(173, 23);
            this.login_textBox.TabIndex = 3;
            // 
            // checkin_button
            // 
            this.checkin_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkin_button.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkin_button.Location = new System.Drawing.Point(116, 123);
            this.checkin_button.Name = "checkin_button";
            this.checkin_button.Size = new System.Drawing.Size(104, 32);
            this.checkin_button.TabIndex = 4;
            this.checkin_button.Text = "CHECK IN";
            this.checkin_button.UseVisualStyleBackColor = true;
            this.checkin_button.Click += new System.EventHandler(this.checkin_button_Click);
            // 
            // CheckIn_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(329, 167);
            this.Controls.Add(this.checkin_button);
            this.Controls.Add(this.login_textBox);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CheckIn_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox login_textBox;
        private System.Windows.Forms.Button checkin_button;
    }
}