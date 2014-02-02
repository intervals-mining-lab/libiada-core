using LibiadaMusic.Analysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibiadaMusicTests.Analysis
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
