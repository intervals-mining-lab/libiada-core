using System;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.Calculators;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.IntervalAnalysis.Characteristics.Calculators
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestPeriodicity
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
        public void TestCalculationForUniformChain()
        {
            Characteristic r = new Characteristic(new Periodicity());

            double Length = 10;
            double ElementCount = 3;
            double ArithmeticMean = Length/ElementCount;

            int Interval1 = 4;
            int Interval2 = 1;
            int Interval3 = 3;
            int Interval4 = 3;

            double IntervalsCount = 3;
            double GeometricMiddling = Math.Pow(Interval1*Interval2*Interval3, 1/IntervalsCount);

            Assert.AreEqual(GeometricMiddling/ArithmeticMean, r.Value(TestUChain, LinkUp.Start));

            IntervalsCount = 3;
            GeometricMiddling = Math.Pow(Interval2*Interval3*Interval4, 1/IntervalsCount);

            Assert.AreEqual(GeometricMiddling/ArithmeticMean, r.Value(TestUChain, LinkUp.End));

            IntervalsCount = 4;
            GeometricMiddling = Math.Pow(Interval1*Interval2*Interval3*Interval4, 1/IntervalsCount);

            Assert.AreEqual(GeometricMiddling/ArithmeticMean, r.Value(TestUChain, LinkUp.Both));


            /*  Debug.WriteLine(TestUChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + r.Value(TestUChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + r.Value(TestUChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + r.Value(TestUChain, LinkUp.End));*/
        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestCalculationForChain()
        {
            Characteristic r = new Characteristic(new Periodicity());

            double Length = 10;

            double ElementACount = 4;
            double ElementBCount = 3;
            double ElementCCount = 3;

            double ArithmeticMeanA = Length/ElementACount;
            double ArithmeticMeanB = Length/ElementBCount;
            double ArithmeticMeanC = Length/ElementCCount;


            double PropabilityA = ElementACount/Length;
            double PropabilityB = ElementBCount/Length;
            double PropabilityC = ElementCCount/Length;

            double D = (ArithmeticMeanC+ ArithmeticMeanA+ ArithmeticMeanB)/3;

            double remoutness11 = 1;
            double remoutness12 = 1;
            double remoutness13 = 4;
            double remoutness14 = 4;
            double remoutness15 = 1;

            double IntervalsACountStart = 4;
            double IntervalsACountEnd = 4;
            double IntervalsACountBoth = 5;

            double remoutness21 = 3;
            double remoutness22 = 1;
            double remoutness23 = 3;
            double remoutness24 = 4;

            double IntervalsBCountStart = 3;
            double IntervalsBCountEnd = 3;
            double IntervalsBCountBoth = 4;


            double remoutness31 = 5;
            double remoutness32 = 3;
            double remoutness33 = 1;
            double remoutness34 = 2;

            double IntervalsCCountStart = 3;
            double IntervalsCCountEnd = 3;
            double IntervalsCCountBoth = 4;

            double IntervalsCountStart = IntervalsACountStart + IntervalsBCountStart + IntervalsCCountStart;
            double IntervalsCountEnd = IntervalsACountEnd + IntervalsBCountEnd + IntervalsCCountEnd;
            double IntervalsCountBoth = IntervalsACountBoth + IntervalsBCountBoth + IntervalsCCountBoth;

            double VStart = remoutness11*remoutness12*remoutness13*remoutness14*
                            remoutness21*remoutness22*remoutness23*
                            remoutness31*remoutness32*remoutness33;

            double VEnd = remoutness12*remoutness13*remoutness14*remoutness15*
                          remoutness22*remoutness23*remoutness24*
                          remoutness32*remoutness33*remoutness34;

            double VBoth = remoutness11*remoutness12*remoutness13*remoutness14*remoutness15*
                           remoutness21*remoutness22*remoutness23*remoutness24*
                           remoutness31*remoutness32*remoutness33*remoutness34;

            double GeometricMiddlingStart = Math.Pow(VStart, 1/IntervalsCountStart);

            Assert.AreEqual(GeometricMiddlingStart/D, r.Value(TestChain, LinkUp.Start));

            double GeometricMiddlingEnd = Math.Pow(VEnd, 1/IntervalsCountEnd);

            Assert.AreEqual(GeometricMiddlingEnd/D, r.Value(TestChain, LinkUp.End));

            double GeometricMiddlingBoth = Math.Pow(VBoth, 1/IntervalsCountBoth);

            Assert.AreEqual(GeometricMiddlingBoth/D, r.Value(TestChain, LinkUp.Both));


            /*   Debug.WriteLine(TestChain);
            Debug.WriteLine(LinkUp.Start.ToString() + " : " + r.Value(TestChain, LinkUp.Start));
            Debug.WriteLine(LinkUp.Both.ToString() + " : " + r.Value(TestChain, LinkUp.Both));
            Debug.WriteLine(LinkUp.End.ToString() + " : " + r.Value(TestChain, LinkUp.End));*/
        }
    }
}