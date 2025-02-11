namespace Libiada.MarkovChains.Tests.MarkovCompare;

using Libiada.Core.Core;

using MarkovChains.MarkovChain;
using MarkovChains.MarkovCompare;
using MarkovChains.Tests.MarkovChain.Generators;

/// <summary>
/// The markov metric tests.
/// </summary>
[TestFixture]
public class MarkovMetricsTests
{
    /// <summary>
    /// The test sequence.
    /// </summary>
    private ComposedSequence testSequence;

    /// <summary>
    /// The initialization method.
    /// </summary>
    [SetUp]
    public void Initialize()
    {
        testSequence = new ComposedSequence("AGTAAGTC");
    }

    /// <summary>
    /// The compare same chain test.
    /// </summary>
    [Test]
    public void CompareSameChainTest()
    {
        MarkovChainNotCongenericStatic markov = new(2, 0, new MockGenerator());
        markov.Teach(testSequence, TeachingMethod.Cycle);
        MarkovMetrics ma = new();
        Assert.That(ma.GetArithmeticalMean(markov), Is.EqualTo(ma.GetArithmeticalMean(markov)));
    }
}
