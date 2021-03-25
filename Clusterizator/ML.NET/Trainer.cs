namespace Clusterizator.ML
{
    using Clusterizator.ML.NET.Converter;

    using Microsoft.ML;
    using Microsoft.ML.Data;
    using Microsoft.ML.Trainers;

    public class Trainer
    {
        public MLContext context { get; private set; }
        
        public Trainer()
        {
            context = new MLContext();
        }

        public TransformerChain<ClusteringPredictionTransformer<KMeansModelParameters>> TrainModel(double[][] inputData,int clustersCount, out SchemaDefinition schema)
        {
            var data = Mapper.Convert(inputData);
            var featureDimension = data[0].Characteristics.Length;
            var definedSchema = SchemaDefinition.Create(typeof(ClusterizationData));
            definedSchema[0].ColumnType = new VectorDataViewType
                (((VectorDataViewType)definedSchema[0].ColumnType).ItemType,
                featureDimension);
            var dataView = context.Data.LoadFromEnumerable(data, definedSchema);
            var pipeline = context.Transforms.Concatenate("Feautures", "Characteristics")
                                    .Append(context.Clustering.Trainers.KMeans("Characteristics", numberOfClusters: clustersCount));
            var model = pipeline.Fit(dataView);
            schema = definedSchema;
            return model;
        }
    }
}
