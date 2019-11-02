using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clusterizator.ML
{
    public class Trainer
    {
        public MLContext _context { get; set; }
        
        public Trainer()
        {
            _context = new MLContext();
        }
        public TransformerChain<ClusteringPredictionTransformer<KMeansModelParameters>> TrainModel(ChainData[] inputData , out SchemaDefinition schema)
        {
            var featureDimension = inputData[0].Characteristics.Length;
            var definedSchema = SchemaDefinition.Create(typeof(ChainData));
            definedSchema[0].ColumnType = new VectorDataViewType
                (((VectorDataViewType)definedSchema[0].ColumnType).ItemType,
                featureDimension);
            var dataView = _context.Data.LoadFromEnumerable(inputData, definedSchema);
            var pipeline = _context.Transforms.Concatenate("Feautures", "Characteristics")
                                    .Append(_context.Clustering.Trainers.KMeans("Characteristics", numberOfClusters: 2));
            var model = pipeline.Fit(dataView);
            schema = definedSchema;
            return model;
        }
    }
}
