namespace LibiadaCore.Misc.SpaceReorganizers
{
    using LibiadaCore.Core;

    /// <summary>
    /// The space reorganizer.
    /// </summary>
    public abstract class SpaceReorganizer
        
    {
        /// <summary>
        /// Reorganizes <see cref="TSource"/> into <see cref="TResult"/>.
        /// </summary>
        /// <param name="source">
        /// Source chain.
        /// </param>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        public abstract AbstractChain Reorganize(AbstractChain source);
    }
}