using System;
using System.IO;
using System.Diagnostics;


namespace DijkstraHeap2
{
    class Dijkstra
    {
        const int Max = 10000000;
        private int[] adj, adjcost, trace, h;
        private bool[] free;
        private int n, m, s, t;
        Heap mheap;

        public void LoadGrap()
        {

            using (StreamReader reader = new StreamReader(@"E:\in.txt"))
            {

                n = int.Parse(reader.ReadLine());
                m = int.Parse(reader.ReadLine());
                s = int.Parse(reader.ReadLine());
                t = int.Parse(reader.ReadLine());

                
                trace = new int[n + 1];
                free = new bool[n + 1];
                h = new int[n + 2];
               
                mheap = new Heap(n);

                //đọc vào H trc
                for (int i = 1; i <= m; i++)
                {
                    string[] token = reader.ReadLine().Split(' ');
                    int u = int.Parse(token[0]);
                    int v = int.Parse(token[1]);
               
                    h[u]++;
                    h[v]++;
                }
                for (int i = 2; i <= n + 1; i++)
                    {
                    h[i] = h[i - 1] + h[i];
                }
                adj = new int[h[n+1]+1];
                adjcost = new int[h[n + 1]+1];
            }
            using (StreamReader reader = new StreamReader(@"E:\in.txt"))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();

                for (int i = 1; i <= m; i++)
                {
                    string[] token = reader.ReadLine().Split(' ');
                    int u = int.Parse(token[0]);
                    int v = int.Parse(token[1]);
                    int c = int.Parse(token[2]);

                    adj[h[u]] = v;
      
                    adj[h[v]] = u;
                    adjcost[h[u]] = c;
                    adjcost[h[v]] = c;
                    h[u]--;
                    h[v]--;
                }
            }
        }

        public void init()
        {
            for (int i = 1; i <= n; i++)
            {
                if (i != s)
                {
                    mheap.add(i, Max);
                }
            }
            mheap.add(s, 0);

            for (int i = 1; i <= n; i++)
                free[i] = true;


        }

        public void doDijkstra()
        {
            do
            {
                int u;
                do
                {
                    if (mheap.isNull())
                    {
                        return;
                    }
                    u = mheap.pop();
                }
                while (free[u] == false);

                free[u] = false;
                for (int v = h[u] + 1; v <= h[u + 1]; v++)
                {
                    if (mheap.getNodeDistance(adj[v]) > mheap.getNodeDistance(u) + adjcost[v])
                    {
                        mheap.setNodeDistance(adj[v],mheap.getNodeDistance(u) + adjcost[v]);
                        trace[adj[v]] = u;
                    }
                }
             

            }
            while (true);
        }
       
        public void Resultl(long time)
        {
            Console.WriteLine("RESULT: "+mheap.getNodeDistance(t));
            Console.WriteLine("TRACE: ");
            int u = n;
            do
            { 
                Console.Write(u+" ");
                u = trace[u];
            }
            while (u != s);
            Console.WriteLine();
            Console.WriteLine("TIME: "+time);
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
            dij.doDijkstra();
            sw.Stop();

            dij.Resultl(sw.ElapsedMilliseconds);
            
        }
    }
}
