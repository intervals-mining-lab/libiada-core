namespace SequenceGenerator
{
    using System.Collections.Generic;

    /// <summary>
    /// The order equality comparer.
    /// </summary>
    public class OrderEqualityComparer : IEqualityComparer<int[]>
    {
        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="first">
        /// The first.
        /// </param>
        /// <param name="second">
        /// The second.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(int[] first, int[] second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetHashCode(int[] obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Length; i++)
            {
                result = unchecked(result * 23 + obj[i].GetHashCode());
            }

            return result;
        }
    }
}
