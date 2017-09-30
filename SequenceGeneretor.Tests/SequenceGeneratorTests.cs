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
        
    }
}
