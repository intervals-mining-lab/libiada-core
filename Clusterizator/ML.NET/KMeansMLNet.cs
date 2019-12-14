using Clusterizator.ML.NET.Converter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clusterizator.ML.NET
{
    class KMeansMLNet : IClusterizator
    {
        private readonly Trainer trainer;
        public KMeansMLNet()
        {
            trainer = new Trainer();
            
        }
        public int[] Cluster(int clustersCount, double[][] data)
        {
            int[] clusters = new int[data.Length];
            var model = trainer.TrainModel(data, clustersCount, out var schema);
            var predictor = trainer._context.Model
                            .CreatePredictionEngine<ClusterizationData, ClusterPrediction>(model, inputSchemaDefinition: schema);
            var datas = Mapper.Convert(data);
            for (int i = 0; i < datas.Length; i++)
            { 
                var result = predictor.Predict(datas[i]);
                clusters[i] = (int)result.PredictedClusterId;
            }
            return clusters;
        }
    }
}


