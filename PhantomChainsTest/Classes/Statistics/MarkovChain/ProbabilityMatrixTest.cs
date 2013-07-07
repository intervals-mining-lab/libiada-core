using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.Statistics.MarkovChain;
using PhantomChainsTest.Classes.Statistics.MarkovChain.Generators;

namespace PhantomChainsTest.Classes.Statistics.MarkovChain
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class ProbabilityMatrixTest
    {
        private Chain TestChain;
        private Chain TestChain2;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Init()
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
        public void GenerationNotUniformMarkovChainRangZeroTest()
        {
            Chain resultTheory = new Chain(10);
            resultTheory[0] = (ValueString)"b";
            resultTheory[1] = (ValueString)"a";
            resultTheory[2] = (ValueString)"a";
            resultTheory[3] = (ValueString)"c";
            resultTheory[4] = (ValueString)"a";
            resultTheory[5] = (ValueString)"a";
            resultTheory[6] = (ValueString)"c";
            resultTheory[7] = (ValueString)"b";
            resultTheory[8] = (ValueString)"b";
            resultTheory[9] = (ValueString)"a";

            MarkovChainNotUniformStatic<Chain, Chain> markov = new MarkovChainNotUniformStatic<Chain, Chain>(3, 0, new MockGenerator());
            markov.Teach(TestChain, TeachingMethod.Cycle);
            Chain resultPractice = markov.Generate(10);
            Assert.AreEqual(resultTheory, resultPractice);
        }


        ///<summary>
        ///</summary>
        [Test]
        public void GenerationUniformMarkovChainLevelTwoTest()
        {
            Chain resultTheory = new Chain(30);
            resultTheory[0] = (ValueString)"a"; // "a" 0.77;
            resultTheory[1] = (ValueString)"a"; // "a" 0.15;
            resultTheory[2] = (ValueString)"b"; // "b" 0.96;
            resultTheory[3] = (ValueString)"a"; // "a" 0.61;
            resultTheory[4] = (ValueString)"a"; // "a" 0.15;
            resultTheory[5] = (ValueString)"b"; // "b" 0.85;
            resultTheory[6] = (ValueString)"a"; // "a" 0.67;
            resultTheory[7] = (ValueString)"a"; // "a" 0.51;
            resultTheory[8] = (ValueString)"a"; // "a" 0.71;
            resultTheory[9] = (ValueString)"a"; // "a" 0.2;
            resultTheory[10] = (ValueString)"a"; // "a" 0.77;
            resultTheory[11] = (ValueString)"a"; // "a" 0.15;
            resultTheory[12] = (ValueString)"b"; // "b" 0.96;
            resultTheory[13] = (ValueString)"a"; // "a" 0.61;
            resultTheory[14] = (ValueString)"a"; // "a" 0.15;
            resultTheory[15] = (ValueString)"b"; // "b" 0.85;
            resultTheory[16] = (ValueString)"a"; // "a" 0.67;
            resultTheory[17] = (ValueString)"a"; // "a" 0.51;
            resultTheory[18] = (ValueString)"a"; // "a" 0.71;
            resultTheory[19] = (ValueString)"a"; // "a" 0.2;
            resultTheory[20] = (ValueString)"a"; // "a" 0.77;
            resultTheory[21] = (ValueString)"a"; // "a" 0.15;
            resultTheory[22] = (ValueString)"b"; // "b" 0.96;
            resultTheory[23] = (ValueString)"a"; // "a" 0.61;
            resultTheory[24] = (ValueString)"a"; // "a" 0.15;
            resultTheory[25] = (ValueString)"b"; // "b" 0.85;
            resultTheory[26] = (ValueString)"a"; // "a" 0.67;
            resultTheory[27] = (ValueString)"a"; // "a" 0.51;
            resultTheory[28] = (ValueString)"a"; // "a" 0.71;
            resultTheory[29] = (ValueString)"a"; // "a" 0.2;


            MarkovChainNotUniformStatic<Chain, Chain> markov = new MarkovChainNotUniformStatic<Chain, Chain>(2, 0, new MockGenerator());
            markov.Teach(TestChain2, TeachingMethod.Cycle);
            Chain resultPractice = markov.Generate(30);
            Assert.AreEqual(resultTheory, resultPractice);            
        }
    }
}