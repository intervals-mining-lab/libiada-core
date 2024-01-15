namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using System.Collections.Generic;

using Libiada.Core.Core;
using Libiada.Core.Core.ArrangementManagers;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

using NUnit.Framework;

/// <summary>
/// The abstract calculator test.
/// </summary>
/// <typeparam name="T">
/// Calculator type.
/// </typeparam>
public abstract class FullCalculatorsTests<T> where T : IFullCalculator, new ()
{
    /// <summary>
    /// The chains.
    /// </summary>
    private readonly List<Chain> chains = ChainsStorage.Chains;

    /// <summary>
    /// Gets or sets the calculator.
    /// </summary>
    protected readonly T Calculator = new T();

    /// <summary>
    /// The chain characteristic test.
    /// </summary>
    /// <param name="index">
    /// The sequence index.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The expected value.
    /// </param>
    protected void ChainCharacteristicTest(int index, Link link, double value)
    {
        Assert.AreEqual(value, Calculator.Calculate(chains[index], link), 0.0001);
    }

    /// <summary>
    /// The series characteristic test.
    /// </summary>
    /// <param name="index">
    /// The sequence index.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The expected value.
    /// </param>
    protected void SeriesCharacteristicTest(int index, Link link, double value)
    {
        chains[index].SetArrangementManagers(ArrangementType.Series);
        Assert.AreEqual(value, Calculator.Calculate(chains[index], link), 0.0001);
    }
}
