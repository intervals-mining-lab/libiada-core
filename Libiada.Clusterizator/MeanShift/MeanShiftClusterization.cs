
namespace Libiada.Clusterizator.MeanShift;

using Accord.MachineLearning;
using Accord.Statistics.Distributions.DensityKernels;

class MeanShiftClusterization : IClusterizator
{
    private readonly MeanShift meanShift;

    public MeanShiftClusterization(double bandwidth)
    {
        meanShift = new MeanShift(new UniformKernel(), bandwidth);
    }

    public int[] Cluster(int clustersCount, double[][] data)
    {
        var clusters = meanShift.Learn(data);
        var result = new int[data.Length];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = clusters.Decide(data[i]);
        }

        return result;
    }
}
