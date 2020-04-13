namespace Clusterizator.AffinityPropagation
{
    internal class APClusteringData
    {
        public double[][] SimilarityMatrix { get; set; }
        public double[][] AvailabilityMatrix { get; set; }
        public double[][] ResponsibilityMatrix { get; set; }
        public double[][] Combined { get; set; }
        public int IterationCount { get; set; }
        public double Lambda { get; set; }

        private readonly int matrixLength;

        public APClusteringData(double[][] matrix, int iterationCount = 250, double lambda = 0.9)
        {
            SimilarityMatrix = matrix;
            matrixLength = matrix.GetLength(0);
            AvailabilityMatrix = new double[matrixLength][];
            ResponsibilityMatrix = new double[matrixLength][];
            Combined = new double[matrixLength][];
            IterationCount = iterationCount;
            Lambda = lambda;
            for (int i = 0; i < matrixLength; i++)
            {
                AvailabilityMatrix[i] = new double[matrixLength];
                ResponsibilityMatrix[i] = new double[matrixLength];
                Combined[i] = new double[matrixLength];
            }
        }

        public void SetResponsibility(int indexA, int indexB)
        {
            double responsibility, previous = ResponsibilityMatrix[indexA][indexB];
            double current, max = double.MinValue;
            for (int i = 0; i < matrixLength; i++)
            {
                if (i != indexB)
                {
                    current = AvailabilityMatrix[indexA][i] + SimilarityMatrix[indexA][i];
                    if (current > max)
                    {
                        max = current;
                    }
                }
            }

            responsibility = SimilarityMatrix[indexA][indexB] - max;
            responsibility = Lambda * previous + (1 - Lambda) * responsibility;
            ResponsibilityMatrix[indexA][indexB] = responsibility;
        }
        public void SetAvailability(int indexA, int indexB)
        {
            double availability = AvailabilityMatrix[indexA][indexB];
            double current = AvailabilityMatrix[indexA][indexB];
            double previous = AvailabilityMatrix[indexA][indexB];
            double sum = 0;
            for (int i = 0; i < matrixLength; i++)
            {
                if (i != indexA && i != indexB)
                {
                    current = ResponsibilityMatrix[i][indexB];
                    if (current < 0)
                    {
                        current = 0.0;
                    }

                    sum += current;
                }
            }
            availability = sum;
            if (indexA != indexB)
            {
                availability = ResponsibilityMatrix[indexB][indexB];
                if (availability > 0)
                {
                    availability = 0.0;
                }
            }
            AvailabilityMatrix[indexA][indexB] = Lambda * previous + (1 - Lambda) * availability;
        }
        public void UpdateAvailibility()
        {
            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    SetAvailability(i, j);
                }
            }
        }

        public void UpdateResponsibility()
        {
            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    SetResponsibility(i, j);
                }
            }
        }
        public void UpdateCombined()
        {
            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    Combined[i][j] = AvailabilityMatrix[i][j] + ResponsibilityMatrix[i][j];
                }
            }
        }

        public int[] FindExamplars()
        {
            var result = new int[matrixLength];
            double max = double.MinValue;
            for (int i = 0; i < matrixLength; i++)
            {
                if (Combined[i][i] > max)
                {
                    max = Combined[i][i];
                    result[i] = i;
                }
            }
            return result;
        }
    }
}
