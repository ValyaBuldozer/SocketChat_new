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
            this.send_button = new System.Windows.Forms.Button();
            this.window_chat = new System.Windows.Forms.TextBox();
            this.input_text = new System.Windows.Forms.TextBox();
            this.message_label = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.name_label = new System.Windows.Forms.Label();
            this.users = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // send_button
            // 
            this.send_button.BackColor = System.Drawing.Color.OrangeRed;
            this.send_button.BackgroundImage = global::ClientApp.Properties.Resources.enter;
            this.send_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.send_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.send_button.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.send_button.Location = new System.Drawing.Point(532, 472);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(71, 65);
            this.send_button.TabIndex = 0;
            this.send_button.UseVisualStyleBackColor = false;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // window_chat
            // 
            this.window_chat.BackColor = System.Drawing.Color.Coral;
            this.window_chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.window_chat.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.window_chat.Location = new System.Drawing.Point(186, 151);
            this.window_chat.Multiline = true;
            this.window_chat.Name = "window_chat";
            this.window_chat.ReadOnly = true;
            this.window_chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.window_chat.Size = new System.Drawing.Size(417, 291);
            this.window_chat.TabIndex = 1;
            // 
            // input_text
            // 
            this.input_text.BackColor = System.Drawing.Color.SandyBrown;
            this.input_text.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input_text.Location = new System.Drawing.Point(186, 472);
            this.input_text.Multiline = true;
            this.input_text.Name = "input_text";
            this.input_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.input_text.Size = new System.Drawing.Size(329, 64);
            this.input_text.TabIndex = 2;
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
            this.оПрограммеToolStripMenuItem,
            this.сменитьПользователяToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(630, 26);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.BackColor = System.Drawing.Color.OrangeRed;
            this.оПрограммеToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // сменитьПользователяToolStripMenuItem
            // 
            this.сменитьПользователяToolStripMenuItem.BackColor = System.Drawing.Color.OrangeRed;
            this.сменитьПользователяToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сменитьПользователяToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.сменитьПользователяToolStripMenuItem.Name = "сменитьПользователяToolStripMenuItem";
            this.сменитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.сменитьПользователяToolStripMenuItem.Text = "Сменить пользователя";
            this.сменитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.сменитьПользователяToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.BackColor = System.Drawing.Color.OrangeRed;
            this.выходToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.выходToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.выходToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(72, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name_label.Location = new System.Drawing.Point(209, 51);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(208, 77);
            this.name_label.TabIndex = 6;
            this.name_label.Text = "CHAT";
            // 
            // users
            // 
            this.users.BackColor = System.Drawing.Color.SandyBrown;
            this.users.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.users.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.users.Location = new System.Drawing.Point(22, 151);
            this.users.Multiline = true;
            this.users.Name = "users";
            this.users.ReadOnly = true;
            this.users.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.users.Size = new System.Drawing.Size(142, 291);
            this.users.TabIndex = 7;
            // 
            // Chat_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(630, 562);
            this.Controls.Add(this.users);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.message_label);
            this.Controls.Add(this.input_text);
            this.Controls.Add(this.window_chat);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.TextBox window_chat;
        private System.Windows.Forms.TextBox input_text;
        private System.Windows.Forms.Label message_label;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменитьПользователяToolStripMenuItem;
        private System.Windows.Forms.TextBox users;
    }
}

