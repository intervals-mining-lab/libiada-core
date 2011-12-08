using System;
using System.Collections;
using System.Collections.Generic;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics;
using ChainAnalises.Classes.Project_A;

namespace MarkovCompare
{
    ///<summary>
    /// ����� ������� ������� � ����������������
    ///</summary>
    public class ChainPicksWithCharacteristics
    {
        private Hashtable chains;
        private List<CharacteristicsEnum> characteristicsNames;
        private List<LinkedUpCharacteristic> charact;

        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="chains">��� ������� � ��������� � ������������ ����������������</param>
        ///<param name="charact">������ ������������� � ��������</param>
        public ChainPicksWithCharacteristics(Hashtable chains, List<LinkedUpCharacteristic> charact)
        {
            this.chains = chains;
            this.charact = charact;
            characteristicsNames = new List<CharacteristicsEnum>();
            for (int i = 0; i < charact.Count; i++)
            {
                characteristicsNames.Add(charact[i].Calc.GetCharacteristicName());
            }
        }

        /// <summary>
        /// ���������� ������� �������� ���������� ��������������
        /// </summary>
        /// <param name="charact">��������������</param>
        /// <returns>�������</returns>
        public Picks GetPicks(CharacteristicsEnum charact)
        {
            Picks picks = new Picks(GetCharacteristicName(characteristicsNames.IndexOf(charact)));
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                picks.Add(((List<double>)iter.Value)[characteristicsNames.IndexOf(charact)]);
            }
            return picks;
        }

        /// <summary>
        /// ���������� ������� �������� ���������� ��������������
        /// </summary>
        /// <returns>�������</returns>
        public Picks GetPicks(int i)
        {
            Picks picks = new Picks(GetCharacteristicName(i));
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                picks.Add(((List<double>)iter.Value)[i]);
            }
            return picks;
        }

        /// <summary>
        /// ����� ������� � �������
        /// </summary>
        public int Count
        {
            get
            {
                return chains.Count;
            }
        }

        ///<summary>
        /// ���������� ������ ������������� ��� ���������� ����
        ///</summary>
        ///<param name="i">����� ���� � �������</param>
        ///<returns>������ �������������</returns>
        ///<exception cref="Exception">������� �� ������</exception>
        public List<double> GetCharactVector(int i)
        {
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                if (i == 0)
                    return (List<double>) iter.Value;
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
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                if (i == 0)
                    return (string) iter.Key;
                i--;
            }
            throw new Exception("������� �� �������");
        }

        ///<summary>
        /// ���������� ����� ����������� ������������� ��� ������ �������
        ///</summary>
        ///<returns></returns>
        public int GetCharacteristicsCount()
        {
            return characteristicsNames.Count;
        }

        ///<summary>
        /// ���������� ��� ��������������
        ///</summary>
        ///<param name="i">����� � ������� ����</param>
        ///<returns>��������� ���</returns>
        public string GetCharacteristicName(int i)
        {
            return characteristicsNames[i].ToString();
        }

        ///<summary>
        /// ���������� ������ ���� �������
        ///</summary>
        ///<returns></returns>
        public List<string> GetAllChains()
        {
            List<string> result = new List<string>();
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                result.Add((string) iter.Key);
            }
            return result;
        }

        ///<summary>
        ///</summary>
        ///<param name="power"></param>
        ///<returns></returns>
        ///<exception cref="NotImplementedException"></exception>
        public ChainPicksWithCharacteristics GetFilteredChainPicks(IChainFilter power)
        {
            Hashtable newChains = new Hashtable();
            IDictionaryEnumerator iter = chains.GetEnumerator();
            while (iter.MoveNext())
            {
                if (power.IsValid((string) iter.Key))
                    newChains.Add(iter.Key, iter.Value);
            }
            return new ChainPicksWithCharacteristics(newChains, charact);
        }

        public void FillChainList(List<string> values)
        {
            throw new NotImplementedException();
        }
    }
}