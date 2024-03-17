namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The duration tests.
/// </summary>
[TestFixture]
public class DurationTests
{
    /// <summary>
    /// The add duration test.
    /// </summary>
    [Test]
    public void AddDurationTest()
    {
        var duration1 = new Duration(1, 2, false);
        var duration2 = new Duration(1, 4, false);
        var duration3 = duration1.AddDuration(duration2);

        Assert.Multiple(() =>
        {
            // duration1
            Assert.That(duration1.Numerator, Is.EqualTo(1));
            Assert.That(duration1.Denominator, Is.EqualTo(2));

            // duration2
            Assert.That(duration2.Numerator, Is.EqualTo(1));
            Assert.That(duration2.Denominator, Is.EqualTo(4));

            // duration3
            Assert.That(duration3.Numerator, Is.EqualTo(3));
            Assert.That(duration3.Denominator, Is.EqualTo(4));
        });

        duration3 = duration3.AddDuration(duration1);

        Assert.Multiple(() =>
        {
            // duration3'
            Assert.That(duration3.Numerator, Is.EqualTo(5));
            Assert.That(duration3.Denominator, Is.EqualTo(4));
        });
    }
}
