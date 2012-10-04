using System.Collections.Generic;

namespace LibiadaCore.Classes.Root
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

        public IBaseObject Clone()
        {
            ChainMessage temp = new ChainMessage(Length);
            FillClone(temp);
            return temp;
        }
    }
}