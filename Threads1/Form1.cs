using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threads1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                for (int i = 0; i < 3000; i++)
                {
                    Debug.WriteLine(i);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("I am doing somthing else!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Create an instance of the calss Thread
            //The comiler accepts a void no parameters delegate
            //(It's defined in System.Treading and it's called ThreadStart)
            //So in this example we have used the lambda expression to pass
            //a void no parameter method to the Thraed's constructor
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 3000; i++)
                {
                    Debug.WriteLine(i);
                }
            });
            
            thread.Start();
        }
    }
}
