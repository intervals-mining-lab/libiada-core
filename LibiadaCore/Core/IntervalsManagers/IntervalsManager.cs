namespace LibiadaCore.Core.IntervalsManagers
{
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
        protected int[] Intervals;

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
            int[] result;
            switch (link)
            {
                case Link.None:
                    result = new int[Intervals.Length];
                    for (int i = 0; i < Intervals.Length; i++)
                    {
                        result[i] = Intervals[i];
                    }

                    return result;
                case Link.Start:
                    result = new int[Intervals.Length + 1];
                    result[0] = Start;
                    for (int i = 0; i < Intervals.Length; i++)
                    {
                        result[i + 1] = Intervals[i];
                    }

                    return result;
                case Link.End:
                    result = new int[Intervals.Length + 1];
                    for (int i = 0; i < Intervals.Length; i++)
                    {
                        result[i] = Intervals[i];
                    }

                    result[result.Length - 1] = End;
                    return result;
                case Link.Both:
                    result = new int[Intervals.Length + 2];
                    result[0] = Start;
                    for (int i = 0; i < Intervals.Length; i++)
                    {
                        result[i + 1] = Intervals[i];
                    }

                    result[result.Length - 1] = End;
                    return result;
                case Link.Cycle:
                    result = new int[Intervals.Length + 1];
                    for (int i = 0; i < Intervals.Length; i++)
                    {
                        result[i] = Intervals[i];
                    }

                    result[result.Length - 1] = Start + End - 1;
                    return result;
                case Link.CycleStart:
                    result = new int[Intervals.Length + 1];
                    for (int i = 0; i < Intervals.Length; i++)
                    {
                        result[i] = Intervals[i];
                    }

                    result[result.Length - 1] = Start + End - 1;
                    return result;
                case Link.CycleEnd:
                    result = new int[Intervals.Length + 1];
                    result[0] = Start + End - 1;
                    for (int i = 0; i < Intervals.Length; i++)
                    {
                        result[i + 1] = Intervals[i];
                    }

                    return result;

                default:
                    throw new InvalidEnumArgumentException("link", (int)link, typeof(Link));
            }
        }
    }
}
