namespace Clusterizator.FRiSCluster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FRiSCluster : IClusterizator
    {
        private readonly int minimumClusters;
        private readonly int maximumClusters;

        public FRiSCluster(int minimumClusters, int maximumClusters)
        {
            if (minimumClusters > maximumClusters)
            {
                throw new ArgumentException("Minimum number of clusters can't be greater then maxim number of clusters");
            }

            this.minimumClusters = minimumClusters;
            this.maximumClusters = maximumClusters;
        }

        public int[] Cluster(int clustersCount, double[][] data)
        {
            double rStar = 1;
            var distances = DistanceCalculator(data);

            //var similarityFunction = new double[data.Length, data.Length];
            var averageSimilarityFunction = new double[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                double localSimilarity = 0;
                for (int j = 0; j < data.Length; j++)
                {
                    localSimilarity += SimilarityFunctionCalculator(distances[i][j], rStar);
                }
                averageSimilarityFunction[i] = localSimilarity / data.Length;
            }

            var pillarIndexes = new List<int>();
            var maxSimilarity = averageSimilarityFunction.Max();
            pillarIndexes.Add(Array.IndexOf(averageSimilarityFunction, maxSimilarity));

            for (int i = 0; i < data.Length; i++)
            {
                if (i != pillarIndexes[0])
                {
                    pillarIndexes.Add(i);
                    //double 
                    for (int j = 0; j < data.Length; j++)
                    {

                    }
                }
            }
                /*pillarIndexes.Add(Array.IndexOf(averageSimilarityFunction, averageSimilarityFunction.Max(x => x < maxSimilarity)));

                var clustersBelonging = new int[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    distances[i] = new List<double>(pillarIndexes.Count);
                    for (int j = 0; j < pillarIndexes.Count; j++)
                    {
                        double distance = 0;
                        for (int k = 0; k < data[0].Length; k++)
                        {
                            distance += Math.Pow((data[i][k] - data[pillarIndexes[j]][k]), 2);
                        }
                        distances[i][j] = Math.Sqrt(distance);
                    }
                }

                for (int i = 0; i < data.Length; i++)
                {
                    clustersBelonging[i] = distances[i].IndexOf(distances[i].Min());
                }

                var competitiveSimilarityFunction = new List<List<double>>(pillarIndexes.Count);
                var cumulativeCompetitiveSimilarityFunction = new double[pillarIndexes.Count];
                for (int i = 0; i < competitiveSimilarityFunction.Count; i++)
                {
                    List<int> clusterBelonging = clustersBelonging
                                .Select((cb, index) => new { index, cluster = cb })
                                .Where(cb => cb.cluster == i)
                                .Select(cb => cb.index).ToList();
                    competitiveSimilarityFunction[i] = new List<double>(clusterBelonging.Count);
                    for (int j = 0; j < clusterBelonging.Count; j++)
                    {

                        for (int k = 0; k < clusterBelonging.Count; k++)
                        {
                            if (j != k)
                            {
                                double distance = 0;
                                for (int l = 0; l < data[0].Length; l++)
                                {
                                    distance += Math.Pow(data[clusterBelonging[i]][l] - data[clusterBelonging[j]][l], 2);
                                }

                                distance = Math.Sqrt(distance);
                                competitiveSimilarityFunction[i][j] += 1 - distance / (distance + distances[pillarIndexes[i]][clustersBelonging[j]]);
                            }
                            else
                            {
                                competitiveSimilarityFunction[i][j] += 1;
                            }
                        }

                        competitiveSimilarityFunction[i][j] /= clusterBelonging[i];
                    }

                    cumulativeCompetitiveSimilarityFunction[i] = competitiveSimilarityFunction[i].Sum();
                }*/

                throw new NotImplementedException();
        }

        private List<double>[] DistanceCalculator(double[][] data)
        {
            var distances = new List<double>[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    double distance = 0;
                    for (int k = 0; k < data[0].Length; k++)
                    {                        
                        distance += Math.Pow(data[i][k] - data[j][k], 2);
                    }
                    distances[i][j] = Math.Sqrt(distance);
                }
            }

            return distances;
        }

        private double SimilarityFunctionCalculator(double r1, double r2)
        {
            double result = 0;
            result = 1 - r1 / (r1 + r2);
            return result;
        }
    }
}
