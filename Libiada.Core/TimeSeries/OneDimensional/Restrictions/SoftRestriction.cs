namespace Libiada.Core.TimeSeries.OneDimensional.Restrictions;

/// <summary>
/// The soft restriction.
/// </summary>
public class SoftRestriction : IRestriction
{
    /// <summary>
    /// The restrict.
    /// </summary>
    /// <param name="differenceModulus">
    /// The difference modulus.
    /// </param>
    /// <returns>
    /// The <see cref="double"/>.
    /// </returns>
    public double Restrict(double differenceModulus)
    {
        return differenceModulus / (1 + differenceModulus);
    }
}