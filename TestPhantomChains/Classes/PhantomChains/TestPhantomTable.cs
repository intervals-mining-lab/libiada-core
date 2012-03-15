using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.PhantomChains;

namespace TestPhantomChains.Classes.PhantomChains
{
    [TestFixture]
    public class TestPhantomTable
    {
        [Test]
        public void TestVolume()
        {
            ValuePhantom M1 = new ValuePhantom();
            ValuePhantom M2 = new ValuePhantom();
            ValuePhantom M3 = new ValuePhantom();

            M1.Add(new ValueChar('1'));
            M1.Add(new ValueChar('2'));
            M1.Add(new ValueChar('3'));
            M2.Add(new ValueChar('4'));
            M2.Add(new ValueChar('3'));
            M3.Add(new ValueChar('a'));

            BaseChain Test = new BaseChain(4);
            Test.Add(M1, 0);
            Test.Add(M2, 1);
            Test.Add(M2, 2);
            Test.Add(M3, 3);

            PhantomTable table = new PhantomTable(Test);
            Assert.AreEqual(12, table[0].Volume);
            Assert.AreEqual(4, table[1].Volume);
            Assert.AreEqual(2, table[2].Volume);
            Assert.AreEqual(1, table[3].Volume);
            Assert.AreEqual(1, table[4].Volume);

        }

        [Test]
        public void TestContent()
        {
            ValuePhantom M1 = new ValuePhantom();
            ValuePhantom M2 = new ValuePhantom();

            M1.Add(new ValueChar('1'));
            M1.Add(new ValueChar('2'));
            M1.Add(new ValueChar('3'));
            M2.Add(new ValueChar('4'));
            M2.Add(new ValueChar('3'));

            BaseChain Test = new BaseChain(3);
            Test.Add(M1, 0);
            Test.Add(M2, 1);
            Test.Add(M2, 2);

            PhantomTable table = new PhantomTable(Test);
            Assert.AreEqual(M1, table[1].Content);
            Assert.AreEqual(M2, table[2].Content);
            Assert.AreEqual(M2, table[3].Content);

        }
    }
}
