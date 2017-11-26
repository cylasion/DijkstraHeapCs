using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TestCreator
{
    class Program
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        static void Main(string[] args)
        {
            int n, m,max;
            int[][] a;
            using (StreamWriter writer = new StreamWriter(@"E:\in.txt"))
            {
                Console.WriteLine("Nhap so dinh va so canh va max");
                n = int.Parse(Console.ReadLine());
                m = int.Parse(Console.ReadLine());
                max = int.Parse(Console.ReadLine()); ;
                writer.WriteLine(n);
                writer.WriteLine(m);
                writer.WriteLine("1");
                writer.WriteLine(n);

                a = new int[n][];
                for (int i = 0; i < n; i++)
                    a[i] = new int[n];




                int v1 = n;
                int u1;
                int count = 0;
                do
                {
                    count++;
                    u1 = RandomNumber(1, v1-1);
                    int k = RandomNumber(1, max);
                    writer.WriteLine(u1 + " " + v1 + " " + k);
                    v1 = u1;
                } while (u1 != 1);





                for (int i =0; i<m-count;i++)
                {

                    int u = RandomNumber(1, n);
                    int v;
                    do
                    {
                        v = RandomNumber(1, n);
                    }
                    while (u == v);

                    int c = RandomNumber(1, max);

                    if (a[u][v] == 0 && a[v][u]==0 )
                    {
                        a[u][v] = 1;
                        a[v][u] = 1;
                        writer.WriteLine(u + " " + v + " " + c);
                    }
                    else
                        i--;
                }
               
               
            }
            
        }
    }
}
