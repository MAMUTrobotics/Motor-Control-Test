using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Motor_test
{
    public partial class Form1 : Form
    {
        byte[] command;

        public Form1()
        {
            InitializeComponent();
        }

        private void combo_serial_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = combo_serial.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            combo_serial.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                combo_serial.Enabled = true;
                btn_send.Enabled = false;
                btn_stopp.Enabled = false;
                btn_connect.Text = "Connect";
            }
            else
            {
                serialPort1.Open();
                combo_serial.Enabled = false;
                btn_send.Enabled = true;
                btn_stopp.Enabled = true;
                btn_connect.Text = "Disconnect";
            }
            
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            serialPort1.Write(command, 0, 4);
        }

        void update_command()
        {
            command = new byte[4];
            UInt16 time = (UInt16)tb_time.Value;
            Int16 speed = (Int16)tb_speed.Value;
            command[0] = (byte)(time >> 8);
            command[1] = (byte)(time & 0xff);
            command[2] = (byte)(speed >> 8);
            command[3] = (byte)(speed & 0xff);
            textBox1.Text = BitConverter.ToString(command).Replace("-", " ");
        }

        private void tb_time_Scroll(object sender, EventArgs e)
        {
            update_command();
            if (tb_time.Value < 10)
                timer1.Interval = 10;
            else if (tb_time.Value > 500)
                timer1.Interval = 500;
            else
                timer1.Interval = tb_time.Value;
        }

        private void tb_speed_Scroll(object sender, EventArgs e)
        {
            update_command();
        }

        private void btn_stopp_Click(object sender, EventArgs e)
        {
            cb_autosend.Checked = false;
            serialPort1.Write(new byte[]{ 0x00,0x00,0x00,0x00},0,4);
        }

        private void cb_autosend_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = cb_autosend.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btn_send_Click(null,null);
        }
    }
}
