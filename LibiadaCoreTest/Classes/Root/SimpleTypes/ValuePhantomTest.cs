using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.SimpleTypes
{
    [TestFixture]
    public class ValuePhantomTest
    {
        [Test]
        public void EqualsTest()
        {
            var m1 = new ValuePhantom {new ValueChar('1'), new ValueChar('2'), new ValueChar('3')};

            Assert.AreEqual(m1, new ValueChar('3'));
        }

        [Test]
        public void AddMessagePhantomTest()
        {
            var m2 = new ValuePhantom { new ValueChar('4'), new ValueChar('2'), new ValueChar('5') };
            var m1 = new ValuePhantom {new ValueChar('1'), new ValueChar('2'), new ValueChar('3'), m2};

            Assert.AreEqual(new ValueChar('1'), m1);
            Assert.AreEqual(new ValueChar('2'), m1);
            Assert.AreEqual(new ValueChar('3'), m1);
            Assert.AreEqual(new ValueChar('4'), m1);
            Assert.AreEqual(new ValueChar('5'), m1);
        }

        [Test]
        public void CloneTest()
        {
            var m1 = new ValuePhantom {new ValueChar('1'), new ValueChar('2'), new ValueChar('3')};

            var itsClone = (ValuePhantom)m1.Clone();
            Assert.AreEqual(m1, itsClone);
        }

        [Test]
        public void EqualsNullValueTest()
        {
            var m1 = new ValuePhantom();
            Assert.AreEqual(m1, NullValue.Instance());

            m1 = new ValuePhantom {new Chain(10)};
            Assert.AreEqual(m1, NullValue.Instance());

            m1.Add(new ValueChar('1'));
            Assert.AreNotEqual(m1, NullValue.Instance());
        }
    }
}