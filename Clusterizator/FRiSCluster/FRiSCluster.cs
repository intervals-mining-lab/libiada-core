using System;
using System.Collections.Generic;
using System.Text;

namespace Clusterizator.FRiSCluster
{
    class FRiSCluster : IClusterizator
    {
        public int[] Cluster(int clustersCount, double[][] data)
        {
            double[][] extendedData = new double[data.Length][];
            double[][] temporaryData = new double[data.Length][];
            double rStar = 1;
            for (int i = 0; i< data.Length; i++)
            {
                extendedData[i] = new double[data[0].Length + 1];
                temporaryData[i] = new double[data[0].Length + 1];
                for(int j = 0; j < data[0].Length; j++)
                {
                    extendedData[i][j] = data[i][j];
                    temporaryData[i][j] = data[i][j];                   
                }
                extendedData[i][extendedData[i].Length - 1] = 0;
                temporaryData[i][temporaryData[i].Length - 1] = rStar;
            }
            double[,] simularityFunction = new double[data.Length, data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if (i != j)
                    {
                        double r1 = 0;//Math.Sqrt(Math.Pow((data[i][0] - data[j][0]), 2) + Math.Pow((data[i][1] - data[j][1]), 2) + Math.Pow(rStar, 2));
                        for (int k = 0; k < data[0].Length; k++)
                        {
                            r1 += Math.Pow((data[i][k] - data[j][k]), 2);
                        }
                        r1 += Math.Pow(rStar, 2);
                        r1 = Math.Sqrt(r1);
                        simularityFunction[i, j] = 1 - r1/(r1+rStar);
                    }
                    else
                    {
                        simularityFunction[i, j] = rStar;
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}
