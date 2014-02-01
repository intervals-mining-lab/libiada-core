using LibiadaMusic.Analysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTest
{
	
	[TestClass]
	public class Test
	{
		
		[TestMethod]
		public void Test1()
		{
			var com = new Composition();
			var e = com.Entropy;
			e = 0.3;
			Assert.AreNotEqual(e,com.Entropy);
		}
		
		[TestMethod]
		public void Test2()
		{
			var dif1 = new Difference();
			var dif2 = new Difference();
			Assert.AreEqual(dif1.D,dif2.D);				
			Assert.IsFalse(false);
		}
		
	}
}
