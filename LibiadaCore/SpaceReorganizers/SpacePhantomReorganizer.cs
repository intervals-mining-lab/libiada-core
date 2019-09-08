namespace LibiadaCore.SpaceReorganizers
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    /// <summary>
    /// Space phantom reorganizer.
    /// </summary>
    public class SpacePhantomReorganizer : SpaceReorganizer
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
            var resent = new BaseChain(source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                var message = source[i] as ValuePhantom ?? new ValuePhantom { source[i] };

                resent.Set(message, i);
            }

            return resent;
        }
    }
}