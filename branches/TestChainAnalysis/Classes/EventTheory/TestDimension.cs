using ChainAnalises.Classes.EventTheory;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.EventTheory
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestDimension
    {
        ///<summary>
        /// Тест проверяющий корректность отношения эквивалентности
        ///</summary>
        [Test]
        public void TestEquals()
        {
            Assert.IsTrue((new Dimension(0, 10)).EqualsAsDimension(new Dimension(0, 10)));
            Assert.IsFalse((new Dimension(0, 10)).EqualsAsDimension(new Dimension(-10, 0)));
            Dimension DD = new Dimension(0, 10);
            Assert.AreEqual(DD, DD);
            Assert.IsTrue(DD.EqualsAsDimension(DD));
        }

        ///<summary>
        /// Тест проверяющий корректность конструктора
        ///</summary>
        [Test]
        public void TestConstructor()
        {
            Assert.IsFalse((new Dimension(-120, 50)).EqualsAsDimension(null));
            Assert.IsTrue((new Dimension(0, 10)).EqualsAsDimension(new Dimension(10, 0)));
            /* try
            {
                new Dimension(0, 0);
                Assert.Fail();
                
            }catch(Exception e)
            {
                if (e.GetType()==typeof(AssertionException))
                {
                    Assert.Fail();
                }
            }*/
        }

        ///<summary>
        /// Тест проверяющий корректность отношения порядка
        ///</summary>
        [Test]
        public void TestCom()
        {
            Dimension DD = new Dimension(0, 12);
            Assert.IsFalse(DD.EqualsAsDimension(new Dimension(-15, -3)));
            Assert.IsTrue(DD.EqualsAsDimension(new Dimension(0, 12)));
            Assert.IsFalse(DD.EqualsAsDimension(new Dimension(-10, -3)));
        }

        ///<summary>
        /// Тест проверяющий корректность получения максимальной и минимальной границы области опрделения
        ///</summary>
        [Test]
        public void TestMaxMin()
        {
            Dimension DD = new Dimension(-155, 15);
            Assert.AreEqual(DD.max, 15);
            Assert.AreEqual(DD.min, -155);
        }

        ///<summary>
        /// Тест проверяющий корректность длинны области определения
        ///</summary>
        [Test]
        public void TestLength()
        {
            Dimension DD = new Dimension(-155, 15);
            Assert.AreEqual(DD.Length, (DD.max - DD.min + 1));
        }

        /*       ///<summary>
        /// Тест проверяющий корректность отношения порядка
        ///</summary>
        [Test]
        public void TestComTo()
        {
            Dimension DD = new Dimension(0, 12);
            Assert.AreEqual(0, DD.CompareTo(new Dimension(-15, -3)));
            Assert.AreNotEqual(0, DD.CompareTo(new Dimension(-10, -3)));
            Assert.Less(0, DD.CompareTo (new Dimension(-10, -3)));
            Assert.Greater(0, DD.CompareTo(new Dimension(-19, -3)));  
        }*/

/*        ///<summary>
        /// Тест проверяющий корректность сериализации и десериализации
        ///</summary>
        public void TestSerializationDeSerialization()
        {
            Dimension DD = new Dimension(0, 12);
            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, DD);
            MS.Position = 0;
            SF = new SoapFormatter();
            Dimension DDAfter = (Dimension) SF.Deserialize(MS);
            Assert.IsTrue(DD.EqualsAsDimension(DDAfter));
        }*/

        ///<summary>
        /// Тестирует Клонирование
        ///</summary>
        public void TestClone()
        {
            Dimension DM = new Dimension(0, 10);
            Dimension DMC = (Dimension) DM.Clone();
            Assert.AreNotSame(DMC, DM);
            Assert.IsTrue(DM.EqualsAsDimension(DMC));
        }
    }
}