namespace BuildingsIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using BuildingsIterator.Filters;
    using BuildingsIterator.Statistics;

    using LibiadaCore.Core.Characteristics;

    /// <summary>
    /// ����� ������� ������� � ����������������
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
        /// ��� ������� � ��������� � ������������ ����������������
        /// </param>
        /// <param name="characters">
        /// ������ ������������� � ��������
        /// </param>
        public ChainPicksWithCharacteristics(Hashtable chains, List<LinkedCharacteristic> characters)
        {
            this.chains = chains;
            this.characteristics = characters;
            this.characteristicsNames = new List<string>();
            for (int i = 0; i < characters.Count; i++)
            {
                this.characteristicsNames.Add(characters[i].Calc.GetType().ToString());
            }
        }

        /// <summary>
        /// ����� ������� � �������
        /// </summary>
        public int Count
        {
            get
            {
                return this.chains.Count;
            }
        }

        /// <summary>
        /// ���������� ������� �������� ���������� ��������������
        /// </summary>
        /// <param name="characteristics">��������������</param>
        /// <returns>�������</returns>
        public Picks GetPicks(string characteristics)
        {
            var picks = new Picks(this.GetCharacteristicName(this.characteristicsNames.IndexOf(characteristics)));
            IDictionaryEnumerator iterator = this.chains.GetEnumerator();
            while (iterator.MoveNext())
            {
                picks.Add(((List<double>)iterator.Value)[this.characteristicsNames.IndexOf(characteristics)]);
            }

            return picks;
        }

        /// <summary>
        /// ���������� ������� �������� ���������� ��������������
        /// </summary>
        /// <param name="i">
        /// The i.
        /// </param>
        /// <returns>
        /// �������.
        /// </returns>
        public Picks GetPicks(int i)
        {
            var picks = new Picks(this.GetCharacteristicName(i));
            IDictionaryEnumerator iterator = this.chains.GetEnumerator();
            while (iterator.MoveNext())
            {
                picks.Add(((List<double>)iterator.Value)[i]);
            }

            return picks;
        }

        /// <summary>
        /// ���������� ������ ������������� ��� ���������� ����
        /// </summary>
        /// <param name="i">����� ���� � �������</param>
        /// <returns>������ �������������</returns>
        /// <exception cref="Exception">������� �� ������</exception>
        public List<double> GetCharacteristicsVector(int i)
        {
            IDictionaryEnumerator iterator = this.chains.GetEnumerator();
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
        /// ���������� ���������� �������
        /// </summary>
        /// <param name="i">����� � �������</param>
        /// <returns>������� � ���� ������</returns>
        public string GetChain(int i)
        {
            IDictionaryEnumerator iterator = this.chains.GetEnumerator();
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
        /// ���������� ����� ����������� ������������� ��� ������ �������
        /// </summary>
        /// <returns></returns>
        public int GetCharacteristicsCount()
        {
            return this.characteristicsNames.Count;
        }

        /// <summary>
        /// ���������� ��� ��������������
        /// </summary>
        /// <param name="i">����� � ������� ����</param>
        /// <returns>��������� ���</returns>
        public string GetCharacteristicName(int i)
        {
            return this.characteristicsNames[i].ToString();
        }

        /// <summary>
        /// ���������� ������ ���� �������
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllChains()
        {
            var result = new List<string>();
            IDictionaryEnumerator iterator = this.chains.GetEnumerator();
            while (iterator.MoveNext())
            {
                result.Add((string) iterator.Key);
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
            IDictionaryEnumerator iterator = this.chains.GetEnumerator();
            while (iterator.MoveNext())
            {
                if (cardinality.IsValid((string)iterator.Key))
                {
                    newChains.Add(iterator.Key, iterator.Value);
                }
            }

            return new ChainPicksWithCharacteristics(newChains, this.characteristics);
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