namespace Libiada.Core.TimeSeries.OneDimensional.Restrictions;

/// <summary>
/// The Restriction interface.
/// </summary>
public interface IRestriction
{
    double Restrict(double distance);
}
