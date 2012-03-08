using NUnit.Framework;
using PhantomChains.Classes.Statistics.MarkovChain;
using PhantomChains.Classes.Statistics.MarkovChain.Generators;
using TestPhantomChains.Classes.Statistics.MarkovChain.Generators;

namespace TestPhantomChains.Classes.Statistics.MarkovChain
{
    /**
     * Тестируем неоднородную марковскую цепь 
     * неоднородная марковская цепь представляет собой 
     * несколько однородных марковских цепей каждая из которых 
     * ипользуется на определенном шаге
     * 
     **/
    [TestFixture]
    public class TestMarkovChainNotUniform
    {
        // Исходная цепь на которой будет происходить обучение
        private Chain TestChain = null;
        private Chain TestChain2 = null;

        [SetUp]
        public void init()
        {
            // Создаем цепь длинной 12
            // |a|d|b|a|a|c|b|b|a|a|c|a|
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

        [Test]
        public void TestMarkovChainNotUniform0Rang2()
        {
            // Используем генератор заглушку
            IGenerator Generator = new MockGenerator();
            // Порядок цепи 2 
            // Значит что каждый элемент зависит от одного предудушего
            int MarkovChainRang = 2;
            // неоднородность 1 
            // следовательно допускаем имеется 2 модели для четных и нечетных позиций
            int NoUniformRang = 0;
            // Создаем марковскую модель передавая её ранг, неоднородность и генератор
            MarkovChainNotUniformStatic<Chain, Chain> MarkovChain = new MarkovChainNotUniformStatic<Chain, Chain>(MarkovChainRang, NoUniformRang, Generator);

            // Длинна генерируемой цепи
            int Length = 30;
            // Обучаем цепь 
            // TeachingMethod.None значнт не какой предворительной обработки цепи не проводится
            MarkovChain.Teach(TestChain2, TeachingMethod.Cycle);

            Chain Temp = MarkovChain.Generate(Length);

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

            Assert.AreEqual(ResultTheory, Temp);
        }

        [Test]
        public void TestMarkovChainNotUniform1Rang2()
        {
            // Используем генератор заглушку
            IGenerator Generator = new MockGenerator();
            // Порядок цепи 2 
            // Значит что каждый элемент зависит от одного предудушего
            int MarkovChainRang = 2;
            // неоднородность 1 
            // следовательно допускаем имеется 2 модели для четных и нечетных позиций
            int NoUniformRang = 1;
            // Создаем марковскую модель передавая её ранг, неоднородность и генератор
            MarkovChainNotUniformStatic<Chain, Chain> MarkovChain = new MarkovChainNotUniformStatic<Chain, Chain>(MarkovChainRang, NoUniformRang, Generator);

            // Длинна генерируемой цепи
            int Length = 12;
            // Обучаем цепь 
            // TeachingMethod.None значнт не какой предворительной обработки цепи не проводится
            MarkovChain.Teach(TestChain, TeachingMethod.None);

            Chain Temp = MarkovChain.Generate(Length);

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
            Chain Result = new Chain(12);
            Result.Add((ValueString)"b", 0); // 1 цепь вероятность по первому уровню. выпало  0,77 Получаем b
            Result.Add((ValueString)"a", 1); // 2 цепь вероятность по второму уровню. выпало  0.15 Получаем a
            Result.Add((ValueString)"c", 2); // 1 цепь вероятность по второму уровню. выпало  0.96 Получаем с
            Result.Add((ValueString)"b", 3); // 2 цепь вероятность по второму уровню. выпало  0.61 Получаем b
            Result.Add((ValueString)"a", 4); // 1 цепь вероятность по второму уровню. выпало  0.15 Получаем a
            Result.Add((ValueString)"c", 5); // 2 цепь вероятность по второму уровню. выпало  0.85 Получаем c
            Result.Add((ValueString)"a", 6); // 1 цепь вероятность по второму уровню. выпало  0.67 Получаем a
            Result.Add((ValueString)"c", 7); // 2 цепь вероятность по второму уровню. выпало  0.51 Получаем c
            Result.Add((ValueString)"a", 8); // 1 цепь вероятность по второму уровню. выпало  0.71 Получаем a
            Result.Add((ValueString)"a", 9); // 2 цепь вероятность по второму уровню. выпало  0.2 Получаем a
            Result.Add((ValueString)"c", 10); // 1 цепь вероятность по второму уровню. выпало  0.77 Получаем с
            Result.Add((ValueString)"b", 11); // 2 цепь вероятность по второму уровню. выпало  0.15 Получаем b

            Assert.AreEqual(Result, Temp);
        }

        [Test]
        public void TestMarkovChainNotUniformDynamic0Rang2()
        {
            // Используем генератор заглушку
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

            Chain Temp = MarkovChain.Generate(Length);

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

            Assert.AreEqual(ResultTheory, Temp);
        }

        [Test]
        public void TestMarkovChainNotUniformDynamic1Rang2()
        {
            // Используем генератор заглушку
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

            Chain Temp = MarkovChain.Generate(Length);

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
            Chain Result = new Chain(12);
            Result.Add((ValueString)"b", 0); // 1 цепь вероятность по первому уровню. выпало  0,77 Получаем b
            Result.Add((ValueString)"a", 1); // 2 цепь вероятность по второму уровню. выпало  0.15 Получаем a
            Result.Add((ValueString)"c", 2); // 1 цепь вероятность по второму уровню. выпало  0.96 Получаем с
            Result.Add((ValueString)"b", 3); // 2 цепь вероятность по второму уровню. выпало  0.61 Получаем b
            Result.Add((ValueString)"a", 4); // 1 цепь вероятность по второму уровню. выпало  0.15 Получаем a
            Result.Add((ValueString)"c", 5); // 2 цепь вероятность по второму уровню. выпало  0.85 Получаем c
            Result.Add((ValueString)"a", 6); // 1 цепь вероятность по второму уровню. выпало  0.67 Получаем a
            Result.Add((ValueString)"c", 7); // 2 цепь вероятность по второму уровню. выпало  0.51 Получаем c
            Result.Add((ValueString)"a", 8); // 1 цепь вероятность по второму уровню. выпало  0.71 Получаем a
            Result.Add((ValueString)"a", 9); // 2 цепь вероятность по второму уровню. выпало  0.2 Получаем a
            Result.Add((ValueString)"c", 10); // 1 цепь вероятность по второму уровню. выпало  0.77 Получаем с
            Result.Add((ValueString)"b", 11); // 2 цепь вероятность по второму уровню. выпало  0.15 Получаем b

            Assert.AreEqual(Result, Temp);
        }
        
    }
}