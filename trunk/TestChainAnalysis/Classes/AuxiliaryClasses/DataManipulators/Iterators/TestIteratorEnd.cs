using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.AuxiliaryClasses.DataManipulators.Iterators
{
    ///<summary>
    /// Тесты для IteratorEnd
    ///</summary>
    [TestFixture]
    public class TestIteratorEnd
    {
        private Chain ChainToIterate;

        ///<summary>
        /// Инициализация  
        ///</summary>
        [SetUp]
        public void init()
        {
            // длинна цепи для инетрации 12
            // цепь = 121331212231
            ChainToIterate = new Chain(12);
            ChainToIterate.Add(new ValueChar('1'), 0);
            ChainToIterate.Add(new ValueChar('2'), 1);
            ChainToIterate.Add(new ValueChar('1'), 2);

            ChainToIterate.Add(new ValueChar('3'), 3);
            ChainToIterate.Add(new ValueChar('3'), 4);
            ChainToIterate.Add(new ValueChar('1'), 5);

            ChainToIterate.Add(new ValueChar('2'), 6);
            ChainToIterate.Add(new ValueChar('1'), 7);
            ChainToIterate.Add(new ValueChar('2'), 8);

            ChainToIterate.Add(new ValueChar('2'), 9);
            ChainToIterate.Add(new ValueChar('3'), 10);
            ChainToIterate.Add(new ValueChar('1'), 11);
        }

        ///<summary>
        /// Тестируем считывание l-граммами 
        ///</summary>
        [Test]
        public void TestReadWindowMode()
        {
            // Длинна возврашаемого фрагмента 3
            int length = 3;
            // Шаг итерации 1
            int step = 1;
            IteratorEnd<Chain, Chain> Iterator = new IteratorEnd<Chain, Chain>(ChainToIterate, length, step);
            // Кол-во итерациий 12 - 3 + 1
            Chain[] Message2 = new Chain[10];
            // С конца 
            // Возвращаемый фрагмент 121
            // |121|331212231
            Message2[9] = new Chain(3);
            Message2[9].Add(new ValueChar('1'), 0);
            Message2[9].Add(new ValueChar('2'), 1);
            Message2[9].Add(new ValueChar('1'), 2);

            Message2[8] = new Chain(3);
            // Возвращаемый фрагмент 213
            // 1|213|31212231
            Message2[8].Add(new ValueChar('2'), 0);
            Message2[8].Add(new ValueChar('1'), 1);
            Message2[8].Add(new ValueChar('3'), 2);

            // Возвращаемый фрагмент 133
            // 12|133|1212231
            Message2[7] = new Chain(3);
            Message2[7].Add(new ValueChar('1'), 0);
            Message2[7].Add(new ValueChar('3'), 1);
            Message2[7].Add(new ValueChar('3'), 2);

            // Возвращаемый фрагмент 331
            // 121|331|212231
            Message2[6] = new Chain(3);
            Message2[6].Add(new ValueChar('3'), 0);
            Message2[6].Add(new ValueChar('3'), 1);
            Message2[6].Add(new ValueChar('1'), 2);

            // Возвращаемый фрагмент 331
            // 1213|312|12231
            Message2[5] = new Chain(3);
            Message2[5].Add(new ValueChar('3'), 0);
            Message2[5].Add(new ValueChar('1'), 1);
            Message2[5].Add(new ValueChar('2'), 2);

            Message2[4] = new Chain(3);
            // Возвращаемый фрагмент 121
            // 12133|121|2231
            Message2[4].Add(new ValueChar('1'), 0);
            Message2[4].Add(new ValueChar('2'), 1);
            Message2[4].Add(new ValueChar('1'), 2);

            // Возвращаемый фрагмент 212
            // 121331|212|231
            Message2[3] = new Chain(3);
            Message2[3].Add(new ValueChar('2'), 0);
            Message2[3].Add(new ValueChar('1'), 1);
            Message2[3].Add(new ValueChar('2'), 2);

            // Возвращаемый фрагмент 122
            // 1213312|122|31
            Message2[2] = new Chain(3);
            Message2[2].Add(new ValueChar('1'), 0);
            Message2[2].Add(new ValueChar('2'), 1);
            Message2[2].Add(new ValueChar('2'), 2);

            Message2[1] = new Chain(3);
            // Возвращаемый фрагмент 223
            // 12133121|223|1
            Message2[1].Add(new ValueChar('2'), 0);
            Message2[1].Add(new ValueChar('2'), 1);
            Message2[1].Add(new ValueChar('3'), 2);

            // Возвращаемый фрагмент 231
            // 121331212|231|
            Message2[0] = new Chain(3);
            Message2[0].Add(new ValueChar('2'), 0);
            Message2[0].Add(new ValueChar('3'), 1);
            Message2[0].Add(new ValueChar('1'), 2);

            int i = -1; // Должно быть  -1 значение
            while (Iterator.Next()) // Следующая позиция итератора.
            {
                i++; // Следующее сообщение из массива
                BaseChain Message1 = Iterator.Current(); // Текущий фрагмент цепи
                Assert.AreEqual(Message1, Message2[i]); // Эквивалентны
            }

            Assert.AreEqual(9, i); // Было 10 итерации начниая с 0 = 9
        }

        ///<summary>
        /// Тестируем считывание блоками
        ///</summary>
        [Test]
        public void TestReadBlockMode()
        {
            // Длинна возврашаемого фрагмента 3
            int length = 3;
            // Шаг итерации 1
            int step = 3;
            IteratorEnd<Chain, Chain> Iterator = new IteratorEnd<Chain, Chain>(ChainToIterate, length, step);
            // Кол-во итерациий 12 / 3 
            Chain[] Message2 = new Chain[4];

            // Возвращаемый фрагмент 121
            // |121|331212231
            Message2[3] = new Chain(3);
            Message2[3].Add(new ValueChar('1'), 0);
            Message2[3].Add(new ValueChar('2'), 1);
            Message2[3].Add(new ValueChar('1'), 2);

            // Возвращаемый фрагмент 331
            // 121|331|212231
            Message2[2] = new Chain(3);
            Message2[2].Add(new ValueChar('3'), 0);
            Message2[2].Add(new ValueChar('3'), 1);
            Message2[2].Add(new ValueChar('1'), 2);

            // Возвращаемый фрагмент 212
            // 121331|212|231
            Message2[1] = new Chain(3);
            Message2[1].Add(new ValueChar('2'), 0);
            Message2[1].Add(new ValueChar('1'), 1);
            Message2[1].Add(new ValueChar('2'), 2);

            // Возвращаемый фрагмент 231
            // 121331212|231|
            Message2[0] = new Chain(3);
            Message2[0].Add(new ValueChar('2'), 0);
            Message2[0].Add(new ValueChar('3'), 1);
            Message2[0].Add(new ValueChar('1'), 2);

            int i = -1;  // Должно быть  -1 значение
            while (Iterator.Next()) // Следующая позиция итератора.
            {
                i++; // Следующее сообщение из массива
                BaseChain Message1 = Iterator.Current(); // Текущий фрагмент цепи
                Assert.AreEqual(Message1, Message2[i]); // Проверка на эквивалентность
            }

            Assert.AreEqual(3, i);// Было 4 итерации начниая с 0 = 3
        }
    }
}