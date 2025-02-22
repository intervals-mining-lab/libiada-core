namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Extensions;

/// <summary>
/// Instrument enum tests.
/// </summary>
[TestFixture(TestOf = typeof(Instrument))]
public class InstrumentTests
{
    /// <summary>
    /// The instruments count.
    /// </summary>
    private const int InstrumentsCount = 1;

    /// <summary>
    /// Array of all instruments.
    /// </summary>
    private readonly Instrument[] instruments = EnumExtensions.ToArray<Instrument>();

    /// <summary>
    /// Tests count of instruments.
    /// </summary>
    [Test]
    public void InstrumentCountTest() => Assert.That(instruments, Has.Length.EqualTo(InstrumentsCount));

    /// <summary>
    /// Tests values of instruments.
    /// </summary>
    [Test]
    public void InstrumentValuesTest()
    {
        for (int i = 0; i < InstrumentsCount; i++)
        {
            Assert.That(instruments, Contains.Item((Instrument)i));
        }
    }

    /// <summary>
    /// Tests names of instruments.
    /// </summary>
    /// <param name="instrument">
    /// The instrument.
    /// </param>
    /// <param name="name">
    /// The name.
    /// </param>
    [TestCase((Instrument)0, "AnyOrUnknown")]
    public void InstrumentNamesTest(Instrument instrument, string name) => Assert.That(instrument.GetName(), Is.EqualTo(name));

    /// <summary>
    /// Tests that all instruments have display value.
    /// </summary>
    /// <param name="instrument">
    /// The instrument.
    /// </param>
    [Test]
    public void InstrumentHasDisplayValueTest([Values] Instrument instrument) => Assert.That(instrument.GetDisplayValue(), Is.Not.Empty);

    /// <summary>
    /// Tests that all instruments have description.
    /// </summary>
    /// <param name="instrument">
    /// The instrument.
    /// </param>
    [Test]
    public void InstrumentHasDescriptionTest([Values] Instrument instrument) => Assert.That(instrument.GetDescription(), Is.Not.Empty);

    /// <summary>
    /// Tests that all instruments values are unique.
    /// </summary>
    [Test]
    public void InstrumentValuesUniqueTest() => Assert.That(instruments.Cast<byte>(), Is.Unique);
}
