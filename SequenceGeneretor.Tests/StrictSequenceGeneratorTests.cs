namespace SequenceGeneretor.Tests
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    using SequenceGenerator;

    [TestFixture]
    public class StrictSequenceGeneratorTests
    {
        [Test]
        public void GeneratorTest()
        {
            var zero = new ValueInt(0);
            var one = new ValueInt(1);
            var expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { one, zero, zero }),
                new BaseChain(new List<IBaseObject> { zero, one, zero }),
                new BaseChain(new List<IBaseObject> { one, one, zero }),
                new BaseChain(new List<IBaseObject> { zero, zero, one }),
                new BaseChain(new List<IBaseObject> { one, zero, one }),
                new BaseChain(new List<IBaseObject> { zero, one, one })
            };
            var strictSequenceGenerator = new StrictSequenceGenerator();
            var actual = strictSequenceGenerator.GenerateSequences(3, 2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompleteGeneratorTest()
        {
            var zero = new ValueInt(0);
            var one = new ValueInt(1);
            var two = new ValueInt(2);
            var expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { zero, zero, zero }),
                new BaseChain(new List<IBaseObject> { one, zero, zero }),
                new BaseChain(new List<IBaseObject> { zero, one, zero }),
                new BaseChain(new List<IBaseObject> { one, one, zero }),
                new BaseChain(new List<IBaseObject> { zero, zero, one }),
                new BaseChain(new List<IBaseObject> { one, zero, one }),
                new BaseChain(new List<IBaseObject> { zero, one, one }),
                new BaseChain(new List<IBaseObject> { two, one, zero }),
                new BaseChain(new List<IBaseObject> { one, two, zero }),
                new BaseChain(new List<IBaseObject> { two, zero, one }),
                new BaseChain(new List<IBaseObject> { zero, two, one }),
                new BaseChain(new List<IBaseObject> { one, zero, two }),
                new BaseChain(new List<IBaseObject> { zero, one, two }),
            };
            var strictSequenceGenerator = new StrictSequenceGenerator();
            var actual = strictSequenceGenerator.GenerateSequences(3);
            Assert.AreEqual(expected, actual);
        }
    }
}
