namespace ClientApp_MF
{
    partial class CheckIn_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckIn_form));
            this.login_button = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.password_button = new MetroFramework.Controls.MetroLabel();
            this.enter_button = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.login_button.Location = new System.Drawing.Point(23, 102);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(54, 23);
            this.login_button.TabIndex = 0;
            this.login_button.Text = "LOGIN";
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Location = new System.Drawing.Point(83, 102);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.Size = new System.Drawing.Size(164, 23);
            this.metroTextBox1.TabIndex = 2;
            // 
            // metroTextBox2
            // 
            this.metroTextBox2.Location = new System.Drawing.Point(83, 131);
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.Size = new System.Drawing.Size(164, 23);
            this.metroTextBox2.TabIndex = 3;
            // 
            // password_button
            // 
            this.password_button.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.password_button.Location = new System.Drawing.Point(23, 131);
            this.password_button.Name = "password_button";
            this.password_button.Size = new System.Drawing.Size(54, 23);
            this.password_button.TabIndex = 4;
            this.password_button.Text = "PSWRD";
            // 
            // enter_button
            // 
            this.enter_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.enter_button.Location = new System.Drawing.Point(253, 102);
            this.enter_button.Name = "enter_button";
            this.enter_button.Size = new System.Drawing.Size(53, 52);
            this.enter_button.Style = MetroFramework.MetroColorStyle.Blue;
            this.enter_button.TabIndex = 5;
            this.enter_button.Text = "ENTER";
            this.enter_button.Theme = MetroFramework.MetroThemeStyle.Light;
            this.enter_button.Click += new System.EventHandler(this.checkin_button_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Location = new System.Drawing.Point(0, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 77);
            this.panel1.TabIndex = 6;
            // 
            // CheckIn_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 166);
            this.Controls.Add(this.enter_button);
            this.Controls.Add(this.password_button);
            this.Controls.Add(this.metroTextBox2);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CheckIn_form";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "CHECK IN";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel login_button;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroLabel password_button;
        private MetroFramework.Controls.MetroButton enter_button;
        private System.Windows.Forms.Panel panel1;
    }
}

