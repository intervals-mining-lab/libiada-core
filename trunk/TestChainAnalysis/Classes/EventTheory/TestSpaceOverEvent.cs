using System;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.Root.SimpleTypes;
using ChainAnalises.Classes.TheoryOfSet;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.EventTheory
{
    ///<summary>
    /// Класс тестирующий класс Пространство  Event
    ///</summary>
    [TestFixture]
    public class TestSpaceDiscreteOverEvent
    {
        private Event BaseSpace = null;

        ///<summary>
        /// Метод инициализирующий
        ///</summary>
        [SetUp]
        public void init()
        {
            BaseSpace = new Event();
        }

        ///<summary>
        /// Тест проверяет корректныю работу метода AddDimension 
        ///</summary>
        [Test]
        public void TestAddDimension()
        {
            Dimension dm1 = new Dimension(0, 10);
            Dimension dm2 = new Dimension(-1, 10);

            BaseSpace.AddDimension(dm1);
            BaseSpace.AddDimension(dm2);

            Assert.AreEqual(2, BaseSpace.DimensionCount());
            Assert.IsTrue(BaseSpace.GetDimension(0).EqualsAsDimension(dm1));
            Assert.IsTrue(BaseSpace.GetDimension(1).EqualsAsDimension(dm2));
        }

        ///<summary>
        /// Тест проверящий поведение при добавлении null в качестве измерения
        ///</summary>
        [Test]
        public void TestAddDimensionNULL()
        {
            try
            {
                BaseSpace.AddDimension(null);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// Тест проверяющий корректное удаление измерений
        /// происходит очищение всего пространства.
        ///</summary>
        [Test]
        public void TestDeleteDimensions()
        {
            Dimension dm1 = new Dimension(0, 10);
            Dimension dm2 = new Dimension(-1, 10);

            BaseSpace.AddDimension(dm1);
            BaseSpace.AddDimension(dm2);

            Assert.AreEqual(2, BaseSpace.DimensionCount());
            Assert.IsTrue(BaseSpace.GetDimension(0).EqualsAsDimension(dm1));
            Assert.IsTrue(BaseSpace.GetDimension(1).EqualsAsDimension(dm2));

            BaseSpace.DeleteDimesnions();
            Assert.AreEqual(0, BaseSpace.DimensionCount());
        }

        ///<summary>
        /// тест проверяет поведение системы при добавлении null объекта в пространство
        ///</summary>
        [Test]
        public void TestAddItemNull()
        {
            try
            {
                Dimension dm1 = new Dimension(0, 10);
                Dimension dm2 = new Dimension(-1, 10);
                
                BaseSpace.AddDimension(dm1);
                BaseSpace.AddDimension(dm2);
                
                BaseSpace.AddItem(null, BaseSpace.GetPlacePattern().SetValues(new long[] {1, 1}));
            }
            catch (NullReferenceException)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// Тестирует поведение системы при коректном добавлении объекта в пространство
        /// При этом следует учитывать возможность не корректного функцианирования метода GetItem
        ///</summary>
        [Test]
        public void TestAddItemInWorkMode()
        {
            Dimension dm1 = new Dimension(0, 10);
            Dimension dm2 = new Dimension(-1, 10);

            BaseSpace.AddDimension(dm1);
            BaseSpace.AddDimension(dm2);

            Place Pl = BaseSpace.GetPlacePattern();
            Pl.SetValues(new long[] {1, 1});

            BaseSpace.AddItem(new ValueInt(1), Pl);
            Assert.AreEqual(new ValueInt(1), BaseSpace.GetItem(Pl));

            Pl.SetValues(new long[] {0, 1});
            Assert.IsTrue(ReferenceEquals(PsevdoValue.Instance(), BaseSpace.GetItem(Pl)));
        }

        ///<summary>
        /// Тестирует ситуацию когда в пространство добавляется объект, при этом в качестве 
        /// места передается null;
        ///</summary>
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAddItemInNull()
        {

            Dimension dm1 = new Dimension(0, 10);
            Dimension dm2 = new Dimension(-1, 10);

            BaseSpace.AddDimension(dm1);
            BaseSpace.AddDimension(dm2);

            BaseSpace.AddItem(new ValueInt(1), null);
        }


        ///<summary>
        /// Тестирует независимость внутреннего объекта от объекта прередоваемого в качестве параметра
        /// в метод реализующий добавление данного объекта.
        ///</summary>
        [Test]
        public void TestAddItemChangeAfterAdd()
        {
            Dimension dm1 = new Dimension(0, 10);
            Dimension dm2 = new Dimension(-1, 10);

            BaseSpace.AddDimension(dm1);
            BaseSpace.AddDimension(dm2);

            Place Pl = BaseSpace.GetPlacePattern();
            Pl.SetValues(new long[] {1, 1});

            ValueInt int1 = new ValueInt(1);

            BaseSpace.AddItem(int1, Pl);
            int1.value = 2;
            Assert.AreNotEqual(int1, BaseSpace.GetItem(Pl));
        }

        ///<summary>
        /// Тест проверяющий независимость внутренного объекта от 
        /// объекта возвращаемого методом GetItem
        ///</summary>
        [Test]
        public void TestAddItemChangeAfterGet()
        {
            Dimension dm1 = new Dimension(0, 10);
            Dimension dm2 = new Dimension(-1, 10);

            BaseSpace.AddDimension(dm1);
            BaseSpace.AddDimension(dm2);

            Place Pl = BaseSpace.GetPlacePattern();
            Pl.SetValues(new long[] {1, 1});

            ValueInt int1 = new ValueInt(1);

            BaseSpace.AddItem(int1, Pl);
            int1 = (ValueInt) BaseSpace.GetItem(Pl);
            int1.value = 5;
            Assert.AreNotEqual(int1, BaseSpace.GetItem(Pl));
        }


        ///<summary>
        /// Тест проверяющий независимость внутреннего объекта алфавита от объекта 
        /// возвращаемого в качестве алфавита
        ///</summary>
        [Test]
        public void TestAlphabetChageAfter()
        {
            Dimension dm1 = new Dimension(0, 10);
            Dimension dm2 = new Dimension(-1, 10);

            BaseSpace.AddDimension(dm1);
            BaseSpace.AddDimension(dm2);

            Place Pl = BaseSpace.GetPlacePattern();
            Pl.SetValues(new long[] {1, 1});

            ValueInt int1 = new ValueInt(1);

            BaseSpace.AddItem(int1, Pl);

            Alphabet Alp = BaseSpace.Alpahbet;

            Alp.Add(new ValueInt(4));

            Assert.IsFalse(BaseSpace.Alpahbet.Equals(Alp));
        }

        ///<summary>
        /// Тест проверяет корректность построения алфавита
        ///</summary>
        [Test]
        public void TestAlphabetAndAddItemInWorkMode()
        {
            Dimension dm1 = new Dimension(0, 10);
            Dimension dm2 = new Dimension(-1, 10);

            BaseSpace.AddDimension(dm1);
            BaseSpace.AddDimension(dm2);

            Place Pl = BaseSpace.GetPlacePattern();
            Pl.SetValues(new long[] {1, 1});

            ValueInt int1 = new ValueInt(1);
            ValueInt int2 = new ValueInt(6);
            ValueInt int3 = new ValueInt(1);

            BaseSpace.AddItem(int1, Pl);

            Pl.SetValues(new long[] {1, 2});
            BaseSpace.AddItem(int2, Pl);

            Pl.SetValues(new long[] {2, 2});
            BaseSpace.AddItem(int3, Pl);

            Pl.SetValues(new long[] {2, 5});
            BaseSpace.AddItem(int3, Pl);

            Pl.SetValues(new long[] {3, 5});
            BaseSpace.AddItem(int1, Pl);
            Pl.SetValues(new long[] {3, 5});
            BaseSpace.AddItem(int2, Pl);

            Alphabet Alp = new Alphabet();
            Alp.Add(int1);
            Alp.Add(int2);

            Assert.AreEqual(BaseSpace.Alpahbet.power, Alp.power);
            Assert.IsTrue(BaseSpace.Alpahbet.Equals(Alp));

            Pl.SetValues(new long[] {1, 1});
            Assert.AreEqual(int1, BaseSpace.GetItem(Pl));

            Pl.SetValues(new long[] {1, 2});
            Assert.AreEqual(int2, BaseSpace.GetItem(Pl));

            Pl.SetValues(new long[] {2, 2});
            Assert.AreEqual(int3, BaseSpace.GetItem(Pl));

            Pl.SetValues(new long[] {2, 5});
            Assert.AreEqual(int3, BaseSpace.GetItem(Pl));

            Pl.SetValues(new long[] {3, 5});
            Assert.AreEqual(int2, BaseSpace.GetItem(Pl));
        }

        ///<summary>
        /// Тест проверяет корректность сохранения элементов добавлеенных ранее
        /// после увеличения размерности пространства
        ///</summary>
        [Test]
        public void TestSavingItemsAfterAddDimension()
        {
            Dimension dm1 = new Dimension(0, 10);
            Dimension dm2 = new Dimension(-1, 10);

            BaseSpace.AddDimension(dm1);


            Place Pl = BaseSpace.GetPlacePattern();
            Pl.SetValues(new long[] {1});

            ValueInt int1 = new ValueInt(1);
            ValueInt int2 = new ValueInt(6);
            ValueInt int3 = new ValueInt(1);

            BaseSpace.AddItem(int1, Pl);

            Pl.SetValues(new long[] {2});
            BaseSpace.AddItem(int2, Pl);

            Pl.SetValues(new long[] {3});
            BaseSpace.AddItem(int3, Pl);

            Pl.SetValues(new long[] {4});
            BaseSpace.AddItem(int3, Pl);

            Pl.SetValues(new long[] {5});
            BaseSpace.AddItem(int1, Pl);
            Pl.SetValues(new long[] {6});
            BaseSpace.AddItem(int2, Pl);

            BaseSpace.AddDimension(dm2);

            Pl = BaseSpace.GetPlacePattern();

            Assert.AreEqual(int1, BaseSpace.GetItem(Pl.SetValues(new long[] {1, 0})));
            Assert.IsTrue(int2.Equals(BaseSpace.GetItem(Pl.SetValues(new long[] {2, 0}))));
            Assert.IsTrue(int3.Equals(BaseSpace.GetItem(Pl.SetValues(new long[] {3, 0}))));
            Assert.IsTrue(int3.Equals(BaseSpace.GetItem(Pl.SetValues(new long[] {4, 0}))));
            Assert.IsTrue(int1.Equals(BaseSpace.GetItem(Pl.SetValues(new long[] {5, 0}))));
            Assert.IsTrue(int2.Equals(BaseSpace.GetItem(Pl.SetValues(new long[] {6, 0}))));
        }

        ///<summary>
        /// Тестриует метод получения i-ого измерения 
        ///</summary>
        [Test]
        public void TestGetDimensions()
        {
            Dimension dm1 = new Dimension(0, 10);
            Dimension dm2 = new Dimension(-1, 10);

            BaseSpace.AddDimension(dm1);
            BaseSpace.AddDimension(dm2);

            Assert.IsTrue(BaseSpace.GetDimension(0).EqualsAsDimension(dm1));
            Assert.IsTrue(BaseSpace.GetDimension(1).EqualsAsDimension(dm2));
        }

        ///<summary>
        /// Метод тестирует независимость внутренного представления паттрена места 
        /// от возвращаемого паттерна места
        ///</summary>
        [Test]
        public void TestChangePlacePatternAfter()
        {
            BaseSpace.AddDimension(new Dimension(0, 10));
            Place Pl = BaseSpace.GetPlacePattern();
            BaseSpace.AddDimension(new Dimension(-10, 10));

            Assert.AreNotEqual(Pl, BaseSpace.GetPlacePattern());
        }

        ///<summary>
        /// Тестирует поведени системы при попытке получить объект с использованием объекта класса место \
        /// принадлежашего другому пространству
        ///</summary>
        [Test]
        public void TestGetWrongPlace()
        {
            try
            {
                BaseSpace.AddDimension(new Dimension(0, 10));
                Place Pl = BaseSpace.GetPlacePattern();
                BaseSpace.AddDimension(new Dimension(-10, 10));
                BaseSpace.GetItem(Pl);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// Тест проверяет поведение системы при попытке добавления объекта с использованием 
        /// объекта место принадлежащего другому пространству
        ///</summary>
        [Test]
        public void TestAddWrongPlace()
        {
            try
            {
                BaseSpace.AddDimension(new Dimension(0, 10));
                Place Pl = BaseSpace.GetPlacePattern();
                BaseSpace.AddDimension(new Dimension(-10, 10));
                BaseSpace.AddItem(new ValueInt(1), Pl);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// Тест проверяет удаление объекта при использовании объекта класса место указывающего 
        /// на ячейку пространства в которой хранится псевдовеличина
        ///</summary>
        [Test]
        public void TestRemoveAtNull()
        {
            BaseSpace.AddDimension(new Dimension(0, 10));
            BaseSpace.RemoveAt(BaseSpace.GetPlacePattern().SetValues(new long[] {2}));
        }

        ///<summary>
        /// Тестирует удаление объекта с использованем объекта класса место указывающего 
        /// на ячейку простраства содержашюю не псевдовеличину.
        ///</summary>
        [Test]
        public void TestRemoveAtNotNull()
        {
            BaseSpace.AddDimension(new Dimension(0, 10));
            BaseSpace.AddItem(new ValueInt(1), BaseSpace.GetPlacePattern().SetValues(new long[] {2}));

            Assert.AreEqual(new ValueInt(1), BaseSpace.GetItem(BaseSpace.GetPlacePattern().SetValues(new long[] {2})));

            BaseSpace.RemoveAt(BaseSpace.GetPlacePattern().SetValues(new long[] {2}));
            Assert.AreNotEqual(new ValueInt(1), BaseSpace.GetItem(BaseSpace.GetPlacePattern().SetValues(new long[] {2})));
            Assert.AreEqual(PsevdoValue.Instance(),
                            BaseSpace.GetItem(BaseSpace.GetPlacePattern().SetValues(new long[] {2})));
        }

        ///<summary>
        /// Тестирует методы MoveNext и Current наследуемых от интерфейса IEnumerator 
        ///</summary>
        [Test]
        public void TestENumirator()
        {
            BaseSpace.AddDimension(new Dimension(0, 10));

            for (int i = 0; i <= 10; i++)
            {
                BaseSpace.AddItem(new ValueInt(i*i), BaseSpace.GetPlacePattern().SetValues(new long[] {i}));
            }


            for (int i = 0; BaseSpace.MoveNext(); i++)
            {
                Assert.AreEqual(new ValueInt(i*i),
                                BaseSpace.GetItem(BaseSpace.GetPlacePattern().SetValues(new long[] {i})));
                Assert.AreEqual(new ValueInt(i*i), BaseSpace.Current);
            }
        }

        ///<summary>
        /// Тестирует поведение методов от IEnumerator при удалении объекта
        ///</summary>
        [Test]
        public void TestENumiratorRemove()
        {
            try
            {
                BaseSpace.AddDimension(new Dimension(0, 10));

                for (int i = 0; i <= 10; i++)
                {
                    BaseSpace.AddItem(new ValueInt(i * i), BaseSpace.GetPlacePattern().SetValues(new long[] { i }));
                }


                for (int i = 0; BaseSpace.MoveNext(); i++)
                {
                    Assert.AreEqual(new ValueInt(i * i),
                                    BaseSpace.GetItem(BaseSpace.GetPlacePattern().SetValues(new long[] { i })));
                    if (i == 5)
                    {
                        BaseSpace.RemoveAt(BaseSpace.GetPlacePattern().SetValues(new long[] { 2 }));
                    }
                    Assert.AreEqual(new ValueInt(i * i), BaseSpace.Current);
                }
            }
            catch (InvalidOperationException)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// Тестирует поведение методов от IEnumerator при увеличении размерости пространства
        ///</summary>
        [Test]
        public void TestENumiratorAddDimension()
        {
            try
            {
                BaseSpace.AddDimension(new Dimension(0, 10));

                for (int i = 0; i <= 10; i++)
                {
                    BaseSpace.AddItem(new ValueInt(i * i), BaseSpace.GetPlacePattern().SetValues(new long[] { i }));
                }


                for (int i = 0; BaseSpace.MoveNext(); i++)
                {
                    Assert.AreEqual(new ValueInt(i * i),
                                    BaseSpace.GetItem(BaseSpace.GetPlacePattern().SetValues(new long[] { i })));
                    if (i == 5)
                    {
                        BaseSpace.AddDimension(new Dimension(-10, 10));
                    }
                    Assert.AreEqual(new ValueInt(i * i), BaseSpace.Current);
                }
            }
            catch (InvalidOperationException)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        ///  Тестирует поведение методов от IEnumerator при добавлении нового объекта в пространство
        ///</summary>
        [Test]
        public void TestENumiratorAddItem()
        {
            try
            {
                BaseSpace.AddDimension(new Dimension(0, 10));

                for (int i = 0; i <= 10; i++)
                {
                    BaseSpace.AddItem(new ValueInt(i * i), BaseSpace.GetPlacePattern().SetValues(new long[] { i }));
                }


                for (int i = 0; BaseSpace.MoveNext(); i++)
                {
                    Assert.AreEqual(new ValueInt(i * i),
                                    BaseSpace.GetItem(BaseSpace.GetPlacePattern().SetValues(new long[] { i })));
                    if (i == 5)
                    {
                        BaseSpace.AddItem(new ValueInt(10), BaseSpace.GetPlacePattern().SetValues(new long[] { 7 }));
                    }
                    Assert.AreEqual(new ValueInt(i * i), BaseSpace.Current);
                }
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        ///  Тестирует поведение методов от IEnumerator при очищении пространства (удалении)
        ///</summary>
        [Test]
        public void TestENumiratorDeleteDimensions()
        {
            try
            {
                BaseSpace.AddDimension(new Dimension(0, 10));

                for (int i = 0; i <= 10; i++)
                {
                    BaseSpace.AddItem(new ValueInt(i * i), BaseSpace.GetPlacePattern().SetValues(new long[] { i }));
                }


                for (int i = 0; BaseSpace.MoveNext(); i++)
                {
                    Assert.AreEqual(new ValueInt(i * i),
                                    BaseSpace.GetItem(BaseSpace.GetPlacePattern().SetValues(new long[] { i })));
                    if (i == 5)
                    {
                        BaseSpace.DeleteDimesnions();
                    }
                    Assert.AreEqual(new ValueInt(i * i), BaseSpace.Current);
                }
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        ///  Тестирует поведение метода current при усливии его вызова перед первым вызовом метода MoveNext
        ///</summary>
        [Test]
        public void TestENumiratorPreFirst()
        {
            try
            {
                BaseSpace.AddDimension(new Dimension(0, 10));

                for (int i = 0; i <= 10; i++)
                {
                    BaseSpace.AddItem(new ValueInt(i * i), BaseSpace.GetPlacePattern().SetValues(new long[] { i }));
                }
                object current = BaseSpace.Current;
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// Тестирует поведение метода current при усливии его вызова после того как метод 
        /// MoveNext начает возвращать false 
        ///</summary>
        [Test]
        public void TestENumiratorPostLast()
        {
            try
            {
                BaseSpace.AddDimension(new Dimension(0, 10));

                for (int i = 0; i <= 10; i++)
                {
                    BaseSpace.AddItem(new ValueInt(i * i), BaseSpace.GetPlacePattern().SetValues(new long[] { i }));
                }

                for (; BaseSpace.MoveNext(); )
                {
                }
                object current = BaseSpace.Current;
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// метод тестирует корректность полчения кол-ва ячеек в пространстве
        ///</summary>
        [Test]
        public void TestItemCount()
        {
            Dimension D1 = new Dimension(0, 10);
            BaseSpace.AddDimension(D1);

            Assert.AreEqual(D1.Length, BaseSpace.PlaceCount);

            Dimension D2 = new Dimension(-10, 10);
            BaseSpace.AddDimension(D2);

            Assert.AreEqual(D1.Length*D2.Length, BaseSpace.PlaceCount);
        }

        ///<summary>
        /// Тестирует поведение метода Reset наследованного от интерфейся IEnumerable
        ///</summary>
        [Test]
        public void TestReset()
        {
            BaseSpace.AddDimension(new Dimension(0, 10));

            for (int i = 0; i <= 10; i++)
            {
                BaseSpace.AddItem(new ValueInt(i*i), BaseSpace.GetPlacePattern().SetValues(new long[] {i}));
            }

            for (; BaseSpace.MoveNext();)
            {
            }
            BaseSpace.Reset();
            BaseSpace.MoveNext();
            object current = BaseSpace.Current;
        }

        ///<summary>
        /// Тест проверяет независимость объекта возвращаемого методом Cutrent и внутренного объекта
        ///</summary>
        [Test]
        public void TestChangeCurrent()
        {
            BaseSpace.AddDimension(new Dimension(0, 10));


            for (int i = 0; i <= 10; i++)
            {
                BaseSpace.AddItem(new ValueInt(i*i), BaseSpace.GetPlacePattern().SetValues(new long[] {i}));
            }

            BaseSpace.MoveNext();
            BaseSpace.MoveNext();
            ValueInt Temp = (ValueInt) BaseSpace.Current;
            Temp.value = 13;
            Assert.AreNotEqual(Temp, BaseSpace.Current);
            Assert.AreEqual(new ValueInt(1*1), BaseSpace.Current);
        }

        ///<summary>
        /// Тест проверет отнощение эквивалентности при условии что втрой параметр null
        ///</summary>
        [Test]
        public void TestEqualsNull()
        {
            BaseSpace.AddDimension(new Dimension(0, 10));
            Assert.IsFalse(BaseSpace.Equals(null));
        }

        ///<summary>
        /// Тест проверяет отношение эквивалентности при сравнении 
        /// пространств имеющих различную размерность
        ///</summary>
        [Test]
        public void TestEqualsDifferentDimensions()
        {
            Event Temp = new Event();
            Temp.AddDimension(new Dimension(0, 10));
            Temp.AddDimension(new Dimension(0, 10));

            BaseSpace.AddDimension(new Dimension(0, 10));


            Assert.IsFalse(BaseSpace.Equals(Temp));
        }


        ///<summary>
        /// Метод проверяет отношение эквивалентности при сравнеии двух пространств отличающихся 
        /// взаимным расположением элементов в пространстве
        ///</summary>
        [Test]
        public void TestEqualsDifferentItems()
        {
            Event Temp = new Event();
            Temp.AddDimension(new Dimension(0, 10));

            Temp.AddItem(new ValueInt(1), Temp.GetPlacePattern().SetValues(new long[] {0}));
            Temp.AddItem(new ValueInt(2), Temp.GetPlacePattern().SetValues(new long[] {1}));
            Temp.AddItem(new ValueInt(3), Temp.GetPlacePattern().SetValues(new long[] {2}));
            Temp.AddItem(new ValueInt(4), Temp.GetPlacePattern().SetValues(new long[] {3}));

            BaseSpace.AddDimension(new Dimension(0, 10));

            BaseSpace.AddItem(new ValueInt(1), BaseSpace.GetPlacePattern().SetValues(new long[] {0}));
            BaseSpace.AddItem(new ValueInt(3), BaseSpace.GetPlacePattern().SetValues(new long[] {1}));
            BaseSpace.AddItem(new ValueInt(2), BaseSpace.GetPlacePattern().SetValues(new long[] {2}));
            BaseSpace.AddItem(new ValueInt(4), BaseSpace.GetPlacePattern().SetValues(new long[] {3}));

            Assert.IsFalse(BaseSpace.Equals(Temp));
        }

        ///<summary>
        /// Провеяет отнощение эквивалентности двух пространств с одинаковами размерностями 
        /// составом и взаимным расположением элементов
        ///</summary>
        [Test]
        public void TestEqualsInWorkMode()
        {
            Event Temp = new Event();
            Temp.AddDimension(new Dimension(0, 10));

            Temp.AddItem(new ValueInt(1), Temp.GetPlacePattern().SetValues(new long[] {0}));
            Temp.AddItem(new ValueInt(2), Temp.GetPlacePattern().SetValues(new long[] {1}));
            Temp.AddItem(new ValueInt(3), Temp.GetPlacePattern().SetValues(new long[] {2}));
            Temp.AddItem(new ValueInt(4), Temp.GetPlacePattern().SetValues(new long[] {3}));

            BaseSpace.AddDimension(new Dimension(0, 10));

            BaseSpace.AddItem(new ValueInt(1), BaseSpace.GetPlacePattern().SetValues(new long[] {0}));
            BaseSpace.AddItem(new ValueInt(2), BaseSpace.GetPlacePattern().SetValues(new long[] {1}));
            BaseSpace.AddItem(new ValueInt(3), BaseSpace.GetPlacePattern().SetValues(new long[] {2}));
            BaseSpace.AddItem(new ValueInt(4), BaseSpace.GetPlacePattern().SetValues(new long[] {3}));

            Assert.IsTrue(BaseSpace.Equals(Temp));
        }

/*
        ///<summary>
        /// Тестирует корректную сериализацию и десериализацию пространства
        ///</summary>
        [Test]
        public void TestSerializeDeserialize()
        {
            Event Temp = new Event();
            Temp.AddDimension(new Dimension(0, 10));

            Temp.AddItem(new ValueInt(1), Temp.GetPlacePattern().SetValues(new long[] {0}));
            Temp.AddItem(new ValueInt(2), Temp.GetPlacePattern().SetValues(new long[] {1}));
            Temp.AddItem(new ValueInt(3), Temp.GetPlacePattern().SetValues(new long[] {2}));
            Temp.AddItem(new ValueInt(4), Temp.GetPlacePattern().SetValues(new long[] {3}));

            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, Temp);

            MS.Position = 0;
            SF = new SoapFormatter();
            Event Des_Alphabet = (Event) SF.Deserialize(MS);
            Assert.AreEqual(Temp, Des_Alphabet);
        }
*/


        ///<summary>
        /// Тестирует корректное клонирование
        ///</summary>
        [Test]
        public void TestClone()
        {
            Event Temp = new Event();
            Temp.AddDimension(new Dimension(0, 10));

            Temp.AddItem(new ValueInt(1), Temp.GetPlacePattern().SetValues(new long[] {0}));
            Temp.AddItem(new ValueInt(2), Temp.GetPlacePattern().SetValues(new long[] {1}));
            Temp.AddItem(new ValueInt(3), Temp.GetPlacePattern().SetValues(new long[] {2}));
            Temp.AddItem(new ValueInt(4), Temp.GetPlacePattern().SetValues(new long[] {3}));

            Event Clone_Alphabet = (Event) Temp.Clone();
            Assert.AreEqual(Temp, Clone_Alphabet);
        }
    }
}