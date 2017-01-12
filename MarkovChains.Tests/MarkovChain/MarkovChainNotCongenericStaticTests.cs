namespace MarkovChains.Tests.MarkovChain
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using MarkovChains.MarkovChain;
    using MarkovChains.MarkovChain.Generators;
    using MarkovChains.Tests.MarkovChain.Generators;

    using NUnit.Framework;

    /// <summary>
    /// Tests of non congeneric markov chain.
    /// Non congeneric (heterogeneous) chain is several separated markov chains (matrixes)
    /// each one is used on separate step.
    /// </summary>
    [TestFixture]
    public class MarkovChainNotCongenericStaticTests
    {
        /// <summary>
        /// Source sequence for teaching markov chain.
        /// </summary>
        private Chain testChain;

        /// <summary>
        /// Another sequence for teaching markov chain.
        /// </summary>
        private Chain secondTestChain;

        /// <summary>
        /// The initialization method.
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            // Creating sequence containing 12 elements.
            // |a|d|b|a|a|c|b|b|a|a|c|a|
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

            secondTestChain = new Chain(12);
            secondTestChain.Set((ValueString)"a", 0);
            secondTestChain.Set((ValueString)"a", 1);
            secondTestChain.Set((ValueString)"a", 2);
            secondTestChain.Set((ValueString)"a", 3);
            secondTestChain.Set((ValueString)"a", 4);
            secondTestChain.Set((ValueString)"a", 5);
            secondTestChain.Set((ValueString)"b", 6);
            secondTestChain.Set((ValueString)"a", 7);
            secondTestChain.Set((ValueString)"a", 8);
            secondTestChain.Set((ValueString)"a", 9);
            secondTestChain.Set((ValueString)"b", 10);
            secondTestChain.Set((ValueString)"a", 11);
        }

        /// <summary>
        /// The markov chain not congeneric zero rank two test.
        /// </summary>
        [Test]
        public void MarkovChainNotCongenericZeroRankTwoTest()
        {
            // using mock of random generator
            IGenerator generator = new MockGenerator();

            // rank of markov chain is 2 (each element depends on one previous element)
            const int MarkovChainRank = 2;

            // heterogeneity is 1 (there are 2 models - for odd and even positions)
            const int NoCongenericRank = 0;

            // creating markov chain
            var markovChain = new MarkovChainNotCongenericStatic(MarkovChainRank, NoCongenericRank, generator);

            // length of generated sequence
            const int Length = 30;

            // teaching markov chain (TeachingMethod.None means there is no preprocessing)
            markovChain.Teach(secondTestChain, TeachingMethod.Cycle);

            var temp = markovChain.Generate(Length);

            /*
             * 1. Sequence a a a a a a b a a a b a
             *   first level (unconditional probability)
             *
             *    a| 10/12 (0,83333)  not more than 0,83333|
             *    b| 2/12 (0,16667)  not more than 1|
             *
             *   second level (conditional probability taking into account 1 previous element)
             *
             *    |   a  |   b  |
             * ---|------|------|
             *  a |7/9(7)|2/9(2)|
             * ---|------|------|
             *  b |1,0(1)|0,0(0)|
             * ---|------|------|
             */

            // expected result of generation
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

            Assert.AreEqual(resultTheory, temp);
        }

        /// <summary>
        /// The markov chain not congeneric one rank two test.
        /// </summary>
        [Test]
        public void MarkovChainNotCongenericOneRangTwoTest()
        {
            // using mock of random generator
            IGenerator generator = new MockGenerator();

            // rank of markov chain is 2 (each element depends on one previous element)
            const int MarkovChainRank = 2;

            // heterogeneity is 1 (there are 2 models - for odd and even positions)
            const int NoCongenericRank = 1;

            // creating markov chain
            var markovChain = new MarkovChainNotCongenericStatic(MarkovChainRank, NoCongenericRank, generator);

            // length of generated sequence
            const int Length = 12;

            // teaching markov chain (TeachingMethod.None means there is no preprocessing)
            markovChain.Teach(testChain, TeachingMethod.None);

            var temp = markovChain.Generate(Length);

            /*
             * Внутри неоднородной марковской цепи существует n однородных марковских цепей. n - порядок неоднородности цепи
             * порядок данных однородных цепей равен порядку неоднородной цепи
             * однородные цепи используются по очереди как при обучении так и  при генерации.
             *
             * В данном тесте внутри неоднородной марковской цепи есть 2 однородные цепи.
             * Матрицы переходных вероятностей (в скобках указано кол-во входений при обучении) в них такие
             *
             * 1. Sequence
             *   first level (unconditional probability)
             *
             *    a| 1/2 (3) |
             *    b| 1/3 (2) |
             *    c| 1/6 (1) |
             *    d| 0 (0)   |
             *
             *   second level (conditional probability taking into account 1 previous element)
             *
             *    |   a  |   b  |  с   |  d   |
             * ---|------|------|------|------|
             *  a |0,3(1)| 0(0) |0,3(1)|0,3(1)|
             * ---|------|------|------|------|
             *  b |0,5(1)|0,5(1)| 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  c | 1(1) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  d | 0(0) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *
             * 2. Sequence
             *   first level (unconditional probability)
             *
             *    a| 2/5 (2) |
             *    b| 1/5 (1) |
             *    c| 1/5 (1) |
             *    d| 1/5 (1) |
             *
             *   second level (conditional probability taking into account 1 previous element)
             *
             *    |   a  |   b  |  с   |  d   |
             * ---|------|------|------|------|
             *  a |0,5(1)| 0(0) |0,5(1)| 0(0) |
             * ---|------|------|------|------|
             *  b | 1(1) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  c | 0(0) | 1(1) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  d | 0(0) | 1(1) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *
             *
             * During teaching pairs are added as folowing
             *   |-| |-| |-| |-| |-|   <>- In second markov chain
             * a d b a a c b b a a c a
             * |_| |_| |_| |_| |_| |_| <>- In first markov chain
             *
             */

            // expected result of generation
            var result = new Chain(12);
            result.Set((ValueString)"b", 0); // 1 chain. цепь вероятность по первому уровню. выпало  0,77 Получаем b
            result.Set((ValueString)"a", 1); // 2 chain. вероятность по второму уровню. выпало  0.15 Получаем a
            result.Set((ValueString)"c", 2); // 1 chain. вероятность по второму уровню. выпало  0.96 Получаем с
            result.Set((ValueString)"b", 3); // 2 chain. вероятность по второму уровню. выпало  0.61 Получаем b
            result.Set((ValueString)"a", 4); // 1 chain. вероятность по второму уровню. выпало  0.15 Получаем a
            result.Set((ValueString)"c", 5); // 2 chain. вероятность по второму уровню. выпало  0.85 Получаем c
            result.Set((ValueString)"a", 6); // 1 chain. вероятность по второму уровню. выпало  0.67 Получаем a
            result.Set((ValueString)"c", 7); // 2 chain. вероятность по второму уровню. выпало  0.51 Получаем c
            result.Set((ValueString)"a", 8); // 1 chain. вероятность по второму уровню. выпало  0.71 Получаем a
            result.Set((ValueString)"a", 9); // 2 chain. вероятность по второму уровню. выпало  0.2 Получаем a
            result.Set((ValueString)"c", 10); // 1 chain. вероятность по второму уровню. выпало  0.77 Получаем с
            result.Set((ValueString)"b", 11); // 2 chain. вероятность по второму уровню. выпало  0.15 Получаем b

            Assert.AreEqual(result, temp);
        }

        /// <summary>
        /// The markov chain not congeneric dynamic zero rank two test.
        /// </summary>
        [Test]
        public void MarkovChainNotCongenericDynamicZeroRangTwoTest()
        {
              // using mock of random generator
            IGenerator generator = new MockGenerator();

            // rank of markov chain is 2 (each element depends on one previous element)
            int markovChainRank = 2;

            // heterogeneity is 1 (there are 2 models - for odd and even positions)
            int notCongenericRank = 0;

            // creating markov chain
            // MarkovChainNotCongenericDynamic<Chain, Chain> MarkovChain = new MarkovChainNotCongenericDynamic<Chain, Chain>(markovChainRank, notCongenericRank, generator);

            // length of generated sequence
            int length = 30;

            // teaching markov chain (TeachingMethod.None means there is no preprocessing)
            // MarkovChain.Teach(secondTestChain, TeachingMethod.Cycle);

            // Chain Temp = MarkovChain.Generate(length);

            /*
             * 1. Sequence a a a a a a b a a a b a
             *   first level (unconditional probability)
             *
             *    a| 10/12 (0,83333) not more than 0,83333|
             *    b| 2/12 (0,16667)  not more than 1|
             *
             *   second level (conditional probability taking into account 1 previous element)
             *
             *    |   a  |   b  |
             * ---|------|------|
             *  a |7/9(7)|2/9(2)|
             * ---|------|------|
             *  b |1,0(1)|0,0(0)|
             * ---|------|------|
             */

            // expected result of generation
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
        }

        /// <summary>
        /// The markov chain not congeneric dynamic one rank two test.
        /// </summary>
        [Test]
        public void MarkovChainNotCongenericDynamicOneRangTwoTest()
        {
            // using mock of random generator
            IGenerator generator = new MockGenerator();

            // rank of markov chain is 2 (each element depends on one previous element)
            int markovChainRank = 2;

            // heterogeneity is 1 (there are 2 models - for odd and even positions)
            int notCongenericRank = 1;

            // creating markov chain
            // MarkovChainNotCongenericDynamic<Chain, Chain> MarkovChain = new MarkovChainNotCongenericDynamic<Chain, Chain>(markovChainRank, notCongenericRank, generator);

            // length of generated sequence
            int length = 12;

            // teaching markov chain (TeachingMethod.None means there is no preprocessing)
            // MarkovChain.Teach(TestChain, TeachingMethod.None);

            // Chain Temp = MarkovChain.Generate(length);

            /**
             * Внутри неоднородной марковской цепи существует n однородных марковских цепей. n - порядок неоднородности цепи
             * порядок данных однородных цепей равен порядку неоднородной цепи
             * однородные цепи используются по очереди как при обучении так и  при генерации.
             *
             * В данном тесте внутри неоднородной марковской цепи есть 2 однородные цепи.
             * Матрицы переходных вероятностей (в скобках указано кол-во входений при обучении) в них такие
             *
             * 1. Sequence
             *   first level (unconditional probability)
             *
             *    a| 1/2 (3) |
             *    b| 1/3 (2) |
             *    c| 1/6 (1) |
             *    d| 0 (0)   |
             *
             *   second level (conditional probability taking into account 1 previous element)
             *
             *    |   a  |   b  |  с   |  d   |
             * ---|------|------|------|------|
             *  a |0,3(1)| 0(0) |0,3(1)|0,3(1)|
             * ---|------|------|------|------|
             *  b |0,5(1)|0,5(1)| 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  c | 1(1) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  d | 0(0) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *
             * 2. Sequence
             *   first level (unconditional probability)
             *
             *    a| 2/5 (2) |
             *    b| 1/5 (1) |
             *    c| 1/5 (1) |
             *    d| 1/5 (1) |
             *
             *   second level (conditional probability taking into account 1 previous element)
             *
             *    |   a  |   b  |  с   |  d   |
             * ---|------|------|------|------|
             *  a |0,5(1)| 0(0) |0,5(1)| 0(0) |
             * ---|------|------|------|------|
             *  b | 1(1) | 0(0) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  c | 0(0) | 1(1) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *  d | 0(0) | 1(1) | 0(0) | 0(0) |
             * ---|------|------|------|------|
             *
             *
             * During teaching pairs are added as folowing
             *   |-| |-| |-| |-| |-|   <>- In second markov chain
             * a d b a a c b b a a c a
             * |_| |_| |_| |_| |_| |_| <>- In first markov chain
             *
             */

            // expected result of generation
            var result = new Chain(12);
            result.Set((ValueString)"b", 0); // 1 chain. вероятность по первому уровню. выпало  0,77 Получаем b
            result.Set((ValueString)"a", 1); // 2 chain. вероятность по второму уровню. выпало  0.15 Получаем a
            result.Set((ValueString)"c", 2); // 1 chain. вероятность по второму уровню. выпало  0.96 Получаем с
            result.Set((ValueString)"b", 3); // 2 chain. вероятность по второму уровню. выпало  0.61 Получаем b
            result.Set((ValueString)"a", 4); // 1 chain. вероятность по второму уровню. выпало  0.15 Получаем a
            result.Set((ValueString)"c", 5); // 2 chain. вероятность по второму уровню. выпало  0.85 Получаем c
            result.Set((ValueString)"a", 6); // 1 chain. вероятность по второму уровню. выпало  0.67 Получаем a
            result.Set((ValueString)"c", 7); // 2 chain. вероятность по второму уровню. выпало  0.51 Получаем c
            result.Set((ValueString)"a", 8); // 1 chain. вероятность по второму уровню. выпало  0.71 Получаем a
            result.Set((ValueString)"a", 9); // 2 chain. вероятность по второму уровню. выпало  0.2 Получаем a
            result.Set((ValueString)"c", 10); // 1 chain. вероятность по второму уровню. выпало  0.77 Получаем с
            result.Set((ValueString)"b", 11); // 2 chain. вероятность по второму уровню. выпало  0.15 Получаем b
        }
    }
}
