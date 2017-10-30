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
            this.window_label = new System.Windows.Forms.Label();
            this.message_label = new System.Windows.Forms.Label();
            this.exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // send_button
            // 
            this.send_button.BackColor = System.Drawing.Color.Tomato;
            this.send_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.send_button.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.send_button.Location = new System.Drawing.Point(426, 310);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(113, 65);
            this.send_button.TabIndex = 0;
            this.send_button.Text = "Отправить";
            this.send_button.UseVisualStyleBackColor = false;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // window_chat
            // 
            this.window_chat.BackColor = System.Drawing.Color.Coral;
            this.window_chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.window_chat.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.window_chat.Location = new System.Drawing.Point(41, 30);
            this.window_chat.Multiline = true;
            this.window_chat.Name = "window_chat";
            this.window_chat.Size = new System.Drawing.Size(498, 277);
            this.window_chat.TabIndex = 1;
            // 
            // input_text
            // 
            this.input_text.BackColor = System.Drawing.Color.SandyBrown;
            this.input_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input_text.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input_text.Location = new System.Drawing.Point(144, 311);
            this.input_text.Multiline = true;
            this.input_text.Name = "input_text";
            this.input_text.Size = new System.Drawing.Size(276, 64);
            this.input_text.TabIndex = 2;
            // 
            // window_label
            // 
            this.window_label.AutoSize = true;
            this.window_label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.window_label.Location = new System.Drawing.Point(38, 9);
            this.window_label.Name = "window_label";
            this.window_label.Size = new System.Drawing.Size(92, 18);
            this.window_label.TabIndex = 3;
            this.window_label.Text = "Окно чата:";
            // 
            // message_label
            // 
            this.message_label.AutoSize = true;
            this.message_label.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.message_label.Location = new System.Drawing.Point(38, 311);
            this.message_label.Name = "message_label";
            this.message_label.Size = new System.Drawing.Size(100, 18);
            this.message_label.TabIndex = 4;
            this.message_label.Text = "Сообщение:";
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.Color.Tomato;
            this.exit_button.BackgroundImage = global::ClientApp.Properties.Resources.close;
            this.exit_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit_button.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit_button.Location = new System.Drawing.Point(545, -2);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(38, 37);
            this.exit_button.TabIndex = 5;
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // Chat_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(579, 387);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.message_label);
            this.Controls.Add(this.window_label);
            this.Controls.Add(this.input_text);
            this.Controls.Add(this.window_chat);
            this.Controls.Add(this.send_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Chat_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Чат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button send_button;
        private System.Windows.Forms.TextBox window_chat;
        private System.Windows.Forms.TextBox input_text;
        private System.Windows.Forms.Label window_label;
        private System.Windows.Forms.Label message_label;
        private System.Windows.Forms.Button exit_button;
    }
}

