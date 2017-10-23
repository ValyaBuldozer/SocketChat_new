namespace ClientApp
{
    partial class Window_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window_form));
            this.send_button = new System.Windows.Forms.Button();
            this.window_chat = new System.Windows.Forms.TextBox();
            this.input_text = new System.Windows.Forms.TextBox();
            this.window_label = new System.Windows.Forms.Label();
            this.message_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // send_button
            // 
            this.send_button.Location = new System.Drawing.Point(322, 257);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(71, 23);
            this.send_button.TabIndex = 0;
            this.send_button.Text = "Отправить";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.Click += new System.EventHandler(this.send_button_Click);
            // 
            // window_chat
            // 
            this.window_chat.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.window_chat.Location = new System.Drawing.Point(41, 28);
            this.window_chat.Multiline = true;
            this.window_chat.Name = "window_chat";
            this.window_chat.Size = new System.Drawing.Size(352, 221);
            this.window_chat.TabIndex = 1;
            // 
            // input_text
            // 
            this.input_text.Location = new System.Drawing.Point(112, 257);
            this.input_text.Name = "input_text";
            this.input_text.Size = new System.Drawing.Size(204, 20);
            this.input_text.TabIndex = 2;
            // 
            // window_label
            // 
            this.window_label.AutoSize = true;
            this.window_label.Location = new System.Drawing.Point(38, 9);
            this.window_label.Name = "window_label";
            this.window_label.Size = new System.Drawing.Size(61, 13);
            this.window_label.TabIndex = 3;
            this.window_label.Text = "Окно чата:";
            // 
            // message_label
            // 
            this.message_label.AutoSize = true;
            this.message_label.Location = new System.Drawing.Point(38, 260);
            this.message_label.Name = "message_label";
            this.message_label.Size = new System.Drawing.Size(68, 13);
            this.message_label.TabIndex = 4;
            this.message_label.Text = "Сообщение:";
            // 
            // Window_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 299);
            this.Controls.Add(this.message_label);
            this.Controls.Add(this.window_label);
            this.Controls.Add(this.input_text);
            this.Controls.Add(this.window_chat);
            this.Controls.Add(this.send_button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window_form";
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
    }
}

