using Clusterizator.ML;
using Clusterizator.ML.NET.Converter;
using Microsoft.ML.Data;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Clusterizator.Tests.ML
{
    [TestFixture(Category = "Unit", TestOf = typeof(Trainer))]
    public class TrainerTests
    {
        private double[][] _data;
        [SetUp]
        public void SetUp()
        {
            _data = new double[][] { 
                                     new double[] { 3, 4},
                                     new double[] { 4,4},
                                     new double[] { 5,4},
                                     new double[] { 8,7},
                                     new double[] { 7,7},
                                     new double[] { 8,9},
                                   };
        }
        [Test]
        public void Test()
        {
            var ml = new Trainer();
            var model = ml.TrainModel(_data, out SchemaDefinition schema);
            var predictor = ml._context.Model.CreatePredictionEngine<ClusterizationData, ClusterPrediction>(model, inputSchemaDefinition:schema);
            var data = Mapper.Convert(_data);
            foreach(var point in data)
            {
                var prediction = predictor.Predict(point);
                Debug.WriteLine($"Cluster: {prediction.PredictedClusterId}");
                Debug.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");
            }
            
        }

    }
}
