using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;
using Segmentation.Classes;

namespace TestSegmentation.Classes
{
    [TestFixture]
    public class TestChainConvolutor
    {
        [Test]
        public void TestConvolute()
        {
            Chain basic_chain = new Chain(15);
            basic_chain[0] = new ValueChar('a');
            basic_chain[1] = new ValueChar('b');
            basic_chain[2] = new ValueChar('c');
            basic_chain[3] = new ValueChar('1');//
            basic_chain[4] = new ValueChar('1');//
            basic_chain[5] = new ValueChar('a');
            basic_chain[6] = new ValueChar('1');
            basic_chain[7] = new ValueChar('b');
            basic_chain[8] = new ValueChar('1');//
            basic_chain[9] = new ValueChar('1');//
            basic_chain[10] = new ValueChar('0');
            basic_chain[11] = new ValueChar('0');
            basic_chain[12] = new ValueChar('0');
            basic_chain[13] = new ValueChar('1');//
            basic_chain[14] = new ValueChar('1');//

            Chain accord = new Chain(2);
            accord[0] = new ValueChar('1');
            accord[1] = new ValueChar('1');

            ChainConvolutor conv = new ChainConvolutor();

            Chain convoluted_chain = new Chain(12);
            convoluted_chain[0] = new ValueChar('a');
            convoluted_chain[1] = new ValueChar('b');
            convoluted_chain[2] = new ValueChar('c');
            convoluted_chain[3] = accord;
            convoluted_chain[4] = new ValueChar('a');
            convoluted_chain[5] = new ValueChar('1');
            convoluted_chain[6] = new ValueChar('b');
            convoluted_chain[7] = accord;
            convoluted_chain[8] = new ValueChar('0');
            convoluted_chain[9] = new ValueChar('0');
            convoluted_chain[10] = new ValueChar('0');
            convoluted_chain[11] = accord;

            Assert.AreEqual(convoluted_chain, (conv.Convolute(basic_chain, accord)));
        }
    }
}
