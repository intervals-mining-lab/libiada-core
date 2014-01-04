using LibiadaCore.Classes.Root.SimpleTypes;
using NUnit.Framework;

namespace LibiadaCoreTest.Classes.Root.SimpleTypes
{
    [TestFixture]
    public class NullValueTest
    {
        [Test]
        public void IncstanceNotNullTest()
        {
            Assert.IsNotNull(NullValue.Instance());
        }

        [Test]
        public void InstanceSingleToneTest()
        {
            Assert.AreSame(NullValue.Instance(), NullValue.Instance());
        }
    }
}