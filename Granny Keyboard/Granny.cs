using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Granny_Keyboard
{
    public partial class Granny : Form
    {
        //new random object for random location of Granny Window and random bg color
        private static readonly Random _random = new Random();
        public void GWindowPayload()
        {
            //change the window bg color
            Color bgColor = Color.FromArgb(_random.Next(0, 255), _random.Next(0, 255), _random.Next(0, 255));
            this.BackColor = bgColor;

            //teleport this window to random locations
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int x = _random.Next(screen.Width - this.Width);
            int y = _random.Next(screen.Height - this.Height);
            this.Location = new Point(x, y);
        }

        public Granny()
        {
            InitializeComponent();
            GWindowPayload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            GWindowPayload();
        }
    }
}
