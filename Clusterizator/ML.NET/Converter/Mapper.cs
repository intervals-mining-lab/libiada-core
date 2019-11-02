using System;
using System.Collections.Generic;
using System.Text;

namespace Clusterizator.ML.NET.Converter
{
    public class Mapper
    {
        public static ClusterizationData[] Convert(double [][] data)
        {
            var clusterizationData = new List<ClusterizationData>();
            foreach (var chain in data)
            {
                clusterizationData.Add(new ClusterizationData() { Characteristics = toFloatArray(chain)});
            }
            return clusterizationData.ToArray();
        }
        private static float[] toFloatArray(double[] arr)
        {
            if (arr == null) return null;
            int n = arr.Length;
            float[] ret = new float[n];
            for (int i = 0; i < n; i++)
            {
                ret[i] = (float)arr[i];
            }
            return ret;
        }
    }
}
