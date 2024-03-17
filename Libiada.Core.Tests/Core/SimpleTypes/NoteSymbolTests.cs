namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Extensions;

/// <summary>
/// Note symbol enum tests.
/// </summary>
[TestFixture(TestOf = typeof(NoteSymbol))]
public class NoteSymbolTests
{
    /// <summary>
    /// The note symbols count.
    /// </summary>
    private const int NoteSymbolsCount = 7;

    /// <summary>
    /// Tests count of note symbols.
    /// </summary>
    [Test]
    public void NoteSymbolCountTest()
    {
        Assert.That(EnumExtensions.ToArray<NoteSymbol>(), Has.Length.EqualTo(NoteSymbolsCount));
    }

    /// <summary>
    /// Tests values of note symbols.
    /// </summary>
    [Test]
    public void NoteSymbolValuesTest()
    {
        var noteSymbols = EnumExtensions.ToArray<NoteSymbol>();
        Assert.That(noteSymbols, Does.Contain((NoteSymbol)0));
        Assert.That(noteSymbols, Does.Contain((NoteSymbol)2));
        Assert.That(noteSymbols, Does.Contain((NoteSymbol)4));
        Assert.That(noteSymbols, Does.Contain((NoteSymbol)5));
        Assert.That(noteSymbols, Does.Contain((NoteSymbol)7));
        Assert.That(noteSymbols, Does.Contain((NoteSymbol)9));
        Assert.That(noteSymbols, Does.Contain((NoteSymbol)11));
    }

    /// <summary>
    /// Tests names of note symbols.
    /// </summary>
    /// <param name="noteSymbol">
    /// The note symbol.
    /// </param>
    /// <param name="name">
    /// The name.
    /// </param>
    [TestCase((NoteSymbol)0, "C")]
    [TestCase((NoteSymbol)2, "D")]
    [TestCase((NoteSymbol)4, "E")]
    [TestCase((NoteSymbol)5, "F")]
    [TestCase((NoteSymbol)7, "G")]
    [TestCase((NoteSymbol)9, "A")]
    [TestCase((NoteSymbol)11, "B")]
    public void NoteSymbolNamesTest(NoteSymbol noteSymbol, string name)
    {
        Assert.That(noteSymbol.GetName(), Is.EqualTo(name));
    }

    /// <summary>
    /// Tests that all note symbols have display value.
    /// </summary>
    /// <param name="noteSymbol">
    /// The note symbol.
    /// </param>
    [Test]
    public void NoteSymbolHasDisplayValueTest([Values]NoteSymbol noteSymbol)
    {
        Assert.That(noteSymbol.GetDisplayValue(), Is.Not.Empty);
    }

    /// <summary>
    /// Tests that all note symbols have description.
    /// </summary>
    /// <param name="noteSymbol">
    /// The note symbol.
    /// </param>
    [Test]
    public void NoteSymbolHasDescriptionTest([Values]NoteSymbol noteSymbol)
    {
        Assert.That(noteSymbol.GetDescription(), Is.Not.Empty);
    }

    /// <summary>
    /// Tests that all note symbols values are unique.
    /// </summary>
    [Test]
    public void NoteSymbolValuesUniqueTest()
    {
        var noteSymbols = EnumExtensions.ToArray<NoteSymbol>();
        var noteSymbolValues = noteSymbols.Cast<byte>();
        Assert.That(noteSymbolValues, Is.Unique);
    }
}
