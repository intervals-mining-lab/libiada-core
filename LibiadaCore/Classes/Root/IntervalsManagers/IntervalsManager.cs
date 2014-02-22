namespace LibiadaCore.Classes.Root.IntervalsManagers
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// The intervals manager.
    /// </summary>
    public abstract class IntervalsManager
    {
        /// <summary>
        /// Gets or sets main intervals block
        /// without start, end or cycle link.
        /// </summary>
        protected int[] Intervals { get; set; }

        /// <summary>
        /// Gets or sets interval from start of chain to first element.
        /// </summary>
        protected int Start { get; set; }

        /// <summary>
        /// Gets or sets interval from last element to end of chain.
        /// </summary>
        protected int End { get; set; }

        /// <summary>
        /// Method, returning intervals array by link.
        /// </summary>
        /// <param name="link">Link of intervals in chain.</param>
        /// <returns>List of intervals.</returns>
        public List<int> GetIntervals(Link link)
        {
            var result = new List<int>(Intervals);
            switch (link)
            {
                case Link.None:
                    return result;
                case Link.Start:
                    result.Insert(0, Start);
                    return result;
                case Link.End:
                    result.Add(End);
                    return result;
                case Link.Both:
                    result.Insert(0, Start);
                    result.Add(End);
                    return result;
                case Link.Cycle:
                    result.Add(Start + End - 1);
                    return result;
                default:
                    throw new InvalidEnumArgumentException("link", (int)link, typeof(Link));
            }
        }
    }
}