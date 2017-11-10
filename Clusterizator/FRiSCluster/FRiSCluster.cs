namespace Clusterizator.FRiSCluster
{
    using LibiadaCore.Extensions;
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
            var distances = CalculateDistance(data);//distances[i][j] - дистанция от i-го объекта до j-го

            //var similarityFunction = new double[data.Length, data.Length];
            var averageSimilarityFunction = new double[data.Length];// значения средней формулы сходимости объектов множества в конкуренции с виртуальным множеством B

            for (int i = 0; i < data.Length; i++)
            {
                double localSimilarity = 0;
                for (int j = 0; j < data.Length; j++)
                {
                    localSimilarity += CalculateSimilarityFunction(distances[i, j], rStar);
                }
                averageSimilarityFunction[i] = localSimilarity / data.Length;
            }

            var pillarIndexes = new List<int>();//столпы
            var maxSimilarity = averageSimilarityFunction.Max();//максимум средней сходимости элементов в конкуренции с B
            pillarIndexes.Add(Array.IndexOf(averageSimilarityFunction, maxSimilarity));

            var clustersBelonging = new int[data.Length];//clusterBelonging[i] принадлежность ко столпу i-го элемента
            var compacts = new double[data.Length][];//суммы мер сходств аналогичная компактности
            for (int i = 0; i < data.Length; i++)
            {
                compacts[i] = new double[data.Length];
            }

            for (int i = 0; i < data.Length; i++)
            {
                if (i != pillarIndexes[0])
                {
                    pillarIndexes.Add(i);
                    clustersBelonging = DetermentClusters(pillarIndexes, distances);
                    compacts[1][i] = 0;
                    for(int j = 0; j < distances.Length; j++)
                    {
                        if(clustersBelonging[j] == pillarIndexes[1])
                        {
                            compacts[1][i] += CalculateSimilarityFunction(distances[pillarIndexes[1], j], distances[pillarIndexes[0], j]);
                        }
                    }
                }
            }
            pillarIndexes[1] = Array.IndexOf(compacts[1], compacts[1].Max());
            clustersBelonging = DetermentClusters(pillarIndexes, distances);
            for (int i = 0; i < data.Length; i++)
            {

            }


                /*pillarIndexes.Add(Array.IndexOf(averageSimilarityFunction, averageSimilarityFunction.Max(x => x < maxSimilarity)));

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

        private double[,] CalculateDistance(double[][] data)
        {
            var distances = new double[data.Length, data.Length];
            
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    double distance = 0;
                    for (int k = 0; k < data[0].Length; k++)
                    {                        
                        distance += Math.Pow(data[i][k] - data[j][k], 2);
                    }
                    distances[i, j] = Math.Sqrt(distance);
                }
            }
            return distances;
        }

        private double CalculateSimilarityFunction(double r1, double r2) => 1 - r1 / (r1 + r2);

        private int[] DetermentClusters(List<int> pillarIndexes, double[,] distances)
        {
            var clustersBelonging = new int[distances.Length];
            for (int i = 0; i < distances.Length; i++)
            {
                var clusterNumber = 0;
                for (int j = 1; j < pillarIndexes.Count; j++)
                {
                    if (distances[pillarIndexes[j], i] < distances[clusterNumber, i])
                    {
                        clusterNumber = pillarIndexes[j];
                    }
                }
                clustersBelonging[i] = clusterNumber;
            }
            return clustersBelonging;
        }
    }
}
