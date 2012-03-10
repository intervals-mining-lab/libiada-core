using System;
using LibiadaCore.Classes.EventTheory;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.EventTheory
{
    ///<summary>
    /// ������ ����� ��������� ����� ������� Event
    ///</summary> 
    [TestFixture]
    public class TestEvent
    {
        private Event BaseEvent = null;
        private Place Key = null;
        private Place Value = null;


        ///<summary>
        /// ����� ������������ ������������� ������.
        ///</summary>
        [SetUp]
        public void init()
        {
            BaseEvent = new Event();
            BaseEvent.AddDimension(new Dimension(0, 10));
            BaseEvent.AddDimension(new Dimension(0, 10));
            Key = BaseEvent.GetPlacePattern();
            Value = BaseEvent.GetPlacePattern();
        }

        ///<summary>
        /// ���� ����������� ������ ���������� � ������� ��� �� ����� �����.
        /// �������� �������������� ��������.
        ///</summary>
        [Test]
        public void TestAddToRuleSelf()
        {
            try
            {
                Key.SetValues(new long[] {1, 1});
                Value.SetValues(new long[] {1, 1});
                BaseEvent.AddToReadRule(Key, Value);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ����� ����������� ���������� ����� � ������� � ������� ������.
        /// ����� ������������� � ������� ������ ���� ���������� � ������ � ���� ��� ��������
        ///</summary>
        [Test]
        public void TestAddToRuleInWorkMode()
        {
            Key.SetValues(new long[] {1, 1});
            Value.SetValues(new long[] {0, 1});
            BaseEvent.AddToReadRule(Key, Value);

            Assert.AreEqual(BaseEvent.GetFromReadRule(Key)[0], Value);
        }

        ///<summary>
        /// ����� ��������� ���������� null ����� � �������
        ///</summary>
        [Test]
        public void TestAddToRuleNullValue()
        {
            try
            {
                Key.SetValues(new long[] {1, 1});
                BaseEvent.AddToReadRule(Key, (Place) null);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ����� ��������� ���������� ����� � ������� ��� null �����.
        ///</summary>
        [Test]
        public void TestAddToRuleNullKey()
        {
            try
            {
                Value.SetValues(new long[] {1, 1});
                BaseEvent.AddToReadRule(null, Value);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� �������� ����� �������� ���������� ���� � ���� ����� � �������.
        ///</summary>
        [Test]
        public void TestAddToRuleSame()
        {
            Key.SetValues(new long[] {1, 1});
            Value.SetValues(new long[] {0, 1});
            BaseEvent.AddToReadRule(Key, Value);
            BaseEvent.AddToReadRule(Key, Value);

            Assert.AreEqual(1, BaseEvent.GetFromReadRule(Key).Count);
            Assert.AreEqual(BaseEvent.GetFromReadRule(Key)[0], Value);
        }

        ///<summary>
        ///��������� �������� ����� �� ������� ������ �������� ������� ��� ����� null
        ///</summary>
        [Test]
        public void TestRemoveFromNull()
        {
            try
            {
                BaseEvent.RemoveFromReadRule(null);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ����� ���������  �������� � ������� � ������� ������
        ///</summary>
        [Test]
        public void TestRemovFromInWorkMode()
        {
            Key.SetValues(new long[] {1, 1});
            Value.SetValues(new long[] {0, 1});
            BaseEvent.AddToReadRule(Key, Value);
            BaseEvent.RemoveFromReadRuleAt(0);

            Assert.IsNull(BaseEvent.GetFromReadRule(Key));
        }

        ///<summary>
        /// ��������� ������� ������� �������� �������� �� ������� � ������������� ����� �������������� ������� ������������
        ///</summary>
        [Test]
        public void TestRemoveFromWrongPlace()
        {

            try
            {            
                BaseEvent.AddDimension(new Dimension(0, 10));
                BaseEvent.AddDimension(new Dimension(-10, 10));
                Place PlaceOtherSpace = BaseEvent.GetPlacePattern();
                BaseEvent.AddDimension(new Dimension(10, 100));
                Place PlaceSpace = BaseEvent.GetPlacePattern();
                BaseEvent.AddItem(new ValueInt(1), PlaceSpace.SetValues(new long[] {0, 0, 0}));
                BaseEvent.RemoveFromReadRule(PlaceOtherSpace.SetValues(new long[] {0, 0})); 
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }


        ///<summary>
        /// ����� ��������� ������ � ������� ������ ����� GetFromRule
        ///</summary>
        [Test]
        public void TestGetFromRuleInWorkMode()
        {
            ReadRule GetFor = new ReadRule(BaseEvent.GetPlacePattern());
            Place pl = BaseEvent.GetPlacePattern().SetValues(new long[] {0, 1});
            BaseEvent.AddToReadRule(pl, GetFor);

            ReadRule GetAfter = BaseEvent.GetFromReadRule(pl);
            Assert.AreEqual(GetFor, GetAfter);
        }

        ///<summary>
        /// ��������� ������� �������� ������� ������ � �������������� �������� null
        ///</summary>
        [Test]
        public void TestGetFromRuleNUll()
        {
            try
            {
                BaseEvent.GetFromReadRule(null);
            }
            catch (NullReferenceException)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ����� ���������� �������
        ///</summary>
        [Test]
        public void TestAddRuleInWorkMode()
        {
            ReadRule rr = new ReadRule(BaseEvent.GetPlacePattern());
            Key.SetValues(new long[] {1, 1});

            Value.SetValues(new long[] {0, 1});
            rr.Add(Value);

            Value.SetValues(new long[] {1, 0});
            rr.Add(Value);

            BaseEvent.AddToReadRule(Key, rr);

            Assert.AreEqual(BaseEvent.GetFromReadRule(Key), rr);
        }

        ///<summary>
        /// ����� ��������� ���������� null ������� � ������� ������
        ///</summary>
        [Test]
        public void TestAddRuleNullValue()
        {
            try
            {
                Key.SetValues(new long[] {1, 1});
                BaseEvent.AddToReadRule(Key, (ReadRule) null);
            }
            catch (Exception)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ����� ��������� ��������� ������� ��� ���������� ������� ��� null �����
        ///</summary>
        [Test]
        public void TestAddRuleNullKey()
        {
            try
            {
                ReadRule rr = new ReadRule(BaseEvent.GetPlacePattern());
                Value.SetValues(new long[] {0, 1});
                rr.Add(Value);
                
                Value.SetValues(new long[] {1, 0});
                rr.Add(Value);
                BaseEvent.AddToReadRule(null, rr);
            }
            catch (NullReferenceException)
            {
                return;
            }
            Assert.Fail();
        }

        ///<summary>
        /// ��������� ���������� ���� ������ ������ � ���� ����� 
        /// ��� ���� ������� ������ �����������
        ///</summary>
        [Test]
        public void TestAddRuleTwice()
        {
            ReadRule rr = new ReadRule(BaseEvent.GetPlacePattern());
            ReadRule rr2 = new ReadRule(BaseEvent.GetPlacePattern());

            Key.SetValues(new long[] {1, 1});

            Value.SetValues(new long[] {0, 1});
            rr.Add(Value);

            Assert.AreEqual(1, rr.Count);
            Assert.AreEqual(Value, rr[0]);

            Value.SetValues(new long[] {1, 0});
            rr2.Add(Value);

            Assert.AreEqual(1, rr2.Count);
            Assert.AreEqual(Value, rr2[0]);

            Assert.AreNotEqual(rr, rr2);


            BaseEvent.AddToReadRule(Key, rr);
            Assert.AreEqual(rr, BaseEvent.GetFromReadRule(Key));

            BaseEvent.AddToReadRule(Key, rr2);
            Assert.AreNotEqual(rr2, BaseEvent.GetFromReadRule(Key));

            Assert.AreNotEqual(rr, BaseEvent.GetFromReadRule(Key));

            Assert.AreEqual(rr2.Add(rr), BaseEvent.GetFromReadRule(Key));
            Assert.AreEqual(Value.SetValues(new long[] {0, 1}), BaseEvent.GetFromReadRule(Key)[0]);
            Assert.AreEqual(Value.SetValues(new long[] {1, 0}), BaseEvent.GetFromReadRule(Key)[1]);
            Assert.IsNotNull(BaseEvent.GetFromReadRule(Key)[1]);
        }

        ///<summary>
        ///��������� �������� ������������ ���-�� ������
        ///</summary>
        [Test]
        public void TestReadRuleCount()
        {
            Key.SetValues(new long[] {1, 1});
            Value.SetValues(new long[] {0, 1});
            BaseEvent.AddToReadRule(Key, Value);


            Key.SetValues(new long[] {4, 6});
            Value.SetValues(new long[] {5, 6});
            BaseEvent.AddToReadRule((Place) Key.Clone(), Value);

            Assert.AreEqual(2, BaseEvent.ReadRuleCount);
        }

        ///<summary>
        /// ���� ��������� ��������� ����������������
        /// ��� ������� ������������ ���� ��� ������������ ������������� ������ � �� ����������� ������������
        ///</summary>
        [Test]
        public void TestEquals()
        {
            Event Event2 = new Event();
            Event2.AddDimension(new Dimension(0, 10));
            Event2.AddDimension(new Dimension(0, 10));

            Place Key2 = Event2.GetPlacePattern();
            Place Value2 = Event2.GetPlacePattern();

            Key.SetValues(new long[] {1, 1});

            Value.SetValues(new long[] {0, 1});
            BaseEvent.AddToReadRule(Key, Value);

            Value.SetValues(new long[] {1, 0});
            BaseEvent.AddToReadRule(Key, Value);


            Key.SetValues(new long[] {4, 3});

            Value.SetValues(new long[] {4, 2});
            BaseEvent.AddToReadRule(Key, Value);

            Key2.SetValues(new long[] {1, 1});

            Value2.SetValues(new long[] {0, 1});
            Event2.AddToReadRule(Key2, Value2);

            Value2.SetValues(new long[] {1, 0});
            Event2.AddToReadRule(Key2, Value2);


            Key2.SetValues(new long[] {4, 3});

            Value2.SetValues(new long[] {4, 2});
            Event2.AddToReadRule(Key2, Value2);


            Assert.IsTrue(BaseEvent.Equals(Event2));
        }

        ///<summary>
        /// ���� ��������� ��������� ����������������
        /// ��� ������� ������������ ���� ��� ������������ ������������� ������ � �� ����������� ������������
        ///</summary>
        [Test]
        public void TestEqualsFalse()
        {
            Event Event2 = new Event();
            Event2.AddDimension(new Dimension(0, 10));
            Event2.AddDimension(new Dimension(0, 10));

            Place Key2 = Event2.GetPlacePattern();
            Place Value2 = Event2.GetPlacePattern();

            Key.SetValues(new long[] {1, 1});

            Value.SetValues(new long[] {0, 1});
            BaseEvent.AddToReadRule(Key, Value);

            Value.SetValues(new long[] {1, 0});
            BaseEvent.AddToReadRule(Key, Value);


            Key.SetValues(new long[] {4, 3});

            Value.SetValues(new long[] {4, 2});
            BaseEvent.AddToReadRule(Key, Value);

            Key2.SetValues(new long[] {1, 1});

            Value2.SetValues(new long[] {0, 1});
            Event2.AddToReadRule(Key2, Value2);

            Value2.SetValues(new long[] {1, 0});
            Event2.AddToReadRule(Key2, Value2);

            Assert.IsFalse(BaseEvent.Equals(Event2));
        }


        ///<summary>
        /// ���� ��������� ��������� ����������������
        /// ��� ������� ������������ ���� ��� ������������ ������������� ������ � �� ����������� ������������
        /// null �������������� ������.
        ///</summary>
        [Test]
        public void TestEqualsNull()
        {
            Key.SetValues(new long[] {1, 1});

            Value.SetValues(new long[] {0, 1});
            BaseEvent.AddToReadRule(Key, Value);

            Value.SetValues(new long[] {1, 0});
            BaseEvent.AddToReadRule(Key, Value);


            Key.SetValues(new long[] {4, 3});

            Value.SetValues(new long[] {4, 2});
            BaseEvent.AddToReadRule(Key, Value);

            Assert.IsFalse(BaseEvent.Equals(null));
        }

        ///<summary>
        /// ���������  ������������ 
        ///</summary>
        [Test]
        public void TestClone()
        {
            Key.SetValues(new long[] {1, 1});

            Value.SetValues(new long[] {0, 1});
            BaseEvent.AddToReadRule(Key, Value);

            Value.SetValues(new long[] {1, 0});
            BaseEvent.AddToReadRule(Key, Value);


            Key.SetValues(new long[] {4, 3});

            Value.SetValues(new long[] {4, 2});
            BaseEvent.AddToReadRule(Key, Value);

            Event ItsClone = (Event) BaseEvent.Clone();
            Assert.AreEqual(BaseEvent, ItsClone);
        }
/*
        ///<summary>
        /// ��������� ���������� ������������ � �������������� ������������
        ///</summary>
        [Test]
        public void TestSerializeDeserialize()
        {
            BaseEvent.AddItem(new ValueInt(1), BaseEvent.GetPlacePattern().SetValues(new long[] {0, 1}));
            BaseEvent.AddItem(new ValueInt(2), BaseEvent.GetPlacePattern().SetValues(new long[] {1, 5}));
            BaseEvent.AddItem(new ValueInt(3), BaseEvent.GetPlacePattern().SetValues(new long[] {2, 9}));
            BaseEvent.AddItem(new ValueInt(4), BaseEvent.GetPlacePattern().SetValues(new long[] {3, 0}));


            Key.SetValues(new long[] {1, 1});

            Value.SetValues(new long[] {0, 1});
            BaseEvent.AddToReadRule(Key, Value);

            Value.SetValues(new long[] {1, 0});
            BaseEvent.AddToReadRule(Key, Value);


            Key.SetValues(new long[] {4, 3});

            Value.SetValues(new long[] {4, 2});
            BaseEvent.AddToReadRule(Key, Value);


            MemoryStream MS = new MemoryStream();
            SoapFormatter SF = new SoapFormatter();
            SF.Serialize(MS, BaseEvent);

            MS.Position = 0;
            SF = new SoapFormatter();
            Event Des_Event = (Event) SF.Deserialize(MS);
            Assert.AreEqual(BaseEvent, Des_Event);
        }*/
    }
}