namespace PhantomChains.Tests
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.DataTransformers;
    using LibiadaCore.Iterators;
    using MarkovChains.MarkovChain.Generators;
    using MarkovChains.Tests.MarkovChain.Generators;

    using NUnit.Framework;

    /// <summary>
    /// The probability phantom chain generator tests.
    /// </summary>
    [TestFixture]
    public class PhantomChainGeneratorTests
    {
        /// <summary>
        /// The mother.
        /// </summary>
        private TestObject mother;

        /// <summary>
        /// The initialization method.
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            mother = new TestObject();
        }

        /// <summary>
        /// The first test.
        /// </summary>
        [Test]
        public void FirstTest()
        {
            var resultChain = new BaseChain(new[] { 1, 2, 2, 1, 2, 1, 2, 1, 2, 2 },
                new Alphabet() { NullValue.Instance(), mother.PhantomMessageBc[1], mother.PhantomMessageA[0] });

            var gen = new PhantomChainGenerator(mother.SourceChain, new MockGenerator());
            List<BaseChain> res = gen.Generate(1);
            Assert.AreEqual(res.Count, 1);
            Assert.AreEqual(resultChain, res[0]);
        }

        /// <summary>
        /// The second test.
        /// </summary>
        [Test]
        public void SecondTest()
        {
            var resultChain = new BaseChain(
                new [] { 1, 2, 1, 2, 3 },
                new Alphabet(){NullValue.Instance(), mother.PhantomMessageBc[1], mother.PhantomMessageA[0], mother.PhantomMessageBc[0] });
            var gen = new PhantomChainGenerator(mother.UnnormalizedChain, new MockGenerator());
            List<BaseChain> res = gen.Generate(1);
            Assert.AreEqual(1, res.Count);
            Assert.AreEqual(resultChain, res[0]);
        }

        /// <summary>
        /// The third test.
        /// </summary>
        [Test]
        public void ThirdTest()
        {
            var resultChain = new BaseChain(63);
            var iterator = new IteratorWritableStart(resultChain);
            iterator.Reset();
            while (iterator.Next())
            {
                iterator.WriteValue(mother.PhantomMessageBc);
            }

            var gen = new PhantomChainGenerator(resultChain, new SimpleGenerator());
            List<BaseChain> res = gen.Generate(3000);
            Assert.AreEqual(res.Count, 3000);
        }

        /// <summary>
        /// The fourth test.
        /// </summary>
        [Test]
        public void FourthTest()
        {
            var resultChain = new BaseChain(10);
            var iterator = new IteratorWritableStart(resultChain);
            iterator.Reset();
            while (iterator.Next())
            {
                iterator.WriteValue(mother.PhantomMessageBc);
            }

            var gen = new PhantomChainGenerator(resultChain, new SimpleGenerator());
            List<BaseChain> res = gen.Generate(1000);
            int counter = 0;
            for (int i = 0; i < 999; i++)
            {
                for (int j = i + 1; j < 1000; j++)
                {
                    if (res[i].Equals(res[j]))
                    {
                        counter++;
                    }
                }
            }

            Assert.AreEqual(0, counter);
        }

        /// <summary>
        /// The sixth test.
        /// </summary>
        [Test]
        public void SixthTest()
        {
            var sourceChain = new BaseChain(new List<IBaseObject>() { (ValueString)"X", (ValueString)"S", (ValueString)"C" });
            BaseChain forBuild = DnaTransformer.Decode(sourceChain);
            var gen = new PhantomChainGenerator(forBuild, new SimpleGenerator());
            List<BaseChain> res = gen.Generate(1);
            Assert.AreEqual(9, res[0].Length);
        }
    }
}
