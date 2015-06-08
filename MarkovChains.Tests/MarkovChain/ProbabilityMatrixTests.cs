namespace MarkovChains.Tests.MarkovChain
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using MarkovChains.MarkovChain;
    using MarkovChains.Tests.MarkovChain.Generators;

    using NUnit.Framework;

    /// <summary>
    /// The probability matrix tests.
    /// </summary>
    [TestFixture]
    public class ProbabilityMatrixTests
    {
        /// <summary>
        /// The test chain.
        /// </summary>
        private Chain testChain;

        /// <summary>
        /// The test chain 2.
        /// </summary>
        private Chain testChain2;

        /// <summary>
        /// The initialization method.
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            testChain = new Chain(12);
            testChain.Set((ValueString)"a", 0);
            testChain.Set((ValueString)"d", 1);
            testChain.Set((ValueString)"b", 2);
            testChain.Set((ValueString)"a", 3);
            testChain.Set((ValueString)"a", 4);
            testChain.Set((ValueString)"c", 5);
            testChain.Set((ValueString)"b", 6);
            testChain.Set((ValueString)"b", 7);
            testChain.Set((ValueString)"a", 8);
            testChain.Set((ValueString)"a", 9);
            testChain.Set((ValueString)"c", 10);
            testChain.Set((ValueString)"a", 11);

            testChain2 = new Chain(12);
            testChain2.Set((ValueString)"a", 0);
            testChain2.Set((ValueString)"a", 1);
            testChain2.Set((ValueString)"a", 2);
            testChain2.Set((ValueString)"a", 3);
            testChain2.Set((ValueString)"a", 4);
            testChain2.Set((ValueString)"a", 5);
            testChain2.Set((ValueString)"b", 6);
            testChain2.Set((ValueString)"a", 7);
            testChain2.Set((ValueString)"a", 8);
            testChain2.Set((ValueString)"a", 9);
            testChain2.Set((ValueString)"b", 10);
            testChain2.Set((ValueString)"a", 11);
        }

        /// <summary>
        /// The generation not congeneric markov chain rang zero test.
        /// </summary>
        [Test]
        public void GenerationNotCongenericMarkovChainRangZeroTest()
        {
            var resultTheory = new Chain(10);
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

            var markov = new MarkovChainNotCongenericStatic(3, 0, new MockGenerator());
            markov.Teach(testChain, TeachingMethod.Cycle);
            var resultPractice = markov.Generate(10);
            Assert.AreEqual(resultTheory, resultPractice);
        }

        /// <summary>
        /// The generation congeneric markov chain level two test.
        /// </summary>
        [Test]
        public void GenerationCongenericMarkovChainLevelTwoTest()
        {
            var resultTheory = new Chain(30);
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

            var markov = new MarkovChainNotCongenericStatic(2, 0, new MockGenerator());
            markov.Teach(testChain2, TeachingMethod.Cycle);
            var resultPractice = markov.Generate(30);
            Assert.AreEqual(resultTheory, resultPractice);
        }
    }
}
