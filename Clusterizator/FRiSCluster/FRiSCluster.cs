using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clusterizator.FRiSCluster
{
    class FRiSCluster : IClusterizator
    {
        private readonly int minimumClusters;
        private readonly int maximumClusters;

        public FRiSCluster(int minimumClusters, int maximumClusters)
        {
            if(minimumClusters > maximumClusters)
            {
                throw new ArgumentException("Minimum number of clusters can't be greater then maxim number of clusters");
            }
            this.minimumClusters = minimumClusters;
            this.maximumClusters = maximumClusters;
        }
        public int[] Cluster(int clustersCount, double[][] data)
        {
            double[][] extendedData = new double[data.Length][];
            double[][] temporaryData = new double[data.Length][];
            double rStar = 1;
            for (int i = 0; i < data.Length; i++)
            {
                extendedData[i] = new double[data[0].Length + 1];
                temporaryData[i] = new double[data[0].Length + 1];
                for (int j = 0; j < data[0].Length; j++)
                {
                    extendedData[i][j] = data[i][j];
                    temporaryData[i][j] = data[i][j];
                }
                extendedData[i][extendedData[i].Length - 1] = 0;
                temporaryData[i][temporaryData[i].Length - 1] = rStar;
            }
            double[,] similarityFunction = new double[data.Length, data.Length];
            double[] averageSimilarityFunction = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if (i != j)
                    {
                        double r1 = 0;
                        for (int k = 0; k < data[0].Length; k++)
                        {
                            r1 += Math.Pow((data[i][k] - data[j][k]), 2);
                        }
                        r1 += Math.Pow(rStar, 2);
                        r1 = Math.Sqrt(r1);
                        similarityFunction[i, j] = 1 - r1 / (r1 + rStar);
                    }
                    else
                    {
                        similarityFunction[i, j] = rStar;
                    }
                    averageSimilarityFunction[i] += similarityFunction[i, j];
                }
                averageSimilarityFunction[i] /= data.Length;
            }
            List<int> pillarIndexes = new List<int>();
            var maxSimilarity = averageSimilarityFunction.Max();
            pillarIndexes.Add(Array.IndexOf(averageSimilarityFunction, maxSimilarity));
            pillarIndexes.Add(Array.IndexOf(averageSimilarityFunction, averageSimilarityFunction.Max(x => x < maxSimilarity)));
            List<double>[] distances = new List<double>[data.Length];
            int[] clustersBelonging = new int[data.Length];
            for (int i = 0;i<data.Length;i++)
            {
                distances[i] = new List<double>(pillarIndexes.Count);
                for(int j = 0;j < pillarIndexes.Count; j++)
                {
                    double distance = 0;
                    for (int k = 0; k < data[0].Length; k++)
                    {
                        distance += Math.Pow((data[i][k] - data[pillarIndexes[j]][k]), 2);
                    } 
                    distances[i][j] = Math.Sqrt(distance);
                }
            }
            for(int i = 0;i < data.Length;i++)
            {
                clustersBelonging[i] = distances[i].IndexOf(distances[i].Min());
            }
            List<List<double>> competitiveSimilarityFunction = new List<List<double>>(pillarIndexes.Count);
            double[] cumulativeCompetitiveSimilarityFunction = new double[pillarIndexes.Count];
            for (int i = 0; i < competitiveSimilarityFunction.Count; i++)
            {
                var clusterBelonging = clustersBelonging
                            .Select((cb, index) => new { index, cluster = cb })
                            .Where(cb => cb.cluster == i)
                            .Select(cb => cb.index).ToList();
                competitiveSimilarityFunction[i] = new List<double>(clusterBelonging.Count);
                for(int j = 0; j < clusterBelonging.Count; j++)
                {
                    
                    for(int k = 0; k < clusterBelonging.Count; k++)
                    {
                        if (j != k)
                        {
                            double distance = 0;
                            for (int l = 0; l < data[0].Length; l++)
                            {
                                distance += Math.Pow((data[clusterBelonging[i]][l] - data[clusterBelonging[j]][l]), 2);
                            }
                            distance = Math.Sqrt(distance);
                            competitiveSimilarityFunction[i][j] += 1 - distance/(distance + distances[pillarIndexes[i]][clustersBelonging[j]]);
                        }
                        else
                        {
                            competitiveSimilarityFunction[i][j] += 1;
                        }
                    }
                    competitiveSimilarityFunction[i][j] /= clusterBelonging[i];                    
                }

                cumulativeCompetitiveSimilarityFunction[i] = competitiveSimilarityFunction[i].Sum();
            }
            throw new NotImplementedException();
        }
    }
}
