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
            this.sendMessage_textBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.СhangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.message_label = new System.Windows.Forms.Label();
            this.users_ListBox = new System.Windows.Forms.ListBox();
            this.Chat_textBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sendMessage_button
            // 
            this.sendMessage_button.BackColor = System.Drawing.Color.LightSkyBlue;
            this.sendMessage_button.BackgroundImage = global::ClientApp.Properties.Resources.enter;
            this.sendMessage_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sendMessage_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendMessage_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sendMessage_button.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendMessage_button.Location = new System.Drawing.Point(442, 363);
            this.sendMessage_button.Name = "sendMessage_button";
            this.sendMessage_button.Size = new System.Drawing.Size(84, 70);
            this.sendMessage_button.TabIndex = 0;
            this.sendMessage_button.UseVisualStyleBackColor = false;
            this.sendMessage_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // sendMessage_textBox
            // 
            this.sendMessage_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendMessage_textBox.BackColor = System.Drawing.Color.AliceBlue;
            this.sendMessage_textBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendMessage_textBox.Location = new System.Drawing.Point(119, 363);
            this.sendMessage_textBox.Multiline = true;
            this.sendMessage_textBox.Name = "sendMessage_textBox";
            this.sendMessage_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendMessage_textBox.Size = new System.Drawing.Size(317, 70);
            this.sendMessage_textBox.TabIndex = 0;
            this.sendMessage_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendMessage_textBox_KeyPress);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About,
            this.Help,
            this.СhangeUser,
            this.Exit});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(529, 26);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.LightSkyBlue;
            this.About.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(123, 22);
            this.About.Text = " О программе";
            this.About.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // Help
            // 
            this.Help.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Help.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(117, 22);
            this.Help.Text = " Инструкция";
            this.Help.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // СhangeUser
            // 
            this.СhangeUser.BackColor = System.Drawing.Color.LightSkyBlue;
            this.СhangeUser.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.СhangeUser.ForeColor = System.Drawing.Color.Black;
            this.СhangeUser.Name = "СhangeUser";
            this.СhangeUser.Size = new System.Drawing.Size(203, 22);
            this.СhangeUser.Text = " Сменить пользователя";
            this.СhangeUser.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(76, 22);
            this.Exit.Text = " Выход";
            this.Exit.Click += new System.EventHandler(this.Top_Menu_Click);
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.4F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.6F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel.Controls.Add(this.message_label, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.users_ListBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.sendMessage_button, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.sendMessage_textBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.Chat_textBox, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 26);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.66423F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.33577F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(529, 436);
            this.tableLayoutPanel.TabIndex = 27;
            // 
            // message_label
            // 
            this.message_label.AutoSize = true;
            this.message_label.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message_label.Location = new System.Drawing.Point(10, 363);
            this.message_label.Margin = new System.Windows.Forms.Padding(10, 3, 3, 0);
            this.message_label.Name = "message_label";
            this.message_label.Size = new System.Drawing.Size(102, 39);
            this.message_label.TabIndex = 28;
            this.message_label.Text = "MSG:";
            // 
            // users_ListBox
            // 
            this.users_ListBox.BackColor = System.Drawing.Color.AliceBlue;
            this.users_ListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.users_ListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.users_ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.users_ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.users_ListBox.ForeColor = System.Drawing.Color.Gray;
            this.users_ListBox.FormattingEnabled = true;
            this.users_ListBox.IntegralHeight = false;
            this.users_ListBox.ItemHeight = 25;
            this.users_ListBox.Location = new System.Drawing.Point(6, 0);
            this.users_ListBox.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.users_ListBox.Name = "users_ListBox";
            this.users_ListBox.Size = new System.Drawing.Size(110, 360);
            this.users_ListBox.TabIndex = 27;
            // 
            // Chat_textBox
            // 
            this.Chat_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Chat_textBox.BackColor = System.Drawing.Color.AliceBlue;
            this.Chat_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel.SetColumnSpan(this.Chat_textBox, 2);
            this.Chat_textBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Chat_textBox.Location = new System.Drawing.Point(119, 3);
            this.Chat_textBox.Name = "Chat_textBox";
            this.Chat_textBox.ReadOnly = true;
            this.Chat_textBox.Size = new System.Drawing.Size(407, 354);
            this.Chat_textBox.TabIndex = 29;
            this.Chat_textBox.Text = "";
            this.Chat_textBox.TextChanged += new System.EventHandler(this.Chat_textBox_TextChanged);
            // 
            // Chat_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(529, 462);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(545, 500);
            this.Name = "Chat_form";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_form_FormClosing);
            this.Load += new System.EventHandler(this.Chat_form_Load);
            this.Shown += new System.EventHandler(this.Chat_form_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendMessage_button;
        private System.Windows.Forms.TextBox sendMessage_textBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.ToolStripMenuItem СhangeUser;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ListBox users_ListBox;
        private System.Windows.Forms.Label message_label;
        private System.Windows.Forms.RichTextBox Chat_textBox;
    }
}

