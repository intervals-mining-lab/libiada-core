using System.Collections.Generic;

namespace SequenceGenerator
{
    public class OrderEqualityComparer : IEqualityComparer<int[]>
    {
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

        public int GetHashCode(int[] obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Length; i++)
            {
                result = unchecked(result * 23 + obj[i]);
            }
            return result;
        }
    }
}
