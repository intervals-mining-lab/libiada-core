using System.Collections.Generic;
using LibiadaCore.Classes.Misc.DataTransformators;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.PhantomChains;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;
using PhantomChainsTest.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChainsTest.Classes.PhantomChains
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class ProbabilityPhantomChainGeneratorTest
    {
        private ObjectMotherPMessageTest Mother;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
        {
            Mother = new ObjectMotherPMessageTest();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void FirstTest()
        {
            BaseChain resultChain = new BaseChain(10);
            resultChain.Add(Mother.PhantomMessageBC[1],0);
            resultChain.Add(Mother.PhantomMessageA[0], 1);
            resultChain.Add(Mother.PhantomMessageA[0], 2);
            resultChain.Add(Mother.PhantomMessageBC[1], 3);
            resultChain.Add(Mother.PhantomMessageA[0], 4);
            resultChain.Add(Mother.PhantomMessageBC[1], 5);
            resultChain.Add(Mother.PhantomMessageA[0], 6);
            resultChain.Add(Mother.PhantomMessageBC[1], 7);
            resultChain.Add(Mother.PhantomMessageA[0], 8);
            resultChain.Add(Mother.PhantomMessageA[0], 9);

            PhantomChainGenerator<BaseChain, BaseChain> gen = new PhantomChainGenerator<BaseChain, BaseChain>(Mother.SourceChain, new MockGenerator());
            List<BaseChain> res = gen.Generate(1);
            Assert.AreEqual(res.Count, 1);
            Assert.AreEqual(resultChain,res[0]);
        }
        ///<summary>
        ///</summary>
        [Test]
        public void SecondTest()
        {
            BaseChain resultChain = new BaseChain(5);
            resultChain.Add(Mother.PhantomMessageBC[1], 0);
            resultChain.Add(Mother.PhantomMessageA[0], 1);
            resultChain.Add(Mother.PhantomMessageBC[1], 2);
            resultChain.Add(Mother.PhantomMessageA[0], 3);
            resultChain.Add(Mother.PhantomMessageBC[0], 4);
            PhantomChainGenerator<BaseChain, BaseChain> gen = new PhantomChainGenerator<BaseChain, BaseChain>(Mother.UnnormalChain, new MockGenerator());
            List<BaseChain> res = gen.Generate(1);
            Assert.AreEqual(1, res.Count);
            Assert.AreEqual(resultChain, res[0]);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void ThirdTest()
        {
            BaseChain resultChain = new BaseChain(63);
            IteratorWritableStart<BaseChain, BaseChain> iter = new IteratorWritableStart<BaseChain, BaseChain>(resultChain);
            iter.Reset();
            while(iter.Next())
            {
                iter.SetCurrent(Mother.PhantomMessageBC);
            }

            PhantomChainGenerator<BaseChain, BaseChain> gen = new PhantomChainGenerator<BaseChain, BaseChain>(resultChain, new SimpleGenerator());
            List<BaseChain> res = gen.Generate(3000);
            Assert.AreEqual(res.Count, 3000);
        }

        [Test]
        public void FourthTest()
        {
            BaseChain resultChain = new BaseChain(10);
            IteratorWritableStart<BaseChain, BaseChain> iter = new IteratorWritableStart<BaseChain, BaseChain>(resultChain);
            iter.Reset();
            while (iter.Next())
            {
                iter.SetCurrent(Mother.PhantomMessageBC);
            }

            PhantomChainGenerator<BaseChain, BaseChain> gen = new PhantomChainGenerator<BaseChain, BaseChain>(resultChain, new SimpleGenerator());
            List<BaseChain> res = gen.Generate(1000);
            int counter = 0;
            for(int i = 0; i < 999;i++)
            {
                for(int j = i+1;j < 1000;j++)
                {
                        if (res[i].Equals(res[j]))
                        {
                            counter++;
                        }
                }
            }
            Assert.AreEqual(0, counter);
        }

        [Test]
        public void SixthTest()
        {
            BaseChain sourceChain = new BaseChain(3);
            sourceChain.Add(new ValueString("X"),0);
            sourceChain.Add(new ValueString("S"), 1);
            sourceChain.Add(new ValueString("C"), 2);
            BaseChain forBuild = DnaTransformator.Decode(sourceChain); 
            PhantomChainGenerator<BaseChain, BaseChain> gen = new PhantomChainGenerator<BaseChain, BaseChain>(forBuild, new SimpleGenerator());
            List<BaseChain> res = gen.Generate(1);
            Assert.AreEqual(9, res[0].Length);
        }
    }
}