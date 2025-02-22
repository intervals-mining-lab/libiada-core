namespace Libiada.Core.Tests.Music;

using Libiada.Core.Extensions;
using Libiada.Core.Music;

/// <summary>
/// PauseTreatment enum tests.
/// </summary>
[TestFixture(TestOf = typeof(PauseTreatment))]
public class PauseTreatmentTests
{
    /// <summary>
    /// The pause treatments count.
    /// </summary>
    private const int PauseTreatmentsCount = 4;

    /// <summary>
    /// Array of all pause treatments.
    /// </summary>
    private readonly PauseTreatment[] pauseTreatments = EnumExtensions.ToArray<PauseTreatment>();

    /// <summary>
    /// Tests count of pause treatments.
    /// </summary>
    [Test]
    public void PauseTreatmentCountTest() => Assert.That(pauseTreatments, Has.Length.EqualTo(PauseTreatmentsCount));

    /// <summary>
    /// Tests values of pause treatments.
    /// </summary>
    [Test]
    public void PauseTreatmentValuesTest()
    {
        for (int i = 0; i < PauseTreatmentsCount; i++)
        {
            Assert.That(pauseTreatments, Contains.Item((PauseTreatment)i));
        }
    }

    /// <summary>
    /// Tests names of pause treatments.
    /// </summary>
    /// <param name="pauseTreatment">
    /// The pause treatment.
    /// </param>
    /// <param name="name">
    /// The name.
    /// </param>
    [TestCase((PauseTreatment)0, "NotApplicable")]
    [TestCase((PauseTreatment)1, "Ignore")]
    [TestCase((PauseTreatment)2, "NoteTrace")]
    [TestCase((PauseTreatment)3, "SilenceNote")]
    public void PauseTreatmentNamesTest(PauseTreatment pauseTreatment, string name) => Assert.That(pauseTreatment.GetName(), Is.EqualTo(name));

    /// <summary>
    /// Tests that all pause treatments have display value.
    /// </summary>
    /// <param name="pauseTreatments">
    /// The pause treatment.
    /// </param>
    [Test]
    public void PauseTreatmentHasDisplayValueTest([Values] PauseTreatment pauseTreatment) => Assert.That(pauseTreatment.GetDisplayValue(), Is.Not.Empty);

    /// <summary>
    /// Tests that all pause treatments have description.
    /// </summary>
    /// <param name="pauseTreatments">
    /// The pause treatment.
    /// </param>
    [Test]
    public void PauseTreatmentHasDescriptionTest([Values] PauseTreatment pauseTreatment) => Assert.That(pauseTreatment.GetDescription(), Is.Not.Empty);

    /// <summary>
    /// Tests that all pause treatments values are unique.
    /// </summary>
    [Test]
    public void PauseTreatmentValuesUniqueTest() => Assert.That(pauseTreatments.Cast<byte>(), Is.Unique);
}
