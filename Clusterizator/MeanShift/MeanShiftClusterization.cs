
using Accord.Statistics.Distributions.DensityKernels;

namespace Clusterizator.MeanShift
{
    using Accord.MachineLearning;

    class MeanShiftClusterization : IClusterizator
    {
        private readonly MeanShift meanShift;

        public MeanShiftClusterization(int dimension, double bandwidth)
        {
            meanShift = new MeanShift(dimension, new UniformKernel(), bandwidth);
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
}
