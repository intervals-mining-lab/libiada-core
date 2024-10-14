namespace Libiada.Core.Tests.Music;

using Libiada.Core.Music;

/// <summary>
/// The param pause treatment tests.
/// </summary>
[TestFixture]
public class PauseTreatmentTests
{
    /// <summary>
    /// The param pause test.
    /// </summary>
    [Test]
    public void ParamPauseTest()
    {
        // TODO: Rewrite this as other enum tests
        Assert.That((int)PauseTreatment.Ignore, Is.EqualTo(1));
        Assert.That((int)PauseTreatment.NoteTrace, Is.EqualTo(2));
        Assert.That((int)PauseTreatment.SilenceNote, Is.EqualTo(3));
    }
}
