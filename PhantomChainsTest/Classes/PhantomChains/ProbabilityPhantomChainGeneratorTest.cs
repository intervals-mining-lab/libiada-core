namespace PhantomChainsTest.Classes.PhantomChains
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Misc.DataTransformers;
    using LibiadaCore.Classes.Misc.Iterators;
    using LibiadaCore.Classes.Root;
    using LibiadaCore.Classes.Root.SimpleTypes;

    using NUnit.Framework;

    using global::PhantomChains.Classes.PhantomChains;

    using global::PhantomChains.Classes.Statistics.MarkovChain.Generators;

    using PhantomChainsTest.Classes.Statistics.MarkovChain.Generators;

    /// <summary>
    /// The probability phantom chain generator test.
    /// </summary>
    [TestFixture]
    public class ProbabilityPhantomChainGeneratorTest
    {
        /// <summary>
        /// The mother.
        /// </summary>
        private ObjectMotherPMessageTest mother;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            mother = new ObjectMotherPMessageTest();
        }

        /// <summary>
        /// The first test.
        /// </summary>
        [Test]
        public void FirstTest()
        {
            var resultChain = new BaseChain(10);
            resultChain.Add(mother.PhantomMessageBc[1], 0);
            resultChain.Add(mother.PhantomMessageA[0], 1);
            resultChain.Add(mother.PhantomMessageA[0], 2);
            resultChain.Add(mother.PhantomMessageBc[1], 3);
            resultChain.Add(mother.PhantomMessageA[0], 4);
            resultChain.Add(mother.PhantomMessageBc[1], 5);
            resultChain.Add(mother.PhantomMessageA[0], 6);
            resultChain.Add(mother.PhantomMessageBc[1], 7);
            resultChain.Add(mother.PhantomMessageA[0], 8);
            resultChain.Add(mother.PhantomMessageA[0], 9);

            var gen = new PhantomChainGenerator<BaseChain, BaseChain>(mother.SourceChain, new MockGenerator());
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
            resultChain.Add(mother.PhantomMessageBc[1], 0);
            resultChain.Add(mother.PhantomMessageA[0], 1);
            resultChain.Add(mother.PhantomMessageBc[1], 2);
            resultChain.Add(mother.PhantomMessageA[0], 3);
            resultChain.Add(mother.PhantomMessageBc[0], 4);
            var gen = new PhantomChainGenerator<BaseChain, BaseChain>(mother.UnnormalChain, new MockGenerator());
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
            var iter = new IteratorWritableStart<BaseChain, BaseChain>(resultChain);
            iter.Reset();
            while (iter.Next())
            {
                iter.WriteValue(mother.PhantomMessageBc);
            }

            var gen = new PhantomChainGenerator<BaseChain, BaseChain>(resultChain, new SimpleGenerator());
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
            var iterator = new IteratorWritableStart<BaseChain, BaseChain>(resultChain);
            iterator.Reset();
            while (iterator.Next())
            {
                iterator.WriteValue(mother.PhantomMessageBc);
            }

            var gen = new PhantomChainGenerator<BaseChain, BaseChain>(resultChain, new SimpleGenerator());
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
            var gen = new PhantomChainGenerator<BaseChain, BaseChain>(forBuild, new SimpleGenerator());
            List<BaseChain> res = gen.Generate(1);
            Assert.AreEqual(9, res[0].Length);
        }
    }
}