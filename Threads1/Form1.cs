﻿using System;
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
            Thread thread = new Thread(() =>
            {
                for (int i = 0; i < 3000; i++)
                {
                    Debug.WriteLine(i);
                }
            });
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("I am doing somthing else!!!");
        }
    }
}
