using System;
using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Base.Sequencies
{
    public class Order:Arrangement
    {
        public Order(Chain chain)
        {
            build(chain);
        }

        private Order(List<int> value)
        {
            build(value);
        }

        private void build(List<int> value)
        {
            values.AddRange(value);
        }

        /// <summary>
        /// Built the order of the chain
        /// </summary>
        /// <param name="chain">input character sequence</param>
        private void build(Chain chain)
        {
            String str;
            Dictionary<String, int> alphabet = new Dictionary<String, int>();

            for (int index = 0, num = 0; index < chain.Length; index++)
            {
                str = chain[index].ToString();
                if (alphabet.ContainsKey(str))
                {
                    values.Add(alphabet[str]);
                }
                else
                {
                    num = num + 1;
                    values.Add(num);
                    alphabet.Add(str, num);
                }
            }

        }


        public INumberSequence substring(int beginIndex, int endIndex)
        {
            Order order = null;

            order = new Order(Sublist(beginIndex, endIndex));
            return order;
        }


        public String toString(String emptiness)
        {
            return null;
        } 
    }
}