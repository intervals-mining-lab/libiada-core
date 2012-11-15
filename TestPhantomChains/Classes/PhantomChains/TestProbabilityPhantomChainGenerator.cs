using System.Collections.Generic;
using LibiadaCore.Classes.Misc.Iterators;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.PhantomChains;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;
using TestPhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace TestPhantomChains.Classes.PhantomChains
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
            List<BaseChain> res = Gen.Generate(1);
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
            List<BaseChain> res = Gen.Generate(1);
            Assert.AreEqual(1, res.Count);
            Assert.AreEqual(ResultChain, res[0]);
        }

        ///<summary>
        ///</summary>
        [Test]
        public void Test3()
        {
            BaseChain ResultChain = new BaseChain(63);
            IteratorWritableStart<BaseChain, BaseChain> Iter = new IteratorWritableStart<BaseChain, BaseChain>(ResultChain);
            Iter.Reset();
            while(Iter.Next())
            {
                Iter.SetCurrent(Mother.PhantomMessage_B_C);
            }

            PhantomChainGenerator<BaseChain, BaseChain> Gen = new PhantomChainGenerator<BaseChain, BaseChain>(ResultChain, new SimpleGenerator());
            List<BaseChain> res = Gen.Generate(3000);
            Assert.AreEqual(res.Count, 3000);
        }

        /*[Test]
        public void Test4()
        {
            BaseChain ResultChain = new BaseChain(10);
            IteratorWritableStart<BaseChain, BaseChain> Iter = new IteratorWritableStart<BaseChain, BaseChain>(ResultChain);
            Iter.Reset();
            while (Iter.Next())
            {
                Iter.SetCurrent(Mother.PhantomMessage_B_C);
            }
            PhantomChainGenerator<BaseChain, BaseChain> Gen = new PhantomChainGenerator<BaseChain, BaseChain>(ResultChain, new SimpleGenerator());
            List<BaseChain> res = Gen.Generate(1);
            TreeNode Cur1 = Gen.GetTree().GetChild(0);
            TreeNode Cur2 = Gen.GetTree().GetChild(1);
            for (int i = 0; i < ResultChain.Length - 2;i++)
            {
                Assert.IsTrue(((Cur1.Children.Count == 0) && (Cur2.Children.Count == 2)) || ((Cur1.Children.Count == 2) && (Cur2.Children.Count == 0)));
                if(Cur1.Children.Count==2)
                {
                    Cur2 = Cur1.GetChild(0);
                    Cur1 = Cur1.GetChild(1);
                }
                else
                {
                    Cur1 = Cur2.GetChild(0);
                    Cur2 = Cur2.GetChild(1);
                }
            }
        }*/

        [Test]
        public void Test5()
        {
            BaseChain ResultChain = new BaseChain(10);
            IteratorWritableStart<BaseChain, BaseChain> Iter = new IteratorWritableStart<BaseChain, BaseChain>(ResultChain);
            Iter.Reset();
            while (Iter.Next())
            {
                Iter.SetCurrent(Mother.PhantomMessage_B_C);
            }

            PhantomChainGenerator<BaseChain, BaseChain> Gen = new PhantomChainGenerator<BaseChain, BaseChain>(ResultChain, new SimpleGenerator());
            List<BaseChain> res = Gen.Generate(1000);
            int counter = 0;
            for(int i = 0; i < 999;i++)
            {
                for(int j = i+1;j < 1000;j++)
                {
                        if (((BaseChain)res[i]).Equals(res[j]))
                        {
                            counter++;
                        }
                }
            }
            Assert.AreEqual(0, counter);
        }

        [Test]
        public void Test6()
        {
            BaseChain SourceChain = new BaseChain(3);
            SourceChain.Add(new ValueString("X"),0);
            SourceChain.Add(new ValueString("S"), 1);
            SourceChain.Add(new ValueString("C"), 2);
            BaseChain ForBuild = Coder.Decode(SourceChain); 
            PhantomChainGenerator<BaseChain, BaseChain> Gen = new PhantomChainGenerator<BaseChain, BaseChain>(ForBuild, new SimpleGenerator());
            List<BaseChain> res = Gen.Generate(1);
            Assert.AreEqual(9, res[0].Length);
        }
    }
}