using System;
using System.Collections;
using ChainAnalises.Classes.EventTheory;
using NUnit.Framework;

namespace TestChainAnalysis.Classes.EventTheory
{
    ///<summary>
    /// ����� �������� ����� ��� ������������ ������ ������� ������ ReadRule
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
        /// ��������� ����������� ���� ��� ���������� null �����
        /// ������� ����������
        ///</summary>
        [Test]
        public void TestConstructorNull()
        {
            try
            {
                new ReadRule(null);
            }
            catch (NullReferenceException)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ����������� ���� ��� ���������� ����� (������� �����)
        ///</summary>
        [Test]
        public void TestConstructorInWorkMode()
        {
            new ReadRule(PlBase);
        }

        ///<summary>
        /// ���� ����������� ���������� ����� �������������� ������� ������������
        ///</summary>
        [Test]
        public void TestAddPlaceFromOtherSpace()
        {
            try
            {
                ReadRule Test = new ReadRule(PlBase);
                Test.Add(PlFromOtherSpace);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ���������� ����� � ������� ������
        ///</summary>
        [Test]
        public void TestAddPlaceInWorkMode()
        {
            rrTest.Add(PlNeighbour);
        }

        ///<summary>
        /// ��������� ���������� ����� � ������� ������
        ///</summary>
        [Test]
        public void TestAddPlaceNotNeighbour()
        {
            try
            {
                rrTest.Add(PlNotNeighbour);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ���������� ������ � ���� �� ����� ������
        ///</summary>
        [Test]
        public void TestAddTwise()
        {
            try
            {
                rrTest.Add(PlNeighbour);
                rrTest.Add(PlNeighbour);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// �e������� ������� ���������� null �����
        ///</summary>
        [Test]
        public void TestAddNull()
        {
            try
            {
                rrTest.Add((Place) null);
            }
            catch (NullReferenceException)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ��������� ��������
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
        /// ��������� ������������� ��������� �� ��� ��������� ������
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
        /// ��������� ��������� � ������� ������
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
        /// ��������� ��������� ����� �������������� ������� ������������ 
        ///</summary>
        [Test]
        public void TestSetFromOtherSpace()
        {
            try
            {
                rrTest.Add(PlNeighbour);
                rrTest[0] = PlFromOtherSpace;
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }


        ///<summary>
        /// ��������� ��������� ����� ������
        ///</summary>
        [Test]
        public void TestSetTwise()
        {
            try
            {
                rrTest.Add(PlNeighbour);
                rrTest.Add(PlNeighbour2);
                rrTest[0] = PlNeighbour2;
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ��������� ����������� ����� 
        ///</summary>
        [Test]
        public void TestSetNotNeighbour()
        {
            try
            {
                rrTest.Add(PlNeighbour);
                rrTest[0] = PlNotNeighbour;
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ��������� null �����
        ///</summary>
        [Test]
        public void TestSetNull()
        {
            try
            {
                rrTest.Add(PlNeighbour);
                rrTest[0] = null;
            }
            catch (NullReferenceException)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� �������� �����
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
        /// �������� �������� �� ������������� ��������
        ///</summary>
        [Test]
        public void TestRemoveOutOfRange()
        {
            try
            {
                rrTest.Add(PlNeighbour);
                rrTest.Add(PlNeighbour2);
                rrTest.Remove(6);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ����� ��������������� � ������� ������
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
        /// ��������� ����� ��������������� � null
        ///</summary>
        [Test]
        public void TestEqualNull()
        {
            try
            {
                rrTest.Add(PlNeighbour);
                rrTest.Add(PlNeighbour2);
                Assert.IsTrue(rrTest.EqualAsRule(null));
            }
            catch (NullReferenceException)
            {
                return;
            }
            Assert.Fail();
        }


        ///<summary>
        /// ��������� ����� ��������������� � ������� ������
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
        /// ��������� ������������
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
        /// ���� ����������� ������������ ������������ � ��������������
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
        /// ��������� ������������ � �������� �������������� ������� ������������
        ///</summary>
        [Test]
        public void TestAddWithRuleOther()
        {
            try
            {
                ReadRule rr2 = new ReadRule(PlFromOtherSpace);
                rrTest.Add(rr2);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ����� ����������� ����������� � null ��������.
        ///</summary>
        [Test]
        public void TestAddWithRuleNull()
        {
            try
            {
                rrTest.Add((ReadRule) null);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ����� ����������� � �������� ������������� ������� �����
        ///</summary>
        [Test]
        public void TestAddWithRuleOtherPlace()
        {
            try
            {
                ReadRule rr2 = new ReadRule(PlNotNeighbour);
                rrTest.Add(rr2);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ����������� � �������� � ������� ������( ������� ������������ ������ � ���� �� �����) 
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