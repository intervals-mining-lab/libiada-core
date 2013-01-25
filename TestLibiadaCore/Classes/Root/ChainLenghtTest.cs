using System;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace TestLibiadaCore.Classes.Root
{
    [TestFixture]
    class ChainLenghtTest
    {
        private char GetElement(int elementIndex)
        { 
            switch (elementIndex%4)
            {
                case 0: return 'G';
                case 1: return 'C';
                case 2: return 'T';
                case 3: return 'A'; 
            }
            return 'A';
            
        }

        [Ignore]
        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test1()
        {
            char simbol;
            String first = new String('A', 1000);
            String second = new String('A', 1001);
           Random  random =new Random();
           for (int i = 0; i < 1000; i++)
           {
               simbol=GetElement(random.Next(3));
               first.Insert(i,simbol.ToString());
               second.Insert(i, simbol.ToString());

           }
            second.Insert(1000,GetElement(random.Next(3)).ToString());
            first[1000].ToString();
            Assert.Fail();

        }


        [Ignore]
        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test2()
        {
            char simbol;
            String first = new String('A', 10000);
            String second = new String('A', 10001);
            Random random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                simbol = GetElement(random.Next(3));
                first.Insert(i, simbol.ToString());
                second.Insert(i, simbol.ToString());

            }
            second.Insert(10000, GetElement(random.Next(3)).ToString());
            first[10000].ToString();
            Assert.Fail();

        }

        [Ignore]
        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test3()
        {
            char simbol;
            String first = new String('A', 100000);
            String second = new String('A', 100001);
            Random random = new Random();
            for (int i = 0; i < 100000; i++)
            {
                simbol = GetElement(random.Next(3));
                first.Insert(i, simbol.ToString());
                second.Insert(i, simbol.ToString());

            }
            second.Insert(100000, GetElement(random.Next(3)).ToString());
            first[100000].ToString();
            Assert.Fail();

        }

        [Ignore]
        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test4()
        {
            char simbol;
            String first = new String('A', 1000000);
            String second = new String('A', 1000001);
            Random random = new Random();
            for (int i = 0; i < 1000000; i++)
            {
                simbol = GetElement(random.Next(3));
                first.Insert(i, simbol.ToString());
                second.Insert(i, simbol.ToString());

            }
            second.Insert(1000000, GetElement(random.Next(3)).ToString());
            first[1000000].ToString();
            Assert.Fail();

        }

        [Ignore]
        [Test]
        public void Chain10Test5()
        {
            char simbol;

            Chain chain1 = new Chain(10);//дата грид не забудь!!!!
            Chain chain2 = new Chain(11);//дата грид не забудь!!!!
            Random random = new Random();
           for (int i = 0; i <10 ; i++)
            {
                simbol = GetElement(random.Next(3));
                chain1[i] = new ValueChar(simbol);
                chain2[i] = new ValueChar(simbol);
                Assert.IsTrue(chain2[i].Equals(chain1[i]));
                Assert.AreEqual(chain2[i].ToString(), simbol.ToString());
            }
          

        }

        [Ignore]
        [Test]
        public void Chain1000000Test6()
        {
            char simbol;

            Chain chain1 = new Chain(1000000);//дата грид не забудь!!!!
            Chain chain2 = new Chain(1000000);//дата грид не забудь!!!!
            Random random = new Random();
            for (int i = 0; i < 1000000; i++)
            {
                simbol = GetElement(random.Next(3));
                chain1[i] = new ValueChar(simbol);
                chain2[i] = new ValueChar(simbol);
                Assert.IsTrue(chain2[i].Equals(chain1[i]));
                Assert.AreEqual(chain2[i].ToString(), simbol.ToString());
            }


        }


    }
}
