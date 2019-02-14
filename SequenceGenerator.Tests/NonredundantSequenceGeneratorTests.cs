using System;
using System.Collections.Generic;
using System.Text;

namespace SequenceGenerator.Tests
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    [TestFixture]
    public class NonredundantSequenceGeneratorTests
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
            };
            var sequenceGenerator = new NonredundantSequenceGenerator();
            var actual = sequenceGenerator.GenerateSequences(3, 2);
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
                new BaseChain(new List<IBaseObject> { one, two, one }),
                new BaseChain(new List<IBaseObject> { two, two, one }),
                new BaseChain(new List<IBaseObject> { three, two, one }),
                new BaseChain(new List<IBaseObject> { two, three, one }),
                new BaseChain(new List<IBaseObject> { one, one, two }),
                new BaseChain(new List<IBaseObject> { two, one, two }),
                new BaseChain(new List<IBaseObject> { three, one, two }),
                new BaseChain(new List<IBaseObject> { one, two, two }),
                new BaseChain(new List<IBaseObject> { one, three, two }),
                new BaseChain(new List<IBaseObject> { two, one, three }),
                new BaseChain(new List<IBaseObject> { one, two, three }),
            };
            var sequenceGenerator = new NonredundantSequenceGenerator();
            var actual = sequenceGenerator.GenerateSequences(3);
            Assert.AreEqual(expected, actual);
        }
    }
}
