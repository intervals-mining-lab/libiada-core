using Clusterizator.ML;
using Microsoft.ML.Data;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Clusterizator.Tests.ML
{
    [TestFixture(Category = "Unit", TestOf = typeof(Trainer))]
    public class TrainerTests
    {
        private ChainData[] _data;
        [SetUp]
        public void SetUp()
        {
            _data = new[] { new ChainData { Characteristics = new float[] { 3,4} },
                            new ChainData { Characteristics = new float[] { 4,4} },
                            new ChainData { Characteristics = new float[] { 5,4} },
                            new ChainData { Characteristics = new float[] { 8,7} },
                            new ChainData { Characteristics = new float[] { 7,7} },
                            new ChainData { Characteristics = new float[] { 8,9} },
                          };
        }
        [Test]
        public void Test()
        {
            var ml = new Trainer();
            var model = ml.TrainModel(_data, out SchemaDefinition schema);
            var predictor = ml._context.Model.CreatePredictionEngine<ChainData, ClusterPrediction>(model, inputSchemaDefinition:schema);
            foreach(var point in _data)
            {
                var prediction = predictor.Predict(point);
                Debug.WriteLine($"Cluster: {prediction.PredictedClusterId}");
                Debug.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");
            }
            
        }

    }
}
