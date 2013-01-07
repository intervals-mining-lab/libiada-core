using System;
using System.Collections.Generic;
using System.Text;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.Root.SimpleTypes;
using LibiadaCore.Classes.TheoryOfSet;
using Segmentation.Classes.Interfaces;

namespace Segmentation.Classes.Base.Sequencies
{
    public class ComplexChain : Chain, IIdentifiable
    {
        protected String name;
        protected List<String> sequence;
        protected LinkUp anchor;
        protected StringBuilder temporarySplice;
        public int Length
        {
            get { return sequence.Count; }
        }

        public ComplexChain()
        {
            init();
        }

        public ComplexChain(String sequence, String chainName):base(sequence)
        {
            name = chainName;
        }

        public ComplexChain(List<int> accord)
        {
            for (int i = 0; i < accord.Count; i++)
            {
                this.sequence.Add(accord[i].ToString());
                this.Add(new ValueInt(accord[i]), i);
            }
        }
       

        private void init()
        {
            temporarySplice = new StringBuilder();
            name = "Тестовая цепь";
            anchor = LinkUp.Start;
            sequence = new List<String>();
        }

        public String GetName()
        {
            return name;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public LinkUp GetAnchor()
        {
            return anchor;
        }

        public void SetAnchor(LinkUp anchor)
        {
            this.anchor = anchor;
        }

        public ComplexChain(String sequence):base(sequence)
        {
            init();
            for (int index = 0; index < sequence.Length; index++)
            {
                this.sequence.Add(sequence[index].ToString());
            }
        }

        public ComplexChain(List<String> sequence):base(sequence.Count)
        {
            init();
            this.sequence = new List<String>(sequence);
            for (int i = 0; i < sequence.Count; i++)
            {
                Add(new ValueString(sequence[i]), i);
            }
        }

        public String elementAt(int index)
        {
            String sequence = null;
            try
            {
                sequence = this.sequence[index];
            }
            catch (Exception e)
            {
            }
            return sequence;
        }

        public List<String> substring(int beginIndex, int endIndex)
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


        public ComplexChain clearAt(int index)
        {
            try
            {
                sequence.RemoveAt(index);
                this.DeleteAt(index);
            }
            catch (Exception e)
            {
            }

            return this;

        }

        public ComplexChain Clone()
        {
            if (IsEmpty()) return null;
            ComplexChain chain = new ComplexChain(sequence);
            chain.SetName(name);
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

        public ComplexChain toUpperCase()
        {
            for (int index = 0; index < sequence.Count; index++)
            {
                sequence[index] = sequence[index].ToUpper();
                Add(new ValueString(sequence[index].ToUpper()), index);
            }

            return this;
        }

        public ComplexChain toLowerCase()
        {
            for (int index = 0; index < sequence.Count; index++)
            {
                sequence[index] = sequence[index].ToLower();
            }

            return this;
        }

        public ComplexChain concat(String str)
        {
            if (String.IsNullOrEmpty(str)) return this;
            sequence.Add(str);

            return this;
        }

        public ComplexChain concat(ComplexChain sequence)
        {
            int startIndex = 0;
            if (sequence.IsEmpty())
                return this;
            this.sequence.AddRange(sequence.substring(startIndex, sequence.Length));

            return this;
        }

        public bool IsEmpty()
        {
            return sequence.Count == 0;
        }

        /**
         * Changes an element in index position
         *
         * @param index a position in a chain
         * @param str a new element
         */

        public void Replace(int index, String str)
        {
            sequence[index] = str;
        }

        /**
         *
         * @return a string representation of the sequence
         */

        public override String ToString()
        {
            temporarySplice.Clear();

            foreach (String aSequence in sequence)
            {
                temporarySplice.Append(aSequence);
            }

            return temporarySplice.ToString();
        }

        /**
         * Returns divided string by delimiter
         *
         * @param delimiter any string
         * @return divided string
         */

        public String ToString(String delimiter)
        {
            temporarySplice.Clear();

            foreach (String aSequence in sequence)
            {
                temporarySplice.Append(aSequence).Append(delimiter);
            }
            temporarySplice.Remove(temporarySplice.Length - delimiter.Length, temporarySplice.Length);
            return temporarySplice.ToString();
        }

        /**
         * Identify whether is there  a chain contains the specified element
         *
         * @param word sequence which is part of a chain
         * @return true if chain contains the specified element
         */

        public bool IsElement(String word)
        {
            return sequence.Contains(word);
        }

        /**
         * Cuts a range of words from pos to pos + len cursorPosition
         * @param pos start cursorPosition
         * @param len count of words cut out
         */

        public void Remove(int pos, int len)
        {
            if ((pos + len) > (sequence.Count)) return;
            for (int index = pos; index < len + pos; index++)
            {
                sequence.RemoveAt(pos);
            }
        }

        /**
         * Joins some elements of the sequence to whole composed string
         *
         * @param pos cursorPosition in the sequence at which to begin the gluing
         * @param len how many words need to join including first word
         */

        public void join(int pos, int len)
        {
            int wordEnd = pos + len;

            temporarySplice.Clear();
            if (wordEnd > sequence.Count) return;
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

        public ComplexChain original()
        {
            return new ComplexChain(ToString());
        }

        /**
         * Joins all hits from start chain to whole composed string
         * Very fast for long sequence, because there is no index check!
         * @param word list of letters to compose
         */

        public void joinAll(List<String> word)
        {
            int length = word.Count;
            int index = 0;
            while (1 == 1)
            {
                try
                {
                    if (sequence.GetRange(index, length - index).Equals(word)) join(index, length);
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