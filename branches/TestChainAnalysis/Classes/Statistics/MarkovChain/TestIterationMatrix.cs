using System;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.SpaceRebuilders;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability;
using ChainAnalises.Classes.Statistics.MarkovChain;
using TestChainAnalysis.Classes.Statistics.MarkovChain.Generators;
using ChainAnalises.Classes.TheoryOfSet;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.Statistics.MarkovChain
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestIterationMatrix
    {
        private Chain TestChain = null;
        private Alphabet alph;
        private ValueChar a;
        private ValueChar b;
        private ValueChar c;
        private ValueChar d;
        private ValueChar f;
        private BaseChain ch;
        private ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute.Matrix matr;

        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
            alph = new Alphabet();
            a = new ValueChar('a');
            b = new ValueChar('b');
            c = new ValueChar('c');
            d = new ValueChar('d');
            f = new ValueChar('f');

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
        }

        ///<summary>
        ///</summary>
        [Test]
        [ExpectedException(typeof (Exception))]
        [Ignore]
        public void TestAddLengthMoreThanChainRang()
        {
            alph.Add(a);
            alph.Add(b);
            alph.Add(c);
            alph.Add(d);

            ch = new BaseChain(3);

            ch.Add(a, 0);
            ch.Add(b, 1);
            ch.Add(b, 2);

            matr = new ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute.Matrix(alph.power, 2);
            int[] array_ch = new int[ch.Length];
            array_ch[0] = alph.IndexOf(ch[0]);
            array_ch[1] = alph.IndexOf(ch[1]);
            array_ch[2] = alph.IndexOf(ch[2]);
            matr.Add(array_ch);
        }

        ///<summary>
        ///</summary>
        /*[Test]
        [Ignore]
        public void TestGet()
        {
            // Заполняем 
            alph.Add(a);
            alph.Add(b);
            alph.Add(c);
            alph.Add(d);

            ch = new BaseChain(2);
            BaseChain ch1 = new BaseChain(2);
            BaseChain ch2 = new BaseChain(2);
            BaseChain ch_1 = new BaseChain(2);
            BaseChain ch1_1 = new BaseChain(2);

            BaseChain ch3 = new BaseChain(1);
            BaseChain ch4 = new BaseChain(1);
            BaseChain ch5 = new BaseChain(1);

            ch.Add(a, 0);
            ch.Add(b, 1);

            ch_1.Add(b, 0);
            ch_1.Add(a, 1);

            ch1.Add(c, 0);
            ch1.Add(b, 1);

            ch1_1.Add(b, 0);
            ch1_1.Add(c, 1);


            matr = new ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute.Matrix(alph, 2);
            matr.Add(ch1);
            matr.Add(ch_1);
            matr.Add(ch);
            matr.Add(ch1_1);
            matr.Add(ch1);
            matr.Add(ch1_1);


            Assert.AreEqual(2, matr.FrequencyFromObject(ch1));

            ch2.Add(a, 0);
            ch2.Add(c, 1);

            Assert.AreEqual(0, matr.FrequencyFromObject(ch2));

            ch3.Add(b, 0);
            Assert.AreEqual(3, matr.FrequencyFromObject(ch3));

            ch4.Add(a, 0);
            Assert.AreEqual(1, matr.FrequencyFromObject(ch4));

            ch5.Add(c, 0);
            Assert.AreEqual(2, matr.FrequencyFromObject(ch5));


        }*/

        ///<summary>
        ///</summary>
        [Test]
        public void TestGetWithIndexes()
        {
            // Заполняем Алфавит элементами из которых может состоять цепь
            alph.Add(a); // 0 => a
            alph.Add(b); // 1 => b
            alph.Add(c); // 2 => c
            alph.Add(d); // 3 => d

            // Вместо итератора перемещаюшегося по одной цепи используем 
            // несколько цепей которые используются в качестве очередных окон (значений) итератора
            // Значния итератора используемые для записи в матрицу
                      ch = new BaseChain(2); // Значение итератора 1
            BaseChain ch1 = new BaseChain(2); // Значение итератора 2
            BaseChain ch_1 = new BaseChain(2); // Значение итератора 3
            BaseChain ch1_1 = new BaseChain(2); // Значение итератора 4

            // Значния итератора используемые при чтении из матрицы
            BaseChain ch2 = new BaseChain(2); // Значение итератора 5
            BaseChain ch3 = new BaseChain(1); // Значение итератора 6
            BaseChain ch4 = new BaseChain(1); // Значение итератора 7
            BaseChain ch5 = new BaseChain(1); // Значение итератора 8

            ch.Add(a, 0);  // Заполним значение итератора 1
            ch.Add(b, 1);  // ab

            ch1.Add(c, 0); // Заполним значение итератора 2
            ch1.Add(b, 1); // bc


            ch_1.Add(b, 0); // Заполним значение итератора 3
            ch_1.Add(a, 1); // ba


            ch1_1.Add(b, 0); // Заполним значение итератора 4
            ch1_1.Add(c, 1);// bc


            // Создаем матрицу с мошностью алфавита равной мощности алфавита на котором определена цепь  и рангом равном           
            // размеру окна итератора (использыемого при обучении и чтении)
            // Старая версия интерфейса (вызята из теста ) TestGet()
            /*matr = new ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute.Matrix(alph, 2);*/
            // Теперь выглядет так
            matr = new ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute.Matrix(alph.power, 2);

            // Для обучени используем теперь не цепь а массив int
            // Старая версия интерфейса (вызята из теста ) TestGet()
            /*matr.Add(ch1);*/

            // Теперь выглядет так
            // Заменяем цепь массивом а элементы их индексом
            int[] array_to_teach = new int[2];
            array_to_teach[0] = alph.IndexOf(ch1[0]);
            array_to_teach[1] = alph.IndexOf(ch1[1]);
            matr.Add(array_to_teach); // Добавили в матрицу сh1 (bc) 

            // Теперь выглядет так
            // Заменяем цепь массивом а элементы их индексом
            array_to_teach = new int[2];
            array_to_teach[0] = alph.IndexOf(ch_1[0]);
            array_to_teach[1] = alph.IndexOf(ch_1[1]);
            matr.Add(array_to_teach); // Добавили в матрицу сh_1 (ba)

            // Теперь выглядет так
            // Заменяем цепь массивом а элементы их индексом
            array_to_teach = new int[2];
            array_to_teach[0] = alph.IndexOf(ch[0]);
            array_to_teach[1] = alph.IndexOf(ch[1]);
            matr.Add(array_to_teach); // Добавили в матрицу сh (ab)

            // Теперь выглядет так
            // Заменяем цепь массивом а элементы их индексом
            array_to_teach = new int[2];
            array_to_teach[0] = alph.IndexOf(ch1_1[0]);
            array_to_teach[1] = alph.IndexOf(ch1_1[1]);
            matr.Add(array_to_teach); // Добавили в матрицу сh1_1 (bc)

            // Теперь выглядет так
            // Заменяем цепь массивом а элементы их индексом
            array_to_teach = new int[2];
            array_to_teach[0] = alph.IndexOf(ch1[0]);
            array_to_teach[1] = alph.IndexOf(ch1[1]);
            matr.Add(array_to_teach); // Добавили в матрицу сh1 (bc) 


            // Теперь выглядет так
            // Заменяем цепь массивом а элементы их индексом
            array_to_teach = new int[2];
            array_to_teach[0] = alph.IndexOf(ch1_1[0]);
            array_to_teach[1] = alph.IndexOf(ch1_1[1]);
            matr.Add(array_to_teach); // Добавили в матрицу сh1_1 (bc)


            // Проверяем что фрагмент bc (ch1) встретилось 2 раза
            // Для чтении используем теперь не цепь а массив int
            // Старая версия интерфейса (вызята из теста ) TestGet()
            /*Assert.AreEqual(2, matr.FrequencyFromObject(ch1));*/

            // Теперь выглядет так
            // Заменяем цепь массивом а элементы их индексом
            array_to_teach = new int[2];
            array_to_teach[0] = alph.IndexOf(ch1[0]);
            array_to_teach[1] = alph.IndexOf(ch1[1]);
            Assert.AreEqual(2, matr.FrequencyFromObject(array_to_teach));

            // Заполняем значение итератора сh2 
            ch2.Add(a, 0); // ac
            ch2.Add(c, 1);

            // Проверяем что фрагмент ac (ch2) встретилось 0 раза
            array_to_teach = new int[2];
            array_to_teach[0] = alph.IndexOf(ch2[0]);
            array_to_teach[1] = alph.IndexOf(ch2[1]);
            Assert.AreEqual(0, matr.FrequencyFromObject(array_to_teach));

            // Заполняем значение итератора сh3 
            ch3.Add(b, 0); // b

            // Проверяем что фрагмент b (ch3) встретилось 3 раза
            array_to_teach = new int[1];
            array_to_teach[0] = alph.IndexOf(ch3[0]);
            Assert.AreEqual(3, matr.FrequencyFromObject(array_to_teach));

            // Заполняем значение итератора сh4 
            ch4.Add(a, 0); // a

            // Проверяем что фрагмент a (ch4) встретилось 1 раза
            array_to_teach = new int[1];
            array_to_teach[0] = alph.IndexOf(ch4[0]);
            Assert.AreEqual(1, matr.FrequencyFromObject(array_to_teach));

            // Заполняем значение итератора сh5 
            ch5.Add(c, 0); // c

            // Проверяем что фрагмент c (ch5) встретилось 2 раза
            array_to_teach = new int[1];
            array_to_teach[0] = alph.IndexOf(ch5[0]);
            Assert.AreEqual(2, matr.FrequencyFromObject(array_to_teach));
        }



        ///<summary>
        ///</summary>
        [Test]
        [Ignore]
        public void TestGetThirdLevelChain()
        {
            matr = new ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute.Matrix(TestChain.Alpahbet.power, 3);

            PsevdoCycleSpace<Chain, Chain> Rebuilder = new PsevdoCycleSpace<Chain, Chain>(2);
            TestChain = Rebuilder.Rebuild(TestChain);

            IteratorStart<Chain, Chain> It = new IteratorStart<Chain, Chain>(TestChain, 3, 1);
            while(It.Next())
            {
                Chain chain = It.Current();
                int[] array_to_teach = new int[chain.Length];
                for (int i = 0; i < chain.Length; i++)
                {
                    array_to_teach[i] = TestChain.Alpahbet.IndexOf(chain[i]);
                }
                matr.Add(array_to_teach);
            }

            int[] ToGet = new int[1];

            // Проверяем безусловные вероятности
            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(6, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(3, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet = new int[2];

            // Проверяем переходыне вероятности марковской цепи 2 порядка
            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(3, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(2, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c"); ;
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet = new int[3];

            // Проверяем переходыне вероятности марковской цепи 1 порядка
            // Если первое событие а
            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(2, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            // Если первое событие b

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(2, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            // Если первое событие c
            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            // Если первое событие d
            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, matr.FrequencyFromObject(ToGet));
        }

        ///<summary>
        ///</summary>
        [Test]
        [Ignore]
        public void TestGetPropabilityMatix()
        {
            matr = new ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute.Matrix(TestChain.Alpahbet.power, 3);

            PsevdoCycleSpace<Chain, Chain> Rebuilder = new PsevdoCycleSpace<Chain, Chain>(2);
            TestChain = Rebuilder.Rebuild(TestChain);

            IteratorStart<Chain, Chain> It = new IteratorStart<Chain, Chain>(TestChain, 3, 1);
            while (It.Next())
            {
                Chain chain = It.Current();
                int[] array_to_teach = new int[chain.Length];
                for (int i = 0; i < chain.Length; i++)
                {
                    array_to_teach[i] = TestChain.Alpahbet.IndexOf(chain[i]);
                }
                matr.Add(array_to_teach);
            }

            ProbabilityMatrix PMatrix = (ProbabilityMatrix) matr.ProbabilityMatrix();

            int[] ToGet = new int[1];

            // Проверяем безусловные вероятности
            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.25, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(1/(double)6, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)12, PMatrix.FrequencyFromObject(ToGet));

            ToGet = new int[2];

            // Проверяем переходыне вероятности марковской цепи 2 порядка
            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(1 / (double)3, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)6, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(2 / (double)3, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(1 / (double)3, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.5, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet = new int[3];

            // Проверяем переходыне вероятности марковской цепи 1 порядка
            // Если первое событие а
            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(2 / (double)3, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            Assert.AreEqual(1 / (double)3, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(0.5, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0.5, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            // Если первое событие b

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            // Если первое событие c
            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(1, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            // Если первое событие d
            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(1, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"a");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"c");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

            ToGet[0] = TestChain.Alpahbet.IndexOf((ValueString)"d");
            ToGet[1] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            ToGet[2] = TestChain.Alpahbet.IndexOf((ValueString)"b");
            Assert.AreEqual(0, PMatrix.FrequencyFromObject(ToGet));

        }

        ///<summary>
        ///</summary>
        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        [Ignore]
        public void TestILargerN()
        {
            alph.Add(a);
            alph.Add(b);
            alph.Add(c);
            alph.Add(d);

            ch = new BaseChain(2);
            ch.Add(f, 0);
            ch.Add(c, 1);

            matr = new ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute.Matrix(alph.power, 2);
            int[] array = new int[ch.Length];
            array[0] = alph.IndexOf(ch[0]);
            array[1] = alph.IndexOf(ch[1]);
            matr.FrequencyFromObject(array);
        }
    }
}