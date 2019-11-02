using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clusterizator.ML
{
    public class ClusterPrediction
    {
        [ColumnName("PredictedLabel")]
        public uint PredictedClusterId;

        [ColumnName("Score")]
        public float[] Distances;
    }
}
