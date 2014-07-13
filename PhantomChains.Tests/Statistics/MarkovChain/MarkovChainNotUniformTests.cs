namespace PhantomChains.Tests.Statistics.MarkovChain
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    using NUnit.Framework;

    using global::PhantomChains.Statistics.MarkovChain;

    using global::PhantomChains.Statistics.MarkovChain.Generators;

    using global::PhantomChains.Tests.Statistics.MarkovChain.Generators;

    /// <summary>
    /// Тестируем неоднородную марковскую цепь 
    /// неоднородная марковская цепь представляет собой 
    /// несколько однородных марковских цепей каждая из которых 
    /// ипользуется на определенном шаге
    /// </summary>
    [TestFixture]
    public class MarkovChainNotUniformTests
    {
        /// <summary>
        /// Исходная цепь на которой будет происходить обучение
        /// </summary>
        private Chain testChain;

        /// <summary>
        /// The test chain 2.
        /// </summary>
        private Chain testChain2;

        /// <summary>
        /// The init.
        /// </summary>
        [SetUp]
        public void Init()
        {
            // Создаем цепь длинной 12
            // |a|d|b|a|a|c|b|b|a|a|c|a|
            this.testChain = new Chain(12);
            this.testChain.Add((ValueString)"a", 0);
            this.testChain.Add((ValueString)"d", 1);
            this.testChain.Add((ValueString)"b", 2);
            this.testChain.Add((ValueString)"a", 3);
            this.testChain.Add((ValueString)"a", 4);
            this.testChain.Add((ValueString)"c", 5);
            this.testChain.Add((ValueString)"b", 6);
            this.testChain.Add((ValueString)"b", 7);
            this.testChain.Add((ValueString)"a", 8);
            this.testChain.Add((ValueString)"a", 9);
            this.testChain.Add((ValueString)"c", 10);
            this.testChain.Add((ValueString)"a", 11);

            this.testChain2 = new Chain(12);
            this.testChain2.Add((ValueString)"a", 0);
            this.testChain2.Add((ValueString)"a", 1);
            this.testChain2.Add((ValueString)"a", 2);
            this.testChain2.Add((ValueString)"a", 3);
            this.testChain2.Add((ValueString)"a", 4);
            this.testChain2.Add((ValueString)"a", 5);
            this.testChain2.Add((ValueString)"b", 6);
            this.testChain2.Add((ValueString)"a", 7);
            this.testChain2.Add((ValueString)"a", 8);
            this.testChain2.Add((ValueString)"a", 9);
            this.testChain2.Add((ValueString)"b", 10);
            this.testChain2.Add((ValueString)"a", 11);
        }

        /// <summary>
        /// The markov chain not uniform zero rang two test.
        /// </summary>
        [Test]
        public void MarkovChainNotUniformZeroRangTwoTest()
        {
            // Используем генератор заглушку
            IGenerator generator = new MockGenerator();

            // Порядок цепи 2 
            // Значит что каждый элемент зависит от одного предудушего
            const int MarkovChainRang = 2;

            // неоднородность 1 
            // следовательно допускаем имеется 2 модели для четных и нечетных позиций
            const int NoUniformRang = 0;

            // Создаем марковскую модель передавая её ранг, неоднородность и генератор
            var markovChain = new MarkovChainNotUniformStatic(MarkovChainRang, NoUniformRang, generator);

            // Длинна генерируемой цепи
            const int Length = 30;

            // Обучаем цепь 
            // TeachingMethod.None значнт не какой предворительной обработки цепи не проводится
            markovChain.Teach(this.testChain2, TeachingMethod.Cycle);

            var temp = markovChain.Generate(Length);

            /* 
             * 1. Цепь a a a a a a b a a a b a
             *   первый уровень (безусловная вероятность)
             *   
             *    a| 10/12 (0,83333)  не более 0,83333| 
             *    b| 2/12 (0,16667)  не более 1|
             * 
             *   второй уровень (условная с учетом 1 предыдущего элемента)
             * 
             *    |   a  |   b  |
             * ---|------|------|
             *  a |7/9(7)|2/9(2)|
             * ---|------|------|
             *  b |1,0(1)|0,0(0)|
             * ---|------|------|
             */

            // Цепь которую хотим получить
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
        /// The markov chain not uniform one rang two test.
        /// </summary>
        [Test]
        public void MarkovChainNotUniformOneRangTwoTest()
        {
            // Используем генератор заглушку
            IGenerator generator = new MockGenerator();

            // Порядок цепи 2 
            // Значит что каждый элемент зависит от одного предудушего
            const int MarkovChainRang = 2;

            // неоднородность 1 
            // следовательно допускаем имеется 2 модели для четных и нечетных позиций
            const int NoUniformRang = 1;

            // Создаем марковскую модель передавая её ранг, неоднородность и генератор
            var markovChain = new MarkovChainNotUniformStatic(MarkovChainRang, NoUniformRang, generator);

            // Длинна генерируемой цепи
            const int Length = 12;

            // Обучаем цепь 
            // TeachingMethod.None значнт не какой предворительной обработки цепи не проводится
            markovChain.Teach(this.testChain, TeachingMethod.None);

            var temp = markovChain.Generate(Length);

            /**
             * Внутри неоднородной марковской цепи существует n однородных марковских цепей. n - порядок неоднородности цепи
             * порядок данных однородных цепей равен порядку неоднородной цепи
             * однородные цепи используются по очереди как при обучении так и  при генерации.
             * 
             * В данном тесте внутри неоднородной марковской цепи есть 2 однородные цепи.
             * Матрицы переходных вероятностей (в скобках указано кол-во входений при обучении) в них такие
             * 
             * 1. Цепь 
             *   первый уровень (безусловная вероятность)
             *   
             *    a| 1/2 (3) |
             *    b| 1/3 (2) |
             *    c| 1/6 (1) |
             *    d| 0 (0)   |
             * 
             *   второй уровень (условная с учетом 1 предыдущего элемента)
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
             * 2. Цепь 
             *   первый уровень (безусловная вероятность)
             *   
             *    a| 2/5 (2) |
             *    b| 1/5 (1) |
             *    c| 1/5 (1) |
             *    d| 1/5 (1) |
             * 
             *   второй уровень (условная с учетом 1 предыдущего элемента)
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
             * при обученни так будут заноситься фрагменты 
             *   |-| |-| |-| |-| |-|   <>- Во вторую цепь
             * a d b a a c b b a a c a
             * |_| |_| |_| |_| |_| |_| <>- В первую цепь
             * 
             */

            // Цепь которую хотим получить
            var result = new Chain(12);
            result.Add((ValueString)"b", 0); // 1 цепь вероятность по первому уровню. выпало  0,77 Получаем b
            result.Add((ValueString)"a", 1); // 2 цепь вероятность по второму уровню. выпало  0.15 Получаем a
            result.Add((ValueString)"c", 2); // 1 цепь вероятность по второму уровню. выпало  0.96 Получаем с
            result.Add((ValueString)"b", 3); // 2 цепь вероятность по второму уровню. выпало  0.61 Получаем b
            result.Add((ValueString)"a", 4); // 1 цепь вероятность по второму уровню. выпало  0.15 Получаем a
            result.Add((ValueString)"c", 5); // 2 цепь вероятность по второму уровню. выпало  0.85 Получаем c
            result.Add((ValueString)"a", 6); // 1 цепь вероятность по второму уровню. выпало  0.67 Получаем a
            result.Add((ValueString)"c", 7); // 2 цепь вероятность по второму уровню. выпало  0.51 Получаем c
            result.Add((ValueString)"a", 8); // 1 цепь вероятность по второму уровню. выпало  0.71 Получаем a
            result.Add((ValueString)"a", 9); // 2 цепь вероятность по второму уровню. выпало  0.2 Получаем a
            result.Add((ValueString)"c", 10); // 1 цепь вероятность по второму уровню. выпало  0.77 Получаем с
            result.Add((ValueString)"b", 11); // 2 цепь вероятность по второму уровню. выпало  0.15 Получаем b

            Assert.AreEqual(result, temp);
        }

        /// <summary>
        /// The markov chain not uniform dynamic zero rang two test.
        /// </summary>
        [Test]
        public void MarkovChainNotUniformDynamicZeroRangTwoTest()
        {
            /*  // Используем генератор заглушку
            IGenerator Generator = new MockGenerator();
            // Порядок цепи 2 
            // Значит что каждый элемент зависит от одного предудушего
            int MarkovChainRang = 2;
            // неоднородность 1 
            // следовательно допускаем имеется 2 модели для четных и нечетных позиций
            int NoUniformRang = 0;
            // Создаем марковскую модель передавая её ранг, неоднородность и генератор
            MarkovChainNotUniformDynamic<Chain, Chain> MarkovChain = new MarkovChainNotUniformDynamic<Chain, Chain>(MarkovChainRang, NoUniformRang, Generator);

            // Длинна генерируемой цепи
            int Length = 30;
            // Обучаем цепь 
            // TeachingMethod.None значнт не какой предворительной обработки цепи не проводится
            MarkovChain.Teach(TestChain2, TeachingMethod.Cycle);

            Chain Temp = MarkovChain.Generate(Length);*/

            /* 
             * 1. Цепь a a a a a a b a a a b a
             *   первый уровень (безусловная вероятность)
             *   
             *    a| 10/12 (0,83333)  не более 0,83333| 
             *    b| 2/12 (0,16667)  не более 1|
             * 
             *   второй уровень (условная с учетом 1 предыдущего элемента)
             * 
             *    |   a  |   b  |
             * ---|------|------|
             *  a |7/9(7)|2/9(2)|
             * ---|------|------|
             *  b |1,0(1)|0,0(0)|
             * ---|------|------|
             */

            // Цепь которую хотим получить
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
        /// The markov chain not uniform dynamic one rang two test.
        /// </summary>
        [Test]
        public void MarkovChainNotUniformDynamicOneRangTwoTest()
        {
            /*   // Используем генератор заглушку
            IGenerator Generator = new MockGenerator();
            // Порядок цепи 2 
            // Значит что каждый элемент зависит от одного предудушего
            int MarkovChainRang = 2;
            // неоднородность 1 
            // следовательно допускаем имеется 2 модели для четных и нечетных позиций
            int NoUniformRang = 1;
            // Создаем марковскую модель передавая её ранг, неоднородность и генератор
            MarkovChainNotUniformDynamic<Chain, Chain> MarkovChain = new MarkovChainNotUniformDynamic<Chain, Chain>(MarkovChainRang, NoUniformRang, Generator);

            // Длинна генерируемой цепи
            int Length = 12;
            // Обучаем цепь 
            // TeachingMethod.None значнт не какой предворительной обработки цепи не проводится
            MarkovChain.Teach(TestChain, TeachingMethod.None);

            Chain Temp = MarkovChain.Generate(Length);*/

            /**
             * Внутри неоднородной марковской цепи существует n однородных марковских цепей. n - порядок неоднородности цепи
             * порядок данных однородных цепей равен порядку неоднородной цепи
             * однородные цепи используются по очереди как при обучении так и  при генерации.
             * 
             * В данном тесте внутри неоднородной марковской цепи есть 2 однородные цепи.
             * Матрицы переходных вероятностей (в скобках указано кол-во входений при обучении) в них такие
             * 
             * 1. Цепь 
             *   первый уровень (безусловная вероятность)
             *   
             *    a| 1/2 (3) |
             *    b| 1/3 (2) |
             *    c| 1/6 (1) |
             *    d| 0 (0)   |
             * 
             *   второй уровень (условная с учетом 1 предыдущего элемента)
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
             * 2. Цепь 
             *   первый уровень (безусловная вероятность)
             *   
             *    a| 2/5 (2) |
             *    b| 1/5 (1) |
             *    c| 1/5 (1) |
             *    d| 1/5 (1) |
             * 
             *   второй уровень (условная с учетом 1 предыдущего элемента)
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
             * при обученни так будут заноситься фрагменты 
             *   |-| |-| |-| |-| |-|   <>- Во вторую цепь
             * a d b a a c b b a a c a
             * |_| |_| |_| |_| |_| |_| <>- В первую цепь
             * 
             */

            // Цепь которую хотим получить
            var result = new Chain(12);
            result.Add((ValueString)"b", 0); // 1 цепь вероятность по первому уровню. выпало  0,77 Получаем b
            result.Add((ValueString)"a", 1); // 2 цепь вероятность по второму уровню. выпало  0.15 Получаем a
            result.Add((ValueString)"c", 2); // 1 цепь вероятность по второму уровню. выпало  0.96 Получаем с
            result.Add((ValueString)"b", 3); // 2 цепь вероятность по второму уровню. выпало  0.61 Получаем b
            result.Add((ValueString)"a", 4); // 1 цепь вероятность по второму уровню. выпало  0.15 Получаем a
            result.Add((ValueString)"c", 5); // 2 цепь вероятность по второму уровню. выпало  0.85 Получаем c
            result.Add((ValueString)"a", 6); // 1 цепь вероятность по второму уровню. выпало  0.67 Получаем a
            result.Add((ValueString)"c", 7); // 2 цепь вероятность по второму уровню. выпало  0.51 Получаем c
            result.Add((ValueString)"a", 8); // 1 цепь вероятность по второму уровню. выпало  0.71 Получаем a
            result.Add((ValueString)"a", 9); // 2 цепь вероятность по второму уровню. выпало  0.2 Получаем a
            result.Add((ValueString)"c", 10); // 1 цепь вероятность по второму уровню. выпало  0.77 Получаем с
            result.Add((ValueString)"b", 11); // 2 цепь вероятность по второму уровню. выпало  0.15 Получаем b
        }
    }
}