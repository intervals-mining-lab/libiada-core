﻿namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Extensions;

/// <summary>
/// Accidental enum tests.
/// </summary>
[TestFixture(TestOf = typeof(Accidental))]
public class AccidentalTests
{
    /// <summary>
    /// The accidentals count.
    /// </summary>
    private const int AccidentalsCount = 5;

    /// <summary>
    /// Tests count of accidentals.
    /// </summary>
    [Test]
    public void AccidentalCountTest()
    {
        Assert.That(EnumExtensions.ToArray<Accidental>(), Has.Length.EqualTo(AccidentalsCount));
    }

    /// <summary>
    /// Tests values of accidentals.
    /// </summary>
    [Test]
    public void AccidentalValuesTest()
    {
        Accidental[] accidentals = EnumExtensions.ToArray<Accidental>();
        for (int i = -2; i < AccidentalsCount - 2; i++)
        {
            Assert.That(accidentals, Does.Contain((Accidental)i));
        }
    }

    /// <summary>
    /// Tests names of accidentals.
    /// </summary>
    /// <param name="accidental">
    /// The accidental.
    /// </param>
    /// <param name="name">
    /// The name.
    /// </param>
    [TestCase((Accidental)(-2), "DoubleFlat")]
    [TestCase((Accidental)(-1), "Flat")]
    [TestCase((Accidental)0, "Bekar")]
    [TestCase((Accidental)1, "Sharp")]
    [TestCase((Accidental)2, "DoubleSharp")]
    public void AccidentalNamesTest(Accidental accidental, string name)
    {
        Assert.That(accidental.GetName(), Is.EqualTo(name));
    }

    /// <summary>
    /// Tests that all accidentals have display value.
    /// </summary>
    /// <param name="accidental">
    /// The accidental.
    /// </param>
    [Test]
    public void AccidentalHasDisplayValueTest([Values]Accidental accidental)
    {
        Assert.That(accidental.GetDisplayValue(), Is.Not.Empty);
    }

    /// <summary>
    /// Tests that all accidentals have description.
    /// </summary>
    /// <param name="accidental">
    /// The accidental.
    /// </param>
    [Test]
    public void AccidentalHasDescriptionTest([Values]Accidental accidental)
    {
        Assert.That(accidental.GetDescription(), Is.Not.Empty);
    }

    /// <summary>
    /// Tests that all accidentals values are unique.
    /// </summary>
    [Test]
    public void AccidentalValuesUniqueTest()
    {
        Accidental[] accidentals = EnumExtensions.ToArray<Accidental>();
        IEnumerable<short> accidentalValues = accidentals.Cast<short>();
        Assert.That(accidentalValues, Is.Unique);
    }
}
