namespace LibiadaCore.Misc.SpaceReorganizers
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Not phantom reorganizer.
    /// </summary>
    public class SpaceNotPhantomReorganizer : SpaceReorganizer
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
                var phantom = source[i] as ValuePhantom;
                resent.Add(phantom != null ? phantom[0] : source[i], i);
            }

            return resent;
        }
    }
}