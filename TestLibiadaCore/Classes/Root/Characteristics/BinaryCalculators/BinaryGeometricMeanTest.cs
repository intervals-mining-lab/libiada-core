using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics.BinaryCalculators;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.BinaryCalculators
{
    [TestFixture]
    public class BinaryGeometricMeanTest
    {
        [Test]
        public void SpatialDependenceTest()
        {
            BinaryGeometricMean calculator = new BinaryGeometricMean();
            Chain chain = new Chain(10);

            ValueChar MessageA = new ValueChar('a');
            ValueChar MessageC = new ValueChar('c');
            ValueChar MessageG = new ValueChar('g');
            ValueChar MessageT = new ValueChar('t');

            chain.Add(MessageC, 0);
            chain.Add(MessageC, 1);
            chain.Add(MessageA, 2);
            chain.Add(MessageC, 3);
            chain.Add(MessageG, 4);
            chain.Add(MessageC, 5);
            chain.Add(MessageT, 6);
            chain.Add(MessageT, 7);
            chain.Add(MessageA, 8);
            chain.Add(MessageC, 9);

            Assert.AreEqual(1.732, Math.Round(calculator.Calculate(chain, MessageC, MessageA, LinkUp.End), 3));
            Assert.AreEqual(Math.Pow(1, 1.0 / 2), calculator.Calculate(chain, MessageA, MessageC, LinkUp.End));
        }
    }
}