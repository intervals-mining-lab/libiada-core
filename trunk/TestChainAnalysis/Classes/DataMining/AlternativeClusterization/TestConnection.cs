using System.Collections;
using System.Collections.Specialized;
using ChainAnalises.Classes.DataMining.Clusterization.AlternativeClusterization;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.DataMining.AlternativeClusterization
{
    [TestFixture]
    public class TestConnection
    {
        [Test]
        public void TestConnection1()
        {
            Connection Conn1 = new Connection(0,1);
            Assert.IsFalse(Conn1.Connected);
        }

        [Test]
        public void TestClone1()
        {
            Connection Conn1 = new Connection(2, 5);
            Conn1.Connected = false;
            Conn1.distance = 6;
            Conn1.normalizedDistance = 0.5;
            Conn1.tau = 3;
            Conn1.tauStar = 7;
            Conn1.λ = 13;
            Connection Conn2 = Conn1.Clone();
            Assert.AreEqual(Conn1.Connected, Conn2.Connected);
            Assert.AreEqual(Conn1.FirstElementIndex, Conn2.FirstElementIndex);
            Assert.AreEqual(Conn1.SecondElementIndex, Conn2.SecondElementIndex);
            Assert.AreEqual(Conn1.distance, Conn2.distance);
            Assert.AreEqual(Conn1.normalizedDistance, Conn2.normalizedDistance);
            Assert.AreEqual(Conn1.tau, Conn2.tau);
            Assert.AreEqual(Conn1.tauStar, Conn2.tauStar);
            Assert.AreEqual(Conn1.λ, Conn2.λ);
            Assert.IsInstanceOf<Connection>(Conn2);
            Assert.AreNotSame(Conn1,Conn2);
        }

        [Test]
        public void TestClone2()
        {
            Connection Conn1 = new Connection(2, 3);
            Conn1.Connected = true;
            Conn1.distance = 1;
            Conn1.normalizedDistance = 0.1;
            Conn1.tau = 44;
            Conn1.tauStar = 0;
            Conn1.λ = 5;
            Connection Conn2 = Conn1.Clone();
            Assert.AreEqual(Conn1.Connected, Conn2.Connected);
            Assert.AreEqual(Conn1.FirstElementIndex, Conn2.FirstElementIndex);
            Assert.AreEqual(Conn1.SecondElementIndex, Conn2.SecondElementIndex);
            Assert.AreEqual(Conn1.distance, Conn2.distance);
            Assert.AreEqual(Conn1.normalizedDistance, Conn2.normalizedDistance);
            Assert.AreEqual(Conn1.tau, Conn2.tau);
            Assert.AreEqual(Conn1.tauStar, Conn2.tauStar);
            Assert.AreEqual(Conn1.λ, Conn2.λ);
            Assert.IsInstanceOf<Connection>(Conn2);
            Assert.AreNotSame(Conn1, Conn2);
        }
    }
}