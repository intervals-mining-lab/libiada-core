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
        Assert.AreEqual((int)PauseTreatment.Ignore, 1);
        Assert.AreEqual((int)PauseTreatment.NoteTrace, 2);
        Assert.AreEqual((int)PauseTreatment.SilenceNote, 3);
    }
}
