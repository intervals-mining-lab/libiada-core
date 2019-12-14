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
                                     new double[] { 1.4172016973019848, 0.6992092204815338, 0.5162038850842143},
                                     new double[] { 1.4171502875265674, 0.6992873437232361, 0.5160427005430666},
                                     new double[] { 1.4136924686420713, 0.6954713046535896, 0.5239371049049106},
                                     new double[] { 1.4116484125411888, 0.70239838858253897, 0.5096385597900692},
                                     new double[] { 1.4213810408458798, 0.7009374196700805, 0.5126424500264222},
                                     new double[] { 1.4230906932945087, 0.7021720704345712, 0.5101034821020338},
                                     new double[] { 1.4218866452469887, 0.7030272402138218, 0.508347504366198},
                                     new double[] { 1.433343959132218, 0.719054042978188, 0.47582788944310295},
                                     new double[] { 1.458538400697937, 0.7274330673337907, 0.45911358620387155},
                                     new double[] { 1.428755465879403, 0.7179142437042983, 0.47811657336208735},
                                     new double[] { 1.4495156341861233, 0.7307731163758003, 0.4525045336979774},
                                     new double[] { 1.432045835503624, 0.7319855400511525, 0.4501129456984594},
                                     new double[] { 1.4630872253570406, 0.7352564289510857, 0.44368060105173246},
                                   };
        }
        [Test]
        public void Test()
        {
            var ml = new Trainer();
            var model = ml.TrainModel(_data, 2, out SchemaDefinition schema);
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
