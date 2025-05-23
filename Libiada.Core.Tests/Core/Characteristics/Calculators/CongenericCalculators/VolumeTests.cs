﻿namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The volume test.
/// </summary>
[TestFixture]
public class VolumeTests : CongenericCalculatorsTests<Volume>
{
    /// <summary>
    /// The congeneric calculation test.
    /// </summary>
    /// <param name="index">
    /// The congeneric sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 3)]
    [TestCase(0, Link.Start, 12)]
    [TestCase(0, Link.End, 9)]
    [TestCase(0, Link.Both, 36)]
    [TestCase(0, Link.Cycle, 18)]

    [TestCase(1, Link.None, 10)]
    [TestCase(1, Link.Start, 40)]
    [TestCase(1, Link.End, 40)]
    [TestCase(1, Link.Both, 160)]
    [TestCase(1, Link.Cycle, 70)]

    [TestCase(2, Link.None, 1)]
    [TestCase(2, Link.Start, 1)]
    [TestCase(2, Link.End, 1)]
    [TestCase(2, Link.Both, 1)]
    [TestCase(2, Link.Cycle, 1)]

    [TestCase(3, Link.None, 1)]
    [TestCase(3, Link.Start, 8)]
    [TestCase(3, Link.End, 1)]
    [TestCase(3, Link.Both, 8)]
    [TestCase(3, Link.Cycle, 8)]

    [TestCase(5, Link.None, 1)]
    [TestCase(5, Link.Start, 1)]
    [TestCase(5, Link.End, 1)]
    [TestCase(5, Link.Both, 1)]
    [TestCase(5, Link.Cycle, 1)]
    public void CongenericCalculationTest(int index, Link link, double value)
    {
        CongenericSequenceCharacteristicTest(index, link, value);
    }
}
