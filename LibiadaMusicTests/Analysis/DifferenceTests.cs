using LibiadaMusic.Analysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusic.Tests.Analysis
{
	[TestClass]
    public class DifferenceTests
	{
		[TestMethod]
        public void DifferenceTest()
		{
			var dif1 = new Difference();
			var dif2 = new Difference();
			Assert.AreEqual(dif1.D,dif2.D);				
			Assert.IsFalse(false);
		}
	}
}
