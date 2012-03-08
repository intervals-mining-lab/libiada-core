using NUnit.Framework;
using PhantomChains.Classes.Statistics;

namespace TestPhantomChains.Classes.Statistics
{
    [TestFixture]
    public class TestSortDictionary
    {
        [SetUp]
        public void init()
        {
            
        }

        [Test]
        public void TestGetByKey()
        {
            SortDictionary Dic = new SortDictionary();
            Dic.Add((ValueString) "a", 0.25);
            Dic.Add((ValueString)"b", 0.75);
            Dic.Add((ValueString)"c", 1);

            Assert.AreEqual(0.25, Dic.GetValue((ValueString) "a"));
            Assert.AreEqual(0.75, Dic.GetValue((ValueString)"b"));
            Assert.AreEqual(1, Dic.GetValue((ValueString)"c"));
        }
        
        [Test]
        public void TestGetIndex()
        {
            SortDictionary Dic = new SortDictionary();
            Dic.Add((ValueString)"c", 1);
            Dic.Add((ValueString)"a", 0.25);
            Dic.Add((ValueString)"b", 0.75);


            Assert.AreEqual(0.25, Dic.GetValueByIndex(0));
            Assert.AreEqual(0.75, Dic.GetValueByIndex(1));
            Assert.AreEqual(1, Dic.GetValueByIndex(2));
        }

        [Test]
        public void TestKeyByIndex()
        {
            SortDictionary Dic = new SortDictionary();
            Dic.Add((ValueString)"c", 1);
            Dic.Add((ValueString)"a", 0.25);
            Dic.Add((ValueString)"b", 0.75);

            Assert.AreEqual((ValueString)"a", Dic.GetKeyByIndex(0));
            Assert.AreEqual((ValueString)"b", Dic.GetKeyByIndex(1));
            Assert.AreEqual((ValueString)"c", Dic.GetKeyByIndex(2));
        }
    }
}