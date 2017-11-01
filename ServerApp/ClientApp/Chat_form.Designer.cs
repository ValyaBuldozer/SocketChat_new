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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat_form));
            this.sendMessage_button = new System.Windows.Forms.Button();
            this.Chat_textBox = new System.Windows.Forms.TextBox();
            this.sendMessage_textBox = new System.Windows.Forms.TextBox();
            this.message_label = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.About_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUser_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.users_textBox = new System.Windows.Forms.TextBox();
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
            this.sendMessage_button.Location = new System.Drawing.Point(532, 472);
            this.sendMessage_button.Name = "sendMessage_button";
            this.sendMessage_button.Size = new System.Drawing.Size(51, 45);
            this.sendMessage_button.TabIndex = 0;
            this.sendMessage_button.UseVisualStyleBackColor = false;
            this.sendMessage_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // Chat_textBox
            // 
            this.Chat_textBox.BackColor = System.Drawing.Color.Coral;
            this.Chat_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Chat_textBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Chat_textBox.Location = new System.Drawing.Point(198, 47);
            this.Chat_textBox.Multiline = true;
            this.Chat_textBox.Name = "Chat_textBox";
            this.Chat_textBox.ReadOnly = true;
            this.Chat_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Chat_textBox.Size = new System.Drawing.Size(432, 395);
            this.Chat_textBox.TabIndex = 1;
            // 
            // sendMessage_textBox
            // 
            this.sendMessage_textBox.BackColor = System.Drawing.Color.SandyBrown;
            this.sendMessage_textBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendMessage_textBox.Location = new System.Drawing.Point(186, 472);
            this.sendMessage_textBox.Multiline = true;
            this.sendMessage_textBox.Name = "sendMessage_textBox";
            this.sendMessage_textBox.Size = new System.Drawing.Size(329, 45);
            this.sendMessage_textBox.TabIndex = 2;
            // 
            // message_label
            // 
            this.message_label.AutoSize = true;
            this.message_label.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message_label.Location = new System.Drawing.Point(47, 472);
            this.message_label.Name = "message_label";
            this.message_label.Size = new System.Drawing.Size(117, 45);
            this.message_label.TabIndex = 4;
            this.message_label.Text = "MSG:";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About_ToolStripMenuItem,
            this.changeUser_ToolStripMenuItem,
            this.Exit_ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(630, 26);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // About_ToolStripMenuItem
            // 
            this.About_ToolStripMenuItem.BackColor = System.Drawing.Color.OrangeRed;
            this.About_ToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.About_ToolStripMenuItem.Name = "About_ToolStripMenuItem";
            this.About_ToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.About_ToolStripMenuItem.Text = "О программе";
            this.About_ToolStripMenuItem.Click += new System.EventHandler(this.About_ToolStripMenuItem_Click);
            // 
            // changeUser_ToolStripMenuItem
            // 
            this.changeUser_ToolStripMenuItem.BackColor = System.Drawing.Color.OrangeRed;
            this.changeUser_ToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeUser_ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.changeUser_ToolStripMenuItem.Name = "changeUser_ToolStripMenuItem";
            this.changeUser_ToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.changeUser_ToolStripMenuItem.Text = "Сменить пользователя";
            this.changeUser_ToolStripMenuItem.Click += new System.EventHandler(this.changeUser_ToolStripMenuItem_Click);
            // 
            // Exit_ToolStripMenuItem
            // 
            this.Exit_ToolStripMenuItem.BackColor = System.Drawing.Color.OrangeRed;
            this.Exit_ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit_ToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit_ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Exit_ToolStripMenuItem.Name = "Exit_ToolStripMenuItem";
            this.Exit_ToolStripMenuItem.Size = new System.Drawing.Size(72, 22);
            this.Exit_ToolStripMenuItem.Text = "Выход";
            this.Exit_ToolStripMenuItem.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // users_textBox
            // 
            this.users_textBox.BackColor = System.Drawing.Color.SandyBrown;
            this.users_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.users_textBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.users_textBox.Location = new System.Drawing.Point(0, 47);
            this.users_textBox.Multiline = true;
            this.users_textBox.Name = "users_textBox";
            this.users_textBox.ReadOnly = true;
            this.users_textBox.Size = new System.Drawing.Size(180, 395);
            this.users_textBox.TabIndex = 7;
            // 
            // Chat_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(630, 527);
            this.Controls.Add(this.users_textBox);
            this.Controls.Add(this.message_label);
            this.Controls.Add(this.sendMessage_textBox);
            this.Controls.Add(this.Chat_textBox);
            this.Controls.Add(this.sendMessage_button);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Chat_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Чат";
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
        private System.Windows.Forms.ToolStripMenuItem Exit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem About_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeUser_ToolStripMenuItem;
        private System.Windows.Forms.TextBox users_textBox;
    }
}

