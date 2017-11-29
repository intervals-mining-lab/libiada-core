namespace Clusterizator.FRiSCluster
{
    using Clusterizator.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FRiSCluster : IClusterizator
    {
        private readonly int minimumClusters;
        private readonly int maximumClusters;
        private double[,] distances;

        private double[][] data;

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
            this.data = data;
            double rStar = 1;
            //var compactness = new Dictionary<int,double>();
            //var pillarIndexes = new Dictionary<int,List<int>>();//столпы
            //var clustersBelonging = new Dictionary<int, int[]>();
            double optimalCompactness = double.MinValue;
            List<int> optimalPillarIndexes = new List<int>();
            int[] optimalClustersBelonging = null;
            double currentCompactness = double.MinValue;
            List<int> currentPillarIndexes = new List<int>();
            int[] currentClustersBelonging = new int[data.Length];
            CalculateDistances();//distances[i][j] - дистанция от i-го объекта до j-го

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

            double maxSimilarity = averageSimilarityFunction.Max();//максимум средней сходимости элементов в конкуренции с B
            currentPillarIndexes.Add(Array.IndexOf(averageSimilarityFunction, maxSimilarity));

            while(currentPillarIndexes.Count < maximumClusters)
            {
                int maxCompactnessIndex = CalculateCompactnessForPotentialPillars(currentPillarIndexes);
                currentPillarIndexes.Add(maxCompactnessIndex);
                currentClustersBelonging = DetermineClusters(currentPillarIndexes);

                for (int j = 0; j < currentPillarIndexes.Count; j++)
                {
                    (currentPillarIndexes[j], currentCompactness) = ReselectPillar(currentPillarIndexes[j], currentPillarIndexes, currentClustersBelonging);
                }
                currentClustersBelonging = DetermineClusters(currentPillarIndexes);
                if (currentPillarIndexes.Count == minimumClusters)
                {
                    optimalCompactness = currentCompactness;
                    optimalClustersBelonging = (int[])currentClustersBelonging.Clone();
                    optimalPillarIndexes = new List<int>(currentPillarIndexes);
                }
                if(currentPillarIndexes.Count > minimumClusters && currentCompactness > optimalCompactness && currentPillarIndexes.Count <= maximumClusters )
                {
                    optimalCompactness = currentCompactness;
                    optimalClustersBelonging = (int[])currentClustersBelonging.Clone();
                    optimalPillarIndexes = new List<int>(currentPillarIndexes);
                }
            }
            for(int i = 0; i < optimalClustersBelonging.Length; i++)
            {
                optimalClustersBelonging[i] = optimalPillarIndexes.IndexOf(optimalClustersBelonging[i]);
                optimalClustersBelonging[i]++;
            }
            if (optimalClustersBelonging == null)
            {
                throw new ClusterizationFailureException("Failed to conduct clusterization");
            }
            return optimalClustersBelonging;
        }

        private (int, double) ReselectPillar(int pillarIndex, List<int> pillarIndexes, int[] clustersBelonging)
        {
            int[] clusterPointsIndexes = data.Select((d, i) => i).Where(i => clustersBelonging[i] == pillarIndex).ToArray();
            var clusterCompactness = new double[clusterPointsIndexes.Length];
            for (int i = 0; i < clusterPointsIndexes.Length; i++)
            {
                clusterCompactness[i] = 0;

                for (int j = 0; j < clusterPointsIndexes.Length; j++)
                {
                    clusterCompactness[i] += CalculateSimilarityFunction(distances[i, j], DistanceToNearestCompetitivePillar(pillarIndexes, j, pillarIndex));
                }
                for(int k = 0; k < pillarIndexes.Count; k++)
                {
                    if(pillarIndexes[k] != pillarIndex)
                    {
                        clusterCompactness[i] += CalculateCompactness(clustersBelonging, pillarIndexes[k], pillarIndexes);
                    }
                }
                clusterCompactness[i] /= data.Length;
            }
            double maxCompactness = clusterCompactness.Max();
            int clusterPillarIndex = Array.IndexOf(clusterCompactness, maxCompactness);
            return (clusterPointsIndexes[clusterPillarIndex], maxCompactness);
        }

        private int CalculateCompactnessForPotentialPillars(List<int> pillarIndexes)
        {
            var compactness = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                if (!pillarIndexes.Contains(i))
                {
                    var tempPillarIndexes = new List<int>(pillarIndexes) { i };
                    int[] clustersBelonging = DetermineClusters(tempPillarIndexes);
                    compactness[i] = CalculateCompactness(clustersBelonging, i, tempPillarIndexes);
                    for (int j = 0; j < pillarIndexes.Count; j++)
                    {
                        compactness[i] += CalculateCompactness(clustersBelonging, pillarIndexes[j], tempPillarIndexes);
                    }
                    compactness[i] /= data.Length;
                }
            }

            return Array.IndexOf(compactness, compactness.Max());
        }

        private void CalculateDistances()
        {
            distances = new double[data.Length, data.Length];

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
        }

        private double CalculateSimilarityFunction(double r1, double r2) => 1 - r1 / (r1 + r2);

        private int[] DetermineClusters(List<int> pillarIndexes)
        {
            var clustersBelonging = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                var clusterNumber = pillarIndexes[0];
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

        private double CalculateCompactness(int[] clustersBelonging, int pillarIndex, List<int> pillarIndexes)
        {
            double compactness = 0;
            for (int j = 0; j < data.Length; j++)
            {
                if (clustersBelonging[j] == pillarIndex)
                {
                    compactness += CalculateSimilarityFunction(distances[pillarIndex, j], DistanceToNearestCompetitivePillar(pillarIndexes, j, pillarIndex));
                }
            }
            return compactness;
        }

        private double DistanceToNearestCompetitivePillar(List<int> pillarIndexes, int pointIndex, int pillarIndex)
        {
            var nearestPillarDistance = new List<double>();
            for (int k = 0; k < pillarIndexes.Count; k++)
            {
                if (pillarIndexes[k] != pillarIndex)
                {
                    nearestPillarDistance.Add(distances[pointIndex, pillarIndexes[k]]);
                }
            }

            return nearestPillarDistance.Min();
        }
    }
}
