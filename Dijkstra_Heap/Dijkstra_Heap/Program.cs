using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_Heap
{
    class dijkstra
    {
        const int Max = 10000000;
        private int[][] a;
        private int[] d, trace;
        private bool[] free;
        private int[] h, adj,adjcost;
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

                a = new int[n + 1][];
                d = new int[n + 1];
                trace = new int[n + 1];
                free = new bool[n + 1];
                h = new int[n + 1];
                adj = new int[n + 1];
                adjcost = new int[n + 1];
                mheap = new Heap(n);

                //đọc vào H trc
                for (int i = 1; i <= m; i++)
                {
                    int u = int.Parse(reader.ReadLine());
                    int v = int.Parse(reader.ReadLine());
                    reader.ReadLine();
                    h[u]++;
                    h[v]++;
                }
                for (int i = 2; i <= n + 1; i++)
                {
                    h[i] = h[i - 1] + h[i];
                }

            }
            using (StreamReader reader = new StreamReader(@"E:\in.txt"))
            {
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
                reader.ReadLine();
              
                for (int i = 1; i <= m; i++)
                {
                    int u = int.Parse(reader.ReadLine());
                    int v = int.Parse(reader.ReadLine());
                    int c = int.Parse(reader.ReadLine());

                    adj[h[u]] = v;
                    h[u]--;
                    adj[h[v]] = u;
                    h[v]--;

                    adjcost[h[u]] = c;
                    adjcost[h[v]] = c;

                }
            }
        }

        public void init()
        {
            for (int i = 1; i <= n; i++)
            {
                if(i!=s)
                {
                    HeapNode node = new HeapNode(i, Max);
                    mheap.add(node);
                }
            }
            HeapNode nodeS = new HeapNode(s, 0);
            mheap.add(nodeS);

            for (int i = 1; i <= n; i++)
                free[i] = true;


        }

        public void DoDijkstra()
        {
            do
            {
                HeapNode headU;
                do
                {
                    if (mheap.isNull())
                        return;
                    headU = mheap.pop();
                }
                while (free[headU.NodeId] == false);
              
                if(headU.NodeId==t)
                {
                    return;
                }

                free[headU.NodeId] = false;

                int u = headU.NodeId;
                for (int v= h[u]+1; v<= h[u+1];v++)
                {
                    if(headU.Value > adj)
                    {

                    }
                }               
            }
            while (true);
        }


    }
}

    class Program
    {
        static void Main(string[] args)
        {
            HeapNode node0 = new HeapNode(0, 0);
            HeapNode node1 = new HeapNode(0, 1);
            HeapNode node2 = new HeapNode(0, 2);
            HeapNode node3 = new HeapNode(0, 3);
            HeapNode node4 = new HeapNode(0, 4);

            Heap heap = new Heap(5);
            heap.add(node2);
            heap.add(node3);
            heap.add(node1);
            heap.add(node4);
            heap.add(node0);
        }
    }
}
