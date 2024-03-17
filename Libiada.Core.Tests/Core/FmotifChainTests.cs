namespace Libiada.Core.Tests.Core;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Music;

/// <summary>
/// The fmotif chain tests.
/// </summary>
[TestFixture]
public class FmotifChainTests
{
    /// <summary>
    /// The fmotif chain test.
    /// </summary>
    [Test]
    public void FmotifChainTest()
    {
        var chain = new FmotifChain();
        chain.FmotifsList.Add(new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0));
        chain.FmotifsList[0].NoteList.Add(new ValueNote(new Pitch(0, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));
        chain.FmotifsList[0].NoteList.Add(new ValueNote(new Pitch(0, NoteSymbol.B, 0), new Duration(1, 2, false), false, Tie.None));
        Assert.That(chain.FmotifsList[0].Id, Is.EqualTo(0));
        Assert.That(chain.FmotifsList[0].NoteList[0].Pitches[0].Step, Is.EqualTo(NoteSymbol.A));
        Assert.That(chain.FmotifsList[0].NoteList[1].Pitches[0].Step, Is.EqualTo(NoteSymbol.B));
    }

    /// <summary>
    /// The fmotif chain equals test.
    /// </summary>
    [Test]
    public void FmotifChainEqualsTest()
    {
        var fmotif1 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 0);
        var fmotif2 = new Fmotif(FmotifType.CompleteMinimalMeasure, PauseTreatment.Ignore, 1);

        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.E, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif1.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.B, 0), new Duration(1, 4, false), false, Tie.None));
        fmotif2.NoteList.Add(new ValueNote(new Pitch(3, NoteSymbol.A, 0), new Duration(1, 4, false), false, Tie.None));

        var firstChain = new FmotifChain();
        firstChain.FmotifsList.Add(fmotif1);
        firstChain.FmotifsList.Add(fmotif2);

        var secondChain = new FmotifChain();
        secondChain.FmotifsList.Add(fmotif1);
        secondChain.FmotifsList.Add(fmotif2);
        Assert.That(firstChain, Is.EqualTo(secondChain));

        secondChain = new FmotifChain();
        secondChain.FmotifsList.Add(fmotif2);
        secondChain.FmotifsList.Add(fmotif1);
        Assert.That(firstChain, Is.Not.EqualTo(secondChain));

        secondChain = new FmotifChain();
        secondChain.FmotifsList.Add(fmotif2);
        secondChain.FmotifsList.Add(fmotif2);
        Assert.That(firstChain, Is.Not.EqualTo(secondChain));

        firstChain = new FmotifChain();
        firstChain.FmotifsList.Add(fmotif1);
        firstChain.FmotifsList.Add(fmotif1);
        firstChain.FmotifsList.Add(fmotif2);
        firstChain.FmotifsList.Add(fmotif1);

        secondChain = new FmotifChain();
        secondChain.FmotifsList.Add(fmotif1);
        secondChain.FmotifsList.Add(fmotif1);
        secondChain.FmotifsList.Add(fmotif2);
        secondChain.FmotifsList.Add(fmotif1);
        Assert.That(firstChain, Is.EqualTo(secondChain));
    }
}
