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
            var one = new ValueInt(1);
            var two = new ValueInt(2);
            var expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { one, one, one }),
                new BaseChain(new List<IBaseObject> { two, one, one }),
                new BaseChain(new List<IBaseObject> { one, two, one }),
                new BaseChain(new List<IBaseObject> { two, two, one }),
                new BaseChain(new List<IBaseObject> { one, one, two }),
                new BaseChain(new List<IBaseObject> { two, one, two }),
                new BaseChain(new List<IBaseObject> { one, two, two }),
                new BaseChain(new List<IBaseObject> { two, two, two })
            };
            var sequenceGenerator = new SequenceGenerator.SequenceGenerator();
            var actual = sequenceGenerator.GenerateSequences(3, 2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void StrictGeneratorTest()
        {
            var one = new ValueInt(1);
            var two = new ValueInt(2);
            var three = new ValueInt(3);
            var expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { two, one, one }),
                new BaseChain(new List<IBaseObject> { one, two, one }),
                new BaseChain(new List<IBaseObject> { two, two, one }),
                new BaseChain(new List<IBaseObject> { one, one, two }),
                new BaseChain(new List<IBaseObject> { two, one, two }),
                new BaseChain(new List<IBaseObject> { one, two, two })
            };
            var sequenceGenerator = new SequenceGenerator.SequenceGenerator();
            var actual = sequenceGenerator.StrictGenerateSequences(3, 2);
            Assert.AreEqual(expected, actual);
            expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { one, one, one })
            };
            sequenceGenerator = new SequenceGenerator.SequenceGenerator();
            actual = sequenceGenerator.StrictGenerateSequences(3, 1);
            Assert.AreEqual(expected, actual);
            expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { three, two, one }),
                new BaseChain(new List<IBaseObject> { two, three, one }),
                new BaseChain(new List<IBaseObject> { three, one, two }),
                new BaseChain(new List<IBaseObject> { one, three, two }),
                new BaseChain(new List<IBaseObject> { two, one, three }),
                new BaseChain(new List<IBaseObject> { one, two, three })
            };
            sequenceGenerator = new SequenceGenerator.SequenceGenerator();
            actual = sequenceGenerator.StrictGenerateSequences(3, 3);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CompleteGeneratorTest()
        {
            var one = new ValueInt(1);
            var two = new ValueInt(2);
            var three = new ValueInt(3);
            var expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { one, one, one }),
                new BaseChain(new List<IBaseObject> { two, one, one }),
                new BaseChain(new List<IBaseObject> { three, one, one }),
                new BaseChain(new List<IBaseObject> { one, two, one }),
                new BaseChain(new List<IBaseObject> { two, two, one }),
                new BaseChain(new List<IBaseObject> { three, two, one }),
                new BaseChain(new List<IBaseObject> { one, three, one }),
                new BaseChain(new List<IBaseObject> { two, three, one }),
                new BaseChain(new List<IBaseObject> { three, three, one }),
                new BaseChain(new List<IBaseObject> { one, one, two }),
                new BaseChain(new List<IBaseObject> { two, one, two }),
                new BaseChain(new List<IBaseObject> { three, one, two }),
                new BaseChain(new List<IBaseObject> { one, two, two }),
                new BaseChain(new List<IBaseObject> { two, two, two }),
                new BaseChain(new List<IBaseObject> { three, two, two }),
                new BaseChain(new List<IBaseObject> { one, three, two }),
                new BaseChain(new List<IBaseObject> { two, three, two }),
                new BaseChain(new List<IBaseObject> { three, three, two }),
                new BaseChain(new List<IBaseObject> { one, one, three }),
                new BaseChain(new List<IBaseObject> { two, one, three }),
                new BaseChain(new List<IBaseObject> { three, one, three }),
                new BaseChain(new List<IBaseObject> { one, two, three }),
                new BaseChain(new List<IBaseObject> { two, two, three }),
                new BaseChain(new List<IBaseObject> { three, two, three }),
                new BaseChain(new List<IBaseObject> { one, three, three }),
                new BaseChain(new List<IBaseObject> { two, three, three }),
                new BaseChain(new List<IBaseObject> { three, three, three })
            };
            var sequenceGenerator = new SequenceGenerator.SequenceGenerator();
            var actual = sequenceGenerator.GenerateSequences(3);
            Assert.AreEqual(expected, actual);
        }
    }
}
