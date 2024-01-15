namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

using System;

/// <summary>
/// Abstract class for all not linkable congeneric characteristics calculators.
/// </summary>
public abstract class NonLinkableCongenericCalculator : ICongenericCalculator
{
    /// <summary>
    /// Calculates the characteristic.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link can only be <see cref="Link.NotApplied"/> in this case.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown if wrong <see cref="Link"/> is provided.
    /// </exception>
    public double Calculate(CongenericChain chain, Link link)
    {
        if (link != Link.NotApplied)
        {
            throw new ArgumentException("Not linkable characteristic calculator provided with link");
        }

        return Calculate(chain);
    }

    /// <summary>
    /// Main calculation method.
    /// </summary>
    /// <param name="chain">
    /// The chain.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public abstract double Calculate(CongenericChain chain);
}
