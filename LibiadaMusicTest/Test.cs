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
			Composition com = new Composition();
			double e = com.entropy;
			e = 0.3;
			Assert.AreNotEqual(e,com.entropy);
		}
		
		[TestMethod]
		public void Test2()
		{
			Difference dif1 = new Difference();
			Difference dif2 = new Difference();
			Assert.AreEqual(dif1.D,dif2.D);				
			Assert.IsFalse(false);
		}
		
	}
}
