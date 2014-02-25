namespace LibiadaCoreTest.Classes.Root.SimpleTypes
{
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The value phantom test.
    /// </summary>
    [TestFixture]
    public class ValuePhantomTest
    {
        /// <summary>
        /// The equals test.
        /// </summary>
        [Test]
        public void EqualsTest()
        {
            var m1 = new ValuePhantom { new ValueChar('1'), new ValueChar('2'), new ValueChar('3') };

            Assert.IsTrue(m1.Equals(new ValueChar('3')));
        }

        /// <summary>
        /// The add message phantom test.
        /// </summary>
        [Test]
        public void AddMessagePhantomTest()
        {
            var m2 = new ValuePhantom { new ValueChar('4'), new ValueChar('2'), new ValueChar('5') };
            var m1 = new ValuePhantom { new ValueChar('1'), new ValueChar('2'), new ValueChar('3'), m2 };

            Assert.IsTrue(m1.Equals(new ValueChar('1')));
            Assert.IsTrue(m1.Equals(new ValueChar('2')));
            Assert.IsTrue(m1.Equals(new ValueChar('3')));
            Assert.IsTrue(m1.Equals(new ValueChar('4')));
            Assert.IsTrue(m1.Equals(new ValueChar('5')));
        }

        /// <summary>
        /// The clone test.
        /// </summary>
        [Test]
        public void CloneTest()
        {
            var m1 = new ValuePhantom { new ValueChar('1'), new ValueChar('2'), new ValueChar('3') };

            var itsClone = (ValuePhantom)m1.Clone();
            Assert.AreEqual(m1, itsClone);
        }

        /// <summary>
        /// The equals null value test.
        /// </summary>
        [Test]
        public void EqualsNullValueTest()
        {
            var m1 = new ValuePhantom();
            Assert.AreEqual(m1, NullValue.Instance());

            m1 = new ValuePhantom { new Chain(10) };
            Assert.AreEqual(m1, NullValue.Instance());

            m1.Add(new ValueChar('1'));
            Assert.AreNotEqual(m1, NullValue.Instance());
        }
    }
}