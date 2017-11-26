
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traditional_Heap
{

    class Heap
    {
        private int size { get; set; }
        private int[] pos, heap,d;

        public Heap(int n)
        {
            pos = new int[n + 1];
            heap = new int[n + 1];
            size = 0;
        }

        private void swap(int i, int j)
        {
            int temp;
            temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
            temp = pos[i];
            pos[i] = pos[j];
            pos[j] = temp;

        }

        public void upheap(int i)
        {
            int j = i / 2;
            if (i == 0 || d[heap[i]] < d[heap[j]])
                return;
            swap(i, j);
            upheap(i / 2);  
        }

        public void downheap(int i)
        {
            int j = i * 2;
            if (j > size)
                return;
            if (j<size && d[heap[j+1]]< d[heap[j]])
            {
                j++;
            }
            if (d[heap[i]] < d[heap[j]])
                return;
            swap(i, j);
            downheap(j);       
        }

        public void add(int node,int value)
        {
            heap[size] = node;
            pos[node] = size;
            d[node] = value;
            pos[node] = size;
            upheap(size);
            size++;
        }

        public int pop()
        {
           
        }

            


    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
