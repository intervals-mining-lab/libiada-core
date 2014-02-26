namespace LibiadaCore.Classes.Misc.SpaceReorganizers
{
    using Root;
    using Root.SimpleTypes;

    /// <summary>
    /// Not phantom reorganizer.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of result chain.
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain.
    /// </typeparam>
    public class SpaceNotPhantomReorganizer<TResult, TSource> : SpaceReorganizer<TResult, TSource>
        where TResult : BaseChain, new()
        where TSource : BaseChain, new()
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
        public override TResult Reorganize(TSource source)
        {
            var resent = new TResult();
            resent.ClearAndSetNewLength(source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                var phantom = source[i] as ValuePhantom;
                resent.Add(phantom != null ? phantom[0] : source[i], i);
            }

            return resent;
        }
    }
}