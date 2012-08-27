using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDA.Analisis;


namespace TestMDA
{
	
	[TestClass]
	public class Test
	{
		
		[TestMethod]
		public void Test1()
		{
			Composition com = new Composition();
			double e = com.GetEntropy();
			e = 0.3;
			Assert.AreNotEqual(e,com.GetEntropy());
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
