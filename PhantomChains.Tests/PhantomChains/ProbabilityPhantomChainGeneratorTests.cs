namespace PhantomChains.Tests.PhantomChains
{
    using System.Collections.Generic;

    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc.DataTransformers;
    using LibiadaCore.Misc.Iterators;

    using NUnit.Framework;

    using global::PhantomChains.PhantomChains;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    using global::PhantomChains.Tests.Statistics.MarkovChain.Generators;

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
            this.mother = new TestObject();
        }

        /// <summary>
        /// The first test.
        /// </summary>
        [Test]
        public void FirstTest()
        {
            var resultChain = new BaseChain(10);
            resultChain.Add(this.mother.PhantomMessageBc[1], 0);
            resultChain.Add(this.mother.PhantomMessageA[0], 1);
            resultChain.Add(this.mother.PhantomMessageA[0], 2);
            resultChain.Add(this.mother.PhantomMessageBc[1], 3);
            resultChain.Add(this.mother.PhantomMessageA[0], 4);
            resultChain.Add(this.mother.PhantomMessageBc[1], 5);
            resultChain.Add(this.mother.PhantomMessageA[0], 6);
            resultChain.Add(this.mother.PhantomMessageBc[1], 7);
            resultChain.Add(this.mother.PhantomMessageA[0], 8);
            resultChain.Add(this.mother.PhantomMessageA[0], 9);

            var gen = new PhantomChainGenerator(this.mother.SourceChain, new MockGenerator());
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
            resultChain.Add(this.mother.PhantomMessageBc[1], 0);
            resultChain.Add(this.mother.PhantomMessageA[0], 1);
            resultChain.Add(this.mother.PhantomMessageBc[1], 2);
            resultChain.Add(this.mother.PhantomMessageA[0], 3);
            resultChain.Add(this.mother.PhantomMessageBc[0], 4);
            var gen = new PhantomChainGenerator(this.mother.UnnormalChain, new MockGenerator());
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
                iter.WriteValue(this.mother.PhantomMessageBc);
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
                iterator.WriteValue(this.mother.PhantomMessageBc);
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
            sourceChain.Add(new ValueString("X"), 0);
            sourceChain.Add(new ValueString("S"), 1);
            sourceChain.Add(new ValueString("C"), 2);
            BaseChain forBuild = DnaTransformer.Decode(sourceChain);
            var gen = new PhantomChainGenerator(forBuild, new SimpleGenerator());
            List<BaseChain> res = gen.Generate(1);
            Assert.AreEqual(9, res[0].GetLength());
        }
    }
}