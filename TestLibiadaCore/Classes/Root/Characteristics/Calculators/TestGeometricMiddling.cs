using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.Characteristics;
using LibiadaCore.Classes.Root.Characteristics.Calculators;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestGeometricMiddling
    {
        private UniformChain TestUChain = null;
        private Chain TestChain = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            ObjectMother Mother = new ObjectMother();
            TestUChain = Mother.TestUniformChain();
            TestChain = Mother.TestChain();

            /*  TextWriterTraceListener Lisen = new TextWriterTraceListener("Characteristic_log" + GetType() + ".txt");
            Debug.Listeners.Add(Lisen);*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic dG = new Characteristic(new GeometricMiddling());

            double dGTheoreticalStart;

            double remoutness11 = 1;
            double remoutness12 = 1;
            double remoutness13 = 4;
            double remoutness14 = 4;
            double remoutness15 = 1;

            double remoutness21 = 3;
            double remoutness22 = 1;
            double remoutness23 = 3;
            double remoutness24 = 4;

            double remoutness31 = 5;
            double remoutness32 = 3;
            double remoutness33 = 1;
            double remoutness34 = 2;

            double MultiplicatedIntervalsStart = remoutness11*remoutness12*remoutness13*remoutness14*
                                                 remoutness21*remoutness22*remoutness23*remoutness31*remoutness32*
                                                 remoutness33;

            int Intervals_CountStart = 10;
            dGTheoreticalStart = Math.Pow(MultiplicatedIntervalsStart, ((double) 1)/Intervals_CountStart);

            Assert.AreEqual(dGTheoreticalStart, dG.Value(TestChain, LinkUp.Start));

            double MultiplicatedIntervalsEnd = remoutness12*remoutness13*remoutness14*remoutness15*
                                               remoutness22*remoutness23*remoutness24*remoutness32*remoutness33*
                                               remoutness34;

            int Intervals_CountEnd = 10;
            double dGTheoreticalEnd = Math.Pow(MultiplicatedIntervalsEnd, ((double) 1)/Intervals_CountEnd);

            Assert.AreEqual(dGTheoreticalEnd, dG.Value(TestChain, LinkUp.End));


            double MultiplicatedIntervalsBoth = remoutness11*remoutness12*remoutness13*remoutness14*remoutness15*
                                                remoutness21*remoutness22*remoutness23*remoutness24*remoutness31*
                                                remoutness32*remoutness33*remoutness34;

            int Intervals_CountBoth = 13;
            double dGTheoreticalBoth = Math.Pow(MultiplicatedIntervalsBoth, ((double) 1)/Intervals_CountBoth);

            Assert.AreEqual(dGTheoreticalBoth, dG.Value(TestChain, LinkUp.Both));


            /*  Debug.WriteLine(TestChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + dG.Value(TestChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + dG.Value(TestChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + dG.Value(TestChain, LinkUp.End));*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForUniformChain()
        {
            Characteristic deltaGeom = new Characteristic(new GeometricMiddling());
            Characteristic G = new Characteristic(new Gamut());
            Characteristic N = new Characteristic(new IntervalsCount());

            int Interval1 = 4;
            int Interval2 = 1;
            int Interval3 = 3;
            int Interval4 = 3;

            double V = Interval1*Interval2*Interval3*Interval4;
            double IntervalsCount = ((double) 1)/4;
            Assert.AreEqual(Math.Pow(V, IntervalsCount), deltaGeom.Value(TestUChain, LinkUp.Both));

            Assert.AreEqual(Math.Pow(2, G.Value(TestUChain, LinkUp.Both)/N.Value(TestUChain, LinkUp.Both)),
                            deltaGeom.Value(TestUChain, LinkUp.Both));

            V = Interval1*Interval2*Interval3;
            IntervalsCount = ((double) 1)/3;
            Assert.AreEqual(Math.Pow(V, IntervalsCount), deltaGeom.Value(TestUChain, LinkUp.Start));

            Assert.AreEqual(Math.Pow(2, G.Value(TestUChain, LinkUp.Start)/N.Value(TestUChain, LinkUp.Start)),
                            deltaGeom.Value(TestUChain, LinkUp.Start));

            V = Interval2*Interval3*Interval4;
            IntervalsCount = ((double) 1)/3;
            Assert.AreEqual(Math.Pow(V, IntervalsCount), deltaGeom.Value(TestUChain, LinkUp.End));

            Assert.AreEqual(Math.Pow(2, G.Value(TestUChain, LinkUp.End)/N.Value(TestUChain, LinkUp.End)),
                            deltaGeom.Value(TestUChain, LinkUp.End));

            /*   Debug.WriteLine(TestUChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + deltaGeom.Value(TestUChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + deltaGeom.Value(TestUChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + deltaGeom.Value(TestUChain, LinkUp.End));*/
        }
    }
}