namespace ClientApp
{
    partial class Chat_form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat_form));
            this.sendMessage_button = new System.Windows.Forms.Button();
            this.Chat_textBox = new System.Windows.Forms.TextBox();
            this.sendMessage_textBox = new System.Windows.Forms.TextBox();
            this.message_label = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.Users_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.СhangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.users = new System.Windows.Forms.ListBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendMessage_button
            // 
            this.sendMessage_button.BackColor = System.Drawing.Color.OrangeRed;
            this.sendMessage_button.BackgroundImage = global::ClientApp.Properties.Resources.enter;
            this.sendMessage_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sendMessage_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendMessage_button.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendMessage_button.Location = new System.Drawing.Point(476, 458);
            this.sendMessage_button.Name = "sendMessage_button";
            this.sendMessage_button.Size = new System.Drawing.Size(75, 75);
            this.sendMessage_button.TabIndex = 0;
            this.sendMessage_button.UseVisualStyleBackColor = false;
            this.sendMessage_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // Chat_textBox
            // 
            this.Chat_textBox.BackColor = System.Drawing.Color.Coral;
            this.Chat_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Chat_textBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Chat_textBox.Location = new System.Drawing.Point(12, 50);
            this.Chat_textBox.Multiline = true;
            this.Chat_textBox.Name = "Chat_textBox";
            this.Chat_textBox.ReadOnly = true;
            this.Chat_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Chat_textBox.Size = new System.Drawing.Size(539, 395);
            this.Chat_textBox.TabIndex = 1;
            // 
            // sendMessage_textBox
            // 
            this.sendMessage_textBox.BackColor = System.Drawing.Color.SandyBrown;
            this.sendMessage_textBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendMessage_textBox.Location = new System.Drawing.Point(111, 458);
            this.sendMessage_textBox.Multiline = true;
            this.sendMessage_textBox.Name = "sendMessage_textBox";
            this.sendMessage_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendMessage_textBox.Size = new System.Drawing.Size(359, 75);
            this.sendMessage_textBox.TabIndex = 2;
            // 
            // message_label
            // 
            this.message_label.AutoSize = true;
            this.message_label.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message_label.Location = new System.Drawing.Point(12, 458);
            this.message_label.Name = "message_label";
            this.message_label.Size = new System.Drawing.Size(102, 39);
            this.message_label.TabIndex = 4;
            this.message_label.Text = "MSG:";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About,
            this.Users_menu,
            this.СhangeUser,
            this.Exit});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(569, 26);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.OrangeRed;
            this.About.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(119, 22);
            this.About.Text = "О программе";
            this.About.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // Users_menu
            // 
            this.Users_menu.BackColor = System.Drawing.Color.OrangeRed;
            this.Users_menu.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Users_menu.Name = "Users_menu";
            this.Users_menu.Size = new System.Drawing.Size(131, 22);
            this.Users_menu.Text = "Пользователи";
            this.Users_menu.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // СhangeUser
            // 
            this.СhangeUser.BackColor = System.Drawing.Color.OrangeRed;
            this.СhangeUser.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.СhangeUser.ForeColor = System.Drawing.Color.Black;
            this.СhangeUser.Name = "СhangeUser";
            this.СhangeUser.Size = new System.Drawing.Size(199, 22);
            this.СhangeUser.Text = "Сменить пользователя";
            this.СhangeUser.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.OrangeRed;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(72, 22);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // users
            // 
            this.users.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.users.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.users.Cursor = System.Windows.Forms.Cursors.Hand;
            this.users.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.users.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.users.ForeColor = System.Drawing.Color.Gray;
            this.users.FormattingEnabled = true;
            this.users.IntegralHeight = false;
            this.users.ItemHeight = 25;
            this.users.Location = new System.Drawing.Point(0, 522);
            this.users.Margin = new System.Windows.Forms.Padding(0);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(569, 25);
            this.users.TabIndex = 25;
            this.users.Visible = false;
            // 
            // Chat_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(569, 547);
            this.Controls.Add(this.users);
            this.Controls.Add(this.sendMessage_textBox);
            this.Controls.Add(this.Chat_textBox);
            this.Controls.Add(this.sendMessage_button);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.message_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Chat_form";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чат";
            this.Shown += new System.EventHandler(this.Chat_form_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendMessage_button;
        private System.Windows.Forms.TextBox Chat_textBox;
        private System.Windows.Forms.TextBox sendMessage_textBox;
        private System.Windows.Forms.Label message_label;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.ToolStripMenuItem СhangeUser;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem Users_menu;
        private System.Windows.Forms.ListBox users;
    }
}

