using LibiadaMusic.Analysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusic.Tests.Analysis
{
	[TestClass]
    public class CompositionTests
	{
	    [TestMethod]
	    public void CompositionTest()
	    {
	        var com = new Composition();
	        var e = com.Entropy;
	        e = 0.3;
	        Assert.AreNotEqual(e, com.Entropy);
	    }
	}
}
