﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_tearm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.count++;
            Form1.AllLoc.Add(new GetAllPoint(Form1.count, Convert.ToInt32(tb_X.Text), Convert.ToInt32(tb_Y.Text)));
            this.Close();
        }
    }
}
