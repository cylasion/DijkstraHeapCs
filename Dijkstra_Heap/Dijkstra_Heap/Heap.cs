using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_Heap
{  
    class HeapNode
    { 
        public int NodeId { get; set; }
        public int Value { get; set; }
        public HeapNode() { }
        public HeapNode(int id,int value) {
            NodeId = id;
            Value = value;   
        }
    }

    class Heap
    {
        private int heapSize;
        List<HeapNode> mHeap;
        public Heap(int n)
        {
            mHeap = new List<HeapNode>(n);
            heapSize = 0;
        }   

        private void swap(int a,int b)
        {
            HeapNode temp = new HeapNode();
            temp = mHeap[a];
            mHeap[a] = mHeap[b];
            mHeap[b] = temp;
        }
    
        private void upheap(int i)
        {
            if (i == 0 || mHeap[i].Value >= mHeap[i / 2].Value)
                return;
            swap(i, i / 2);
            upheap(i / 2); 
        }
        private void downheap(int i)
        {
            int j = i * 2;
            if (j > heapSize)
                return;
            if(j<heapSize && mHeap[j].Value>mHeap[j+1].Value)
            {
                j++;
            }
            if(mHeap[i].Value > mHeap[j].Value)
            {
                swap(i, j);
                downheap(j);
            }
        }

        public void add(HeapNode node)
        {
         
            mHeap.Add(node);
            upheap(heapSize);
            heapSize++;
           
        }


        public HeapNode pop()
        {
            HeapNode result = mHeap[0];
            swap(0, heapSize);
            heapSize--;
            downheap(0);
            return result;
        }

        public void UpdateHead(int newvalue)
        {
            mHeap[0].Value = newvalue;
            downheap(0);
        }

        public bool isNull()
        {
            if(heapSize ==0)
            {
                return true;
            }
            return false;
        }

    }


}
