namespace Libiada.Core.Tests.Core.ArrangementManagers;

using Libiada.Core.Core;
using Libiada.Core.Core.ArrangementManagers;

/// <summary>
/// The binary intervals manager tests.
/// </summary>
[TestFixture]
public class BinaryIntervalsManagerTests
{
    /// <summary>
    /// The elements.
    /// </summary>
    private readonly Dictionary<string, IBaseObject> elements = SequencesStorage.Elements;

    /// <summary>
    /// The get binary interval test.
    /// </summary>
    [Test]
    public void GetBinaryIntervalTest()
    {
        ComposedSequence sequence = SequencesStorage.CompusedSequences[2];
        BinaryIntervalsManager intervalManager = sequence.GetRelationIntervalsManager(elements["A"], elements["C"]);
        Assert.Multiple(() =>
        {
            Assert.That(intervalManager.GetBinaryInterval(1), Is.EqualTo(1));
            Assert.That(intervalManager.GetBinaryInterval(2), Is.EqualTo(1));
            Assert.That(intervalManager.GetBinaryInterval(3), Is.EqualTo(-1));
        });

        intervalManager = sequence.GetRelationIntervalsManager(elements["C"], elements["A"]);
        Assert.Multiple(() =>
        {
            Assert.That(intervalManager.GetBinaryInterval(1), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(2), Is.EqualTo(1));
            Assert.That(intervalManager.GetBinaryInterval(3), Is.EqualTo(-1));
            Assert.That(intervalManager.GetBinaryInterval(4), Is.EqualTo(3));
            Assert.That(intervalManager.GetBinaryInterval(5), Is.EqualTo(-1));
        });

        intervalManager = sequence.GetRelationIntervalsManager(elements["C"], elements["T"]);
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
    /// The get binary interval in incomplete sequence test.
    /// </summary>
    [Test]
    public void GetBinaryIntervalIncompleteSequenceTest()
    {
        ComposedSequence sequence = SequencesStorage.BinarySequences[20];
        BinaryIntervalsManager intervalManager = sequence.GetRelationIntervalsManager(elements["A"], elements["C"]);
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

        intervalManager = sequence.GetRelationIntervalsManager(elements["C"], elements["A"]);
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
