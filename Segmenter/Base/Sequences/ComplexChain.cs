namespace Segmenter.Base.Sequences
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators;
    using LibiadaCore.Core.SimpleTypes;
    using LibiadaCore.Misc;

    /// <summary>
    /// The complex chain.
    /// </summary>
    public class ComplexChain : Chain
    {
        /// <summary>
        /// The anchor.
        /// </summary>
        public Link Anchor = Link.Start;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexChain"/> class.
        /// </summary>
        /// <param name="accord">
        /// The accord.
        /// </param>
        public ComplexChain(List<int> accord)
        {
            for (int i = 0; i < accord.Count; i++)
            {
                Set(new ValueInt(accord[i]), i);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexChain"/> class.
        /// </summary>
        /// <param name="sequence">
        /// The sequence.
        /// </param>
        public ComplexChain(string sequence)
            : base(sequence)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexChain"/> class.
        /// </summary>
        /// <param name="sequence">
        /// The sequence.
        /// </param>
        public ComplexChain(List<string> sequence)
            : base(sequence.Count)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                Set(new ValueString(sequence[i]), i);
            }
        }

        /// <summary>
        /// The substring.
        /// </summary>
        /// <param name="beginIndex">
        /// The begin index.
        /// </param>
        /// <param name="endIndex">
        /// The end index.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> Substring(int beginIndex, int endIndex)
        {
            List<string> sequence = null;
            try
            {
                sequence = new List<string>(ToList().GetRange(beginIndex, endIndex - beginIndex));
            }
            catch (Exception)
            {
            }

            return sequence;
        }

        /// <summary>
        /// The to list.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> ToList()
        {
            var result = new List<string>();
            for (int i = 0; i < GetLength(); i++)
            {
                result.Add(this[i].ToString());
            }

            return result;
        }

        /// <summary>
        /// The clear at.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
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

        /// <summary>
        /// Deletes element in provided position.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// Deleted element.
        /// </returns>
        public IBaseObject DeleteAt(int index)
        {
            IBaseObject element = alphabet[building[index]];
            ICalculator calc = new ElementsCount();
            CongenericChain tempCongenericChain = CongenericChain(element);
            if ((int)calc.Calculate(tempCongenericChain, Link.None) == 1)
            {
                var temp = congenericChains;
                congenericChains = new CongenericChain[temp.Length - 1];
                int j = 0;
                foreach (CongenericChain congenericChain in temp)
                {
                    if (!congenericChain.Element.Equals(element))
                    {
                        congenericChains[j] = congenericChain;
                        j++;
                    }
                }

                alphabet.Remove(building[index]);
                for (int k = 0; k < building.Length; k++)
                {
                    if (building[index] < building[k])
                    {
                        building[k] = building[k] - 1;
                    }
                }
            }

            foreach (CongenericChain congenericChain in congenericChains)
            {
                congenericChain.DeleteAt(index);
            }

            building = ArrayManipulator.DeleteAt(building, index);
            return element;
        }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="ComplexChain"/>.
        /// </returns>
        public new ComplexChain Clone()
        {
            var chain = new ComplexChain(ToList()) { Anchor = Anchor };

            return chain;
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="complexChain">
        /// The complex chain.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(ComplexChain complexChain)
        {
            if (complexChain.GetLength() != GetLength())
            {
                return false;
            }

            for (int index = 0; index < complexChain.GetLength(); index++)
            {
                if (!this[index].ToString().Equals(complexChain[index].ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The concat.
        /// </summary>
        /// <param name="str">
        /// The string.
        /// </param>
        /// <returns>
        /// The <see cref="ComplexChain"/>.
        /// </returns>
        public ComplexChain Concat(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return this;
            }

            ComplexChain temp = Clone();
            ClearAndSetNewLength(GetLength() + 1);
            for (int i = 0; i < temp.GetLength(); i++)
            {
                this[i] = temp[i];
            }

            this[GetLength() - 1] = new ValueString(str);
            return this;
        }

        /// <summary>
        /// The concat.
        /// </summary>
        /// <param name="sequence">
        /// The sequence.
        /// </param>
        /// <returns>
        /// The <see cref="ComplexChain"/>.
        /// </returns>
        public ComplexChain Concat(ComplexChain sequence)
        {
            if (sequence.IsEmpty())
            {
                return this;
            }

            ComplexChain temp = Clone();

            ClearAndSetNewLength(GetLength() + sequence.GetLength());
            for (int i = 0; i < temp.GetLength(); i++)
            {
                this[i] = temp[i];
            }

            for (int j = 0; j < sequence.GetLength(); j++)
            {
                this[j + temp.GetLength()] = sequence[j];
            }

            return this;
        }

        /// <summary>
        /// The is empty.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsEmpty()
        {
            return GetLength() == 0;
        }

        /// <summary>
        /// Cuts a range of words from position to position + len cursorPosition
        /// </summary>
        /// <param name="pos">start cursor position</param>
        /// <param name="len">count of words cut out</param>
        public void Remove(int pos, int len)
        {
            if ((pos + len) > GetLength())
            {
                return;
            }

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
            var temporarySplice = new StringBuilder();
            temporarySplice.Clear();
            if (wordEnd > GetLength())
            {
                return;
            }

            for (int index = pos; index < wordEnd; index++)
            {
                temporarySplice.Append(this[index]);
            }

            for (int i = 0; i < len - 1; i++)
            {
                DeleteAt(pos);
            }

            Set(new ValueString(temporarySplice.ToString()), pos);
        }

        /// <summary>
        /// The original.
        /// </summary>
        /// <returns>
        /// The <see cref="ComplexChain"/>.
        /// </returns>
        public ComplexChain Original()
        {
            return new ComplexChain(ToString());
        }

        /// <summary>
        /// Joins all hits from start chain to whole composed string
        /// Very fast for long sequence, because there is no index check!
        /// </summary>
        /// <param name="word">list of letters to compose</param>
        public void JoinAll(List<string> word)
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
