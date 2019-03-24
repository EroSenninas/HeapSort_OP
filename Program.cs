using System;
using System.IO;
using System.Diagnostics;

namespace Labaratorinis_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Test_Array_List(seed);
        }

        public static void HeapSort(DataArray items)
        {
            int heapSize = items.Length - 1;
            for (int i = heapSize/2; i >= 0; i--)
            {
                Heapify(items, heapSize, i);
            }
            for (int i = items.Length - 1; i >= 0; i--)
            {
                items.Swap(0, i);
                heapSize--;
                Heapify(items, heapSize, 0);
            }
        }

        public static void HeapSort(DataList items)
        {
            int heapSize = items.Length - 1;
            for (int i = heapSize/2; i >= 0; i--)
            {
                HeapifyList(items, heapSize, i);
            }
            for (int i = items.Length - 1; i > 0; i--)
            {
                items.Swap(0, i);
                heapSize--;
                HeapifyList(items, heapSize, 0);
            }
        }

        public static void Heapify(DataArray items, int heapSize, int index)
        {
            int left = index*2;
            int right = index*2 + 1;
            int largest = 0;

            if (left <= heapSize && items[left] > items[index])
            {
                largest = left;
            }
            else largest = index;

            if (right <= heapSize && items[right] > items[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                items.Swap(index, largest);
                Heapify(items, heapSize, largest);
            }
        }

        public static void HeapifyList(DataList items, int heapSize, int index)
        {
            int left = index * 2;
            int right = index * 2 + 1;
            int largest = 0;

            if (left <= heapSize && items.findNode(left) > items.findNode(index))
            {
                largest = left;
            }
            else largest = index;

            if (right <= heapSize && items.findNode(right) > items.findNode(largest))
            {
                largest = right;
            }

            if (largest != index)
            {
                items.Swap(index, largest);
                HeapifyList(items, heapSize, largest);
            }
        }

        public static void Test_Array_List(int seed)
        {
            int n = 1000;
            Console.WriteLine("Heap sort operatyvioje atmintyje:");
            Console.WriteLine("Duomenu masyvas:");
            Console.WriteLine("_______________________________________");
            Console.WriteLine("| Elementu kiekis |  Rikiavimo laikas |");
            Console.WriteLine("|-----------------|-------------------|");
            for (int i = 0; i < 7; i++)
            {
                MyDataArray myarray = new MyDataArray(n, seed);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                HeapSort(myarray);
                watch.Stop();
                Console.WriteLine("| {0,15} | {1,17} |", n, watch.Elapsed);
                n = n * 2;
                watch.Reset();
            }
            Console.WriteLine("|-----------------|-------------------|");

            Console.WriteLine("\nDuomenu susietas sarasas:");
            Console.WriteLine("_______________________________________");
            Console.WriteLine("| Elementu kiekis |  Rikiavimo laikas |");
            Console.WriteLine("|-----------------|-------------------|");
            n = 1000;
            for (int i = 0; i < 7; i++)
            {
                MyDataList mylist = new MyDataList(n, seed);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                HeapSort(mylist);
                watch.Stop();
                Console.WriteLine("| {0,15} | {1,17} |", n, watch.Elapsed);
                n = n * 2;
                watch.Reset();
            }
            Console.WriteLine("|-----------------|-------------------|");
        }
    }

    abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract double this[int index] { get; }
        public abstract void Swap(int ind, int largest);
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(" {0:F5} ", this[i]);
            }
            Console.WriteLine();
        }
    }

    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract double Head();
        public abstract double Next();
        public abstract double findNode(int index);
        public abstract void Swap(int ind, int largest);
        public void Print(int n)
        {
            Console.WriteLine(" {0:F5} ", Head());
            for (int i = 1; i < n; i++)
            {
                Console.WriteLine(" {0:F5} ", Next());
            }
            Console.WriteLine();
        }
    }
}
