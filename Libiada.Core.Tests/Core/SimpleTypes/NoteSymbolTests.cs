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
        var actualCount = EnumExtensions.ToArray<NoteSymbol>().Length;
        Assert.AreEqual(NoteSymbolsCount, actualCount);
    }

    /// <summary>
    /// Tests values of note symbols.
    /// </summary>
    [Test]
    public void NoteSymbolValuesTest()
    {
        var noteSymbols = EnumExtensions.ToArray<NoteSymbol>();
        Assert.IsTrue(noteSymbols.Contains((NoteSymbol)0));
        Assert.IsTrue(noteSymbols.Contains((NoteSymbol)2));
        Assert.IsTrue(noteSymbols.Contains((NoteSymbol)4));
        Assert.IsTrue(noteSymbols.Contains((NoteSymbol)5));
        Assert.IsTrue(noteSymbols.Contains((NoteSymbol)7));
        Assert.IsTrue(noteSymbols.Contains((NoteSymbol)9));
        Assert.IsTrue(noteSymbols.Contains((NoteSymbol)11));
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
        Assert.AreEqual(name, noteSymbol.GetName());
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
        Assert.IsFalse(string.IsNullOrEmpty(noteSymbol.GetDisplayValue()));
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
        Assert.IsFalse(string.IsNullOrEmpty(noteSymbol.GetDescription()));
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
