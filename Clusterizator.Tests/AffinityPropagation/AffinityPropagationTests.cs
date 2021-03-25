using NUnit.Framework;
using System.Diagnostics;

namespace Clusterizator.Tests.AffinityPropagation
{
    [TestFixture(Category = "Unit", TestOf = typeof(Clusterizator.AffinityPropagation.AffinityPropagation))]
    class AffinityPropagationTests
    {
        private double[][] data;
        [SetUp]
        public void SetUp()
        {
            data = new double[][] {
                                     new double[] { 1.4172016973019848, 0.6992092204815338, 0.5162038850842143},
                                     new double[] { 1.4171502875265674, 0.6992873437232361, 0.5160427005430666},
                                     new double[] { 1.4136924686420713, 0.6954713046535896, 0.5239371049049106},
                                   };
        }

        // TODO: wright real tests!
        [Test]
        public void Test()
        {
            var clusterization = new Clusterizator.AffinityPropagation.AffinityPropagation();
            var result = clusterization.Cluster(0, data);
            foreach(var res in result)
            {
                Debug.WriteLine(res);
            }
            
        }
    }
}
