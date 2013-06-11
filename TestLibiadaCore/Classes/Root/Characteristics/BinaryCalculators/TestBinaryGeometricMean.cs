using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class TestBinaryGeometricMean
    {
        [Test]
        public void TestSpatialDependence()
        {
            BinaryGeometricMean calculator = new BinaryGeometricMean();
            Chain chain = new Chain(10);

            ValueChar messageA = new ValueChar('a');
            ValueChar messageC = new ValueChar('c');
            ValueChar messageG = new ValueChar('g');
            ValueChar messageT = new ValueChar('t');

            chain.Add(messageC, 0);
            chain.Add(messageC, 1);
            chain.Add(messageA, 2);
            chain.Add(messageC, 3);
            chain.Add(messageG, 4);
            chain.Add(messageC, 5);
            chain.Add(messageT, 6);
            chain.Add(messageT, 7);
            chain.Add(messageA, 8);
            chain.Add(messageC, 9);

            Assert.AreEqual(1.732, Math.Round(calculator.Calculate(chain, messageC, messageA, LinkUp.End), 3));
            Assert.AreEqual(Math.Pow(1, 1.0 / 2), calculator.Calculate(chain, messageA, messageC, LinkUp.End));
        }
    }
}