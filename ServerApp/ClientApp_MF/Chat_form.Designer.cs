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
            this.chat_textbox = new MetroFramework.Controls.MetroTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.users_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.change_user = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMessage = new MetroFramework.Controls.MetroTextBox();
            this.users_box = new MetroFramework.Controls.MetroTextBox();
            this.send_button = new MetroFramework.Controls.MetroButton();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // chat_textbox
            // 
            this.chat_textbox.Location = new System.Drawing.Point(159, 103);
            this.chat_textbox.Multiline = true;
            this.chat_textbox.Name = "chat_textbox";
            this.chat_textbox.Size = new System.Drawing.Size(290, 299);
            this.chat_textbox.TabIndex = 2;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about,
            this.users_menu,
            this.change_user,
            this.exit});
            this.menuStrip.Location = new System.Drawing.Point(20, 60);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(433, 24);
            this.menuStrip.TabIndex = 3;
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(94, 20);
            this.about.Text = "О программе";
            // 
            // users_menu
            // 
            this.users_menu.Name = "users_menu";
            this.users_menu.Size = new System.Drawing.Size(97, 20);
            this.users_menu.Text = "Пользователи";
            // 
            // change_user
            // 
            this.change_user.Name = "change_user";
            this.change_user.Size = new System.Drawing.Size(132, 20);
            this.change_user.Text = "Сменить пользоватя";
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(53, 20);
            this.exit.Text = "Выход";
            // 
            // sendMessage
            // 
            this.sendMessage.Location = new System.Drawing.Point(23, 400);
            this.sendMessage.Multiline = true;
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(386, 39);
            this.sendMessage.TabIndex = 1;
            // 
            // users_box
            // 
            this.users_box.Location = new System.Drawing.Point(23, 103);
            this.users_box.Multiline = true;
            this.users_box.Name = "users_box";
            this.users_box.Size = new System.Drawing.Size(137, 299);
            this.users_box.TabIndex = 5;
            // 
            // send_button
            // 
            this.send_button.Location = new System.Drawing.Point(407, 400);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(42, 39);
            this.send_button.Style = MetroFramework.MetroColorStyle.White;
            this.send_button.TabIndex = 0;
            this.send_button.Text = "SEND";
            this.send_button.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // Chat_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 461);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.chat_textbox);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.users_box);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Chat_form";
            this.Resizable = false;
            this.Text = "CHAT";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox chat_textbox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.ToolStripMenuItem users_menu;
        private System.Windows.Forms.ToolStripMenuItem change_user;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private MetroFramework.Controls.MetroTextBox sendMessage;
        private MetroFramework.Controls.MetroTextBox users_box;
        private MetroFramework.Controls.MetroButton send_button;
    }
}