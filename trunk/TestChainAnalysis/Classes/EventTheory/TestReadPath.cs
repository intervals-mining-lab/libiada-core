using System;
using System.Collections;
using System.IO;
using ChainAnalises.Classes.EventTheory;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.EventTheory
{
    ///<summary>
    /// Набор тестов для маршрута
    ///</summary>
    [TestFixture]
    public class TestReadPath
    {
        ///<summary>
        /// Тестирует конструктор при передачи ему null
        /// Ожидаем исключение
        ///</summary>
        [Test]
        public void TestConstructorNull()
        {
            try
            {
                new ReadPath(null);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof (AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует конструктор в рабочем режиме. 
        ///</summary>
        [Test]
        public void TestConstructorInWorkMode()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Assert.IsTrue(RP[0].EqualsAsPlace(First));
        }

        ///<summary>
        /// Тестирует добавление места в рабочем режиме
        ///</summary>
        [Test]
        public void TestAddInWorkMode()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP.Add(Third);
            Assert.IsTrue(RP[0].EqualsAsPlace(First));
            Assert.IsTrue(RP[1].EqualsAsPlace(Second));
        }

        ///<summary>
        /// Тестирует добавление места нарушая принцип соседства
        /// Ожидаем исключение
        ///</summary>
        [Test]
        public void TestAddNeighbourFail()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(8, 1);
            try
            {
                RP.Add(Second);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof (AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует добавление места нарушая принцип совместимости
        /// Ожидаем исключение
        ///</summary>
        [Test]
        public void TestAddComalibleToFail()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            ar.Add(new Dimension(0, 10));
            Place Second = new Place(ar);
            Second.SetValue(3, 0);
            Second.SetValue(7, 1);
            Second.SetValue(2, 2);
            try
            {
                RP.Add(Second);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof (AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует добавление места нарушая принцип уникальности (ссылочной)
        /// Ожидаем исключение
        ///</summary>
        [Test]
        public void TestAddUniquePointerFail()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = First;
            try
            {
                RP.Add(Second);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof (AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует добавление места нарушая принцип уникальности
        /// Ожидаем исключение
        ///</summary>
        [Test]
        public void TestAddUniqueFail()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(3, 0);
            Third.SetValue(7, 1);

            try
            {
                RP.Add(Third);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof (AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует добавление null места
        /// Ожидаем исключение
        ///</summary>
        [Test]
        public void TestAddNull()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            try
            {
                RP.Add(null);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof (AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует чтение произвольное места
        ///</summary>
        [Test]
        public void TestThis()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP.Add(Third);
            Assert.IsTrue(RP[1].EqualsAsPlace(Second));
        }

        ///<summary>
        /// Тестирует изменение возвращаемого this[] места
        ///</summary>
        [Test]
        public void TestThisWrite()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP.Add(Third);
            RP[2].SetValue(3, 1);
            Assert.AreEqual(6, RP[2].GetValues()[1]);

            Third.SetValue(3, 1);
            Assert.AreEqual(6, RP[2].GetValues()[1]);
        }

        ///<summary>
        /// Тестирует изменение возвращаемого this[] места
        ///</summary>
        [Test]
        public void TestRemove()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP.Add(Third);
            Assert.IsTrue(RP[RP.Length - 1].EqualsAsPlace(Third));
            RP.Remove();
            Assert.IsFalse(RP[RP.Length - 1].EqualsAsPlace(Third));
            Assert.IsTrue(RP[RP.Length - 1].EqualsAsPlace(Second));
        }

        ///<summary>
        /// Тестирует Клонирование
        ///</summary>
        [Test]
        public void TestClone()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP.Add(Third);

            ReadPath RP2 = (ReadPath) RP.Clone();
            Assert.IsTrue(RP2.EqualAsReadPath(RP2));
        }

        ///<summary>
        /// Тестирует сравнение с null путем.
        /// Ожидается исключение
        ///</summary>
        [Test]
        public void TestEqualAsReadPathNull()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP.Add(Third);
            try
            {
                RP.EqualAsReadPath(null);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof (AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует сравнение с путем принадлежащим другому протсранству.
        /// Ожидается исключение
        ///</summary>
        [Test]
        public void TestEqualAsReadPathOtherSpace()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP.Add(Third);

            ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            First = new Place(ar);
            First.SetValue(3, 0);
            ReadPath RP2 = new ReadPath(First);
            Second = new Place(ar);
            Second.SetValue(4, 0);
            RP2.Add(Second);
            Third = new Place(ar);
            Third.SetValue(5, 0);
            RP2.Add(Third);
            try
            {
                RP.EqualAsReadPath(RP2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof (AssertionException))
                {
                    Assert.Fail();
                }
            }
        }


        ///<summary>
        ///Тестирует сравнение с путем в рабочем режиме
        /// Ожидается true
        ///</summary>
        [Test]
        public void TestEqualAsReadPathInWorkModeTrue()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP.Add(Third);

            ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP2 = new ReadPath(First);
            Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP2.Add(Second);
            Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP2.Add(Third);
            Assert.IsTrue(RP.EqualAsReadPath(RP2));
        }

        ///<summary>
        /// Тестирует сравнение с путем в рабочем режиме
        /// Ожидается false
        ///</summary>
        [Test]
        public void TestEqualAsReadPathInWorkModeFalse()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP.Add(Third);

            ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP2 = new ReadPath(First);
            Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP2.Add(Second);
            Third = new Place(ar);
            Third.SetValue(5, 0);
            Third.SetValue(7, 1);
            RP2.Add(Third);
            Assert.IsFalse(RP.EqualAsReadPath(RP2));
        }

/*        ///<summary>
        /// Тест проверяющий корректность сериализации и десериализации
        ///</summary>
        public void TestSerializationDeSerialization()
        {
            ArrayList ar = new ArrayList();
            ar.Add(new Dimension(0, 10));
            ar.Add(new Dimension(0, 10));
            Place First = new Place(ar);
            First.SetValue(3, 0);
            First.SetValue(7, 1);
            ReadPath RP = new ReadPath(First);
            Place Second = new Place(ar);
            Second.SetValue(4, 0);
            Second.SetValue(7, 1);
            RP.Add(Second);
            Place Third = new Place(ar);
            Third.SetValue(4, 0);
            Third.SetValue(6, 1);
            RP.Add(Third);

            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, RP);
            MS.Position = 0;
            SF = new SoapFormatter();

            ReadPath RPAfter = (ReadPath) SF.Deserialize(MS);
            Assert.IsTrue(RP.EqualAsReadPath(RPAfter));
        }*/
    }
}