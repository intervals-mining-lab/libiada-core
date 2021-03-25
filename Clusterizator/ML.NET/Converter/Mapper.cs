namespace Clusterizator.ML.NET.Converter
{
    public class Mapper
    {
        public static ClusterizationData[] Convert(double[][] data)
        {
            var clusterizationData = new ClusterizationData[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                clusterizationData[i] = new ClusterizationData()
                                            {
                                                Characteristics = ToFloatArray(data[i])
                                            };
            }

            return clusterizationData;
        }

        private static float[] ToFloatArray(double[] source)
        {
            float[] result = new float[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = (float)source[i];
            }

            return result;
        }
    }
}
