using NUnit.Framework;
using Segmentation.Classes.Base.Sequencies;

namespace TestSegmentation.Classes.Base.Sequencies
{
    [TestFixture]
    public class OrderTest
    {
        private ComplexChain chain;

        [SetUp]
        public void SetUp()
        {
            chain = new ComplexChain("AACAGGTGCCCCTTATTT");
        }

        [Test]
        public void testsubstring()
        {
            Order builtOrder1, builtOrder2;
            ComplexChain chain;
            builtOrder1 = new Order(this.chain);
            chain = new ComplexChain("112133432222441444");
            builtOrder2 = new Order(chain);
            Assert.True(builtOrder1.Equals(builtOrder2));

        }
    }
}