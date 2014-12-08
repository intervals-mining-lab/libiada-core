namespace PhantomChains.Tests
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;
    using LibiadaCore.Misc.Iterators;

    using MarkovChains.MarkovChain.Generators;
    using MarkovChains.Tests.MarkovChain.Generators;

    using NUnit.Framework;

    /// <summary>
    /// The probability phantom chain generator tests.
    /// </summary>
    [TestFixture]
    public class ProbabilityPhantomChainGeneratorTests
    {
        /// <summary>
        /// The mother.
        /// </summary>
        private TestObject mother;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            mother = new TestObject();
        }

        /// <summary>
        /// The first test.
        /// </summary>
        [Test]
        public void FirstTest()
        {
            var resultChain = new BaseChain(10);
            resultChain.Set(mother.PhantomMessageBc[1], 0);
            resultChain.Set(mother.PhantomMessageA[0], 1);
            resultChain.Set(mother.PhantomMessageA[0], 2);
            resultChain.Set(mother.PhantomMessageBc[1], 3);
            resultChain.Set(mother.PhantomMessageA[0], 4);
            resultChain.Set(mother.PhantomMessageBc[1], 5);
            resultChain.Set(mother.PhantomMessageA[0], 6);
            resultChain.Set(mother.PhantomMessageBc[1], 7);
            resultChain.Set(mother.PhantomMessageA[0], 8);
            resultChain.Set(mother.PhantomMessageA[0], 9);

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
            var resultChain = new BaseChain(5);
            resultChain.Set(mother.PhantomMessageBc[1], 0);
            resultChain.Set(mother.PhantomMessageA[0], 1);
            resultChain.Set(mother.PhantomMessageBc[1], 2);
            resultChain.Set(mother.PhantomMessageA[0], 3);
            resultChain.Set(mother.PhantomMessageBc[0], 4);
            var gen = new PhantomChainGenerator(mother.UnnormalChain, new MockGenerator());
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
            var iter = new IteratorWritableStart(resultChain);
            iter.Reset();
            while (iter.Next())
            {
                iter.WriteValue(mother.PhantomMessageBc);
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
            var sourceChain = new BaseChain(3);
            sourceChain.Set(new ValueString("X"), 0);
            sourceChain.Set(new ValueString("S"), 1);
            sourceChain.Set(new ValueString("C"), 2);
            BaseChain forBuild = DnaTransformer.Decode(sourceChain);
            var gen = new PhantomChainGenerator(forBuild, new SimpleGenerator());
            List<BaseChain> res = gen.Generate(1);
            Assert.AreEqual(9, res[0].GetLength());
        }
    }
}