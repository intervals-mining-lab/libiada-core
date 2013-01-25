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
    public class DepthTest
    {
        private UniformChain TestUChain = null;
        private Chain TestChain = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            ObjectMother Mother = new ObjectMother();
            TestUChain = Mother.TestUniformChain();
            TestChain = Mother.TestChain();


            /*   TextWriterTraceListener Lisen = new TextWriterTraceListener("Characteristic_log" + GetType() + ".txt");
            Debug.Listeners.Add(Lisen);*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void CalculationForUniformChainTest()
        {
            Characteristic G = new Characteristic(new Depth());
            int Interval1 = 4;
            int Interval3 = 3;
            int Interval4 = 3;
            int Interval2 = 1;
            Assert.AreEqual(
                Math.Log(Interval1, 2) + Math.Log(Interval3, 2) + Math.Log(Interval4, 2) + Math.Log(Interval2, 2),
                G.Value(TestUChain, LinkUp.Both));
            Assert.AreEqual(Math.Log(Interval2, 2) + Math.Log(Interval3, 2) + Math.Log(Interval4, 2),
                            G.Value(TestUChain, LinkUp.End));
            Assert.AreEqual(Math.Log(Interval1, 2) + Math.Log(Interval3, 2) + Math.Log(Interval2, 2),
                            G.Value(TestUChain, LinkUp.Start));

            /*  Debug.WriteLine(TestUChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + G.Value(TestUChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + G.Value(TestUChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + G.Value(TestUChain, LinkUp.End));*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void CalculationForChainTest()
        {
            Characteristic G = new Characteristic(new Depth());

            double remoutness11 = Math.Log(1, 2);
            double remoutness12 = Math.Log(1, 2);
            double remoutness13 = Math.Log(4, 2);
            double remoutness14 = Math.Log(4, 2);
            double remoutness15 = Math.Log(1, 2);

            double SumAStart = remoutness11 + remoutness12 + remoutness13 + remoutness14;
            double SumAEnd = remoutness12 + remoutness13 + remoutness14 + remoutness15;
            double SumABoth = remoutness11 + remoutness12 + remoutness13 + remoutness14 + remoutness15;

            double remoutness21 = Math.Log(3, 2);
            double remoutness22 = Math.Log(1, 2);
            double remoutness23 = Math.Log(3, 2);
            double remoutness24 = Math.Log(4, 2);

            double SumBStart = remoutness21 + remoutness22 + remoutness23;
            double SumBEnd = remoutness22 + remoutness23 + remoutness24;
            double SumBBoth = remoutness21 + remoutness22 + remoutness23 + remoutness24;

            double remoutness31 = Math.Log(5, 2);
            double remoutness32 = Math.Log(3, 2);
            double remoutness33 = Math.Log(1, 2);
            double remoutness34 = Math.Log(2, 2);

            double SubCStart = remoutness31 + remoutness32 + remoutness33;
            double SubCEnd = remoutness32 + remoutness33 + remoutness34;
            double SubCBoth = remoutness31 + remoutness32 + remoutness33 + remoutness34;

            double SumStart = SumAStart + SumBStart + SubCStart;
            double SumEnd = SumAEnd + SumBEnd + SubCEnd;
            double SumBoth = SumABoth + SumBBoth + SubCBoth;


            Assert.AreEqual(SumStart, G.Value(TestChain, LinkUp.Start));
            Assert.AreEqual(SumEnd, G.Value(TestChain, LinkUp.End));
            Assert.AreEqual(SumBoth, G.Value(TestChain, LinkUp.Both));


            /*    Debug.WriteLine(TestChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + G.Value(TestChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + G.Value(TestChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + G.Value(TestChain, LinkUp.End));*/
        }
    }
}