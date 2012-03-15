using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;
using PhantomChains.Classes.Statistics;

namespace TestPhantomChains.Classes.Statistics
{
    ///<summary>
    ///</summary>
    [TestFixture]
    public class TestFrequencyList
    {
        ///<summary>
        ///</summary>
        [SetUp]
        public void init()
        {
        }

        ///<summary>
        ///</summary>
        ///
        [Test]
        public void TestSumFrequencyLists()
        {
            FrequencyList FrequencyListA = new FrequencyList();
            FrequencyList FrequencyListB = new FrequencyList();

            ValueInt object1 = 4;
            ValueInt object2 = 5;
            ValueInt object3 = 6;


            FrequencyListA.Add(object2);
            FrequencyListA.Add(object3);
            FrequencyListA.Add(object3);

            FrequencyListB.Add(object2);
            FrequencyListB.Add(object1);
            FrequencyListB.Add(object3);

            FrequencyListA.Sum(FrequencyListB);


            Assert.IsTrue(FrequencyListA.Contains(object1));
            Assert.AreEqual(1, FrequencyListA.FrequencyFromObject(object1));

            Assert.IsTrue(FrequencyListA.Contains(object2));
            Assert.AreEqual(2, FrequencyListA.FrequencyFromObject(object2));

            Assert.IsTrue(FrequencyListA.Contains(object3));
            Assert.AreEqual(3, FrequencyListA.FrequencyFromObject(object3));
        }
    }
}