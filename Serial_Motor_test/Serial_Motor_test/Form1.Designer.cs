namespace Serial_Motor_test
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_connect = new System.Windows.Forms.Button();
            this.combo_serial = new System.Windows.Forms.ComboBox();
            this.tb_time = new System.Windows.Forms.TrackBar();
            this.tb_speed = new System.Windows.Forms.TrackBar();
            this.btn_send = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_stopp = new System.Windows.Forms.Button();
            this.cb_autosend = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tb_time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_speed)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(12, 12);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // combo_serial
            // 
            this.combo_serial.FormattingEnabled = true;
            this.combo_serial.Location = new System.Drawing.Point(93, 14);
            this.combo_serial.Name = "combo_serial";
            this.combo_serial.Size = new System.Drawing.Size(121, 21);
            this.combo_serial.TabIndex = 1;
            this.combo_serial.SelectedIndexChanged += new System.EventHandler(this.combo_serial_SelectedIndexChanged);
            // 
            // tb_time
            // 
            this.tb_time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_time.Location = new System.Drawing.Point(12, 41);
            this.tb_time.Maximum = 20000;
            this.tb_time.Name = "tb_time";
            this.tb_time.Size = new System.Drawing.Size(260, 45);
            this.tb_time.TabIndex = 2;
            this.tb_time.Scroll += new System.EventHandler(this.tb_time_Scroll);
            // 
            // tb_speed
            // 
            this.tb_speed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_speed.Location = new System.Drawing.Point(12, 92);
            this.tb_speed.Maximum = 20000;
            this.tb_speed.Minimum = -20000;
            this.tb_speed.Name = "tb_speed";
            this.tb_speed.Size = new System.Drawing.Size(260, 45);
            this.tb_speed.TabIndex = 3;
            this.tb_speed.Scroll += new System.EventHandler(this.tb_speed_Scroll);
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Location = new System.Drawing.Point(12, 143);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 4;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 200);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 20);
            this.textBox1.TabIndex = 5;
            // 
            // btn_stopp
            // 
            this.btn_stopp.Enabled = false;
            this.btn_stopp.Location = new System.Drawing.Point(93, 143);
            this.btn_stopp.Name = "btn_stopp";
            this.btn_stopp.Size = new System.Drawing.Size(75, 23);
            this.btn_stopp.TabIndex = 6;
            this.btn_stopp.Text = "Stopp";
            this.btn_stopp.UseVisualStyleBackColor = true;
            this.btn_stopp.Click += new System.EventHandler(this.btn_stopp_Click);
            // 
            // cb_autosend
            // 
            this.cb_autosend.AutoSize = true;
            this.cb_autosend.Location = new System.Drawing.Point(174, 147);
            this.cb_autosend.Name = "cb_autosend";
            this.cb_autosend.Size = new System.Drawing.Size(71, 17);
            this.cb_autosend.TabIndex = 7;
            this.cb_autosend.Text = "Autosend";
            this.cb_autosend.UseVisualStyleBackColor = true;
            this.cb_autosend.CheckedChanged += new System.EventHandler(this.cb_autosend_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cb_autosend);
            this.Controls.Add(this.btn_stopp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.tb_speed);
            this.Controls.Add(this.tb_time);
            this.Controls.Add(this.combo_serial);
            this.Controls.Add(this.btn_connect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.ComboBox combo_serial;
        private System.Windows.Forms.TrackBar tb_time;
        private System.Windows.Forms.TrackBar tb_speed;
        private System.Windows.Forms.Button btn_send;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_stopp;
        private System.Windows.Forms.CheckBox cb_autosend;
        private System.Windows.Forms.Timer timer1;
    }
}

