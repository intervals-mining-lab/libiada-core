using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;
using LibiadaCore.Tests.Core;

namespace LibiadaCore.Tests.Misc
{
    using LibiadaCore.Misc;

    using NUnit.Framework;
    [TestFixture]
    public class HighOrderFactoryTests
    {
        [Test]
        public void ChainTest()
        {
            var result = HighOrderFactory.Create(ChainsStorage.Chains[0], Link.Start);
            var expected = new Chain(10);
            expected[0] = new ValueInt(1);
            expected[1] = new ValueInt(1);
            expected[2] = new ValueInt(3);
            expected[3] = new ValueInt(1);
            expected[4] = new ValueInt(5);
            expected[5] = new ValueInt(4);
            expected[6] = new ValueInt(3);
            expected[7] = new ValueInt(3);
            expected[8] = new ValueInt(1);
            expected[9] = new ValueInt(4);
            Assert.AreEqual(expected, result);
        }
    }
}
