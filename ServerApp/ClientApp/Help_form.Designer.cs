namespace ClientApp
{
    partial class Help_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help_form));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Info_box_reg = new System.Windows.Forms.RichTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.registration = new System.Windows.Forms.ToolStripMenuItem();
            this.interfaceElements = new System.Windows.Forms.ToolStripMenuItem();
            this.sendingMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.Info_box_interf = new System.Windows.Forms.RichTextBox();
            this.Info_box_mes = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Info_box_reg
            // 
            this.Info_box_reg.BackColor = System.Drawing.Color.AliceBlue;
            this.Info_box_reg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Info_box_reg.Location = new System.Drawing.Point(12, 30);
            this.Info_box_reg.Name = "Info_box_reg";
            this.Info_box_reg.ReadOnly = true;
            this.Info_box_reg.Size = new System.Drawing.Size(364, 237);
            this.Info_box_reg.TabIndex = 0;
            this.Info_box_reg.Text = "Reg";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registration,
            this.interfaceElements,
            this.sendingMessages});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(403, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // registration
            // 
            this.registration.BackColor = System.Drawing.Color.LightSkyBlue;
            this.registration.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registration.Name = "registration";
            this.registration.Size = new System.Drawing.Size(93, 20);
            this.registration.Text = "Регистрация";
            this.registration.Click += new System.EventHandler(this.registration_Click);
            // 
            // interfaceElements
            // 
            this.interfaceElements.BackColor = System.Drawing.Color.LightSkyBlue;
            this.interfaceElements.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.interfaceElements.Name = "interfaceElements";
            this.interfaceElements.Size = new System.Drawing.Size(151, 20);
            this.interfaceElements.Text = "Элементы интерфейса";
            this.interfaceElements.Click += new System.EventHandler(this.interfaceElements_Click);
            // 
            // sendingMessages
            // 
            this.sendingMessages.BackColor = System.Drawing.Color.LightSkyBlue;
            this.sendingMessages.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sendingMessages.Name = "sendingMessages";
            this.sendingMessages.Size = new System.Drawing.Size(148, 20);
            this.sendingMessages.Text = "Отправка соообшений";
            this.sendingMessages.Click += new System.EventHandler(this.sendingMessages_Click);
            // 
            // Info_box_interf
            // 
            this.Info_box_interf.BackColor = System.Drawing.Color.AliceBlue;
            this.Info_box_interf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Info_box_interf.Location = new System.Drawing.Point(12, 30);
            this.Info_box_interf.Name = "Info_box_interf";
            this.Info_box_interf.ReadOnly = true;
            this.Info_box_interf.Size = new System.Drawing.Size(364, 237);
            this.Info_box_interf.TabIndex = 2;
            this.Info_box_interf.Text = "Interf";
            // 
            // Info_box_mes
            // 
            this.Info_box_mes.BackColor = System.Drawing.Color.AliceBlue;
            this.Info_box_mes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Info_box_mes.Location = new System.Drawing.Point(12, 30);
            this.Info_box_mes.Name = "Info_box_mes";
            this.Info_box_mes.ReadOnly = true;
            this.Info_box_mes.Size = new System.Drawing.Size(364, 237);
            this.Info_box_mes.TabIndex = 3;
            this.Info_box_mes.Text = "Mes";
            // 
            // Help_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 279);
            this.Controls.Add(this.Info_box_mes);
            this.Controls.Add(this.Info_box_interf);
            this.Controls.Add(this.Info_box_reg);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Help_form";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Help";
            this.Shown += new System.EventHandler(this.Help_form_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.RichTextBox Info_box_reg;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem registration;
        private System.Windows.Forms.ToolStripMenuItem interfaceElements;
        private System.Windows.Forms.ToolStripMenuItem sendingMessages;
        private System.Windows.Forms.RichTextBox Info_box_interf;
        private System.Windows.Forms.RichTextBox Info_box_mes;
    }
}