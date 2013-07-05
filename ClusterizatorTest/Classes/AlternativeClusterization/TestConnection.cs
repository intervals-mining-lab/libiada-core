using Clusterizator.Classes.AlternativeClusterization;
using NUnit.Framework;

namespace ClusterizatorTest.Classes.AlternativeClusterization

{
    [TestFixture]
    public class TestConnection
    {

        [Test]
        public void TestConnection1()
        {
            Connection conn1 = new Connection(0, 1);
            Assert.IsFalse(conn1.Connected);
        }

        [Test]
        public void TestClone1()
        {
            Connection conn1 = new Connection(2, 5)
                {
                    Connected = false,
                    Distance = 6,
                    NormalizedDistance = 0.5,
                    Tau = 3,
                    TauStar = 7,
                    λ = 13
                };
            Connection conn2 = conn1.Clone();
            Assert.AreEqual(conn1.Connected, conn2.Connected);
            Assert.AreEqual(conn1.FirstElementIndex, conn2.FirstElementIndex);
            Assert.AreEqual(conn1.SecondElementIndex, conn2.SecondElementIndex);
            Assert.AreEqual(conn1.Distance, conn2.Distance);
            Assert.AreEqual(conn1.NormalizedDistance, conn2.NormalizedDistance);
            Assert.AreEqual(conn1.Tau, conn2.Tau);
            Assert.AreEqual(conn1.TauStar, conn2.TauStar);
            Assert.AreEqual(conn1.λ, conn2.λ);
            Assert.IsInstanceOf(typeof (Connection), conn2);
            Assert.AreNotSame(conn1,conn2);
        }



        [Test]
        public void TestClone2()
        {
            Connection conn1 = new Connection(2, 3)
                {
                    Connected = true,
                    Distance = 1,
                    NormalizedDistance = 0.1,
                    Tau = 44,
                    TauStar = 0,
                    λ = 5
                };
            Connection conn2 = conn1.Clone();
            Assert.AreEqual(conn1.Connected, conn2.Connected);
            Assert.AreEqual(conn1.FirstElementIndex, conn2.FirstElementIndex);
            Assert.AreEqual(conn1.SecondElementIndex, conn2.SecondElementIndex);
            Assert.AreEqual(conn1.Distance, conn2.Distance);
            Assert.AreEqual(conn1.NormalizedDistance, conn2.NormalizedDistance);
            Assert.AreEqual(conn1.Tau, conn2.Tau);
            Assert.AreEqual(conn1.TauStar, conn2.TauStar);
            Assert.AreEqual(conn1.λ, conn2.λ);
            Assert.IsInstanceOf(typeof (Connection), conn2);
            Assert.AreNotSame(conn1, conn2);
        }
    }
}


