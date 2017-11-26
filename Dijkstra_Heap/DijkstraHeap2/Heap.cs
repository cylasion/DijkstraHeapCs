using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace DijkstraHeap2
{
    class Heap
    {
        private int[] d, heap,pos;
        //d[i] : độ dài từ d0ỉnh đầu đến i
        //heap[i] : cây heap ( lưu đỉnh )
        //pos[i] = vị trí đỉnh i trong cây heap 
        private int heapSize;

        public Heap(int n)
        {
            d = new int[n + 1];
            heap = new int[n + 1];
            pos = new int[n + 1];
            heapSize = 1;
        }

        private void swap(int i, int j)
        {
            int temp;
            temp = pos[heap[i]];
            pos[heap[i]] = pos[heap[j]];
            pos[heap[j]]= temp;
            temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
            
        }

        private void downheap(int i)
        {
            int j;
            j = i * 2;
            if (j >= heapSize)
                return;
            if (j < heapSize && d[heap[j]] > d[heap[j + 1]])
                j++;
            if (d[heap[i]] < d[heap[j]])
                return;
            swap(i, j);
            downheap(j);
        }

        private void upheap(int i)
        {
         
            if (i==1 ||d[heap[i / 2]] < d[heap[i]])
                return;
            swap(i,i/2);
            upheap(i/2);
        }
            
        public void add(int node,int value)
        {
            d[node] = value;
            pos[node] = heapSize;
            heap[heapSize] = node;
            upheap(heapSize);
            heapSize++;

        }

        public int pop()
        {
            int node = heap[1];
            heapSize--;
            swap(1, heapSize);
            downheap(1);
            return node;
        }

    

        public bool isNull()
        {
            if(heapSize<1)
            {
                return true;
            }
            return false;
        }

        public int getNodeDistance(int i)
        {
            return d[i];
        }
        public void setNodeDistance(int i,int value)
        {
            d[i] = value;
            upheap(pos[i]);
        }
    }
}
