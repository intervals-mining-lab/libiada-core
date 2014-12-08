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
        /// Reorganizes <see cref="AbstractChain"/> into <see cref="AbstractChain"/>.
        /// </summary>
        /// <param name="source">
        /// Source chain.
        /// </param>
        /// <returns>
        /// The <see cref="AbstractChain"/>.
        /// </returns>
        public override AbstractChain Reorganize(AbstractChain source)
        {
            var resent = new BaseChain();
            resent.ClearAndSetNewLength(source.GetLength());
            for (int i = 0; i < source.GetLength(); i++)
            {
                var phantom = source[i] as ValuePhantom;
                resent.Set(phantom != null ? phantom[0] : source[i], i);
            }

            return resent;
        }
    }
}