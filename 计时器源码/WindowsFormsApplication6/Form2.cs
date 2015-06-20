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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int second=10;
        int lastsecond;
        String mins;
        String seconds;
        INIClass ini;
        private void Form2_Load(object sender, EventArgs e)
        {
            ini = new INIClass(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().Length - 10)+"/jishiqi.ini");
            second=(int)(float.Parse(ini.IniReadValue("time","min"))*60);
            lastsecond = (int)(float.Parse(ini.IniReadValue("lasttime", "min")) * 60);
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = 0;
            this.TopMost = true;
            mins = (second / 60) < 10 ? ("0" + (second / 60).ToString()) : (second / 60).ToString();
            seconds = (second % 60) < 10 ? ("0" + (second % 60).ToString()) : (second % 60).ToString();
            label4.Text = mins + ":" + seconds;
            timer1.Start();
            timer2.Enabled = false;
            while (second <= lastsecond)
            {
                if (timer2.Enabled == false)
                {
                    label1.ForeColor = Color.White;
                    label4.ForeColor = Color.White;
                    this.BackColor = Color.Red;
                    timer2.Enabled = true;
                }
                else
                {
                    label1.ForeColor = Color.Black;
                    label4.ForeColor = Color.Black;
                    this.BackColor = Color.White;
                    timer2.Enabled = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                second--;
                mins = (second / 60) < 10 ? ("0" + (second / 60).ToString()) : (second / 60).ToString();
                seconds = (second % 60) < 10 ? ("0" + (second % 60).ToString()) : (second % 60).ToString();
                label4.Text = mins + ":" + seconds;
                if (second == 0)
                {
                    timer1.Enabled = false;
                    this.Visible = false;
                    Form3 f3=new Form3();
                    f3.Show();
                }
                if (second == lastsecond)
                {
                    timer2.Start();
                    label1.ForeColor = Color.White;
                    label4.ForeColor = Color.White;
                    this.BackColor = Color.Red;
                }
        }

        private Point offset;

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                button2.Text = "继续";
                timer1.Enabled = false;
            }
            else {
                button2.Text = "暂停";
                timer1.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {          
                        if (this.BackColor == Color.Red)
                        {
                            label1.ForeColor = Color.Black;
                            label4.ForeColor = Color.Black;
                            this.BackColor = Color.White;
                            
                        }
                        else
                        {
                            label1.ForeColor = Color.White;
                            label4.ForeColor = Color.White;
                            this.BackColor = Color.Red;
                        }
        }

    }
}
