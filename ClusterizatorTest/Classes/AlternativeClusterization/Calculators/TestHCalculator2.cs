using System;
using System.Collections.Specialized;
using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;
using System.Collections.Generic;
using Clusterizator.Classes.AlternativeClusterization.Calculators;

namespace ClusterizatorTest.Classes.AlternativeClusterization.Calculators
{
    [TestFixture]
    public class TestHCalculator2
    {
        private GraphManager manager;

        [SetUp]
        public void Init()
        {
            List<GraphElement> elements = new List<GraphElement>();
            List<Connection> connections = new List<Connection>();

            HybridDictionary hd1 = new HybridDictionary {{"y", 0}, {"x", 10}};
            HybridDictionary hd2 = new HybridDictionary {{"y", 2}, {"x", 15}};
            HybridDictionary hd3 = new HybridDictionary {{"y", 5}, {"x", 25}};
            HybridDictionary hd4 = new HybridDictionary {{"y", 6}, {"x", 15}};
            HybridDictionary hd5 = new HybridDictionary {{"y", 6}, {"x", 18}};


            elements.Add(new GraphElement(hd1, "1"));
            elements.Add(new GraphElement(hd2, "2"));
            elements.Add(new GraphElement(hd3, "3"));
            elements.Add(new GraphElement(hd4, "4"));
            elements.Add(new GraphElement(hd5, "5"));

            connections.Add(new Connection(0, 1));
            connections.Add(new Connection(0, 2));
            connections.Add(new Connection(0, 3));
            connections.Add(new Connection(0, 4));
            connections.Add(new Connection(1, 2));
            connections.Add(new Connection(1, 3));
            connections.Add(new Connection(1, 4));
            connections.Add(new Connection(2, 3));
            connections.Add(new Connection(2, 4));
            connections.Add(new Connection(3, 4));


            manager = new GraphManager(connections, elements);
        }

        //TODO: ����� ��� H
        [Test]
        public void Test4Points0()
        {
            manager.Connections[0].Connected = true;
            manager.Connections[1].Connected = false;
            manager.Connections[2].Connected = false;
            manager.Connections[3].Connected = false;
            manager.Connections[4].Connected = true;
            manager.Connections[5].Connected = false;
            manager.Connections[6].Connected = false;
            manager.Connections[7].Connected = true;
            manager.Connections[8].Connected = false;
            manager.Connections[9].Connected = false;
            
            manager.Elements[0].TaxonNumber = 1;
            manager.Elements[1].TaxonNumber = 1;
            manager.Elements[2].TaxonNumber = 1;
            manager.Elements[3].TaxonNumber = 1;
            manager.Elements[4].TaxonNumber = 2;

            double d = HCalculator.Calculate(manager);
            d = Math.Round(d*100)/100;
            Assert.AreEqual(0.64, d);
        }

           [Test]
           public void Test4Points1()
           {
               manager.Connections[0].Connected = true;
               manager.Connections[1].Connected = false;
               manager.Connections[2].Connected = false;
               manager.Connections[3].Connected = false;
               manager.Connections[4].Connected = false;
               manager.Connections[5].Connected = false;
               manager.Connections[6].Connected = false;
               manager.Connections[7].Connected = false;
               manager.Connections[8].Connected = false;
               manager.Connections[9].Connected = true;
            
               manager.Elements[0].TaxonNumber = 1;
               manager.Elements[1].TaxonNumber = 1;
               manager.Elements[2].TaxonNumber = 3;
               manager.Elements[3].TaxonNumber = 2;
               manager.Elements[4].TaxonNumber = 2;

               double d = HCalculator.Calculate(manager);
               d = Math.Round(d*100)/100;
               Assert.AreEqual(0.86, d);
         }

           [Test]
           public void Test4Points6()
           {
               manager.Connections[0].Connected = false;
               manager.Connections[1].Connected = false;
               manager.Connections[2].Connected = false;
               manager.Connections[3].Connected = false;
               manager.Connections[4].Connected = false;
               manager.Connections[5].Connected = false;
               manager.Elements[0].TaxonNumber = 1;
               manager.Elements[1].TaxonNumber = 2;
               manager.Elements[2].TaxonNumber = 3;
               manager.Elements[3].TaxonNumber = 4;
               Assert.AreEqual(1, HCalculator.Calculate(manager));
           }
    }
}