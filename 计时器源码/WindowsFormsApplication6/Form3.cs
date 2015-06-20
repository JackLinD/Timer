using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        INIClass ini;
        private void Form3_Load(object sender, EventArgs e)
        {
            ini = new INIClass(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 10) + "/jishiqi.ini");
            label2.Text = ini.IniReadValue("last", "lan");
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            float newx = this.Size.Width;
            float newy = this.Size.Height;
            button1.SetBounds((int)(newx / 5), (int)((newy / 10) * 9), (int)((newx / 5)*3), button1.Size.Height);
            label2.SetBounds(0, (int)((newy / 10) * 4), (int)newx, label2.Size.Height);
        }

        private void label2_FontChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
