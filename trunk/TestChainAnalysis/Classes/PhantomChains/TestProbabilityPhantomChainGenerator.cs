using System.Collections;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.PhantomChains;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;
using NUnit.Framework;
using TestChainAnalysis.Classes.Statistics.MarkovChain.Generators;

namespace TestChainAnalysis.Classes.PhantomChains
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestProbabilityPhantomChainGenerator
    {
        private ObjectMotherPMessageTest Mother;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            Mother = new ObjectMotherPMessageTest();
        }

        ///<summary>
        ///</summary>
        [Test]
        public void Test()
        {
            BaseChain ResultChain = new BaseChain(10);
            ResultChain.Add(Mother.PhantomMessage_B_C[1],0);
            ResultChain.Add(Mother.PhantomMessage_A[0], 1);
            ResultChain.Add(Mother.PhantomMessage_A[0], 2);
            ResultChain.Add(Mother.PhantomMessage_B_C[1], 3);
            ResultChain.Add(Mother.PhantomMessage_A[0], 4);
            ResultChain.Add(Mother.PhantomMessage_B_C[1], 5);
            ResultChain.Add(Mother.PhantomMessage_A[0], 6);
            ResultChain.Add(Mother.PhantomMessage_B_C[1], 7);
            ResultChain.Add(Mother.PhantomMessage_A[0], 8);
            ResultChain.Add(Mother.PhantomMessage_A[0], 9);

            PhantomChainGenerator<BaseChain, BaseChain> Gen = new PhantomChainGenerator<BaseChain, BaseChain>(Mother.SourceChain, new MockGenerator());
            ArrayList res = Gen.Generate(1);
            Assert.AreEqual(res.Count, 1);
            Assert.AreEqual(ResultChain,res[0]);
        }
        ///<summary>
        ///</summary>
        [Test]
        public void Test2()
        {
            BaseChain ResultChain = new BaseChain(5);
            ResultChain.Add(Mother.PhantomMessage_B_C[1], 0);
            ResultChain.Add(Mother.PhantomMessage_A[0], 1);
            ResultChain.Add(Mother.PhantomMessage_B_C[1], 2);
            ResultChain.Add(Mother.PhantomMessage_A[0], 3);
            ResultChain.Add(Mother.PhantomMessage_B_C[0], 4);
            PhantomChainGenerator<BaseChain, BaseChain> Gen = new PhantomChainGenerator<BaseChain, BaseChain>(Mother.UnnormalChain, new MockGenerator());
            ArrayList res = Gen.Generate(1);
            Assert.AreEqual(1, res.Count);
            Assert.AreEqual(ResultChain, res[0]);
        }

        ///<summary>
        ///</summary>
        [Test]
        [Ignore]
        public void Tes3t()
        {
            BaseChain ResultChain = new BaseChain(50);
            IteratorWritableStart<BaseChain, BaseChain> Iter = new IteratorWritableStart<BaseChain, BaseChain>(ResultChain);
            Iter.Reset();
            while(Iter.Next())
            {
                Iter.SetCurrent(Mother.PhantomMessage_B_C);
            }

            PhantomChainGenerator<BaseChain, BaseChain> Gen = new PhantomChainGenerator<BaseChain, BaseChain>(ResultChain, new SimpleGenerator());
            ArrayList res = Gen.Generate(3000);
            Assert.AreEqual(res.Count, 3000);
        }

    }
}