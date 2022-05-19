namespace Final_tearm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pan_title = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pan_search = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pan_res = new System.Windows.Forms.Panel();
            this.lb_avgspeed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_km = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_addbook = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pan_resSearch = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tb_des = new Guna.UI2.WinForms.Guna2TextBox();
            this.tb_source = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Algorithm = new System.Windows.Forms.ComboBox();
            this.pan_pic = new System.Windows.Forms.Panel();
            this.pic_map = new System.Windows.Forms.PictureBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pan_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pan_search.SuspendLayout();
            this.pan_res.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pan_pic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_map)).BeginInit();
            this.SuspendLayout();
            // 
            // pan_title
            // 
            this.pan_title.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pan_title.Controls.Add(this.pictureBox1);
            this.pan_title.Controls.Add(this.label5);
            this.pan_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_title.Location = new System.Drawing.Point(0, 0);
            this.pan_title.Margin = new System.Windows.Forms.Padding(2);
            this.pan_title.Name = "pan_title";
            this.pan_title.Size = new System.Drawing.Size(1284, 122);
            this.pan_title.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Final_tearm.Properties.Resources.logo_map;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.label5.Location = new System.Drawing.Point(122, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(521, 63);
            this.label5.TabIndex = 7;
            this.label5.Text = "Google Map Shopee";
            // 
            // pan_search
            // 
            this.pan_search.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pan_search.Controls.Add(this.progressBar1);
            this.pan_search.Controls.Add(this.pan_res);
            this.pan_search.Controls.Add(this.pictureBox3);
            this.pan_search.Controls.Add(this.pan_resSearch);
            this.pan_search.Controls.Add(this.pictureBox2);
            this.pan_search.Controls.Add(this.tb_des);
            this.pan_search.Controls.Add(this.tb_source);
            this.pan_search.Controls.Add(this.label3);
            this.pan_search.Controls.Add(this.cb_Algorithm);
            this.pan_search.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_search.Location = new System.Drawing.Point(0, 122);
            this.pan_search.Margin = new System.Windows.Forms.Padding(2);
            this.pan_search.Name = "pan_search";
            this.pan_search.Size = new System.Drawing.Size(324, 659);
            this.pan_search.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 341);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(309, 32);
            this.progressBar1.TabIndex = 122;
            // 
            // pan_res
            // 
            this.pan_res.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_res.Controls.Add(this.lb_avgspeed);
            this.pan_res.Controls.Add(this.label8);
            this.pan_res.Controls.Add(this.lb_km);
            this.pan_res.Controls.Add(this.lb_time);
            this.pan_res.Controls.Add(this.label4);
            this.pan_res.Controls.Add(this.label2);
            this.pan_res.Controls.Add(this.btn_addbook);
            this.pan_res.Location = new System.Drawing.Point(12, 400);
            this.pan_res.Name = "pan_res";
            this.pan_res.Size = new System.Drawing.Size(308, 163);
            this.pan_res.TabIndex = 121;
            this.pan_res.Visible = false;
            // 
            // lb_avgspeed
            // 
            this.lb_avgspeed.AutoSize = true;
            this.lb_avgspeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_avgspeed.Location = new System.Drawing.Point(194, 50);
            this.lb_avgspeed.Name = "lb_avgspeed";
            this.lb_avgspeed.Size = new System.Drawing.Size(71, 24);
            this.lb_avgspeed.TabIndex = 137;
            this.lb_avgspeed.Text = "27km/h";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 24);
            this.label8.TabIndex = 136;
            this.label8.Text = "Tốc độ trung bình:";
            // 
            // lb_km
            // 
            this.lb_km.AutoSize = true;
            this.lb_km.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_km.Location = new System.Drawing.Point(194, 78);
            this.lb_km.Name = "lb_km";
            this.lb_km.Size = new System.Drawing.Size(55, 24);
            this.lb_km.TabIndex = 135;
            this.lb_km.Text = "27km";
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_time.Location = new System.Drawing.Point(194, 19);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(62, 24);
            this.lb_time.TabIndex = 134;
            this.lb_time.Text = "1h20p";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 24);
            this.label4.TabIndex = 133;
            this.label4.Text = "Dự tính thời gian:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 132;
            this.label2.Text = "Tổng số:";
            // 
            // btn_addbook
            // 
            this.btn_addbook.BorderRadius = 5;
            this.btn_addbook.CheckedState.Parent = this.btn_addbook;
            this.btn_addbook.CustomImages.Parent = this.btn_addbook;
            this.btn_addbook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_addbook.ForeColor = System.Drawing.Color.White;
            this.btn_addbook.HoverState.Parent = this.btn_addbook;
            this.btn_addbook.Location = new System.Drawing.Point(142, 110);
            this.btn_addbook.Margin = new System.Windows.Forms.Padding(2);
            this.btn_addbook.Name = "btn_addbook";
            this.btn_addbook.ShadowDecoration.Parent = this.btn_addbook;
            this.btn_addbook.Size = new System.Drawing.Size(162, 39);
            this.btn_addbook.TabIndex = 131;
            this.btn_addbook.Text = "Xem lộ trình cụ thể";
            this.btn_addbook.Click += new System.EventHandler(this.btn_addbook_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Final_tearm.Properties.Resources.template;
            this.pictureBox3.Location = new System.Drawing.Point(3, 14);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(23, 65);
            this.pictureBox3.TabIndex = 121;
            this.pictureBox3.TabStop = false;
            // 
            // pan_resSearch
            // 
            this.pan_resSearch.AutoScroll = true;
            this.pan_resSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_resSearch.Location = new System.Drawing.Point(12, 95);
            this.pan_resSearch.Name = "pan_resSearch";
            this.pan_resSearch.Size = new System.Drawing.Size(308, 241);
            this.pan_resSearch.TabIndex = 120;
            this.pan_resSearch.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Final_tearm.Properties.Resources.swap;
            this.pictureBox2.Location = new System.Drawing.Point(276, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 119;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // tb_des
            // 
            this.tb_des.Animated = true;
            this.tb_des.BorderRadius = 20;
            this.tb_des.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_des.DefaultText = "";
            this.tb_des.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_des.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_des.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_des.DisabledState.Parent = this.tb_des;
            this.tb_des.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_des.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.tb_des.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_des.FocusedState.Parent = this.tb_des;
            this.tb_des.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_des.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_des.HoverState.Parent = this.tb_des;
            this.tb_des.Location = new System.Drawing.Point(33, 50);
            this.tb_des.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tb_des.Name = "tb_des";
            this.tb_des.PasswordChar = '\0';
            this.tb_des.PlaceholderText = "Search Location";
            this.tb_des.SelectedText = "";
            this.tb_des.ShadowDecoration.Parent = this.tb_des;
            this.tb_des.Size = new System.Drawing.Size(236, 39);
            this.tb_des.TabIndex = 118;
            this.tb_des.TextChanged += new System.EventHandler(this.tb_des_TextChanged);
            this.tb_des.Leave += new System.EventHandler(this.tb_des_Leave);
            this.tb_des.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_des_MouseClick);
            // 
            // tb_source
            // 
            this.tb_source.Animated = true;
            this.tb_source.BorderRadius = 20;
            this.tb_source.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_source.DefaultText = "";
            this.tb_source.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tb_source.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tb_source.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_source.DisabledState.Parent = this.tb_source;
            this.tb_source.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tb_source.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.tb_source.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_source.FocusedState.Parent = this.tb_source;
            this.tb_source.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tb_source.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tb_source.HoverState.Parent = this.tb_source;
            this.tb_source.Location = new System.Drawing.Point(33, 5);
            this.tb_source.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tb_source.Name = "tb_source";
            this.tb_source.PasswordChar = '\0';
            this.tb_source.PlaceholderText = "Search Location";
            this.tb_source.SelectedText = "";
            this.tb_source.ShadowDecoration.Parent = this.tb_source;
            this.tb_source.Size = new System.Drawing.Size(236, 39);
            this.tb_source.TabIndex = 117;
            this.tb_source.TextChanged += new System.EventHandler(this.tb_source_TextChanged);
            this.tb_source.Leave += new System.EventHandler(this.tb_source_Leave);
            this.tb_source.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tb_source_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 580);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Choose Algorithm";
            // 
            // cb_Algorithm
            // 
            this.cb_Algorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Algorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Algorithm.FormattingEnabled = true;
            this.cb_Algorithm.Items.AddRange(new object[] {
            "A*",
            "Dijkstra ",
            "Greedy"});
            this.cb_Algorithm.Location = new System.Drawing.Point(15, 615);
            this.cb_Algorithm.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Algorithm.Name = "cb_Algorithm";
            this.cb_Algorithm.Size = new System.Drawing.Size(293, 33);
            this.cb_Algorithm.TabIndex = 4;
            this.cb_Algorithm.SelectedIndexChanged += new System.EventHandler(this.cb_Algorithm_SelectedIndexChanged);
            // 
            // pan_pic
            // 
            this.pan_pic.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pan_pic.Controls.Add(this.pic_map);
            this.pan_pic.Location = new System.Drawing.Point(325, 122);
            this.pan_pic.Margin = new System.Windows.Forms.Padding(2);
            this.pan_pic.Name = "pan_pic";
            this.pan_pic.Size = new System.Drawing.Size(959, 659);
            this.pan_pic.TabIndex = 2;
            // 
            // pic_map
            // 
            this.pic_map.Location = new System.Drawing.Point(3, 2);
            this.pic_map.Margin = new System.Windows.Forms.Padding(2);
            this.pic_map.Name = "pic_map";
            this.pic_map.Size = new System.Drawing.Size(954, 654);
            this.pic_map.TabIndex = 3;
            this.pic_map.TabStop = false;
            this.pic_map.Click += new System.EventHandler(this.pic_map_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1284, 781);
            this.Controls.Add(this.pan_pic);
            this.Controls.Add(this.pan_search);
            this.Controls.Add(this.pan_title);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pan_title.ResumeLayout(false);
            this.pan_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pan_search.ResumeLayout(false);
            this.pan_search.PerformLayout();
            this.pan_res.ResumeLayout(false);
            this.pan_res.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pan_pic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_title;
        private System.Windows.Forms.Panel pan_search;
        private System.Windows.Forms.Panel pan_pic;
        private System.Windows.Forms.PictureBox pic_map;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Algorithm;
        internal Guna.UI2.WinForms.Guna2TextBox tb_des;
        internal Guna.UI2.WinForms.Guna2TextBox tb_source;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel pan_resSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pan_res;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btn_addbook;
        private System.Windows.Forms.Label lb_km;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lb_avgspeed;
        private System.Windows.Forms.Label label8;
    }
}

