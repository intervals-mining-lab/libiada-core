namespace Libiada.Clusterizator.Krab;

using Clusterizator.Krab.Calculators;

/// <summary>
/// KRAB clusterization class.
/// </summary>
public class KrabClusterization : IClusterizator
{
    /// <summary>
    /// The power weight.
    /// </summary>
    private readonly double powerWeight;

    /// <summary>
    /// The normalized distance weight.
    /// </summary>
    private readonly double normalizedDistanceWeight;

    /// <summary>
    /// The distance weight.
    /// </summary>
    private readonly double distanceWeight;

    /// <summary>
    /// The manager.
    /// </summary>
    private GraphManager manager;

    /// <summary>
    /// The optimal divide.
    /// </summary>
    private GraphManager optimalDivide;

    /// <summary>
    /// The optimal f.
    /// </summary>
    private double optimalF;

    /// <summary>
    /// Initializes a new instance of the <see cref="KrabClusterization"/> class.
    /// </summary>
    /// <param name="powerWeight">
    /// The power weight.
    /// </param>
    /// <param name="normalizedDistanceWeight">
    /// The normalized distance weight.
    /// </param>
    /// <param name="distanceWeight">
    /// The distance weight.
    /// </param>
    public KrabClusterization(double powerWeight, double normalizedDistanceWeight, double distanceWeight)
    {
        this.powerWeight = powerWeight;
        this.normalizedDistanceWeight = normalizedDistanceWeight;
        this.distanceWeight = distanceWeight;
    }

    /// <summary>
    /// Clusterization method for given groups number.
    /// </summary>
    /// <param name="clustersCount">
    /// Groups count.
    /// </param>
    /// <param name="data">
    /// Characteristics values for every object.
    /// First dimension represents objects.
    /// Second Dimension represents characteristics.
    /// </param>
    /// <returns>
    /// Optimal clusterization as <see cref="ClusterizationVariants"/>.
    /// </returns>
    public int[] Cluster(int clustersCount, double[][] data)
    {
        // all connections (pairs of elements)
        var connections = new List<Connection>();

        // all elements
        var elements = new List<GraphElement>();

        for (int i = 0; i < data.Length; i++)
        {
            elements.Add(new GraphElement(data[i], i));
        }

        for (int j = 0; j < elements.Count - 1; j++)
        {
            for (int k = j + 1; k < elements.Count; k++)
            {
                connections.Add(new Connection(j, k));
            }
        }

        manager = new GraphManager(connections, elements);

        // calculating distances
        CommonCalculator.CalculateCharacteristic(manager, normalizedDistanceWeight, distanceWeight);
        manager.ConnectGraph();
        GraphManager tempManager = manager.Clone();
        ChooseDivision(clustersCount, 0, manager);
        var result = new int[data.Length];

        // extracting clusters from the graph
        for (int j = 0; j < optimalDivide.Elements.Count; j++)
        {
            result[j] = optimalDivide.Elements[j].TaxonNumber;
        }

        manager = tempManager;
        return result;
    }

    /// <summary>
    /// Recursive method for finding optimal division of graph into clusters (groups).
    /// </summary>
    /// <param name="clusters">
    /// Clusters left to separate.
    /// </param>
    /// <param name="position">
    /// Starting position for iteration.
    /// </param>
    /// <param name="currentManager">
    /// Graph and its manager.
    /// </param>
    private void ChooseDivision(int clusters, int position, GraphManager currentManager)
    {
        // if recursive calls are required
        if (clusters > 1)
        {
            for (int i = position; i < (manager.Connections.Count - clusters); i++)
            {
                // creatingcopy of graph to be able to disconnect pair of nodes (cut the link)
                GraphManager tempManager = currentManager.Clone();
                if (tempManager.Connections[i].Connected)
                {
                    tempManager.Cut(tempManager.Connections[i]);
                    ChooseDivision(clusters - 1, i + 1, tempManager);
                }
            }
        }
        else
        {
            // calculating clusterization quality
            double f = QualityCalculator.Calculate(currentManager, manager, powerWeight);
            if (f > optimalF)
            {
                // saving optimal clusterization
                optimalDivide = currentManager;
                optimalF = f;
            }
        }
    }
}
