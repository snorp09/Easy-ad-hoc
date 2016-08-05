using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*I set these as public due to not know they would be used.
         * They are used in button1_click.
         * name is the ssid and pass is the key.
         */
        public string name;
        public string pass;
        public string command;
        // These are used to check if the program is running.
        public bool Running;
        public bool halted;

        private void button1_Click(object sender, EventArgs e)
        {
            /* This is the code for the set button. The set button runs the following command in cmd:
             * netsh wlan set hostednetwork mode=allow ssid= key= 
             */
            name = textBox1.Text;
            pass = textBox2.Text;
            command = "/c netsh wlan set hostednetwork mode=allow ssid=" +name +" key=" +pass;
            System.Diagnostics.Process.Start("CMD.exe", command);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // This runs the cmd command to start the ad hoc.
            System.Diagnostics.Process.Start("CMD.exe", "/c netsh wlan start hostednetwork");
            // This displays the "Already running" window
            var Error1 = new Error_1();
            if (Running == true)
            {
                Error1.ShowDialog();
            }
            Running = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // this runs the command to stop the ad hoc.
            System.Diagnostics.Process.Start("CMD.exe", "/c netsh wlan stop hostednetwork");
            Running = false;
            var Error2 = new Error_2();
            if (halted == true)
            {
                Error2.ShowDialog();
            }
            halted = true;

        }
    }
}
