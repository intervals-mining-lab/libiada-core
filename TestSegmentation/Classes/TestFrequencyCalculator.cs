using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;
using Segmentation.Classes;

namespace TestSegmentation.Classes
{
    [TestFixture]
    public class TestCalculator
    {

        [Test]
        public void TestFrecuencyCalculator()
        {
            Chain basic_chain = new Chain(15);

            Chain element1 = new Chain(2);
            element1[0] = new ValueChar('a');
            element1[1] = new ValueChar('a');

            Chain element2 = new Chain(3);
            element2[0] = new ValueChar('b');
            element2[1] = new ValueChar('b');
            element2[2] = new ValueChar('b');

            Chain element3 = new Chain(2);
            element3[0] = new ValueChar('c');
            element3[1] = new ValueChar('c');

            basic_chain[0] = element1;
            basic_chain[1] = element3;
            basic_chain[2] = element1;
            basic_chain[3] = element1;
            basic_chain[4] = element2;
            basic_chain[5] = element3;
            basic_chain[6] = element1;
            basic_chain[7] = element3;
            basic_chain[8] = element2;
            basic_chain[9] = element3;
            basic_chain[10] = element3;
            basic_chain[11] = element2;
            basic_chain[12] = element1;
            basic_chain[13] = element1;
            basic_chain[14] = element3;
           
            //element1 - 6
            //element2 - 3
            //element3 - 6

            double f1 = 6/(double)15;
            double f2 = 3 / (double)15;
            double f3 = 6 / (double)15;

            //double f11 = fc.frequency(basic_chain, element1);
            //double f22 = fc.frequency(basic_chain, element2);
            //double f33 = fc.frequency(basic_chain, element3);

            Assert.AreEqual(f1, Calculator.frequency(basic_chain, element1));
            Assert.AreEqual(f2, Calculator.frequency(basic_chain, element2));
            Assert.AreEqual(f3, Calculator.frequency(basic_chain, element3));
        }


        [Test]
        public void TestFrecuencyOfAccordCalculator()
        {
            Chain basic_chain = new Chain(20);


            basic_chain[0] = new ValueChar('a');//a
            basic_chain[1] = new ValueChar('a');//a
            basic_chain[2] = new ValueChar('a');
            basic_chain[3] = new ValueChar('c');//c
            basic_chain[4] = new ValueChar('c');//c
            basic_chain[5] = new ValueChar('b');///b
            basic_chain[6] = new ValueChar('b');///b
            basic_chain[7] = new ValueChar('b');///b
            basic_chain[8] = new ValueChar('a');//a
            basic_chain[9] = new ValueChar('a');//a
            basic_chain[10] = new ValueChar('c');//c
            basic_chain[11] = new ValueChar('c');//c
            basic_chain[12] = new ValueChar('c');
            basic_chain[13] = new ValueChar('a');//a
            basic_chain[14] = new ValueChar('a');//a
            basic_chain[15] = new ValueChar('b');///b
            basic_chain[16] = new ValueChar('b');///b
            basic_chain[17] = new ValueChar('b');///b
            basic_chain[18] = new ValueChar('c');//c
            basic_chain[19] = new ValueChar('c');//c


            Chain element1 = new Chain(2);
            element1[0] = new ValueChar('a');
            element1[1] = new ValueChar('a');

            Chain element2 = new Chain(3);
            element2[0] = new ValueChar('b');
            element2[1] = new ValueChar('b');
            element2[2] = new ValueChar('b');

            Chain element3 = new Chain(2);
            element3[0] = new ValueChar('c');
            element3[1] = new ValueChar('c');
                        
            //element1 - 3
            //element2 - 2
            //element3 - 3

            double f1 = 3 / (double)17;
            double f2 = 2 / (double)16;
            double f3 = 3 / (double)17;


            Assert.AreEqual(f1, Calculator.frequency_of_accord(basic_chain, element1));
            Assert.AreEqual(f2, Calculator.frequency_of_accord(basic_chain, element2));
            Assert.AreEqual(f3, Calculator.frequency_of_accord(basic_chain, element3));
        }
    }
}