namespace LibiadaCore.Misc.SpaceReorganizers
{
    using LibiadaCore.Core;

    /// <summary>
    /// The space reorganizer.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of result chain.
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain.
    /// </typeparam>
    public abstract class SpaceReorganizer<TResult, TSource> 
        where TResult : BaseChain, new() where TSource : BaseChain, new()
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
        public abstract TResult Reorganize(TSource source);
    }
}