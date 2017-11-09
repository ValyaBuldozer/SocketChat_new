namespace ClientApp_MF
{
    partial class Chat_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat_form));
            this.sendMessage_button = new MetroFramework.Controls.MetroButton();
            this.message_label = new MetroFramework.Controls.MetroLabel();
            this.Chat_textBox = new MetroFramework.Controls.MetroTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.Users_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.СhangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessage_textBox = new MetroFramework.Controls.MetroTextBox();
            this.users_box = new MetroFramework.Controls.MetroTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendMessage_button
            // 
            this.sendMessage_button.Location = new System.Drawing.Point(374, 418);
            this.sendMessage_button.Name = "sendMessage_button";
            this.sendMessage_button.Size = new System.Drawing.Size(75, 25);
            this.sendMessage_button.TabIndex = 0;
            this.sendMessage_button.Text = "SEND";
            // 
            // message_label
            // 
            this.message_label.AutoSize = true;
            this.message_label.Location = new System.Drawing.Point(23, 418);
            this.message_label.Name = "message_label";
            this.message_label.Size = new System.Drawing.Size(70, 19);
            this.message_label.TabIndex = 1;
            this.message_label.Text = "MESSAGE:";
            // 
            // Chat_textBox
            // 
            this.Chat_textBox.Location = new System.Drawing.Point(166, 103);
            this.Chat_textBox.Multiline = true;
            this.Chat_textBox.Name = "Chat_textBox";
            this.Chat_textBox.Size = new System.Drawing.Size(283, 299);
            this.Chat_textBox.TabIndex = 2;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About,
            this.Users_menu,
            this.СhangeUser,
            this.Exit});
            this.menuStrip.Location = new System.Drawing.Point(20, 60);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(433, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(94, 20);
            this.About.Text = "О программе";
            this.About.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // Users_menu
            // 
            this.Users_menu.Name = "Users_menu";
            this.Users_menu.Size = new System.Drawing.Size(97, 20);
            this.Users_menu.Text = "Пользователи";
            this.Users_menu.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // СhangeUser
            // 
            this.СhangeUser.Name = "СhangeUser";
            this.СhangeUser.Size = new System.Drawing.Size(132, 20);
            this.СhangeUser.Text = "Сменить пользоватя";
            this.СhangeUser.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(53, 20);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // sendMessage_textBox
            // 
            this.sendMessage_textBox.Location = new System.Drawing.Point(99, 418);
            this.sendMessage_textBox.Multiline = true;
            this.sendMessage_textBox.Name = "sendMessage_textBox";
            this.sendMessage_textBox.Size = new System.Drawing.Size(257, 23);
            this.sendMessage_textBox.TabIndex = 1;
            // 
            // users_box
            // 
            this.users_box.Location = new System.Drawing.Point(23, 103);
            this.users_box.Multiline = true;
            this.users_box.Name = "users_box";
            this.users_box.Size = new System.Drawing.Size(126, 299);
            this.users_box.TabIndex = 5;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Chat_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 461);
            this.Controls.Add(this.users_box);
            this.Controls.Add(this.sendMessage_textBox);
            this.Controls.Add(this.Chat_textBox);
            this.Controls.Add(this.message_label);
            this.Controls.Add(this.sendMessage_button);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Chat_form";
            this.Resizable = false;
            this.Text = "CHAT";
            this.Shown += new System.EventHandler(this.Chat_form_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton sendMessage_button;
        private MetroFramework.Controls.MetroLabel message_label;
        private MetroFramework.Controls.MetroTextBox Chat_textBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.ToolStripMenuItem Users_menu;
        private System.Windows.Forms.ToolStripMenuItem СhangeUser;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private MetroFramework.Controls.MetroTextBox sendMessage_textBox;
        private MetroFramework.Controls.MetroTextBox users_box;
        private System.Windows.Forms.Timer timer;
    }
}