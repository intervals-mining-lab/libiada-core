using System.Collections.Generic;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;
using NUnit.Framework;

namespace SequenceGeneretor.Tests
{
    [TestFixture]
    public class SequenceGeneratorTests
    {
        [Test]
        public void GeneratorTest()
        {
            var zero = new ValueInt(0);
            var one = new ValueInt(1);
            var expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { zero, zero, zero }),
                new BaseChain(new List<IBaseObject> { one, zero, zero }),
                new BaseChain(new List<IBaseObject> { zero, one, zero }),
                new BaseChain(new List<IBaseObject> { one, one, zero }),
                new BaseChain(new List<IBaseObject> { zero, zero, one }),
                new BaseChain(new List<IBaseObject> { one, zero, one }),
                new BaseChain(new List<IBaseObject> { zero, one, one }),
                new BaseChain(new List<IBaseObject> { one, one, one })
            };
            var sequenceGenerator = new SequenceGenerator.SequenceGenerator();
            var actual = sequenceGenerator.GenerateSequences(3, 2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StrictGeneratorTest()
        {
            var zero = new ValueInt(0);
            var one = new ValueInt(1);
            var two = new ValueInt(2);
            var expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { one, zero, zero }),
                new BaseChain(new List<IBaseObject> { zero, one, zero }),
                new BaseChain(new List<IBaseObject> { one, one, zero }),
                new BaseChain(new List<IBaseObject> { zero, zero, one }),
                new BaseChain(new List<IBaseObject> { one, zero, one }),
                new BaseChain(new List<IBaseObject> { zero, one, one })
            };
            var sequenceGenerator = new SequenceGenerator.SequenceGenerator();
            var actual = sequenceGenerator.StrictGenerateSequences(3, 2);
            Assert.AreEqual(expected, actual);
            expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { zero, zero, zero })
            };
            sequenceGenerator = new SequenceGenerator.SequenceGenerator();
            actual = sequenceGenerator.StrictGenerateSequences(3, 1);
            Assert.AreEqual(expected, actual);
            expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { two, one, zero }),
                new BaseChain(new List<IBaseObject> { one, two, zero }),
                new BaseChain(new List<IBaseObject> { two, zero, one }),
                new BaseChain(new List<IBaseObject> { zero, two, one }),
                new BaseChain(new List<IBaseObject> { one, zero, two }),
                new BaseChain(new List<IBaseObject> { zero, one, two })
            };
            sequenceGenerator = new SequenceGenerator.SequenceGenerator();
            actual = sequenceGenerator.StrictGenerateSequences(3, 3);
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
                new BaseChain(new List<IBaseObject> { two, zero, zero }),
                new BaseChain(new List<IBaseObject> { zero, one, zero }),
                new BaseChain(new List<IBaseObject> { one, one, zero }),
                new BaseChain(new List<IBaseObject> { two, one, zero }),
                new BaseChain(new List<IBaseObject> { zero, two, zero }),
                new BaseChain(new List<IBaseObject> { one, two, zero }),
                new BaseChain(new List<IBaseObject> { two, two, zero }),
                new BaseChain(new List<IBaseObject> { zero, zero, one }),
                new BaseChain(new List<IBaseObject> { one, zero, one }),
                new BaseChain(new List<IBaseObject> { two, zero, one }),
                new BaseChain(new List<IBaseObject> { zero, one, one }),
                new BaseChain(new List<IBaseObject> { one, one, one }),
                new BaseChain(new List<IBaseObject> { two, one, one }),
                new BaseChain(new List<IBaseObject> { zero, two, one }),
                new BaseChain(new List<IBaseObject> { one, two, one }),
                new BaseChain(new List<IBaseObject> { two, two, one }),
                new BaseChain(new List<IBaseObject> { zero, zero, two }),
                new BaseChain(new List<IBaseObject> { one, zero, two }),
                new BaseChain(new List<IBaseObject> { two, zero, two }),
                new BaseChain(new List<IBaseObject> { zero, one, two }),
                new BaseChain(new List<IBaseObject> { one, one, two }),
                new BaseChain(new List<IBaseObject> { two, one, two }),
                new BaseChain(new List<IBaseObject> { zero, two, two }),
                new BaseChain(new List<IBaseObject> { one, two, two }),
                new BaseChain(new List<IBaseObject> { two, two, two })
            };
            var sequenceGenerator = new SequenceGenerator.SequenceGenerator();
            var actual = sequenceGenerator.GenerateSequences(3);
            Assert.AreEqual(expected, actual);
        }
    }
}
