﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labaratorinis_01
{
    class MyDataList : DataList
    {
        class MyLinkedListNode
        {
            public MyLinkedListNode nextNode { get; set; }
            public double data { get; set; }
            public MyLinkedListNode(double data)
            {
                this.data = data;
            }
        }

        MyLinkedListNode headNode;
        MyLinkedListNode prevNode;
        MyLinkedListNode currentNode;

        public MyDataList(int n, int seed)
        {
            length = n;
            Random rand = new Random(seed);
            headNode = new MyLinkedListNode(rand.NextDouble());
            currentNode = headNode;
            for (int i = 1; i < length; i++)
            {
                prevNode = currentNode;
                currentNode.nextNode = new MyLinkedListNode(rand.NextDouble());
                currentNode = currentNode.nextNode;
            }
            currentNode.nextNode = null;
        }
        public override double Head()
        {
            currentNode = headNode;
            prevNode = null;
            return currentNode.data;
        }
        public override double Next()
        {
            prevNode = currentNode;
            currentNode = currentNode.nextNode;
            return currentNode.data;
        }

        public override double findNode(int index)
        {
            int k = 0;
            currentNode = headNode;
            while (index != k)
            {
                currentNode = currentNode.nextNode;
                k++;
            }
            return currentNode.data;
        }

        public override void Swap(int ind, int largest)
        {
            double temp = 0.0;
            MyLinkedListNode q;
            int k = 0;
            q = currentNode = headNode;
                while (k != largest)
                {
                    if (k == ind)
                    {
                        q = currentNode;
                        temp = currentNode.data;
                    }
                    currentNode = currentNode.nextNode;
                    k++;
                }
                q.data = currentNode.data;
                currentNode.data = temp;             
        }
    }
}
