using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibiadaCore.Core;
using NUnit.Framework;

namespace LibiadaCore.Tests.Core
{
    [TestFixture]
    public class AbstractChainTests
    {
        [Test]
        public void ToStringTest()
        {
            var stringExpected = "abcabccc";
            var chain = new Chain(stringExpected);
            Assert.AreEqual(stringExpected, chain.ToString());
            var baseChain = new BaseChain(stringExpected);
            Assert.AreEqual(stringExpected, baseChain.ToString());
        }

        [Test]
        public void ToStringDelimiterTest()
        {
            var source = "abcabccc";
            var expected = "a b c a b c c c";
            var chain = new Chain(source);
            Assert.AreEqual(expected, chain.ToString(" "));
            var baseChain = new BaseChain(source);
            Assert.AreEqual(expected, baseChain.ToString(" "));
        }
    }
}
