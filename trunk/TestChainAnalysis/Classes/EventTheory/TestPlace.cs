using System;
using System.Collections;
using ChainAnalises.Classes.EventTheory;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.EventTheory
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestPlace
    {
        ///<summary>
        /// Тест тестирующий конструктор....
        /// Тестирует если передаем null протранство
        ///</summary>
        public void TestConstructorNull()
        {
            // Null пространство и пусто пространство
            try
            {
                new Place(null);
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
        /// Тест тестирующий конструктор....
        /// Тестирует если передаем пустое протранство
        ///</summary>
        public void TestConstructorFreeSpace()
        {
            try
            {
                new Place(new ArrayList());
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
        /// Тест тестирующий конструктор....
        /// Тестирует если передаем протранство содержащее одно и тоже измерение > 1 раза 
        ///</summary>
        public void TestConstructorBrokenSpace()
        {
            ArrayList Ar = new ArrayList();
            Dimension Ds = new Dimension(0, 10);
            Ar.Add(new Dimension(-50, -48));
            Ar.Add(Ds);
            Ar.Add(Ds);
            Ar.Add(new Dimension(-2, 10));
            try
            {
                new Place(Ar);
//                Assert.Fail();
            }
            catch (Exception)
            {
//            if(e.GetType()==typeof(AssertionException)) {
                Assert.Fail();
                //}
            }
        }

        ///<summary>
        /// Тест тестирующий конструктор....
        /// Тестирует передачу второго измерения > первого протранства
        ///</summary>
        public void TestConstructorFirstDimensionLess()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(-50, -48));
            Ar.Add(new Dimension(-2, 10));
            Place Pl = new Place(Ar);
            Assert.IsTrue(((Dimension) Ar[0]).EqualsAsDimension((Dimension) Pl.Dimension[0]));
            Assert.IsTrue(((Dimension) Ar[1]).EqualsAsDimension((Dimension) Pl.Dimension[1]));
        }

        ///<summary>
        /// Тест тестирующий конструктор....
        /// Тестирует передачу первое измерение > второго протранства 
        ///</summary>
        public void TestConstructorSecondDimensionLess()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(-50, 150));
            Ar.Add(new Dimension(-2, 10));
            Place Pl = new Place(Ar);
            Assert.IsTrue(((Dimension) Ar[0]).EqualsAsDimension((Dimension) Pl.Dimension[0]));
            Assert.IsTrue(((Dimension) Ar[1]).EqualsAsDimension((Dimension) Pl.Dimension[1]));
        }

        ///<summary>
        /// Тест тестирующий конструктор....
        /// Тестирует передачу первое измерение = второму протранства 
        ///</summary>
        public void TestConstructorDimensionsEquals()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 150));
            Ar.Add(new Dimension(0, 150));
            Place Pl = new Place(Ar);
            Assert.IsTrue(((Dimension) Ar[0]).EqualsAsDimension((Dimension) Pl.Dimension[0]));
            Assert.IsTrue(((Dimension) Ar[1]).EqualsAsDimension((Dimension) Pl.Dimension[1]));
        }

        ///<summary>
        /// Тест тестирующий конструктор....
        /// Тестирует если передаем не пространство(один из элеметов не измерение)
        ///</summary>
        public void TestConstructorNotAllAreDimension()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(-50, 100));
            Ar.Add(new object());
            Ar.Add(new Dimension(-2, 10));
            Place Pl = null;
            try
            {
                Pl = new Place(Ar);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof (AssertionException))
                {
                    Assert.Fail();
                }
                if (Pl != null) Assert.AreEqual(Pl.Dimension.Count, Pl.GetValues().GetLength(0));
            }
        }

        ///<summary>
        /// Тестирует ситуацию когда список заданый при создании Place изменится
        ///</summary>
        public void TestChangeSpaceAfterCreatePlace()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 150));
            Place Pl = new Place(Ar);
            Ar.Add(new Dimension(0, 150));
            Ar.Add(new Dimension(0, 150));
            Ar.Add(new Dimension(0, 150));
            Assert.AreEqual(1, Pl.Dimension.Count);
            Assert.AreEqual(1, Pl.GetValues().GetLength(0));
        }

        ///<summary>
        /// Тестирует ситуацию когда пытаемся установит знаение измерению имеющему индекс больше чем размерность
        ///</summary>
        public void TestSetValueIndexGreateThanMax()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 10));
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(10, 3);
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
        /// Тестирует ситуацию когда пытаемся установит знаение измерению имеющему индекс меньше 0
        /// </summary>
        public void TestSetValueIndexLessThanZero()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 10));
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(10, -3);
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
        /// Тестирует ситуацию когда пытаемся установит знаение меньше минимальной границы на которой определено измерение
        /// </summary>
        public void TestSetValueLessThanMin()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 10));
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(-10, 0);
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
        /// Тестирует ситуацию когда пытаемся установит знаение больше максимальной границы на которой определено измерение
        /// </summary>
        public void TestSetValueGreateThanMax()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 10));
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(100, 0);
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
        /// Тестирует ситуацию когда пытаемся установит знаение равное максимальной границе на которой определено измерение
        /// </summary>
        public void TestSetValueEqualsMax()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 10));
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(10, 0);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        ///<summary>
        /// Тестирует ситуацию когда пытаемся установит знаение равное минимельной границе на которой определено измерение
        /// </summary>
        public void TestSetValueEqualsMin()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 10));
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(0, 0);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        ///<summary>
        /// Тестирует установку в рабочем режиме
        /// </summary>
        public void TestSetValueInWorkMode()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 10));
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(5, 0);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

