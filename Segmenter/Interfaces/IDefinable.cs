namespace Segmenter.Interfaces
{
    /// <summary>
    /// Provides the best found value
    /// </summary>
    public interface IDefinable
    {
        /// <summary>
        /// Returns the best value for this case
        /// </summary>
        /// <returns>the best value for this case</returns>
        double GetValue(); 
    }
}
