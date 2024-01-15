namespace Libiada.MarkovChains.Tests.MarkovCompare;

using Libiada.Core.Core;

using MarkovChains.MarkovChain;
using MarkovChains.MarkovCompare;
using MarkovChains.Tests.MarkovChain.Generators;

using NUnit.Framework;

/// <summary>
/// The markov metric tests.
/// </summary>
[TestFixture]
public class MarkovMetricsTests
{
    /// <summary>
    /// The test chain.
    /// </summary>
    private Chain testChain;

    /// <summary>
    /// The initialization method.
    /// </summary>
    [SetUp]
    public void Initialize()
    {
        testChain = new Chain("AGTAAGTC");
    }

    /// <summary>
    /// The compare same chain test.
    /// </summary>
    [Test]
    public void CompareSameChainTest()
    {
        var markov = new MarkovChainNotCongenericStatic(2, 0, new MockGenerator());
        markov.Teach(testChain, TeachingMethod.Cycle);
        var ma = new MarkovMetrics();
        Assert.AreEqual(ma.GetArithmeticalMean(markov), ma.GetArithmeticalMean(markov));
    }
}
