using System;
using System.Runtime.ExceptionServices;

namespace _007_Prim_s_MST
{
    internal class Graph
    {
        static int MAX = 100;
        static int INF = 999; // 무한대를 의미
        private int V; // 정점의 개수
        string[] vertex = new string[MAX];
        int[,] adj = new int[MAX, MAX]; // 인접행렬
        private int MSTWeight = 0;

        internal void Prime(int start)
        {
            bool[] selected = new bool[V];
            int[] dist = new int[V];

            // dist[], selectd[] 초기화
            for (int i = 0; i < V; i++)
            {
                dist[i] = INF;
                selected[i] = false;
            }
            PrintDist(dist);
            PrintSeledcted(selected);

            dist[start] = 0; // 시작점

            for (int i = 0; i < V; i++)
            {
                int u = GetMinVertex(selected, dist);
                selected[u] = true;

                MSTWeight += dist[u];
                Console.WriteLine("select = {0}, W = {1} ", vertex[u], MSTWeight);

                // dist[] 업데이트 // 핵심부분!!
                for(int v = 0; v< V; v++)
                {
                    if (adj[u, v]!= INF)
                        if (!selected[v] && adj[u, v] < dist[v])
                            dist[v] = adj[u, v];

                    PrintDist(dist);
                    PrintSeledcted(selected);
                }
                
            }
        }

        private void PrintSeledcted(bool[] selected)
        {
            Console.Write("selected[] : \t");
            for (int i = 0; i < V; i++)
            {
                Console.Write("{0,8}", selected[i]);
            }
            Console.WriteLine();
        }

        private void PrintDist(int[] dist)
        {
            Console.Write("Dist[] : \t");
            for (int i = 0; i < V; i++)
            {
                Console.Write("{0,8}", dist[i]);
            }
            Console.WriteLine();
        }

        // MST에 포함되지 않은 정점 중에서 거리가 최소인 정점을 찾아서 리턴
        private int GetMinVertex(bool[] selected, int[] dist)
        {
            int minV = 0; // 기본값을 -1로 설정
            int minDist = INF;

            for (int v = 0; v < V; v++)
            {
                if (!selected[v] && dist[v] < minDist)
                {
                    minV = v;
                    minDist = dist[v];
                }
            }

            // 기본값으로 minV를 반환
            return minV; // -1이 반환되면 유효한 정점이 없음을 의미
        }


        internal void printGraph()
        {
            Console.WriteLine("vertex 수 = " + V);
            for(int i = 0; i < V; i++)
            {
                Console.WriteLine(vertex[i]);
                for (int j = 0; j < V; j++)
                    Console.Write("{0,8}", adj[i, j]);
                Console.WriteLine();
            }
        }

        internal void ReadGraph(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines("../../" + filename); // ReadAllLines 파일을 읽어서 가져온다
            V = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {   // 6
                // A	0	3	999	2	4	999
                string[] s = lines[i].Split('\t');

                InsertVertex(i - 1, s[0]);

                for (int j = 1; j < s.Length; j++)
                    InsertEdge(i - 1, j - 1, int.Parse(s[j]));                                                    
            }
        }

        private void InsertEdge(int i, int j, int w)
        {
            adj[i, j] = w;
        }

        private void InsertVertex(int index, string name)
        {
            vertex[index] = name;
        }
    }
}