using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_Prim_s_MST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.ReadGraph("Graph.txt");
            g.printGraph();

            g.Prime(1); // () 안에 있는 숫자는 -> 출발 숫자임. ex) 5 = F
        }
    }
}
