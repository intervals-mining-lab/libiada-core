namespace LibiadaCore.Misc.SpaceReorganizers
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Space phantom reorganizer.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of result chain.
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain.
    /// </typeparam>
    public class SpacePhantomReorganizer : SpaceReorganizer
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
        public override AbstractChain Reorganize(AbstractChain source)
        {
            var resent = new BaseChain();
            resent.ClearAndSetNewLength(source.GetLength());
            for (int i = 0; i < source.GetLength(); i++)
            {
                var message = source[i] as ValuePhantom ?? new ValuePhantom { source[i] };

                resent.Add(message, i);
            }

            return resent;
        }
    }
}
