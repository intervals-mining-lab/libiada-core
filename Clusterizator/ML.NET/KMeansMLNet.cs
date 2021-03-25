namespace Clusterizator.ML.NET
{
    using Clusterizator.ML.NET.Converter;

    public class KMeansMLNet : IClusterizator
    {
        public int[] Cluster(int clustersCount, double[][] data)
        {
            Trainer trainer = new Trainer();

            int[] clusters = new int[data.Length];
            var model = trainer.TrainModel(data, clustersCount, out var schema);
            var predictor = trainer.context.Model
                            .CreatePredictionEngine<ClusterizationData, ClusterPrediction>(model, inputSchemaDefinition: schema);
            var clustrizationData = Mapper.Convert(data);
            
            for (int i = 0; i < clustrizationData.Length; i++)
            {
                var result = predictor.Predict(clustrizationData[i]);
                clusters[i] = (int)result.PredictedClusterId;
            }

            return clusters;
        }
    }
}


