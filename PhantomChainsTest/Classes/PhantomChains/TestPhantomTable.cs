using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.PhantomChains;

namespace PhantomChainsTest.Classes.PhantomChains
{
    [TestFixture]
    public class TestPhantomTable
    {
        [Test]
        public void TestVolume()
        {
            ValuePhantom m1 = new ValuePhantom();
            ValuePhantom m2 = new ValuePhantom();
            ValuePhantom m3 = new ValuePhantom();

            m1.Add(new ValueChar('1'));
            m1.Add(new ValueChar('2'));
            m1.Add(new ValueChar('3'));
            m2.Add(new ValueChar('4'));
            m2.Add(new ValueChar('3'));
            m3.Add(new ValueChar('a'));

            BaseChain test = new BaseChain(4);
            test.Add(m1, 0);
            test.Add(m2, 1);
            test.Add(m2, 2);
            test.Add(m3, 3);

            PhantomTable table = new PhantomTable(test);
            Assert.AreEqual(12, table[0].Volume);
            Assert.AreEqual(4, table[1].Volume);
            Assert.AreEqual(2, table[2].Volume);
            Assert.AreEqual(1, table[3].Volume);
            Assert.AreEqual(1, table[4].Volume);

        }

        [Test]
        public void TestContent()
        {
            ValuePhantom m1 = new ValuePhantom();
            ValuePhantom m2 = new ValuePhantom();

            m1.Add(new ValueChar('1'));
            m1.Add(new ValueChar('2'));
            m1.Add(new ValueChar('3'));
            m2.Add(new ValueChar('4'));
            m2.Add(new ValueChar('3'));

            BaseChain test = new BaseChain(3);
            test.Add(m1, 0);
            test.Add(m2, 1);
            test.Add(m2, 2);

            PhantomTable table = new PhantomTable(test);
            Assert.AreEqual(m1, table[1].Content);
            Assert.AreEqual(m2, table[2].Content);
            Assert.AreEqual(m2, table[3].Content);

        }
    }
}