/*
        ///<summary>
        /// Тестирует  установку значений в рабочем режиме с указанием объекта измерения
        ///</summary>
        public void TestSetValueDimensionInWorkMode()
        {
            ArrayList Ar = new ArrayList();
            Dimension dm = new Dimension(0, 10);
            Ar.Add(new Dimension(0, 10));
            Ar.Add(dm);
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(5, dm);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.AreEqual(5,Pl.GetValue(1));
        }

        ///<summary>
        /// Тестирует  установку значений в несуществующее измерение
        ///</summary>
        public void TestSetValueDimensionAbsent()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 10));
            Ar.Add(new Dimension(0,10));
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(5, new Dimension(0,10));
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType()==typeof(AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует  установку значений в null измерение
        ///</summary>
        public void TestSetValueDimensionNull()
        {
            ArrayList Ar = new ArrayList();
            Ar.Add(new Dimension(0, 10));
            Ar.Add(new Dimension(0, 10));
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(5, null);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует  установку значений меньше минимальной границы области определения измерения
        ///</summary>
        public void TestSetValueDimensionLessThanMin()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0,10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(-10, Dm1);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует  установку значений больше максимальной границы области определения измерения
        ///</summary>
        public void TestSetValueDimensionGreaterThanMax()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(100, Dm2);
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(AssertionException))
                {
                    Assert.Fail();
                }
            }
        }

        ///<summary>
        /// Тестирует  установку значений равную максимальной границы области определения измерения
        ///</summary>
        public void TestSetValueDimensionEqualMax()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(10, Dm2);
            }
            catch (Exception)
            {
                    Assert.Fail();
            }
        }

        ///<summary>
        /// Тестирует  установку значений равную максимальной границы области определения измерения
        ///</summary>
        public void TestSetValueDimensionEqualMin()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValue(0, Dm3);
            }
            catch (Exception)
            {
                    Assert.Fail();
            }
        }
*/

        ///<summary>
        /// Тестирует  установку значений из массива в рабочем режиме
        ///</summary>
        [Test]
        public void TestSetValuesInWorkMode()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;

            Place plnew = Pl.SetValues(values);

            Assert.IsTrue(plnew.EqualsAsPlace(Pl));
        }

        ///<summary>
        /// Тестирует  установку значений из массива 
        /// длинна которого меньше размерности пространства которому принадлежит место
        ///</summary>
        public void TestSetValuesCountNotEqualsDimensionCount()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[2];
            values[0] = 5;
            values[1] = 2;
            try
            {
                Pl.SetValues(values);
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
        /// Тестирует  установку значений выходящих за область определния измерений из массива
        ///</summary>
        public void TestSetValuesNotInWorkRange()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 12;
            values[2] = 2;
            try
            {
                Pl.SetValues(values);
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
        /// Тестирует  установку граничных значений области определения измерений из массива
        ///</summary>
        public void TestSetValuesOnborderOfWorkRange()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 0;
            values[1] = 10;
            values[2] = 0;
            try
            {
                Pl.SetValues(values);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        ///<summary>
        /// Тестирует  установку значений из null массива
        ///</summary>
        public void TestSetValuesfromNull()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            try
            {
                Pl.SetValues(null);
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
        /// Тестирует  получение значений в рабочем режиме
        ///</summary>
        public void TestGetValueInWorkMode()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl.SetValues(values);
            Assert.AreEqual(2, Pl.GetValue(1));
        }

        ///<summary>
        /// Тестирует  получение значений несуществующего измерния
        ///</summary>
        public void TestGetValueAbsentDimension()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl.SetValues(values);
            try
            {
                Pl.GetValue(6);
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

/*
        ///<summary>
        /// Тестирует  получение значений по измериеню в рабочем режиме
        ///</summary>
        public void TestGetValueByDimesnionInWorkMode()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl.SetValues(values);
            Assert.AreEqual(2, Pl.GetValue(Dm2));
        }

        ///<summary>
        /// Тестирует  получение значений по измерению несуществующего измерния
        ///</summary>
        public void TestGetValueByDimensionAbsentDimension()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl.SetValues(values);
            try
            {
                Pl.GetValue(new Dimension(0,10));
                Assert.Fail();
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(AssertionException))
                {
                    Assert.Fail();
                }
            }

        }
*/

        ///<summary>
        /// Тестирует  получение значений в масиив в рабочем режиме
        ///</summary>
        public void TestGetValuesInWorkMode()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl.SetValues(values);
            Assert.AreEqual(values, Pl.GetValues());
        }

        ///<summary>
        /// Тестирует изменение измерения принадлежащего месту
        ///</summary>
        public void TestDimensionsChangeDimension()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl = new Place(Ar);
            long[] values = new long[2];
            values[0] = 5;
            values[1] = 2;
            Pl.SetValues(values);
//          Pl.Dimension[1] = Dm3;
            Assert.AreNotEqual(Pl.Dimension[1], Dm3);
        }

        ///<summary>
        /// Тестирует сравнение списка измерений
        ///</summary>
        public void TestDimensionsAreEqualsDimension()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl = new Place(Ar);
            long[] values = new long[2];
            values[0] = 5;
            values[1] = 2;
            Pl.SetValues(values);
            Assert.IsTrue(((Dimension) Ar[0]).EqualsAsDimension((Dimension) Pl.Dimension[0]));
            Assert.IsTrue(((Dimension) Ar[1]).EqualsAsDimension((Dimension) Pl.Dimension[1]));
        }

        ///<summary>
        /// Тестирует совместимость самому себе
        ///</summary>
        public void TestCompaibleToItSelf()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl = new Place(Ar);
            Assert.IsTrue(Pl.CompatibleTo(Pl));
        }

        ///<summary>
        /// Тестирует совместимость месту принадлежащему однму пространству
        ///</summary>
        public void TestCompaibleToPlaceFromSameSpace()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl = new Place(Ar);
            Place Pl2 = new Place(Ar);
            Assert.IsTrue(Pl.CompatibleTo(Pl2));
        }

        ///<summary>
        /// Тестирует совместимость null месту
        ///</summary>
        public void TestCompaibleToNullPlace()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl = new Place(Ar);
            try
            {
                Pl.CompatibleTo(null);
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
        /// Тестирует совместимость месту принадлежащему разным пространствам
        ///</summary>
        public void TestCompaibleToPlaceFromDiferentSpace()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl = new Place(Ar);
            Ar.Add(Dm3);
            Place Pl2 = new Place(Ar);
            Assert.IsFalse(Pl.CompatibleTo(Pl2));
        }

        ///<summary>
        /// Тестирует проверку на соседство самому себе
        ///</summary>
        public void TestNeighbourToItSelf()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl.SetValues(values);
            Assert.IsFalse(Pl.Neighbour(Pl));
        }

        ///<summary>
        /// Тестирует проверку на соседство месту принадлежаешему другому пространства 
        ///</summary>
        public void TestNeighbourToPlaceFromOtherSpace()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl1 = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl1.SetValues(values);
            Ar = new ArrayList();
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl2 = new Place(Ar);
            values = new long[2];
            values[0] = 5;
            values[1] = 3;
            Pl2.SetValues(values);
            Assert.IsFalse(Pl1.Neighbour(Pl2));
        }

        ///<summary>
        /// Тестирует проверку на соседство null месту
        ///</summary>
        public void TestNeighbourToNull()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl1 = new Place(Ar);
            long[] values = new long[2];
            values[0] = 5;
            values[1] = 2;
            Pl1.SetValues(values);
            Assert.IsFalse(Pl1.Neighbour(null));
        }

        ///<summary>
        /// Тестирует проверку на соседство сеседнему месту
        ///</summary>
        public void TestNeighbourToNeighbourPlace()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl1 = new Place(Ar);
            Place Pl2 = new Place(Ar);
            long[] values = new long[2];
            values[0] = 5;
            values[1] = 2;
            Pl1.SetValues(values);
            values[1] = 3;
            Pl2.SetValues(values);
            Assert.IsTrue(Pl1.Neighbour(Pl2));
        }

        ///<summary>
        /// Тестирует проверку на соседство не соседнему месту расстояние в нескольких значениях
        ///</summary>
        public void TestNeighbourToNoNeighbourPlace()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl1 = new Place(Ar);
            Place Pl2 = new Place(Ar);
            long[] values = new long[2];
            values[0] = 5;
            values[1] = 2;
            Pl1.SetValues(values);
            values[0] = 6;
            values[1] = 3;
            Pl2.SetValues(values);
            Assert.IsFalse(Pl1.Neighbour(Pl2));
        }

        ///<summary>
        /// Тестирует проверку на соседство не соседнему месту расстояние в одном значении но существенно
        ///</summary>
        public void TestNeighbourToFarPlace()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl1 = new Place(Ar);
            Place Pl2 = new Place(Ar);
            long[] values = new long[2];
            values[0] = 5;
            values[1] = 2;
            Pl1.SetValues(values);
            values[1] = 9;
            Pl2.SetValues(values);
            Assert.IsFalse(Pl1.Neighbour(Pl2));
        }

        ///<summary>
        /// Тестирует проверку на соседство самому себе
        ///</summary>
        public void TestNeighbourToSelf()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl1 = new Place(Ar);
            long[] values = new long[2];
            values[0] = 5;
            values[1] = 2;
            Pl1.SetValues(values);
            Assert.IsFalse(Pl1.Neighbour(Pl1));
        }

        ///<summary>
        /// Тестирует проверку на равенство как места null месту
        ///</summary>
        public void TestEqualsAsPlaceToNull()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl1 = new Place(Ar);
            Assert.IsFalse(Pl1.EqualsAsPlace(null));
        }

        ///<summary>
        /// Тестирует проверку на равенство как места принадлежаешему другому пространства 
        ///</summary>
        public void TestEqualsAsPlaceToPlaceFromOtherSpace()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl1 = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl1.SetValues(values);
            Ar = new ArrayList();
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Place Pl2 = new Place(Ar);
            values = new long[2];
            values[0] = 5;
            values[1] = 3;
            Pl2.SetValues(values);
            Assert.IsFalse(Pl1.EqualsAsPlace(Pl2));
        }

        ///<summary>
        /// Тестирует проверку на равенство как места принадлежаешему другому пространства 
        ///</summary>
        public void TestEqualsAsPlaceToPlaceInWorkMode()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl1 = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl1.SetValues(values);
            Place Pl2 = new Place(Ar);
            values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl2.SetValues(values);
            Assert.IsTrue(Pl1.EqualsAsPlace(Pl2));
        }

        ///<summary>
        /// Тест проверяющий корректность клонирования
        ///</summary>
        public void TestClone()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl.SetValues(values);

            Place PlAfter = (Place) Pl.Clone();

            Assert.AreNotSame(Pl, PlAfter);
            Assert.IsTrue(Pl.EqualsAsPlace(PlAfter));
            Pl.SetValue(7, 1);
            Assert.AreEqual(2, PlAfter.GetValue(1));
        }
/*
        ///<summary>
        /// Тест проверяющий корректность сериализации и десериализации
        ///</summary>
        public void TestSerializationDeSerialization()
        {
            ArrayList Ar = new ArrayList();
            Dimension Dm1 = new Dimension(0, 10);
            Dimension Dm2 = new Dimension(0, 10);
            Dimension Dm3 = new Dimension(0, 10);
            Ar.Add(Dm1);
            Ar.Add(Dm2);
            Ar.Add(Dm3);
            Place Pl = new Place(Ar);
            long[] values = new long[3];
            values[0] = 5;
            values[1] = 2;
            values[2] = 7;
            Pl.SetValues(values);
            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, Pl);
            MS.Position = 0;
            SF = new SoapFormatter();
            Place PlAfter = (Place) SF.Deserialize(MS);
            Assert.IsTrue(Pl.EqualsAsPlace(PlAfter));
        }*/
    }
}