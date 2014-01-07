using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.PhantomChains;

namespace PhantomChainsTest.Classes.PhantomChains
{
    [TestFixture]
    public class PhantomTableTest
    {
        [Test]
        public void VolumeTest()
        {
            var m3 = new ValuePhantom {new ValueChar('a')};
            var m1 = new ValuePhantom {new ValueChar('1'), new ValueChar('2'), new ValueChar('3')};
            var m2 = new ValuePhantom {new ValueChar('4'), new ValueChar('3')};
            
            var test = new BaseChain(4);
            test.Add(m1, 0);
            test.Add(m2, 1);
            test.Add(m2, 2);
            test.Add(m3, 3);

            var table = new PhantomTable(test);
            Assert.AreEqual(12, table[0].Volume);
            Assert.AreEqual(4, table[1].Volume);
            Assert.AreEqual(2, table[2].Volume);
            Assert.AreEqual(1, table[3].Volume);
            Assert.AreEqual(1, table[4].Volume);

        }

        [Test]
        public void ContentTest()
        {
            var m1 = new ValuePhantom {new ValueChar('1'), new ValueChar('2'), new ValueChar('3')};
            var m2 = new ValuePhantom {new ValueChar('4'), new ValueChar('3')};

            var test = new BaseChain(3);
            test.Add(m1, 0);
            test.Add(m2, 1);
            test.Add(m2, 2);

            var table = new PhantomTable(test);
            Assert.AreEqual(m1, table[1].Content);
            Assert.AreEqual(m2, table[2].Content);
            Assert.AreEqual(m2, table[3].Content);

        }
    }
}
