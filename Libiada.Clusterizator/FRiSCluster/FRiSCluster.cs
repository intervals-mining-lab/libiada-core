﻿namespace Libiada.Clusterizator.FRiSCluster;

using Clusterizator.Exceptions;

/// <summary>
/// The clusterization using Competitive Similarity Function.
/// </summary>
public class FRiSCluster : IClusterizator
{
    /// <summary>
    /// The minimum clusters number.
    /// </summary>
    private readonly int minimumClusters;

    /// <summary>
    /// The maximum clusters number.
    /// </summary>
    private readonly int maximumClusters;

    /// <summary>
    /// The distances between all data points.
    /// </summary>
    private double[,] distances;

    /// <summary>
    /// The data points.
    /// </summary>
    private double[][] data;

    /// <summary>
    /// Initializes a new instance of the <see cref="FRiSCluster"/> class.
    /// </summary>
    /// <param name="minimumClusters">
    /// The minimum clusters number.
    /// </param>
    /// <param name="maximumClusters">
    /// The maximum clusters number.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown if minimum clusters number is greater than maximum clusters number.
    /// </exception>
    public FRiSCluster(int minimumClusters, int maximumClusters)
    {
        if (minimumClusters > maximumClusters)
        {
            throw new ArgumentException("Minimum number of clusters can't be greater then maxim number of clusters");
        }

        this.minimumClusters = minimumClusters;
        this.maximumClusters = maximumClusters;
    }

    /// <summary>
    /// Groups points into simple clusters using Competitive Similarity Function.
    /// </summary>
    /// <param name="clustersCount">
    /// The clusters count.
    /// </param>
    /// <param name="data">
    /// The data pints.
    /// </param>
    /// <returns>
    /// The cluster number for each data point as <see cref="T:int[]"/>.
    /// </returns>
    public int[] Cluster(int clustersCount, double[][] data)
    {
        this.data = data;

        double rStar = 1;

        //distances[i][j] - distance from i-th element to j-th
        CalculateDistances();

        // average competitive similarity in comparison to virtual sample (set) B
        double[] averageSimilarityFunction = new double[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            double localSimilarity = 0;

            for (int j = 0; j < data.Length; j++)
            {
                localSimilarity += CalculateSimilarityFunction(distances[i, j], rStar);
            }
            averageSimilarityFunction[i] = localSimilarity / data.Length;
        }

        int[] optimalClustersBelonging = Cluster(averageSimilarityFunction);

        return optimalClustersBelonging;
    }

    private int[] Cluster(double[] averageSimilarityFunction)
    {
        // maximum of average similarity in competition with sample (set) B
        List<int> currentPillarIndexes = [];
        double maxSimilarity = averageSimilarityFunction.Max();
        currentPillarIndexes.Add(Array.IndexOf(averageSimilarityFunction, maxSimilarity));

        double currentCompactness = double.MinValue;
        double optimalCompactness = double.MinValue;
        int[] optimalClustersBelonging = null;

        while (currentPillarIndexes.Count < maximumClusters)
        {
            int[] currentClustersBelonging = AddPillar(currentPillarIndexes);
            //bool pillarsNotEqual = true;
            //while (pillarsNotEqual)
            //{
            List<int> tempPillarIndexes = new(currentPillarIndexes);
                for (int j = 0; j < currentPillarIndexes.Count; j++)
                {
                    (currentPillarIndexes[j], currentCompactness) = ReselectPillar(
                        currentPillarIndexes[j],
                        currentPillarIndexes,
                        currentClustersBelonging);
                }

                // updating data points references to new pillars
                currentClustersBelonging = DetermineClusters(currentPillarIndexes);
            //    pillarsNotEqual = false;
            //    for (int i = 0; i < currentPillarIndexes.Count; i++)
            //    {
            //        if (currentPillarIndexes[i] != tempPillarIndexes[i])
            //        {
            //            pillarsNotEqual = true;
            //            break;
            //        }
            //    }
            //}

            if (currentPillarIndexes.Count == minimumClusters)
            {
                optimalCompactness = currentCompactness;
                optimalClustersBelonging = (int[])currentClustersBelonging.Clone();
            }

            if (currentPillarIndexes.Count > minimumClusters && currentCompactness > optimalCompactness)
            {
                optimalCompactness = currentCompactness;
                optimalClustersBelonging = (int[])currentClustersBelonging.Clone();
            }
        }

        if (optimalClustersBelonging == null)
        {
            throw new ClusterizationFailureException("Failed to conduct clusterization");
        }

        return optimalClustersBelonging;
    }

    /// <summary>
    /// Adds new pillar using max compactness.
    /// </summary>
    /// <param name="currentPillarIndexes">
    /// The current pillar indexes.
    /// </param>
    /// <returns>
    /// The <see cref="T:int[]"/>.
    /// </returns>
    private int[] AddPillar(List<int> currentPillarIndexes)
    {
        int maxCompactnessIndex = CalculateCompactnessForPotentialPillars(currentPillarIndexes);
        currentPillarIndexes.Add(maxCompactnessIndex);
        return DetermineClusters(currentPillarIndexes);
    }

