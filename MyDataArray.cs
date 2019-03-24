using System;
using System.IO;
namespace Labaratorinis_01
{
    class MyDataArray : DataArray
    {
        double[] data;
        public MyDataArray(int n, int seed)
        {
            data = new double[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                data[i] = rand.NextDouble();
            }
        }

        public override double this[int index]
        {
            get { return data[index]; }
        }

        public override void Swap(int ind, int largest)
        {
            double temp = data[ind];
            data[ind] = data[largest];
            data[largest] = temp;
        }
    }
}
