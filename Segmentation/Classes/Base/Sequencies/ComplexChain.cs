using System;
using System.Collections.Generic;
using System.Text;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Base.Sequencies
{
    public class ComplexChain : Chain
    {
        protected List<String> sequence;
        protected LinkUp anchor;

        public ComplexChain()
        {
            Init();
        }

        public ComplexChain(String sequence, String chainName)
            : base(sequence)
        {
        }

        public ComplexChain(List<int> accord)
        {
            for (int i = 0; i < accord.Count; i++)
            {
                this.sequence.Add(accord[i].ToString());
                this.Add(new ValueInt(accord[i]), i);
            }
        }

        public ComplexChain(String sequence)
            : base(sequence)
        {
            Init();
            for (int index = 0; index < sequence.Length; index++)
            {
                this.sequence.Add(sequence[index].ToString());
            }
        }

        public ComplexChain(List<String> sequence)
            : base(sequence.Count)
        {
            Init();
            this.sequence = new List<String>(sequence);
            for (int i = 0; i < sequence.Count; i++)
            {
                Add(new ValueString(sequence[i]), i);
            }
        }


        private void Init()
        {
            anchor = LinkUp.Start;
            sequence = new List<String>();
        }

        public LinkUp GetAnchor()
        {
            return anchor;
        }

        public void SetAnchor(LinkUp anchor)
        {
            this.anchor = anchor;
        }

        public List<String> Substring(int beginIndex, int endIndex)
        {
            List<String> sequence = null;
            try
            {
                sequence = new List<String>(this.sequence.GetRange(beginIndex, endIndex - beginIndex));
            }
            catch (Exception e)
            {
            }

            return sequence;
        }


        public void ClearAt(int index)
        {
            try
            {
                sequence.RemoveAt(index);
                this.DeleteAt(index);
            }
            catch (Exception e)
            {
            }

        }

        public ComplexChain Clone()
        {
            ComplexChain chain = new ComplexChain(sequence);
            chain.SetAnchor(anchor);

            return chain;
        }

        public bool Equals(ComplexChain complexChain)
        {
            if (complexChain.Length != Length)
                return false;
            for (int index = 0; index < complexChain.Length; index++)
            {
                if (!this.sequence[index].Equals(complexChain[index].ToString()))
                    return false;
            }

            return true;
        }

        public ComplexChain Concat(String str)
        {
            if (String.IsNullOrEmpty(str)) return this;
            ComplexChain temp = this.Clone();
            sequence.Add(str);
            ClearAndSetNewLength(Length + 1);
            for (int i = 0; i < temp.Length; i++)
            {
                this[i] = temp[i];
            }
            this[this.Length - 1] = new ValueString(str);
            return this;
        }

        public ComplexChain Concat(ComplexChain sequence)
        {
            int startIndex = 0;
            
            if (sequence.IsEmpty())
                return this;
            ComplexChain temp = this.Clone();
            this.sequence.AddRange(sequence.Substring(startIndex, sequence.Length));
            
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
            return this.Length == 0;
        }

        /// <summary>
        /// Changes an element in index position
        /// </summary>
        /// <param name="index">a position in a chain</param>
        /// <param name="str">a new element</param>
        public void Replace(int index, String str)
        {
            sequence[index] = str;
            this[index] = new ValueString(str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>a string representation of the sequence</returns>
        public override String ToString()
        {
            StringBuilder temporarySplice = new StringBuilder();
            temporarySplice.Clear();

            foreach (String aSequence in sequence)
            {
                temporarySplice.Append(aSequence);
            }

            return temporarySplice.ToString();
        }

        /// <summary>
        /// Cuts a range of words from pos to pos + len cursorPosition
        /// </summary>
        /// <param name="pos">start cursorPosition</param>
        /// <param name="len">count of words cut out</param>
        public void Remove(int pos, int len)
        {
            if ((pos + len) > (this.Length)) return;
            for (int index = pos; index < len + pos; index++)
            {
                sequence.RemoveAt(pos);
                this.DeleteAt(pos);
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
            if (wordEnd > this.Length) return;
            for (int index = pos; index < wordEnd; index++)
            {
                temporarySplice.Append(sequence[index]);
            }
            for (int i = 0; i < len - 1; i++)
            {
                sequence.RemoveAt(pos);
                DeleteAt(pos);
            }
            //sequence.GetRange(pos, wordEnd - 1 - pos).Clear();
            Add(new ValueString(temporarySplice.ToString()), pos);
            sequence[pos] = temporarySplice.ToString();
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
            while (1 == 1)
            {
                try
                {
                    if (sequence.GetRange(index, length - index).Equals(word)) Join(index, length);
                    index++;
                }
                catch (Exception e)
                {
                    return;
                }
            }
        }
    }
}