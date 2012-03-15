using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.Statistics.MarkovChain;
using TestPhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace TestPhantomChains.Classes.Statistics.MarkovChain
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestProbabilityMatrix
    {
        private Chain TestChain = null;
        private Chain TestChain2 = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            TestChain = new Chain(12);
            TestChain.Add((ValueString)"a", 0);
            TestChain.Add((ValueString)"d", 1);
            TestChain.Add((ValueString)"b", 2);
            TestChain.Add((ValueString)"a", 3);
            TestChain.Add((ValueString)"a", 4);
            TestChain.Add((ValueString)"c", 5);
            TestChain.Add((ValueString)"b", 6);
            TestChain.Add((ValueString)"b", 7);
            TestChain.Add((ValueString)"a", 8);
            TestChain.Add((ValueString)"a", 9);
            TestChain.Add((ValueString)"c", 10);
            TestChain.Add((ValueString)"a", 11);


            TestChain2 = new Chain(12);
            TestChain2.Add((ValueString)"a", 0);
            TestChain2.Add((ValueString)"a", 1);
            TestChain2.Add((ValueString)"a", 2);
            TestChain2.Add((ValueString)"a", 3);
            TestChain2.Add((ValueString)"a", 4);
            TestChain2.Add((ValueString)"a", 5);
            TestChain2.Add((ValueString)"b", 6);
            TestChain2.Add((ValueString)"a", 7);
            TestChain2.Add((ValueString)"a", 8);
            TestChain2.Add((ValueString)"a", 9);
            TestChain2.Add((ValueString)"b", 10);
            TestChain2.Add((ValueString)"a", 11);

        }

        ///<summary>
        ///</summary>
        [Test]
        public void TestGenerationNotUniformMarkovChainRang0()
        {
            Chain ResultTheory = new Chain(10);
            ResultTheory[0] = (ValueString)"b";
            ResultTheory[1] = (ValueString)"a";
            ResultTheory[2] = (ValueString)"a";
            ResultTheory[3] = (ValueString)"c";
            ResultTheory[4] = (ValueString)"a";
            ResultTheory[5] = (ValueString)"a";
            ResultTheory[6] = (ValueString)"c";
            ResultTheory[7] = (ValueString)"b";
            ResultTheory[8] = (ValueString)"b";
            ResultTheory[9] = (ValueString)"a";

            MarkovChainNotUniformStatic<Chain, Chain> Markov = new MarkovChainNotUniformStatic<Chain, Chain>(3, 0, new MockGenerator());
            Markov.Teach(TestChain, TeachingMethod.Cycle);
            Chain ResultPractice = Markov.Generate(10);
            Assert.AreEqual(ResultTheory, ResultPractice);
        }


        ///<summary>
        ///</summary>
        public void TestGenerationUniformMarkovChainLevel2()
        {
            Chain ResultTheory = new Chain(30);
            ResultTheory[0] = (ValueString)"a"; // "a" 0.77;
            ResultTheory[1] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[2] = (ValueString)"b"; // "b" 0.96;
            ResultTheory[3] = (ValueString)"a"; // "a" 0.61;
            ResultTheory[4] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[5] = (ValueString)"b"; // "b" 0.85;
            ResultTheory[6] = (ValueString)"a"; // "a" 0.67;
            ResultTheory[7] = (ValueString)"a"; // "a" 0.51;
            ResultTheory[8] = (ValueString)"a"; // "a" 0.71;
            ResultTheory[9] = (ValueString)"a"; // "a" 0.2;
            ResultTheory[10] = (ValueString)"a"; // "a" 0.77;
            ResultTheory[11] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[12] = (ValueString)"b"; // "b" 0.96;
            ResultTheory[13] = (ValueString)"a"; // "a" 0.61;
            ResultTheory[14] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[15] = (ValueString)"b"; // "b" 0.85;
            ResultTheory[16] = (ValueString)"a"; // "a" 0.67;
            ResultTheory[17] = (ValueString)"a"; // "a" 0.51;
            ResultTheory[18] = (ValueString)"a"; // "a" 0.71;
            ResultTheory[19] = (ValueString)"a"; // "a" 0.2;
            ResultTheory[20] = (ValueString)"a"; // "a" 0.77;
            ResultTheory[21] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[22] = (ValueString)"b"; // "b" 0.96;
            ResultTheory[23] = (ValueString)"a"; // "a" 0.61;
            ResultTheory[24] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[25] = (ValueString)"b"; // "b" 0.85;
            ResultTheory[26] = (ValueString)"a"; // "a" 0.67;
            ResultTheory[27] = (ValueString)"a"; // "a" 0.51;
            ResultTheory[28] = (ValueString)"a"; // "a" 0.71;
            ResultTheory[29] = (ValueString)"a"; // "a" 0.2;


            MarkovChainNotUniformStatic<Chain, Chain> Markov = new MarkovChainNotUniformStatic<Chain, Chain>(2, 0, new MockGenerator());
            Markov.Teach(TestChain2, TeachingMethod.Cycle);
            Chain ResultPractice = Markov.Generate(30);
            Assert.AreEqual(ResultTheory, ResultPractice);            
        }

        ///<summary>
        ///</summary>
 /*       [Test]
        public void TestGenerationNotUniformMarkovChain()
        {
            Chain ResultTheory = new Chain(30);
            ResultTheory[0] = (ValueString)"a"; // "a" 0.77;
            ResultTheory[1] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[2] = (ValueString)"b"; // "b" 0.96;
            ResultTheory[3] = (ValueString)"a"; // "a" 0.61;
            ResultTheory[4] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[5] = (ValueString)"b"; // "b" 0.85;
            ResultTheory[6] = (ValueString)"a"; // "a" 0.67;
            ResultTheory[7] = (ValueString)"a"; // "a" 0.51;
            ResultTheory[8] = (ValueString)"a"; // "a" 0.71;
            ResultTheory[9] = (ValueString)"a"; // "a" 0.2;
            ResultTheory[10] = (ValueString)"a"; // "a" 0.77;
            ResultTheory[11] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[12] = (ValueString)"b"; // "b" 0.96;
            ResultTheory[13] = (ValueString)"a"; // "a" 0.61;
            ResultTheory[14] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[15] = (ValueString)"b"; // "b" 0.85;
            ResultTheory[16] = (ValueString)"a"; // "a" 0.67;
            ResultTheory[17] = (ValueString)"a"; // "a" 0.51;
            ResultTheory[18] = (ValueString)"a"; // "a" 0.71;
            ResultTheory[19] = (ValueString)"a"; // "a" 0.2;
            ResultTheory[20] = (ValueString)"a"; // "a" 0.77;
            ResultTheory[21] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[22] = (ValueString)"b"; // "b" 0.96;
            ResultTheory[23] = (ValueString)"a"; // "a" 0.61;
            ResultTheory[24] = (ValueString)"a"; // "a" 0.15;
            ResultTheory[25] = (ValueString)"a"; // "b" 0.85;
            ResultTheory[26] = (ValueString)"a"; // "a" 0.67;
            ResultTheory[27] = (ValueString)"a"; // "a" 0.51;
            ResultTheory[28] = (ValueString)"a"; // "a" 0.71;
            ResultTheory[29] = (ValueString)"a"; // "a" 0.2;  
            //    a = 0.8(3)  ( 0 )              // a = 0.8 ( -0.0(3) )
            //    b = 0.1(6)  ( 0 )              // b = 0.2 (  0.0(3) )



            MarkovChainNotUniformDynamic<Chain, Chain> Markov = new MarkovChainNotUniformDynamic<Chain, Chain>(2, 0, new MockGenerator());
            Markov.Teach(TestChain2, TeachingMethod.Cycle);

            Chain ResultPractice = Markov.Generate(30);
            Assert.AreEqual(ResultTheory, ResultPractice);
        }*/
    }
}