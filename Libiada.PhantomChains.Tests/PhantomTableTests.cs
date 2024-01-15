namespace PhantomChains.Tests
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    /// <summary>
    /// The phantom table tests.
    /// </summary>
    [TestFixture]
    public class PhantomTableTests
    {
        /// <summary>
        /// The volume test.
        /// </summary>
        [Test]
        public void VolumeTest()
        {
            var m3 = new ValuePhantom { new ValueString('a') };
            var m1 = new ValuePhantom { new ValueString('1'), new ValueString('2'), new ValueString('3') };
            var m2 = new ValuePhantom { new ValueString('4'), new ValueString('3') };

            var test = new BaseChain(new List<IBaseObject>() { m1, m2, m2, m3 });

            var table = new PhantomTable(test);
            Assert.AreEqual(12, table[0].Volume);
            Assert.AreEqual(4, table[1].Volume);
            Assert.AreEqual(2, table[2].Volume);
            Assert.AreEqual(1, table[3].Volume);
            Assert.AreEqual(1, table[4].Volume);
        }

        /// <summary>
        /// The content test.
        /// </summary>
        [Test]
        public void ContentTest()
        {
            var m1 = new ValuePhantom { new ValueString('1'), new ValueString('2'), new ValueString('3') };
            var m2 = new ValuePhantom { new ValueString('4'), new ValueString('3') };

            var test = new BaseChain(new List<IBaseObject>() { m1, m2, m2 });

            var table = new PhantomTable(test);
            Assert.AreEqual(m1, table[1].Content);
            Assert.AreEqual(m2, table[2].Content);
            Assert.AreEqual(m2, table[3].Content);
        }
    }
}
