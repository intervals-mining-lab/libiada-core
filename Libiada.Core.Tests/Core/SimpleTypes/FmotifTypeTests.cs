﻿namespace Libiada.Core.Tests.Core.SimpleTypes;

using Libiada.Core.Core.SimpleTypes;
using Libiada.Core.Extensions;

/// <summary>
/// Fmotif type enum tests.
/// </summary>
[TestFixture(TestOf = typeof(FmotifType))]
public class FmotifTypeTests
{
    /// <summary>
    /// The fmotif types count.
    /// </summary>
    private const int FmotifTypesCount = 6;

    /// <summary>
    /// Tests count of fmotif types.
    /// </summary>
    [Test]
    public void FmotifTypeCountTest()
    {
        int actualCount = EnumExtensions.ToArray<FmotifType>().Length;
        Assert.That(actualCount, Is.EqualTo(FmotifTypesCount));
    }

    /// <summary>
    /// Tests values of fmotif types.
    /// </summary>
    [Test]
    public void FmotifTypeValuesTest()
    {
        FmotifType[] fmotifTypes = EnumExtensions.ToArray<FmotifType>();
        for (int i = 0; i < FmotifTypesCount; i++)
        {
            Assert.That(fmotifTypes, Does.Contain((FmotifType)i));
        }
    }

    /// <summary>
    /// Tests names of fmotif types.
    /// </summary>
    /// <param name="fmotifType">
    /// The fmotif type.
    /// </param>
    /// <param name="name">
    /// The name.
    /// </param>
    [TestCase((FmotifType)0, "None")]
    [TestCase((FmotifType)1, "CompleteMinimalMeasure")]
    [TestCase((FmotifType)2, "PartialMinimalMeasure")]
    [TestCase((FmotifType)3, "IncreasingSequence")]
    [TestCase((FmotifType)4, "CompleteMinimalMetrorhythmicGroup")]
    [TestCase((FmotifType)5, "PartialMinimalMetrorhythmicGroup")]
    public void FmotifTypeNamesTest(FmotifType fmotifType, string name)
    {
        Assert.That(fmotifType.GetName(), Is.EqualTo(name));
    }

    /// <summary>
    /// Tests that all fmotif types have display value.
    /// </summary>
    /// <param name="fmotifType">
    /// The fmotif type.
    /// </param>
    [Test]
    public void FmotifTypeHasDisplayValueTest([Values]FmotifType fmotifType)
    {
        Assert.That(fmotifType.GetDisplayValue(), Is.Not.Empty);
    }

    /// <summary>
    /// Tests that all fmotif types have description.
    /// </summary>
    /// <param name="fmotifType">
    /// The fmotif type.
    /// </param>
    [Test]
    public void FmotifTypeHasDescriptionTest([Values]FmotifType fmotifType)
    {
        Assert.That(fmotifType.GetDescription(), Is.Not.Empty);
    }

    /// <summary>
    /// Tests that all fmotif types values are unique.
    /// </summary>
    [Test]
    public void FmotifTypeValuesUniqueTest()
    {
        FmotifType[] fmotifTypes = EnumExtensions.ToArray<FmotifType>();
        IEnumerable<byte> fmotifTypeValues = fmotifTypes.Cast<byte>();
        Assert.That(fmotifTypeValues, Is.Unique);
    }
}
