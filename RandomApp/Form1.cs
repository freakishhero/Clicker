using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomApp
{
    public partial class Form1 : Form
    {
        private Timer timer1;

        const UInt32 WM_KEYDOWN = 0x0100;
        const int VK_F5 = 0x74;
        const int VK_SPACEBAR = 0x20;
        bool start = false;

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        public void InitTimer(int delay)
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = delay * 1000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(start)
            {
                Process[] processes = Process.GetProcessesByName("Minecraft");

                foreach (var process in processes)
                {
                    PostMessage(process.MainWindowHandle, WM_KEYDOWN, VK_SPACEBAR, 0);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitTimer(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!start)
            {
                button1.Text = "Stop";
                start = true;
                int timer = 0;
                int.TryParse(textBox1.Text, out timer);
                timer1.Interval = timer * 1000;
            }
            else
            {
                button1.Text = "Start";
                start = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
