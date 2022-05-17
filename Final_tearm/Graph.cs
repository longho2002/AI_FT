using System;
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
    internal class Graph
    {
        private const int SIZE = 50;
        protected int goal = 5;
        protected int start = 0;
        protected int n = 33;
        protected double[] heuristic = new double[SIZE];
        protected int[,] coordinates = new int[SIZE, 2];
        public List<Point> AllPoint;

        public Graph()
        {
        }

        public void init()
        {
            AllPoint = loadAllPoint();
            int n = AllPoint.Count;
            for (int i = 0; i < n; i++)
            {
                coordinates[i, 0] = AllPoint[i].X;
                coordinates[i, 1] = AllPoint[i].Y;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (graph[i, j] != 0)
                        graph[i, j] = calc(i, j);
                }
            }
        }

        void heuritis()
        {
            for (int i = 0; i < n; i++)
            {
                //7 * min(deltaX,deltaY) + 10 * ( max(deltaX,deltaY) - min(deltaX,deltaY) )

                heuristic[i] = calc(i, goal);

                //heuristic[i] = 7 * Math.Min(coordinates[i, 1], coordinates[goal, 1]) + 10 *
                //    (Math.Max(coordinates[i, 1], coordinates[goal, 1]) -
                //     Math.Min(coordinates[i, 0], coordinates[goal, 0]));
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

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (graph[i, j] != 0)
                        graph[i, j] = calc(i, j);
                }
            }

        }

        private List<Point> loadAllPoint()
        {
            List<Point> allPoint = new List<Point>();
            //allPoint.Add(new Point(x, y));
            allPoint.Add(new Point(424, 386));
            allPoint.Add(new Point(508, 312));
            allPoint.Add(new Point(581, 412));
            allPoint.Add(new Point(561, 385));
            allPoint.Add(new Point(700, 448));
            allPoint.Add(new Point(783, 445));
            allPoint.Add(new Point(615, 604));
            allPoint.Add(new Point(437, 560));
            allPoint.Add(new Point(272, 367));
            allPoint.Add(new Point(212, 228));
            allPoint.Add(new Point(378, 193));
            allPoint.Add(new Point(474, 44));
            allPoint.Add(new Point(688, 167));
            allPoint.Add(new Point(105, 564));
            allPoint.Add(new Point(306, 32));
            allPoint.Add(new Point(568, 161));
            allPoint.Add(new Point(603, 189));
            allPoint.Add(new Point(72, 171));
            allPoint.Add(new Point(269, 125));
            allPoint.Add(new Point(361, 152));
            allPoint.Add(new Point(595, 251));
            allPoint.Add(new Point(553, 214));
            allPoint.Add(new Point(405, 52));
            allPoint.Add(new Point(520, 417));
            allPoint.Add(new Point(716, 484));
            allPoint.Add(new Point(366, 523));
            allPoint.Add(new Point(166, 476));
            allPoint.Add(new Point(74, 535));
            allPoint.Add(new Point(282, 255));
            allPoint.Add(new Point(344, 180));
            allPoint.Add(new Point(575, 353));
            allPoint.Add(new Point(632, 402));
            allPoint.Add(new Point(188, 157));
            return allPoint;
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
                    if (visited[i] == false && graph[value, i] != 0)
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


        protected double[,] graph = new double[,]
        {{0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0,},

        {
            1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
        },
        {
            0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0,
        },
        {
            0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
        },
        {
            0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        },
        {
            1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0,
        },
        {
            0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
        },
        {
            0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
        },
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        }
    };

        //protected int[,] coordinates = new int[,] { { 0, 2 }, { 2, 0 }, { 2, 4 }, { 6, 0 }, { 6, 4 }, { 8, 2 } };

        private double calc(int i, int j)
        {
            return (Math.Sqrt(Math.Pow((coordinates[i, 0] - coordinates[j, 0]), 2) +
                              Math.Pow((coordinates[i, 1] - coordinates[j, 1]), 2)));
        }



        /////////////////////////////Dijkstra///////////////////////////////////
        private int minDistance(double[] dist, bool[] sptSet)
        {
            // Initialize min value
            double min = int.MaxValue;
            int min_index = -1; ;

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
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                        way[v] = u;
                    }
            }
            return way;
        }
    }
}
