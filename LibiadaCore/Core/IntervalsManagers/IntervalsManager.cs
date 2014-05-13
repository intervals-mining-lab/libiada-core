namespace LibiadaCore.Core.IntervalsManagers
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
        protected int[] intervals;

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
        public int[] GetIntervals(Link link)
        {
            int[] result;// = new List<int>(this.Intervals);
            switch (link)
            {
                case Link.None:
                    result = new int[intervals.Length];
                    for (int i = 0; i < intervals.Length; i++)
                    {
                        result[i] = intervals[i];
                    }

                    return result;
                case Link.Start:
                    result = new int[intervals.Length + 1];
                    result[0] = Start;
                    for (int i = 0; i < intervals.Length; i++)
                    {
                        result[i + 1] = intervals[i];
                    }

                    return result;
                case Link.End:
                    result = new int[intervals.Length + 1];
                    for (int i = 0; i < intervals.Length; i++)
                    {
                        result[i] = intervals[i];
                    }

                    result[result.Length - 1] = End;
                    return result;
                case Link.Both:
                    result = new int[intervals.Length + 2];
                    result[0] = Start;
                    for (int i = 0; i < intervals.Length; i++)
                    {
                        result[i + 1] = intervals[i];
                    }

                    result[result.Length - 1] = End;
                    return result;
                case Link.Cycle:
                    result = new int[intervals.Length + 1];
                    for (int i = 0; i < intervals.Length; i++)
                    {
                        result[i] = intervals[i];
                    }

                    result[result.Length - 1] = Start + End - 1;
                    return result;
                default:
                    throw new InvalidEnumArgumentException("link", (int)link, typeof(Link));
            }
        }
    }
}