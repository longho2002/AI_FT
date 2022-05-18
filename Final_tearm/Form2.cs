using System;
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

        private void Form2_Load(object sender, EventArgs e)
        {
            int c = 0;
            for (int i = Form1.c - 1; i>=0; i--)
            {
                if (Form1.graph.name[Form1.tracing[i]].Trim() != "")
                {
                    panel1.Controls.Add(createlb(179, (c + 1) * 38 + 20,
                        (c + 1).ToString() + " " + Form1.graph.name[Form1.tracing[i]]));
                    c++;
                }
                
            }
        }

        Label createlb(int x, int y, string text)
        {
            Label lb = new Label();
            lb.AutoSize = true;
            lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lb.Location = new System.Drawing.Point(x, y);
            lb.Size = new System.Drawing.Size(143, 24);
            lb.Text = text;
            return lb;
        }
    }
}
