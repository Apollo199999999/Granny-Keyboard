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
    public partial class coordinates : Form
    {
        public coordinates()
        {
            InitializeComponent();
        }

        private void coordinates_Move(object sender, EventArgs e)
        {
            label1.Text = this.Location.ToString();
        }
    }
}
