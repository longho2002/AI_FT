using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace Final_tearm
{
    public partial class Form1 : Form
    {
        int c = 0;
        int[] tracing = new int[35];
        private int chooseSource = 0;
        private int chooseDes = 0;
        Graph graph = new Graph();
        public static int count = 0;
        public static ArrayList AllLoc = new ArrayList();
        private Panel curPan = new Panel();
        bool flag = false;
        private int choosetb = 1;
        private int curAlgorithm = 0;


        public Form1()
        {
            InitializeComponent();
        }

        void reloadMap()
        {
            pic_map.Controls.Clear();
            for (int i = 0; i < graph.AllPoint.Count; i++)
            {
                PictureBox p = new PictureBox()
                {
                    Width = 24,
                    Height = 24,
                    Location = graph.AllPoint[i],
                    Image = Image.FromFile(Application.StartupPath + "\\Resources\\" + "map-marker-icon.png"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,
                };
                ToolTip item = new ToolTip();
                item.SetToolTip(p, "Số 1 VVN");
                p.Click += (sen, earg) =>
                {
                    pic_map.Controls.Remove(curPan);
                    curPan = createLocInfo("UTE", "X: 123, Y: 123", 12);
                    pic_map.Controls.Add(curPan);
                    pic_map.Controls.SetChildIndex(curPan, 1);
                };
                pic_map.Controls.Add(p);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(1300, 800);
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            pic_map.Image = Image.FromFile(Application.StartupPath + "\\Resources\\" + "map.png");
            pic_map.SizeMode = PictureBoxSizeMode.StretchImage;
            //cb_dep.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cb_dep.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cb_des.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cb_des.AutoCompleteSource = AutoCompleteSource.ListItems;
            graph.init();
            reloadMap();
            cb_Algorithm.SelectedIndex = 0;
            tb_source.Focus();
            //Dijkstra(2, 22);
        }


        private void pic_map_Paint(object sender, PaintEventArgs e)
        {
            for (int j = 1; j < c; j++)
            {
                e.Graphics.DrawLine(new Pen(Color.Red, 3), graph.AllPoint[tracing[j]].X + 12, graph.AllPoint[tracing[j]].Y + 12, graph.AllPoint[tracing[j - 1]].X + 12, graph.AllPoint[tracing[j - 1]].Y + 12);
                //e.Graphics.FillRectangle(new SolidBrush(Color.Cyan), AllPoint[j].X - 15, AllPoint[j].Y - 15, 30, 30);
            }
        }

        Panel createLocInfo(string name, string coordinate, int id)
        {
            // 
            // label1
            // 
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(24, 9);
            label1.Size = new System.Drawing.Size(41, 20);
            label1.Text = name;
            // 
            // label2
            // 
            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(24, 41);
            label2.Size = new System.Drawing.Size(96, 20);
            label2.Text = coordinate;
            // 
            // gunaImageButton2
            // 
            GunaImageButton gunaImageButton2 = new GunaImageButton();
            gunaImageButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            gunaImageButton2.Image = global::Final_tearm.Properties.Resources.cancel;
            gunaImageButton2.BackColor = Color.Transparent;
            gunaImageButton2.ImageSize = new System.Drawing.Size(20, 20);
            gunaImageButton2.Location = new System.Drawing.Point(286, 6);
            gunaImageButton2.OnHoverImage = null;
            gunaImageButton2.OnHoverImageOffset = new System.Drawing.Point(0, 0);
            gunaImageButton2.Size = new System.Drawing.Size(21, 26);
            gunaImageButton2.Click += (sender, e) =>
            {
                Util.Animate((sender as GunaImageButton).Parent, Util.Effect.Center, 150, 180);
                pic_map.Controls.Remove((sender as GunaImageButton).Parent);
            };
            // 
            // gunaImageButton1
            // 
            GunaImageButton gunaImageButton1 = new GunaImageButton();
            gunaImageButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            gunaImageButton1.Image = global::Final_tearm.Properties.Resources.direction_icon_25;
            gunaImageButton1.ImageSize = new System.Drawing.Size(40, 40);
            gunaImageButton1.Location = new System.Drawing.Point(237, 25);
            gunaImageButton1.OnHoverImage = null;
            gunaImageButton1.OnHoverImageOffset = new System.Drawing.Point(0, 0);
            gunaImageButton1.Size = new System.Drawing.Size(43, 36);
            gunaImageButton1.BackColor = Color.Transparent;
            gunaImageButton1.Click += (sender, e) =>
            {
                pic_map.Controls.Remove((sender as GunaImageButton).Parent);
                //lay ra id
                chooseSource = Convert.ToInt32((sender as GunaImageButton).Parent.Controls[0].Text);
                tb_source.Text = (sender as GunaImageButton).Parent.Controls[1].Text;
                tb_des.Focus();
            };

            // 
            // pan_infoLoc
            // 
            Label lb_id = new Label()
            {
                Text = id.ToString(),
                Visible = false,
            };
            Panel pan_infoLoc = new Panel();
            pan_infoLoc.Controls.Add(lb_id);
            pan_infoLoc.Controls.Add(label1);
            pan_infoLoc.BackColor = System.Drawing.Color.LightCoral;
            pan_infoLoc.Controls.Add(gunaImageButton2);
            pan_infoLoc.Controls.Add(gunaImageButton1);
            pan_infoLoc.Controls.Add(label2);
            pan_infoLoc.Location = new System.Drawing.Point(356, 574);
            pan_infoLoc.Size = new System.Drawing.Size(310, 73);
            pan_infoLoc.TabIndex = 4;
            return pan_infoLoc;
        }

        void A_star(int src, int des)
        {
            c = 0;
            int[] path;
            path = graph.a_star(src, des);
            for (int i = 0; i < 33; i++)
            {
                tracing[i] = -1;
            }
            int e = des;
            while (e != src)
            {
                tracing[c++] = e;
                e = path[e];
            }
            tracing[c++] = src;
        }

        void Dijkstra(int src, int des)
        {
            c = 0;
            flag = false;
            int[] path;
            path = graph.dijkstra(src, des);
            for (int i = 0; i < 33; i++)
            {
                tracing[i] = -1;
            }

            int e = path[des];
            tracing[c++] = des;
            if (path[des] != -1)
            {
                tracing[c++] = path[des];
                flag = true;
            }
            while (e != -1)
            {
                if (path[e] != -1)
                    tracing[c++] = path[e];
                e = path[e];
            }
        }

        Panel createSearch(int y, string name, int id)
        {
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(8, 6);
            label1.Size = new System.Drawing.Size(79, 20);
            label1.Text = name;

            Panel panel1 = new Panel();

            Label lb_id = new Label()
            {
                Text = id.ToString(),
                Visible = false,
            };
            panel1.MouseHover += (sender, e) =>
            {
                (sender as Panel).BackColor = Color.Gray;
            };
            panel1.MouseLeave += (sender, e) =>
            {
                (sender as Panel).BackColor = Color.White;
            };
            label1.Click += (sender, e) =>
            {
                panResClick((sender as Label).Parent, e);
            };
            panel1.Click += panResClick;
            panel1.Controls.Add(lb_id);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, y);
            panel1.Size = new Size(308, 32);
            panel1.TabIndex = 0;

            return panel1;
        }
        private void tb_des_MouseClick(object sender, MouseEventArgs e)
        {
            choosetb = 2;
        }
        private void tb_source_MouseClick(object sender, MouseEventArgs e)
        {
            choosetb = 1;

        }
        void panResClick(object sender, EventArgs e)
        {
            if (choosetb == 1)
            {
                chooseSource = Convert.ToInt32((sender as Panel).Controls[0].Text);
                tb_source.Text = (sender as Panel).Controls[1].Text;
            }
            else
            {
                chooseDes = Convert.ToInt32((sender as Panel).Controls[0].Text);
                tb_des.Text = (sender as Panel).Controls[1].Text;
            }
            if (tb_source.Text.Trim() != "" && tb_des.Text.Trim() != "")
            {
                if (curAlgorithm == 0)
                    A_star(2, 22);
                else
                    Dijkstra(2, 22);
                pic_map.Invalidate();
                pic_map.Paint += pic_map_Paint;
                pan_res.Visible = true;
            }
            pan_resSearch.Controls.Clear();
            pan_resSearch.Visible = false;
        }
        private void tb_source_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                pan_resSearch.Controls.Add(createSearch(32 * i, "UTE", 12));
            }
            pan_resSearch.Visible = true;
        }
        private void tb_des_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                pan_resSearch.Controls.Add(createSearch(32 * i, "UTE", 12));
            }
            pan_resSearch.Visible = true;
        }
        private void tb_source_Leave(object sender, EventArgs e)
        {
            pan_resSearch.Visible = false;
            pan_resSearch.Controls.Clear();
        }
        private void tb_des_Leave(object sender, EventArgs e)
        {
            pan_resSearch.Visible = false;
            pan_resSearch.Controls.Clear();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string tmp = tb_des.Text;
            tb_des.Text = tb_source.Text;
            tb_source.Text = tmp;
        }

        private void pic_map_Click(object sender, EventArgs e)
        {
            pic_map.Controls.Remove(curPan);
        }
    }
}
