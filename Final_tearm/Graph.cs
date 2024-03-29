﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Microsoft.SqlServer.Server;
using Microsoft.VisualBasic;

namespace Final_tearm
{
    public class Graph
    {
        private const int SIZE = 205;
        protected int goal = 5;
        protected int start = 0;
        protected int n = 205;
        protected double[] heuristic = new double[SIZE];
        protected int[,] coordinates = new int[SIZE, 2];
        public List<Point> AllPoint;
        public List<List<double>> graph = new List<List<double>>();


        public Graph()
        {
        }

        public void init()
        {
            DocFile();
            AllPoint = loadAllPoint();
            int n = AllPoint.Count;
            for (int i = 0; i < n; i++)
            {
                coordinates[i, 0] = AllPoint[i].X;
                coordinates[i, 1] = AllPoint[i].Y;
            }
        }

        void heuritis()
        {
            for (int i = 0; i < n; i++)
            {
                heuristic[i] = calc(i, goal);
            }
        }

        public Graph(int start, int goal)
        {
            this.start = start;
            this.goal = goal;
            for (int i = 0; i < n; i++)
            {
                heuristic[i] = calc(i, goal);
            }

        }

        private bool checkEmpGraph(int u, float v)
        {
            for (int i = 0; i < graph[u].Count; i++)
            {
                if (graph[u][i] == v)
                    return false;
            }
            return true;
        }

        /////////////////////////////A*///////////////////////////////////
        public int[] a_star(int start, int goal)
        {
            List<int> st = new List<int>();
            st.Add(start);
            bool[] visited = new bool[n];
            int[] path = new int[n];
            double[] heuristic = new double[n];
            double[] distance = new double[n];

            for (int i = 0; i < n; i++)
            {
                path[i] = -1;
                distance[i] = 999999;
            }

            distance[start] = 0;
            visited[start] = true;

            while (st.Count != 0)
            {
                int value = st[0];
                st.RemoveAt(0);
                for (int i = 0; i < n; i++)
                {
                    if (visited[i] == false && !checkEmpGraph(value, i))
                    {
                        if (goal == i)
                        {
                            path[i] = value;
                            return path;
                        }

                        visited[i] = true;
                        path[i] = value;
                        distance[i] = distance[value] + calc(value, i);
                        heuristic[i] = calc(i, goal);
                        st.Add(i);
                    }
                }

                int index = 0;
                double min = 99999;
                for (int i = 0; i < st.Count; i++)
                {
                    if (distance[st[i]] + heuristic[st[i]] < min)
                    {
                        index = i;
                        min = distance[st[i]] + heuristic[st[i]];
                    }
                }

                int tmp = st[index];
                st[index] = st[0];
                st[0] = tmp;
            }

            return path;
        }

        public double calc(int i, int j)
        {
            return (Math.Sqrt(Math.Pow((coordinates[i, 0] - coordinates[j, 0]), 2) +
                              Math.Pow((coordinates[i, 1] - coordinates[j, 1]), 2)));
        }



        /////////////////////////////greedy///////////////////////////////////
        public int[] greedy(int start, int goal)
        {
            List<int> st = new List<int>();
            st.Add(start);
            bool[] visited = new bool[n];
            int[] path = new int[n];
            double[] heuristic = new double[n];


            for (int i = 0; i < n; i++)
            {
                path[i] = -1;
            }

            visited[start] = true;

            while (st.Count != 0)
            {
                int value = st[0];
                st.RemoveAt(0);
                for (int i = 0; i < n; i++)
                {
                    if (visited[i] == false && !checkEmpGraph(value, i))
                    {
                        if (goal == i)
                        {
                            path[i] = value;
                            return path;
                        }

                        visited[i] = true;
                        path[i] = value;
                        heuristic[i] = calc(i, goal);
                        st.Add(i);
                    }
                }

                int index = 0;
                double min = 99999;
                for (int i = 0; i < st.Count; i++)
                {
                    if (heuristic[st[i]] < min)
                    {
                        index = i;
                        min = heuristic[st[i]];
                    }
                }

                int tmp = st[index];
                st[index] = st[0];
                st[0] = tmp;
            }

            return path;
        }



