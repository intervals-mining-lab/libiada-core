using System;
using System.Collections.Generic;
using System.Text;

namespace Segmentator.Classes.Base.Sequencies
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.SimpleTypes;

    public class ComplexChain : Chain
    {
        public Link Anchor = Link.Start;

        public ComplexChain(List<int> accord)
        {
            for (int i = 0; i < accord.Count; i++)
            {
                Add(new ValueInt(accord[i]), i);
            }
        }

        public ComplexChain(String sequence)
            : base(sequence)
        {
        }

        public ComplexChain(List<String> sequence)
            : base(sequence.Count)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                Add(new ValueString(sequence[i]), i);
            }
        }


        public List<String> Substring(int beginIndex, int endIndex)
        {
            List<String> sequence = null;
            try
            {
                sequence = new List<String>(ToList().GetRange(beginIndex, endIndex - beginIndex));
            }
            catch (Exception)
            {
            }

            return sequence;
        }

        public List<String> ToList()
        {
            List<String> result = new List<string>();
            for (int i = 0; i < Length; i++)
            {
                result.Add(this[i].ToString());
            }
            return result;
        } 

        public void ClearAt(int index)
        {
            try
            {
                DeleteAt(index);
            }
            catch (Exception)
            {
            }

        }

        public new ComplexChain Clone()
        {
            ComplexChain chain = new ComplexChain(ToList()) {Anchor = Anchor};

            return chain;
        }

        public bool Equals(ComplexChain complexChain)
        {
            if (complexChain.Length != Length)
                return false;
            for (int index = 0; index < complexChain.Length; index++)
            {
                if (!this[index].ToString().Equals(complexChain[index].ToString()))
                    return false;
            }

            return true;
        }

        public ComplexChain Concat(String str)
        {
            if (String.IsNullOrEmpty(str)) return this;
            ComplexChain temp = Clone();
            ClearAndSetNewLength(Length + 1);
            for (int i = 0; i < temp.Length; i++)
            {
                this[i] = temp[i];
            }
            this[Length - 1] = new ValueString(str);
            return this;
        }

        public ComplexChain Concat(ComplexChain sequence)
        {
            if (sequence.IsEmpty())
                return this;
            ComplexChain temp = Clone();
            
            ClearAndSetNewLength(Length + sequence.Length);
            for (int i = 0; i < temp.Length; i++)
            {
                this[i] = temp[i];
            }
            for (int j = 0; j < sequence.Length; j++)
            {
                this[j + temp.Length] = sequence[j];
            }
            return this;
        }

        public bool IsEmpty()
        {
            return Length == 0;
        }

        /// <summary>
        /// Cuts a range of words from pos to pos + len cursorPosition
        /// </summary>
        /// <param name="pos">start cursorPosition</param>
        /// <param name="len">count of words cut out</param>
        public void Remove(int pos, int len)
        {
            if ((pos + len) > (Length)) return;
            for (int index = pos; index < len + pos; index++)
            {
                DeleteAt(pos);
            }
        }

        /// <summary>
        /// Joins some elements of the sequence to whole composed string
        /// </summary>
        /// <param name="pos">cursorPosition in the sequence at which to begin the gluing</param>
        /// <param name="len">how many words need to join including first word</param>
        public void Join(int pos, int len)
        {
            int wordEnd = pos + len;
            StringBuilder temporarySplice = new StringBuilder();
            temporarySplice.Clear();
            if (wordEnd > Length) return;
            for (int index = pos; index < wordEnd; index++)
            {
                temporarySplice.Append(this[index]);
            }
            for (int i = 0; i < len - 1; i++)
            {
                DeleteAt(pos);
            }
            Add(new ValueString(temporarySplice.ToString()), pos);
        }

        public ComplexChain Original()
        {
            return new ComplexChain(ToString());
        }

        /// <summary>
        /// Joins all hits from start chain to whole composed string
        /// Very fast for long sequence, because there is no index check!
        /// </summary>
        /// <param name="word">list of letters to compose</param>
        public void JoinAll(List<String> word)
        {
            int length = word.Count;
            int index = 0;
            while (true)
            {
                try
                {
                    if (ToList().GetRange(index, length - index).Equals(word))
                    {
                        Join(index, length);
                    }
                    index++;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}