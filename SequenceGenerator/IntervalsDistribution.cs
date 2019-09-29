using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceGenerator
{
    public class IntervalsDistribution
    {
        public Dictionary<int, int> Distribution { get; internal set; }


        public IntervalsDistribution()
        {
            Distribution = new Dictionary<int, int>();
        }

        public void AddInterval(int interval)
        {
            if (Distribution.ContainsKey(interval))
            {
                Distribution[interval]++;
            }
            else
            {
                Distribution.Add(interval, 1);
            }
        }

        public override bool Equals(object obj)
        {
            if(!(obj is IntervalsDistribution))
            {
                return false;
            }
            var distr = obj as IntervalsDistribution;
            bool equal = false;
            if (this.Distribution.Count == distr.Distribution.Count)
            {
                equal = true;
                foreach (var pair in this.Distribution)
                {
                    int value;
                    if (distr.Distribution.TryGetValue(pair.Key, out value))
                    {
                        if (value != pair.Value)
                        {
                            equal = false;
                            break;
                        }
                    }
                    else
                    {
                        equal = false;
                        break;
                    }
                }
            }
            return equal;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = -1573927371;
                foreach (var element in Distribution)
                {
                    hashCode = hashCode ^ element.Key.GetHashCode();
                    hashCode = hashCode ^ element.Value.GetHashCode();
                }

                return hashCode;
            }
        }
    }
}