    /// <summary>
    /// Reselects pillar inside cluster to provide max compactness.
    /// </summary>
    /// <param name="pillarIndex">
    /// Index of the pillar to reselect.
    /// </param>
    /// <param name="pillarIndexes">
    /// The pillar indexes.
    /// </param>
    /// <param name="clustersBelonging">
    /// Information on belongings of all data points to clusters.
    /// </param>
    /// <returns>
    /// The <see cref="(int, double)"/>.
    /// </returns>
    private (int clusterPointsIndex, double compactness) ReselectPillar(int pillarIndex, List<int> pillarIndexes, int[] clustersBelonging)
    {
        int[] clusterPointsIndexes = data.Select((d, i) => i).Where(i => clustersBelonging[i] == pillarIndexes.IndexOf(pillarIndex)).ToArray();
        double[] clusterCompactness = new double[clusterPointsIndexes.Length];

        for (int i = 0; i < clusterPointsIndexes.Length; i++)
        {
            clusterCompactness[i] = 0;

            for (int j = 0; j < clusterPointsIndexes.Length; j++)
            {
                clusterCompactness[i] += CalculateSimilarityFunction(distances[i, j], DistanceToNearestCompetitivePillar(pillarIndexes, j, pillarIndex));
            }
            for (int k = 0; k < pillarIndexes.Count; k++)
            {
                if (pillarIndexes[k] != pillarIndex)
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

    /// <summary>
    /// Finds data point with max compactness as new pillar.
    /// Tries all data points as possible new pillar
    /// and selects one with maximum compactness.
    /// </summary>
    /// <param name="pillarIndexes">
    /// List of hypothetical pillars
    /// (not necessary the actual ones).
    /// </param>
    /// <returns>
    /// The index of new pillar as <see cref="int"/>.
    /// </returns>
    private int CalculateCompactnessForPotentialPillars(List<int> pillarIndexes)
    {
        double[] compactness = new double[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            if (!pillarIndexes.Contains(i))
            {
                List<int> tempPillarIndexes = new(pillarIndexes) { i };
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

    /// <summary>
    /// Calculates distances for all possible pairs of data points.
    /// </summary>
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

    /// <summary>
    /// Calculates similarity function for given pair of distances.
    /// </summary>
    /// <param name="r1">
    /// The distance to the own pillar.
    /// </param>
    /// <param name="r2">
    /// The distance to the nearest competitor pillar.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    private double CalculateSimilarityFunction(double r1, double r2) => 1 - r1 / (r1 + r2);

    /// <summary>
    /// Distributes data pints into clusters.
    /// Determines pillars to which each data point belongs.
    /// </summary>
    /// <param name="pillarIndexes">
    /// The pillars indexes.
    /// </param>
    /// <returns>
    /// The index of cluster for each data point as <see cref="T:int[]"/>.
    /// </returns>
    private int[] DetermineClusters(List<int> pillarIndexes)
    {
        int[] clustersBelonging = new int[distances.GetLength(0)];

        for (int i = 0; i < clustersBelonging.Length; i++)
        {
            int clusterNumber = 0;

            for (int j = 1; j < pillarIndexes.Count; j++)
            {
                if (distances[pillarIndexes[j], i] < distances[pillarIndexes[clusterNumber], i])
                {
                    clusterNumber = j;
                }
            }
            clustersBelonging[i] = clusterNumber;
        }
        return clustersBelonging;
    }

    /// <summary>
    /// Calculates compactness measure for given set of pillars.
    /// </summary>
    /// <param name="clustersBelonging">
    /// The clusters belonging.
    /// </param>
    /// <param name="pillarIndex">
    /// The pillar index.
    /// </param>
    /// <param name="pillarIndexes">
    /// The pillar indexes.
    /// </param>
    /// <returns>
    /// The compactness as <see cref="double"/>.
    /// </returns>
    private double CalculateCompactness(int[] clustersBelonging, int pillarIndex, List<int> pillarIndexes)
    {
        double compactness = 0;

        for (int j = 0; j < data.Length; j++)
        {
            if (clustersBelonging[j] == pillarIndexes.IndexOf(pillarIndex))
            {
                compactness += CalculateSimilarityFunction(distances[pillarIndex, j], DistanceToNearestCompetitivePillar(pillarIndexes, j, pillarIndex));
            }
        }
        return compactness;
    }

    /// <summary>
    /// Calculates distance to nearest competitive pillar for given data point.
    /// </summary>
    /// <param name="pillarIndexes">
    /// The pillar indexes.
    /// </param>
    /// <param name="pointIndex">
    /// The point index.
    /// </param>
    /// <param name="pillarIndex">
    /// Index of data point's pillar.
    /// </param>
    /// <returns>
    /// The distance to nearest competitive pillar as <see cref="double"/>.
    /// </returns>
    private double DistanceToNearestCompetitivePillar(List<int> pillarIndexes, int pointIndex, int pillarIndex)
    {
        List<double> nearestPillarDistance = [];

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