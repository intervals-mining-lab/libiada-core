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
        Assert.Multiple(() =>
        {
            Assert.That(intervalManager.GetBinaryInterval(1), Is.EqualTo(1));
            Assert.That(intervalManager.GetBinaryInterval(2), Is.EqualTo(1));
            Assert.That(intervalManager.GetBinaryInterval(3), Is.EqualTo(-1));
        });

        intervalManager = chain.GetRelationIntervalsManager(elements["C"], elements["A"]);
        Assert.Multiple(() =>
        {
            Assert.That(intervalManager.GetBinaryInterval(1), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(2), Is.EqualTo(1));
            Assert.That(intervalManager.GetBinaryInterval(3), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(4), Is.EqualTo(3));
            Assert.That(intervalManager.GetBinaryInterval(5), Is.EqualTo(-1));
        });

        intervalManager = chain.GetRelationIntervalsManager(elements["C"], elements["T"]);
        Assert.Multiple(() =>
        {
            Assert.That(intervalManager.GetBinaryInterval(1), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(2), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(3), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(4), Is.EqualTo(1));
        });
        Assert.That(intervalManager.GetBinaryInterval(4), Is.EqualTo(1));
    }

    /// <summary>
    /// The get binary interval in incomplete chain test.
    /// </summary>
    [Test]
    public void GetBinaryIntervalIncompleteChainTest()
    {
        var chain = ChainsStorage.BinaryChains[20];
        var intervalManager = chain.GetRelationIntervalsManager(elements["A"], elements["C"]);
        Assert.Multiple(() =>
        {
            Assert.That(intervalManager.GetBinaryInterval(1), Is.EqualTo(1));
            Assert.That(intervalManager.GetBinaryInterval(2), Is.EqualTo(2));
            Assert.That(intervalManager.GetBinaryInterval(3), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(4), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(5), Is.EqualTo(1));
            Assert.That(intervalManager.GetBinaryInterval(6), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(7), Is.EqualTo(-1));
        });

        intervalManager = chain.GetRelationIntervalsManager(elements["C"], elements["A"]);
        Assert.Multiple(() =>
        {
            Assert.That(intervalManager.GetBinaryInterval(1), Is.EqualTo(1));
            Assert.That(intervalManager.GetBinaryInterval(2), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(3), Is.EqualTo(2));
            Assert.That(intervalManager.GetBinaryInterval(4), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(5), Is.EqualTo(1));
            Assert.That(intervalManager.GetBinaryInterval(6), Is.EqualTo(-1));
        });
    }
}
