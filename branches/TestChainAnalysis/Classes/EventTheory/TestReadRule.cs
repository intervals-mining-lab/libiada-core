using System;
using System.Collections;
using ChainAnalises.Classes.EventTheory;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.EventTheory
{
    ///<summary>
    /// Класс содержит тесты для тестирования класса правило чтения ReadRule
    ///</summary>
    [TestFixture]
    public class TestReadRule
    {
        private Place PlBase = null;
        private Place PlFromOtherSpace = null;
        private Place PlNeighbour = null;
        private Place PlNeighbour2 = null;
        private Place PlNotNeighbour = null;

        private ArrayList ArOtherSpace = null;
        private ArrayList ArBase = null;
        private ReadRule rrTest = null;

        ///<summary>
        ///</summary>
        [SetUp]
        public void Intialize()
        {
            ArOtherSpace = new ArrayList();
            ArBase = new ArrayList();

            ArBase.Add(new Dimension(0, 10));
            ArBase.Add(new Dimension(-10, 10));
            ArBase.Add(new Dimension(0, 10));

            ArOtherSpace.Add(new Dimension(0, 10));

            PlBase = new Place(ArBase);

            PlNeighbour = new Place(ArBase);
            PlNeighbour2 = new Place(ArBase);
            PlNotNeighbour = new Place(ArBase);
            PlFromOtherSpace = new Place(ArOtherSpace);

            PlBase.SetValues(new long[3] {5, 6, 7});
            PlNeighbour.SetValues(new long[3] {5, 7, 7});
            PlNeighbour2.SetValues(new long[3] {4, 6, 7});
            PlNotNeighbour.SetValues(new long[3] {7, 7, 7});

            rrTest = new ReadRule(PlBase);
        }

        ///<summary>
        /// Тестирует конструктор если ему передается null место
        /// Ожидаем исключение
        ///</summary>
        [Test]
        [ExpectedException(typeof (NullReferenceException))]
        public void TestConstructorNull()
        {
            new ReadRule(null);
        }

        ///<summary>
        /// Тестирует конструктор если ему передается место (Рабочий режим)
        ///</summary>
        [Test]
        public void TestConstructorInWorkMode()
        {
            new ReadRule(PlBase);
        }

        ///<summary>
        /// Тест проверяющий добавление места принадлежащего другому пространству
        ///</summary>
        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestAddPlaceFromOtherSpace()
        {
            ReadRule Test = new ReadRule(PlBase);
            Test.Add(PlFromOtherSpace);
        }

        ///<summary>
        /// Проверяет добавление места в рабочем режиме
        ///</summary>
        [Test]
        public void TestAddPlaceInWorkMode()
        {
            rrTest.Add(PlNeighbour);
        }

        ///<summary>
        /// Проверяет добавление места в рабочем режиме
        ///</summary>
        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestAddPlaceNotNeighbour()
        {
            rrTest.Add(PlNotNeighbour);
        }

        ///<summary>
        /// Проверяет добавление одного и того же места дважды
        ///</summary>
        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestAddTwise()
        {
            rrTest.Add(PlNeighbour);
            rrTest.Add(PlNeighbour);
        }

        ///<summary>
        /// Тeстирует вариант добавления null места
        ///</summary>
        [Test]
        [ExpectedException(typeof (NullReferenceException))]
        public void TestAddNull()
        {
            rrTest.Add((Place) null);
        }

        ///<summary>
        /// Тестирует получение элемента
        ///</summary>
        [Test]
        public void TestGet()
        {
            rrTest.Add(PlNeighbour);
            rrTest.Add(PlNeighbour2);
            Assert.IsTrue(PlNeighbour.EqualsAsPlace(rrTest[0]));
            Assert.IsTrue(PlNeighbour2.EqualsAsPlace(rrTest[1]));
            Assert.AreNotSame(PlNeighbour, rrTest[0]);
            Assert.AreNotSame(PlNeighbour2, rrTest[1]);
        }

        ///<summary>
        /// Тестирует невозможность изменения из вне элементов класса
        ///</summary>
        [Test]
        public void TestGetAndChange()
        {
            rrTest.Add(PlNeighbour);
            rrTest.Add(PlNeighbour2);
            Place PlaceToChange = rrTest[1];
            PlaceToChange.SetValues(new long[] {0, 0, 0});
            Assert.IsFalse(PlaceToChange.EqualsAsPlace(rrTest[1]));
        }

        ///<summary>
        /// Тестирует установку в арбочем режиме
        ///</summary>
        [Test]
        public void TestSetInWorkMode()
        {
            rrTest.Add(PlNeighbour);
            rrTest[0] = PlNeighbour2;
            Assert.IsTrue(PlNeighbour2.EqualsAsPlace(rrTest[0]));
            PlNeighbour2.SetValues(new long[] {0, 0, 0});
            Assert.IsFalse(PlNeighbour2.EqualsAsPlace(rrTest[0]));
        }

        ///<summary>
        /// Тестирует установку места принадлежащего другому пространству 
        ///</summary>
        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestSetFromOtherSpace()
        {
            rrTest.Add(PlNeighbour);
            rrTest[0] = PlFromOtherSpace;
        }


        ///<summary>
        /// Тестирует установку места дважды
        ///</summary>
        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestSetTwise()
        {
            rrTest.Add(PlNeighbour);
            rrTest.Add(PlNeighbour2);
            rrTest[0] = PlNeighbour2;
        }

        ///<summary>
        /// Тестирует установку несоседнего места 
        ///</summary>
        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestSetNotNeighbour()
        {
            rrTest.Add(PlNeighbour);
            rrTest[0] = PlNotNeighbour;
        }

        ///<summary>
        /// Тестирует установку null места
        ///</summary>
        [Test]
        [ExpectedException(typeof (NullReferenceException))]
        public void TestSetNull()
        {
            rrTest.Add(PlNeighbour);
            rrTest[0] = null;
        }

        ///<summary>
        /// Тестирует удаление места
        ///</summary>
        [Test]
        public void TestRemove()
        {
            rrTest.Add(PlNeighbour);
            rrTest.Add(PlNeighbour2);
            rrTest.Remove(0);
            Assert.IsTrue(PlNeighbour2.EqualsAsPlace(rrTest[0]));
            Assert.AreEqual(1, rrTest.Count);
        }

        ///<summary>
        /// Тестиует удаление не существующего элемента
        ///</summary>
        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void TestRemoveOutOfRange()
        {
            rrTest.Add(PlNeighbour);
            rrTest.Add(PlNeighbour2);
            rrTest.Remove(6);
        }

        ///<summary>
        /// Тестирует метод эквивалентности в рабочем режиме
        ///</summary>
        [Test]
        public void TestEqualAsRule()
        {
            rrTest.Add(PlNeighbour);
            rrTest.Add(PlNeighbour2);

            ReadRule RR = new ReadRule(PlBase);
            RR.Add(PlNeighbour);
            RR.Add(PlNeighbour2);
            Assert.IsTrue(RR.EqualAsRule(rrTest));
        }

        ///<summary>
        /// Тестирует метод эквивалентности с null
        ///</summary>
        [Test]
        [ExpectedException(typeof (NullReferenceException))]
        public void TestEqualNull()
        {
            rrTest.Add(PlNeighbour);
            rrTest.Add(PlNeighbour2);
            Assert.IsTrue(rrTest.EqualAsRule(null));
        }


        ///<summary>
        /// Тестирует метод эквивалентности в рабочем режиме
        ///</summary>
        [Test]
        public void TestEqualAsRuleFalse()
        {
            rrTest.Add(PlNeighbour);
            rrTest.Add(PlNeighbour2);

            ReadRule RR = new ReadRule(PlBase);
            RR.Add(PlNeighbour);
            Assert.IsFalse(RR.EqualAsRule(rrTest));
        }

        ///<summary>
        /// Тестирует клонирование
        ///</summary>
        [Test]
        public void TestClone()
        {
            rrTest.Add(PlNeighbour);
            rrTest.Add(PlNeighbour2);

            ReadRule RR = rrTest.Clone();
            Assert.IsTrue(RR.EqualAsRule(rrTest));
        }
/*

        ///<summary>
        /// Тест проверяющий корректность сериализации и десериализации
        ///</summary>
        [Test]
        public void TestSerializationDeSerialization()
        {
            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, rrTest);
            MS.Position = 0;
            SF = new SoapFormatter();

            ReadRule RPAfter = (ReadRule) SF.Deserialize(MS);
            Assert.IsTrue(rrTest.EqualAsRule(RPAfter));
        }
*/

        ///<summary>
        /// Тестирует объекдинение с правилом принадлежаещей другому пространству
        ///</summary>
        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestAddWithRuleOther()
        {
            ReadRule rr2 = new ReadRule(PlFromOtherSpace);
            rrTest.Add(rr2);
        }

        ///<summary>
        /// Метод тестирующий объединение с null правилом.
        ///</summary>
        [Test]
        [ExpectedException(typeof (NullReferenceException))]
        public void TestAddWithRuleNull()
        {
            rrTest.Add((ReadRule) null);
        }

        ///<summary>
        /// Тестирует метод объединения с правилом принаддежащим другому месту
        ///</summary>
        [Test]
        [ExpectedException(typeof (Exception))]
        public void TestAddWithRuleOtherPlace()
        {
            ReadRule rr2 = new ReadRule(PlNotNeighbour);
            rrTest.Add(rr2);
        }

        ///<summary>
        /// Тестирует объединение с правилом в рабочем режиме( правила принадлежать одному и тому же месту) 
        ///</summary>
        [Test]
        public void TestAddWithRuleInWorkMode()
        {
            ReadRule rr2 = rrTest.Clone();
            ReadRule rr3 = rrTest.Clone();

            rrTest.Add(PlNeighbour);

            rr2.Add(PlNeighbour2);

            rr3.Add(PlNeighbour);
            rr3.Add(PlNeighbour2);

            Assert.AreEqual(rrTest.Add(rr2), rr3);
        }
    }
}