        /////////////////////////////Dijkstra///////////////////////////////////
        private int minDistance(double[] dist, bool[] sptSet)
        {
            // Initialize min value
            double min = int.MaxValue;
            int min_index = -1;


            for (int v = 0; v < n; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        public int[] dijkstra(int src, int end)
        {
            this.start = src;
            this.goal = end;
            double[] dist = new double[n];
            bool[] sptSet = new bool[n];
            int[] way = new int[n];

            for (int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
                way[i] = -1;
            }


            dist[src] = 0;
            way[src] = -1;

            for (int count = 0; count < n - 1; count++)
            {

                int u = minDistance(dist, sptSet);

                sptSet[u] = true;


                for (int v = 0; v < n; v++)
                    if (!sptSet[v] && !checkEmpGraph(u, v) && dist[u] != int.MaxValue && dist[u] + calc(u, v) < dist[v])
                    {
                        dist[v] = dist[u] + calc(u, v);
                        way[v] = u;
                    }
            }

            return way;
        }


        //////////////////////////////////data/////////////////////////////////////
        ///
        ///

        public void DocFile()
        {
            string[] s = File.ReadAllLines("data.txt");
            int n = 0;
            for (int i = 0; i < 205; i++)
            {
                string[] tmp = s[i].Split(' ');

                graph.Add(new List<double>());
                graph[i] = new List<double>();


                n = tmp.Length;
                for (int j = 0; j < n; j++)
                {
                    graph[i].Add(Convert.ToInt32(tmp[j]) - 1);
                }
            }
        }
        private List<Point> loadAllPoint()
        {
            List<Point> allPoint = new List<Point>();
            //allPoint.Add(new Point(x, y));
            /*1:*/
            allPoint.Add(new Point(3, 596));/*
            2:*/
            allPoint.Add(new Point(28, 578));/*
            3:*/
            allPoint.Add(new Point(52, 557));/*
            4:*/
            allPoint.Add(new Point(77, 527));/*
            5:*/
            allPoint.Add(new Point(101, 509));/*
            6:*/
            allPoint.Add(new Point(123, 490));/*
            7:*/
            allPoint.Add(new Point(148, 480));/*
            8:*/
            allPoint.Add(new Point(180, 470));/*
            9:*/
            allPoint.Add(new Point(202, 458));/*
            10:*/
            allPoint.Add(new Point(210, 435));/*
            11:*/
            allPoint.Add(new Point(220, 409));/*
            12:*/
            allPoint.Add(new Point(234, 383));/*
            13:*/
            allPoint.Add(new Point(246, 360));/*
            14:*/
            allPoint.Add(new Point(255, 329));/*
            15:*/
            allPoint.Add(new Point(257, 301));/*
            16:*/
            allPoint.Add(new Point(263, 277));/*
            17:*/
            allPoint.Add(new Point(281, 250));/*
            18:*/
            allPoint.Add(new Point(312, 234));/*
            19:*/
            allPoint.Add(new Point(337, 211));/*
            20:*/
            allPoint.Add(new Point(344, 189));/*
            21:*/
            allPoint.Add(new Point(353, 150));/*
            22:*/
            allPoint.Add(new Point(324, 138));/*
            23:*/
            allPoint.Add(new Point(293, 127));/*
            24:*/
            allPoint.Add(new Point(256, 126));/*
            25:*/
            allPoint.Add(new Point(227, 141));/*
            26:*/
            allPoint.Add(new Point(186, 155));/*
            27:*/
            allPoint.Add(new Point(153, 163));/*
            28:*/
            allPoint.Add(new Point(123, 179));/*
            29:*/
            allPoint.Add(new Point(97, 193));/*
            30:*/
            allPoint.Add(new Point(70, 213));/*
            31:*/
            allPoint.Add(new Point(36, 226));/*
            32:*/
            allPoint.Add(new Point(5, 254));/*
            33:*/
            allPoint.Add(new Point(22, 197));/*
            34:*/
            allPoint.Add(new Point(50, 260));/*
            35:*/
            allPoint.Add(new Point(39, 287));/*
            36:*/
            allPoint.Add(new Point(30, 312));/*
            37:*/
            allPoint.Add(new Point(22, 337));/*
            38:*/
            allPoint.Add(new Point(5, 373));/*
            39:*/
            allPoint.Add(new Point(3, 416));/*
            40:*/
            allPoint.Add(new Point(367, 115));/*
            41:*/
            allPoint.Add(new Point(380, 84));/*
            42:*/
            allPoint.Add(new Point(406, 58));/*
            43:*/
            allPoint.Add(new Point(418, 21));/*
            44:*/
            allPoint.Add(new Point(461, 1));/*
            45:*/
            allPoint.Add(new Point(390, 161));/*
            46:*/
            allPoint.Add(new Point(421, 178));/*
            47:*/
            allPoint.Add(new Point(458, 191));/*
            48:*/
            allPoint.Add(new Point(490, 204));/*
            49:*/
            allPoint.Add(new Point(529, 209));/*
            50:*/
            allPoint.Add(new Point(566, 217));/*
            51:*/
            allPoint.Add(new Point(592, 245));/*
            52:*/
            allPoint.Add(new Point(627, 231));/*
            53:*/
            allPoint.Add(new Point(650, 209));/*
            54:*/
            allPoint.Add(new Point(680, 178));/*
            55:*/
            allPoint.Add(new Point(696, 145));/*
            56:*/
            allPoint.Add(new Point(714, 114));/*
            57:*/
            allPoint.Add(new Point(730, 83));/*
            58:*/
            allPoint.Add(new Point(750, 57));/*
            59:*/
            allPoint.Add(new Point(768, 26));/*
            60:*/
            allPoint.Add(new Point(606, 275));/*
            61:*/
            allPoint.Add(new Point(636, 314));/*
            62:*/
            allPoint.Add(new Point(561, 274));/*
            63:*/
            allPoint.Add(new Point(532, 299));/*
            64:*/
            allPoint.Add(new Point(503, 323));/*
            65:*/
            allPoint.Add(new Point(473, 343));/*
            66:*/
            allPoint.Add(new Point(445, 370));/*
            67:*/
            allPoint.Add(new Point(421, 396));/*
            68:*/
            allPoint.Add(new Point(396, 438));/*
            69:*/
            allPoint.Add(new Point(384, 476));/*
            70:*/
            allPoint.Add(new Point(365, 520));/*
            71:*/
            allPoint.Add(new Point(341, 565));/*
            72:*/
            allPoint.Add(new Point(323, 604));/*
            73:*/
            allPoint.Add(new Point(311, 636));/*
            74:*/
            allPoint.Add(new Point(564, 324));/*
            75:*/
            allPoint.Add(new Point(608, 351));/*
            76:*/
            allPoint.Add(new Point(631, 378));/*
            77:*/
            allPoint.Add(new Point(657, 408));/*
            78:*/
            allPoint.Add(new Point(689, 448));/*
            79:*/
            allPoint.Add(new Point(716, 483));/*
            80:*/
            allPoint.Add(new Point(751, 523));/*
            81:*/
            allPoint.Add(new Point(791, 549));/*
            82:*/
            allPoint.Add(new Point(858, 579));/*
            83:*/
            allPoint.Add(new Point(858, 542));/*
            84:*/
            allPoint.Add(new Point(859, 623));/*
            85:*/
            allPoint.Add(new Point(811, 632));/*
            86:*/
            allPoint.Add(new Point(778, 597));/*
            87:*/
            allPoint.Add(new Point(731, 584));/*
            88:*/
            allPoint.Add(new Point(692, 626));/*
            89:*/
            allPoint.Add(new Point(754, 627));/*
            90:*/
            allPoint.Add(new Point(653, 566));/*
            91:*/
            allPoint.Add(new Point(621, 605));/*
            92:*/
            allPoint.Add(new Point(589, 635));/*
            93:*/
            allPoint.Add(new Point(684, 520));/*
            94:*/
            allPoint.Add(new Point(717, 544));/*
            95:*/
            allPoint.Add(new Point(545, 612));/*
            96:*/
            allPoint.Add(new Point(542, 578));/*
            97:*/
            allPoint.Add(new Point(506, 563));/*
            98:*/
            allPoint.Add(new Point(482, 596));/*
            99:*/
            allPoint.Add(new Point(431, 554));/*
            100:*/
            allPoint.Add(new Point(392, 630));/*
            101:*/
            allPoint.Add(new Point(384, 584));/*
            102:*/
            allPoint.Add(new Point(402, 521));/*
            103:*/
            allPoint.Add(new Point(449, 479));/*
            104:*/
            allPoint.Add(new Point(502, 507));/*
            105:*/
            allPoint.Add(new Point(560, 383));/*
            106:*/
            allPoint.Add(new Point(580, 410));/*
            107:*/
            allPoint.Add(new Point(489, 430));/*
            108:*/
            allPoint.Add(new Point(610, 451));/*
            109:*/
            allPoint.Add(new Point(620, 501));/*
            110:*/
            allPoint.Add(new Point(546, 467));/*
            111:*/
            allPoint.Add(new Point(583, 555));/*
            112:*/
            allPoint.Add(new Point(794, 494));/*
            113:*/
            allPoint.Add(new Point(856, 503));/*
            114:*/
            allPoint.Add(new Point(849, 448));/*
            115:*/
            allPoint.Add(new Point(864, 389));/*
            116:*/
            allPoint.Add(new Point(886, 347));/*
            117:*/
            allPoint.Add(new Point(904, 295));/*
            118:*/
            allPoint.Add(new Point(913, 248));/*
            119:*/
            allPoint.Add(new Point(921, 200));/*
            120:*/
            allPoint.Add(new Point(926, 162));/*
            121:*/
            allPoint.Add(new Point(917, 94));/*
            122:*/
            allPoint.Add(new Point(873, 64));/*
            123:*/
            allPoint.Add(new Point(897, 8));/*
            124:*/
            allPoint.Add(new Point(805, 41));/*
            125:*/
            allPoint.Add(new Point(809, 125));/*
            126:*/
            allPoint.Add(new Point(743, 136));/*
            127:*/
            allPoint.Add(new Point(816, 171));/*
            128:*/
            allPoint.Add(new Point(870, 194));/*
            129:*/
            allPoint.Add(new Point(823, 74));/*
            130:*/
            allPoint.Add(new Point(795, 212));/*
            131:*/
            allPoint.Add(new Point(855, 271));/*
            132:*/
            allPoint.Add(new Point(812, 408));/*
            133:*/
            allPoint.Add(new Point(770, 350));/*
            134:*/
            allPoint.Add(new Point(732, 383));/*
            135:*/
            allPoint.Add(new Point(772, 446));/*
            136:*/
            allPoint.Add(new Point(749, 422));/*
            137:*/
            allPoint.Add(new Point(731, 332));/*
            138:*/
            allPoint.Add(new Point(724, 289));/*
            139:*/
            allPoint.Add(new Point(728, 239));/*
            140:*/
            allPoint.Add(new Point(730, 194));/*
            141:*/
            allPoint.Add(new Point(668, 262));/*
            142:*/
            allPoint.Add(new Point(694, 380));/*
            143:*/
            allPoint.Add(new Point(601, 188));/*
            144:*/
            allPoint.Add(new Point(567, 161));/*
            145:*/
            allPoint.Add(new Point(616, 119));/*
            146:*/
            allPoint.Add(new Point(672, 92));/*
            147:*/
            allPoint.Add(new Point(646, 154));/*
            148:*/
            allPoint.Add(new Point(682, 50));/*
            149:*/
            allPoint.Add(new Point(718, 12));/*
            150:*/
            allPoint.Add(new Point(639, 48));/*
            151:*/
            allPoint.Add(new Point(601, 5));/*
            152:*/
            allPoint.Add(new Point(482, 43));/*
            153:*/
            allPoint.Add(new Point(489, 143));/*
            154:*/
            allPoint.Add(new Point(525, 83));/*
            155:*/
            allPoint.Add(new Point(447, 101));/*
            156:*/
            allPoint.Add(new Point(517, 120));/*
            157:*/
            allPoint.Add(new Point(593, 90));/*
            158:*/
            allPoint.Add(new Point(530, 6));/*
            159:*/
            allPoint.Add(new Point(327, 86));/*
            160:*/
            allPoint.Add(new Point(302, 34));/*
            161:*/
            allPoint.Add(new Point(358, 32));/*
            162:*/
            allPoint.Add(new Point(223, 84));/*
            163:*/
            allPoint.Add(new Point(191, 46));/*
            164:*/
            allPoint.Add(new Point(227, 3));/*
            165:*/
            allPoint.Add(new Point(150, 16));/*
            166:*/
            allPoint.Add(new Point(108, 133));/*
            167:*/
            allPoint.Add(new Point(118, 85));/*
            168:*/
            allPoint.Add(new Point(138, 46));/*
            169:*/
            allPoint.Add(new Point(183, 107));/*
            170:*/
            allPoint.Add(new Point(67, 167));/*
            171:*/
            allPoint.Add(new Point(50, 113));/*
            172:*/
            allPoint.Add(new Point(19, 52));/*
            173:*/
            allPoint.Add(new Point(79, 30));/*
            174:*/
            allPoint.Add(new Point(79, 71));/*
            175:*/
            allPoint.Add(new Point(283, 174));/*
            176:*/
            allPoint.Add(new Point(208, 229));/*
            177:*/
            allPoint.Add(new Point(168, 285));/*
            178:*/
            allPoint.Add(new Point(141, 324));/*
            179:*/
            allPoint.Add(new Point(98, 347));/*
            180:*/
            allPoint.Add(new Point(193, 361));/*
            181:*/
            allPoint.Add(new Point(86, 426));/*
            182:*/
            allPoint.Add(new Point(36, 409));/*
            183:*/
            allPoint.Add(new Point(140, 417));/*
            184:*/
            allPoint.Add(new Point(125, 453));/*
            185:*/
            allPoint.Add(new Point(62, 485));/*
            186:*/
            allPoint.Add(new Point(170, 551));/*
            187:*/
            allPoint.Add(new Point(210, 618));/*
            188:*/
            allPoint.Add(new Point(133, 618));/*
            189:*/
            allPoint.Add(new Point(243, 487));/*
            190:*/
            allPoint.Add(new Point(289, 535));/*
            191:*/
            allPoint.Add(new Point(346, 431));/*
            192:*/
            allPoint.Add(new Point(309, 470));/*
            193:*/
            allPoint.Add(new Point(292, 365));/*
            194:*/
            allPoint.Add(new Point(368, 391));/*
            195:*/
            allPoint.Add(new Point(281, 423));/*
            196:*/
            allPoint.Add(new Point(405, 360));/*
            197:*/
            allPoint.Add(new Point(348, 306));/*
            198:*/
            allPoint.Add(new Point(359, 340));/*
            199:*/
            allPoint.Add(new Point(406, 267));/*
            200:*/
            allPoint.Add(new Point(455, 291));/*
            201:*/
            allPoint.Add(new Point(399, 217));/*
            202:*/
            allPoint.Add(new Point(352, 259));/*
            203:*/
            allPoint.Add(new Point(478, 237));/*
            204:*/
            allPoint.Add(new Point(112, 255));/*
            205:*/
            allPoint.Add(new Point(154, 209));
            return allPoint;
        }


        public List<string> name = new List<string>()
        {
            " ",
            "CGV Giga Mall Thủ Đức",
            " "," "," "," "," "," "," "," "," "," "," "," "," "," ",
            "Đường Phạm Văn Đồng",
            " "," ",
            "Khu Chế Xuất Linh Trung 1",
            "Cầu Vượt Linh Xuân",
            " "," ",
            "Ga Sóng Thần",
            " "," "," "," "," "," ",
            "Ngã Tư Bình Phước",
            " "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",
            "Xa Lộ Đại Hàn",
            " "," "," ",
            "Cầu Vượt Trạm 2",
            " ",
            "Công Viên Văn Hóa Suối Tiên",
            "Bệnh Viên Ung Bướu TP. HCM - Cơ Sở 2",
            "Nghĩa Trang Liệt Sỹ Tp. HCM",
            " "," "," "," "," "," "," "," ",
            "HUTECH Khu E - Trung Tâm Đào Tạo Nhân Lực CLC",
            "Xa Lộ Hà Nội",
            " "," "," "," "," "," "," "," "," "," "," "," ",
            "Trường Đại Học FPT TP. HCM",
            " "," "," "," "," "," "," "," "," "," "," "," ",
            "Nhà Máy SAMSUNG Khu Công Nghệ Cao",
            " "," "," "," "," "," "," ",
            "Trường Cao Đẳng Công Thương TP. HCM",
            " "," "," "," "," ",
            "Trường Đại Học Tài Chính - Marketing",
            "Phân Hiệu Trường ĐH Giao Thông Vận Tải TP. HCM",
            " "," "," "," "," "," ",
            "Vinhomes Grand Park S1.03",
            " "," ",
            "Nghĩa Trang Phúc An Viên",
            " "," "," ",
            "Chùa Hội Sơn",
            "Chùa Bửu Long",
            " "," ",
            "Công Viên Lịch Sử Văn Hóa Dân Tộc",
            " "," "," "," "," ",
            "Vietnam Golf & Country Club",
            " "," "," "," ",
            "Trường Cao Đẳng Cảnh Sát Nhân Dân 2 Cơ Sở 2",
            " "," "," "," "," "," "," ",
            "Đại học Quốc Gia TP. HCM",
            "Trường ĐH Nông Lâm",
            "Trường ĐH Khoa Học Tự nhiên",
            "Ký túc xá Khu A ĐH Quốc Gia TP. HCM",
            " "," ",
            "Nghĩa Trang Nhân Dân Bình An",
            " "," ",
            "Ký túc xá ĐH Quốc Gia TP. HCM",
            " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",
            "Chợ Đầu Mối Nông Sản Thủ Đức",
            " "," "," "," "," ",
            "Bệnh Viện TP THủ Đức",
            "Khu Phố Tam Bình",
            " "," "," "," ",
            "Trường THPT Hiệp Bình",
            " "," "," "," "," "," ",
            "Đường số 2, Phường Trường Thọ",
            " ",
            "Chùa 1 Cột Thủ ĐỨc - Nam Thiên Nhất Trụ",
            " ",
            "Chợ Thủ Đức",
            "Đường Võ Văn Ngân",
            " ",
            "Trường ĐH Sư Phạm Kỹ Thuật TP. HCM",
            " "," ",
            "Nghĩa Trang TP. HCM",
            "Tổng Công Ty Việt Thắng",
            " "," "," "," "," "
        };
    }
}