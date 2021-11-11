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

namespace AutoEventHandler1
{
    public partial class Form1 : Form
    {
        bool isSuspended = false;
        AutoResetEvent resetEvent = new AutoResetEvent(false);
        Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(() =>
              {
                  for (int i = 0; i < 3000; i++)
                  {
                      if (isSuspended)
                      {
                          isSuspended = false;
                          resetEvent.WaitOne();
                      }
                      //Thread.Sleep(5000);
                      if (InvokeRequired)
                          Invoke(new Action(() => { label1.Text = i.ToString(); }));

                      Debug.WriteLine(i);
                  }
              });
            thread.Start();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //thread.Suspend();
            isSuspended = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //thread.Resume();
            resetEvent.Set();
        }
    }
}
