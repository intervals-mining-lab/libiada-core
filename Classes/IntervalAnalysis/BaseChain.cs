using System;
using ChainAnalises.Classes.EventTheory;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.Root.SimpleTypes;

namespace ChainAnalises.Classes.IntervalAnalysis
{
    ///<summary>
    /// 
    ///</summary>
    [Serializable]
    public class BaseChain : Space, IBaseObject
    {
        ///<summary>
        /// ������ ����.
        /// ������ ��� ������
        ///</summary>
        public int Length
        {
            get { return PlaceCount; }
        }

        ///<summary>
        /// ��������� ��������� �������� ������ � �������� ���� �� �������
        /// � ������ ������ �� ������� ���� ���������� ����������
        ///</summary>
        ///<param name="index">����� ��������</param>
        public IBaseObject this[int index]
        {
            get { return Get(index); }

            set { Add(value, index); }
        }

        ///<summary>
        /// ����� ����������� �������� ������� �� �������
        /// � ������ ������ �� ������� ���� ���������� ����������
        ///</summary>
        ///<param name="index">������ ��������</param>
        ///<returns>���������� �������</returns>
        public IBaseObject Get(int index)
        {
            return GetItem(GetPlacePattern().SetValues(new long[] {index}));
        }

        ///<summary>
        /// ����� ����������� ���������� ������� �� �������
        ///</summary>
        ///<param name="baseObject">��������������� ������� </param>
        ///<param name="index">����� ������� � ���� ���� ��������������� �������</param>
        public void Add(IBaseObject baseObject, int index)
        {
            AddItem(baseObject, GetPlacePattern().SetValues(new long[] {index}));
        }

        ///<summary>
        /// ����� ��������� ������� � ������� ���� 
        /// � ������ ������ �� ������� ���� ���������� ����������
        ///</summary>
        ///<param name="index">����� �������</param>
        public void RemoveAt(int index)
        {
            RemoveAt(GetPlacePattern().SetValues(new long[] {index}));
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < Length; i++)
            {
                result += this[i].ToString();
            }
            return result;
        }

        ///<summary>
        ///</summary>
        ///<param name="length"></param>
        ///<exception cref="Exception"></exception>
        public BaseChain(int length)
        {
            ClearAndSetNewLength(length);
        }

        ///<summary>
        ///</summary>
        ///<param name="length"></param>
        ///<exception cref="Exception"></exception>
        public void ClearAndSetNewLength(int length)
        {
            if (length <= 0)
            {
                throw new Exception("������ ���� <= 0");
            }
            DeleteDimesnions();
            AddDimension(new Dimension(0, length - 1));            
        }

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public BaseChain(BaseChainBin Bin):base(Bin)
        {
            
        }

        ///<summary>
        ///</summary>
        public BaseChain()
        {
            
        }

        
        ///<summary>
        /// ������� ���� �� ������ ��������
        ///</summary>
        ///<param name="s"></param>
        ///<exception cref="NotImplementedException"></exception>
        public BaseChain(string s)
        {
            ClearAndSetNewLength(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                Add((ValueChar) s[i], i);
            }
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public new IBin GetBin()
        {
            BaseChainBin Temp = new BaseChainBin();
            FillBin(Temp);
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public override IBaseObject Clone()
        {
            BaseChain temp = new BaseChain(Length);
            FillClone(temp);
            return temp;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.Equals(PsevdoValue.Instance()))
            {
                for (int i = 0; i < Length; i++)
                {
                    if (!Get(i).Equals(PsevdoValue.Instance()))
                    {
                        return base.Equals(obj);
                    }
                }
                return true;
            }
            return base.Equals(obj);
        }
    }

    ///<summary>
    ///</summary>
    public class BaseChainBin:SpaceBin,IBin
    {
        public new IBaseObject GetInstance()
        {
            return new BaseChain(this);
        }
    }
}