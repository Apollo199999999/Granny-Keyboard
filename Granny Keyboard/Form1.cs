using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Input;
using WindowsInput;
using System.Windows.Media;
using System.IO;
using System.Media;
using System.Reflection;

namespace Granny_Keyboard
{
    
    public partial class Form1 : Form
    {

        GlobalKeyboardHook gHook;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (button1.Text == "Start")
            {
                gHook.hook();
                button1.Text = "Stop";
                
            }
            else
            {
                gHook.unhook();
                button1.Text = "Start";
                
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            gHook = new GlobalKeyboardHook(); // Create a new GlobalKeyboardHook
                                              // Declare a KeyDown Event
            
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            gHook.KeyUp += new KeyEventHandler(gHook_KeyUp);

            // Add the keys you want to hook to the HookedKeys list
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);

            //coordinates c = new coordinates();
            //c.Show();
        }

        // Generate a random number between two numbers  
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Handle the KeyDown Event
        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode != Keys.Back)
            {
                gHook.KeyDown -= new KeyEventHandler(gHook_KeyDown);
                InputSimulator input = new InputSimulator();

                input.Keyboard.TextEntry("Granny");
               
                System.IO.Stream str = Properties.Resources.Granny;
                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
                snd.Play();

                var width = RandomNumber(200, Screen.PrimaryScreen.Bounds.Width);
                var height = RandomNumber(200, Screen.PrimaryScreen.Bounds.Height);

                Granny G = new Granny();
                G.Location = new Point(width, height);
                G.Show();

                gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            }
            
        }

        public void gHook_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gHook.unhook();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
