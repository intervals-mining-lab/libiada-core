using System.Collections;
using System.Collections.Generic;
using ChainAnalises.Classes.IntervalAnalysis.Characteristics.AuxiliaryInterfaces;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.IntervalAnalysis
{
    ///<summary>
    /// ����� ���������� �� ���� ��� ��� ChainMessagBin �������� ������ ������ ��������. 
    ///</summary>
    public class ChainMessage : Chain, IBaseObject
    {
        ///<summary>
        /// ����������
        ///</summary>
        ///<param name="length">������ ����</param>
        public ChainMessage(int length): base(length)
        {
            
        }

        ///<summary>
        /// �� ������������������� �����������.
        /// ������� ������ ����� ���� ������ ClearAndSetLength
        /// ��� ������������� ������ ���� � ��������� ��� ���� �����.
        ///</summary>
        public ChainMessage()
        {
            
        }

        ///<summary>
        /// ����������� �������� �� ����
        ///</summary>
        ///<param name="Bin">��� ChainMessage</param>
        public ChainMessage(ChainMessageBin Bin):base(Bin.values.Count)
        {
            int pos = 0;
            foreach (IBin item in Bin.values)
            {
                Add(item.GetInstance(), pos);
                pos++;
            }
        }

        public override IBaseObject Clone()
        {
            ChainMessage temp = new ChainMessage(Length);
            FillClone(temp);
            return temp;
        }

        
        ///<summary>
        /// �������� ��� �������
        ///</summary>
        ///<returns>���</returns>
        public new IBin GetBin()
        {
            ChainMessageBin Temp = new ChainMessageBin();
            FillBin(Temp);
            return Temp;
        }

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public void FillBin(ChainMessageBin Bin)
        {
            foreach (int position_num in vault)
            {
                Bin.values.Add(pAlphabet[position_num].GetBin());
            }
        }

    }

    ///<summary>
    /// ����� ���� ChainMessage
    ///</summary>
    public class ChainMessageBin: IBin
    {
        public List<IBin> values = new List<IBin>();
        ///<summary>
        /// ��������� ������� �� ����
        ///</summary>
        ///<returns>������ ChainMessage �� ��������� ������ �������</returns>
        public IBaseObject GetInstance()
        {
            return new ChainMessage(this);
        }
    }
}