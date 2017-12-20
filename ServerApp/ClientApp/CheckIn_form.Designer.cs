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
            this.close_button = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.help_button = new System.Windows.Forms.Button();
            this.password_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.checkin_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // login_label
            // 
            this.login_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_label.Location = new System.Drawing.Point(56, 13);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(57, 23);
            this.login_label.TabIndex = 0;
            this.login_label.Text = "LOG:";
            // 
            // password_label
            // 
            this.password_label.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.password_label.AutoSize = true;
            this.password_label.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password_label.Location = new System.Drawing.Point(24, 63);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(89, 23);
            this.password_label.TabIndex = 1;
            this.password_label.Text = "PSWRD:";
            // 
            // login_textBox
            // 
            this.login_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.login_textBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_textBox.Location = new System.Drawing.Point(119, 13);
            this.login_textBox.Name = "login_textBox";
            this.login_textBox.Size = new System.Drawing.Size(181, 23);
            this.login_textBox.TabIndex = 0;
            this.login_textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // close_button
            // 
            this.close_button.BackgroundImage = global::ClientApp.Properties.Resources.close1;
            this.close_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.close_button.Location = new System.Drawing.Point(0, 0);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(34, 35);
            this.close_button.TabIndex = 2;
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel.Controls.Add(this.help_button);
            this.panel.Controls.Add(this.close_button);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel.Location = new System.Drawing.Point(309, 3);
            this.panel.Name = "panel";
            this.tableLayoutPanel.SetRowSpan(this.panel, 3);
            this.panel.Size = new System.Drawing.Size(40, 134);
            this.panel.TabIndex = 1;
            // 
            // help_button
            // 
            this.help_button.BackgroundImage = global::ClientApp.Properties.Resources.helper_ico;
            this.help_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.help_button.Location = new System.Drawing.Point(-1, 30);
            this.help_button.Name = "help_button";
            this.help_button.Size = new System.Drawing.Size(34, 35);
            this.help_button.TabIndex = 3;
            this.help_button.UseVisualStyleBackColor = true;
            this.help_button.Click += new System.EventHandler(this.help_button_Click);
            // 
            // password_maskedTextBox
            // 
            this.password_maskedTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.password_maskedTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.password_maskedTextBox.Location = new System.Drawing.Point(119, 63);
            this.password_maskedTextBox.Name = "password_maskedTextBox";
            this.password_maskedTextBox.PasswordChar = '*';
            this.password_maskedTextBox.ResetOnSpace = false;
            this.password_maskedTextBox.Size = new System.Drawing.Size(181, 23);
            this.password_maskedTextBox.TabIndex = 1;
            this.password_maskedTextBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // checkin_button
            // 
            this.checkin_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkin_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkin_button.Enabled = false;
            this.checkin_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkin_button.Location = new System.Drawing.Point(119, 103);
            this.checkin_button.Name = "checkin_button";
            this.checkin_button.Size = new System.Drawing.Size(184, 34);
            this.checkin_button.TabIndex = 4;
            this.checkin_button.Text = "CHECK IN";
            this.checkin_button.UseVisualStyleBackColor = true;
            this.checkin_button.Click += new System.EventHandler(this.checkin_button_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.84615F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.15385F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel.Controls.Add(this.checkin_button, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.panel, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.password_maskedTextBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.password_label, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.login_textBox, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.login_label, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(352, 140);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // CheckIn_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(352, 140);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CheckIn_form";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check In";
            this.Shown += new System.EventHandler(this.CheckIn_form_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckIn_form_KeyDown);
            this.panel.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.TextBox login_textBox;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.MaskedTextBox password_maskedTextBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button checkin_button;
        private System.Windows.Forms.Button help_button;
    }
}