using System.Collections.Generic;
using LibiadaCore.Core;
using LibiadaCore.Core.SimpleTypes;
using NUnit.Framework;
using SequenceGenerator;

namespace SequenceGeneretor.Tests
{
    [TestFixture]
    public class OrderGeneratorTests
    {
        [Test]
        public void GeneratorTest()
        {
            var one = new ValueInt(1);
            var two = new ValueInt(2);
            var expected = new List<BaseChain>
            {
                new BaseChain(new List<IBaseObject> { one, one, one }),
                new BaseChain(new List<IBaseObject> { one, two, one }),
                new BaseChain(new List<IBaseObject> { one, one, two }),
                new BaseChain(new List<IBaseObject> { one, two, two })
            };
            var orderGenerator = new OrderGenerator();
            var actual = orderGenerator.GenerateOrders(3, 2);
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
                new BaseChain(new List<IBaseObject> { one, two, one }),
                new BaseChain(new List<IBaseObject> { one, one, two }),
                new BaseChain(new List<IBaseObject> { one, two, two }),
                new BaseChain(new List<IBaseObject> { one, one, three }),
                new BaseChain(new List<IBaseObject> { one, two, three })
            };
            var orderGenerator = new OrderGenerator();
            var actual = orderGenerator.GenerateOrders(3);
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
                new BaseChain(new List<IBaseObject> { one, two, three, one }),
                new BaseChain(new List<IBaseObject> { one, one, three, two }),
                new BaseChain(new List<IBaseObject> { one, two, three, two }),
                new BaseChain(new List<IBaseObject> { one, two, one, three }),
                new BaseChain(new List<IBaseObject> { one, one, two, three }),
                new BaseChain(new List<IBaseObject> { one, two, two, three }),
                new BaseChain(new List<IBaseObject> { one, two, three, three }),
            };
            var orderGenerator = new OrderGenerator();
            var actual = orderGenerator.StrictGenerateOrders(4, 3);
            Assert.AreEqual(expected, actual);
        }
    }
}
