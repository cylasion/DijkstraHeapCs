using System;
using System.Diagnostics;
using System.IO;
 
namespace Dijkstra
{
    class Dijkstra
    {
        const int Max = 10000000;
        private  int[][] a;
        private  int[] d, trace;
        private  bool[] free;
        private  int n, m, s, t;

        public  void LoadGrap()
        {
            using (StreamReader reader = new StreamReader(@"E:\in.txt"))
            {

                n = int.Parse(reader.ReadLine());
                m = int.Parse(reader.ReadLine());
                s = int.Parse(reader.ReadLine());
                t = int.Parse(reader.ReadLine());

                a = new int[n+1][];
                d = new int[n+1];
                trace = new int[n+1];
                free = new bool[n+1];

                for (int i = 1; i <= n; i++)
                {
                    a[i] = new int[n+1];
                    for (int j = 1; j <= n; j++)
                    {
                        if (i == j)
                            a[i][j] = 0;
                        else
                            a[i][j] = Max;
                    }
                }
                for (int i = 1; i <=m; i++)
                {
                    string[] token = reader.ReadLine().Split(' ');
                    int u = int.Parse(token[0]);
                    int v = int.Parse(token[1]);
                    int c = int.Parse(token[2]);
                    a[u][v] = c;
                    a[v][u] = c;
                    //reader.ReadLine();

                }
            } 
        }

        public  void init()
        {
            for (int i =1; i <=n; i++)
                d[i] = Max;
            d[s] = 0;
            for (int i =1; i <= n; i++)
                free[i] = true;


        }

        public  void DoDijkstra()
        {
            do
            {
                int u = 0;
                int min = Max;
                for (int i = 1; i <= n; i++)
                {
                    if (free[i] == true && d[i] < min)
                    {
                        u = i;
                        min = d[i];
                    }
                }
                if (u == 0 || u == t)
                {
                    return;
                }
                free[u] = false;
                for (int v = 1; v <= n; v++)
                {
                    if (d[v] > d[u] + a[u][v])
                    {
                        d[v] = d[u] + a[u][v];
                        trace[v] = u;
                    }
                }
            }
            while (true);
        }

        public void Result(long time)
        {
            Console.WriteLine("RESULT: " +d[t]);
            Console.WriteLine("TRACE: ");
            int u = n;
            do
            {
                Console.Write(u + " ");
                u = trace[u];
            }
            while (u != s);
            Console.WriteLine();
            Console.WriteLine("TIME " + time);
            Console.ReadKey();
        }
    }

    class Program
    {
       static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Dijkstra dij = new Dijkstra();
            dij.LoadGrap();
            dij.init();
            dij.DoDijkstra();
            sw.Stop();
            dij.Result(sw.ElapsedMilliseconds);
        }
    }
}
