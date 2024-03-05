namespace Libiada.Core.Tests.Core.ArrangementManagers;

using Libiada.Core.Core;

/// <summary>
/// The binary intervals manager tests.
/// </summary>
[TestFixture]
public class BinaryIntervalsManagerTests
{
    /// <summary>
    /// The elements.
    /// </summary>
    private readonly Dictionary<string, IBaseObject> elements = ChainsStorage.Elements;

    /// <summary>
    /// The get binary interval test.
    /// </summary>
    [Test]
    public void GetBinaryIntervalTest()
    {
        var chain = ChainsStorage.Chains[2];
        var intervalManager = chain.GetRelationIntervalsManager(elements["A"], elements["C"]);
        Assert.AreEqual(1, intervalManager.GetBinaryInterval(1));
        Assert.AreEqual(1, intervalManager.GetBinaryInterval(2));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(3));

        intervalManager = chain.GetRelationIntervalsManager(elements["C"], elements["A"]);
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(1));
        Assert.AreEqual(1, intervalManager.GetBinaryInterval(2));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(3));
        Assert.AreEqual(3, intervalManager.GetBinaryInterval(4));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(5));

        intervalManager = chain.GetRelationIntervalsManager(elements["C"], elements["T"]);
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(1));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(2));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(3));
        Assert.AreEqual(1, intervalManager.GetBinaryInterval(4));
        Assert.AreEqual(1, intervalManager.GetBinaryInterval(4));
    }

    /// <summary>
    /// The get binary interval in incomplete chain test.
    /// </summary>
    [Test]
    public void GetBinaryIntervalIncompleteChainTest()
    {
        var chain = ChainsStorage.BinaryChains[20];
        var intervalManager = chain.GetRelationIntervalsManager(elements["A"], elements["C"]);
        Assert.AreEqual(1, intervalManager.GetBinaryInterval(1));
        Assert.AreEqual(2, intervalManager.GetBinaryInterval(2));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(3));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(4));
        Assert.AreEqual(1, intervalManager.GetBinaryInterval(5));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(6));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(7));

        intervalManager = chain.GetRelationIntervalsManager(elements["C"], elements["A"]);
        Assert.AreEqual(1, intervalManager.GetBinaryInterval(1));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(2));
        Assert.AreEqual(2, intervalManager.GetBinaryInterval(3));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(4));
        Assert.AreEqual(1, intervalManager.GetBinaryInterval(5));
        Assert.AreEqual(-1, intervalManager.GetBinaryInterval(6));
    }
}
