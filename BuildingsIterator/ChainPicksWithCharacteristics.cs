namespace BuildingsIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Filters;
    using Statistics;

    /// <summary>
    /// ����� ������� ������� � ����������������.
    /// </summary>
    public class ChainPicksWithCharacteristics
    {
        /// <summary>
        /// The chains.
        /// </summary>
        private readonly Hashtable chains;

        /// <summary>
        /// The characteristics names.
        /// </summary>
        private readonly List<string> characteristicsNames;

        /// <summary>
        /// The characters.
        /// </summary>
        private readonly List<LinkedCharacteristic> characteristics;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChainPicksWithCharacteristics"/> class.
        /// </summary>
        /// <param name="chains">
        /// ��� ������� � ��������� � ������������ ����������������.
        /// </param>
        /// <param name="characters">
        /// ������ ������������� � ��������.
        /// </param>
        public ChainPicksWithCharacteristics(Hashtable chains, List<LinkedCharacteristic> characters)
        {
            this.chains = chains;
            characteristics = characters;
            characteristicsNames = new List<string>();
            for (int i = 0; i < characters.Count; i++)
            {
                characteristicsNames.Add(characters[i].Calculator.GetType().ToString());
            }
        }

        /// <summary>
        /// Gets count of chains in sample.
        /// </summary>
        public int Count
        {
            get { return chains.Count; }
        }

        /// <summary>
        /// ���������� ������� �������� ���������� ��������������.
        /// </summary>
        /// <param name="characteristic">
        /// Characteristic name.
        /// </param>
        /// <returns>
        /// The sample.
        /// </returns>
        public Picks GetPicks(string characteristic)
        {
            var picks = new Picks(GetCharacteristicName(characteristicsNames.IndexOf(characteristic)));
            IDictionaryEnumerator iterator = chains.GetEnumerator();
            while (iterator.MoveNext())
            {
                picks.Add(((List<double>)iterator.Value)[characteristicsNames.IndexOf(characteristic)]);
            }

            return picks;
        }

        /// <summary>
        /// ���������� ������� �������� ���������� ��������������.
        /// </summary>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <returns>
        /// The sample.
        /// </returns>
        public Picks GetPicks(int i)
        {
            var picks = new Picks(GetCharacteristicName(i));
            IDictionaryEnumerator iterator = chains.GetEnumerator();
            while (iterator.MoveNext())
            {
                picks.Add(((List<double>)iterator.Value)[i]);
            }

            return picks;
        }

        /// <summary>
        /// ���������� ������ ������������� ��� ���������� ����.
        /// </summary>
        /// <param name="i">
        /// ����� ���� � �������.
        /// </param>
        /// <returns>
        /// ������ �������������.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown if element is not found.
        /// </exception>
        public List<double> GetCharacteristicsVector(int i)
        {
            IDictionaryEnumerator iterator = chains.GetEnumerator();
            while (iterator.MoveNext())
            {
                if (i == 0)
                {
                    return (List<double>)iterator.Value;
                }

                i--;
            }

            throw new Exception("������� �� ������");
        }

        /// <summary>
        /// ���������� ���������� �������.
        /// </summary>
        /// <param name="i">
        /// ����� � �������.
        /// </param>
        /// <returns>
        /// ������� � ���� ������.
        /// </returns>
        public string GetChain(int i)
        {
            IDictionaryEnumerator iterator = chains.GetEnumerator();
            while (iterator.MoveNext())
            {
                if (i == 0)
                {
                    return (string)iterator.Key;
                }

                i--;
            }

            throw new Exception("������� �� �������");
        }

        /// <summary>
        /// The get characteristics count.
        /// ���������� ����� ����������� ������������� ��� ������ �������.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetCharacteristicsCount()
        {
            return characteristicsNames.Count;
        }

        /// <summary>
        /// ���������� ��� ��������������.
        /// </summary>
        /// <param name="i">
        /// ����� � ������� ����.
        /// </param>
        /// <returns>
        /// ��������� ���.
        /// </returns>
        public string GetCharacteristicName(int i)
        {
            return characteristicsNames[i].ToString();
        }

        /// <summary>
        /// The get all chains.
        /// ���������� ������ ���� �������.
        /// </summary>
        /// <returns>
        /// The <see cref="List{String}"/>.
        /// </returns>
        public List<string> GetAllChains()
        {
            var result = new List<string>();
            IDictionaryEnumerator iterator = chains.GetEnumerator();
            while (iterator.MoveNext())
            {
                result.Add((string)iterator.Key);
            }

            return result;
        }

        /// <summary>
        /// The get filtered chain picks.
        /// </summary>
        /// <param name="cardinality">
        /// The cardinality.
        /// </param>
        /// <returns>
        /// The <see cref="ChainPicksWithCharacteristics"/>.
        /// </returns>
        public ChainPicksWithCharacteristics GetFilteredChainPicks(IChainFilter cardinality)
        {
            var newChains = new Hashtable();
            IDictionaryEnumerator iterator = chains.GetEnumerator();
            while (iterator.MoveNext())
            {
                if (cardinality.IsValid((string)iterator.Key))
                {
                    newChains.Add(iterator.Key, iterator.Value);
                }
            }

            return new ChainPicksWithCharacteristics(newChains, characteristics);
        }

        /// <summary>
        /// The fill chain list.
        /// </summary>
        /// <param name="values">
        /// The values.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// Not implemented.
        /// </exception>
        public void FillChainList(List<string> values)
        {
            throw new NotImplementedException();
        }
    }
}
