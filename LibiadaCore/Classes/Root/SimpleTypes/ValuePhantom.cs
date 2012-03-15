using System;
using System.Collections;
using LibiadaCore.Classes.EventTheory;
using LibiadaCore.Classes.TheoryOfSet;

namespace LibiadaCore.Classes.Root.SimpleTypes
{
    ///<summary>
    /// ��������� ���������, �������� � ���� ��������� ��������� �������� ����� �������.
    ///</summary>
    [Serializable]
    public class ValuePhantom : Alphabet, IBaseObject
    {

        ///<summary>
        /// ����������� ��� ����������
        ///</summary>
        public ValuePhantom()
        {
            
        }
        ///<summary>
        ///</summary>
        public ValuePhantom(AlphabetBin Bin) : base(Bin)
        {
        }

        public new IBin GetBin()
        {
            ValuePhantomBin Temp = new ValuePhantomBin();
            FillBin(Temp);
            return Temp;
        }

        /// <summary>
        /// ��������� ���������� ��������� ��������� � ��������� � ���������
        /// </summary>
        /// <param name="obj"> ��������� ��������� ������������ � ��������</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return
                EqualsAsPhantom(obj as ValuePhantom) || EqualsAsPsevdo(obj as PsevdoValue) ||
                EqualsAsElement(obj as IBaseObject);
        }

        private bool EqualsAsPsevdo(PsevdoValue psevdoValue)
        {
            if (psevdoValue == null)
            {
                return false;
            }
            return power == 0;
        }

        private bool EqualsAsElement(IBaseObject baseObject)
        {
            for (int i = 0; i < power; i++)
            {
                if (IndexOf(baseObject) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        private bool EqualsAsPhantom(ValuePhantom messagePhantom)
        {
            return base.Equals(messagePhantom);
        }

        ///<summary>
        /// ����� ��������� ��������� ��������� � �������, ����� �����������.
        /// ��� �������� ������� ������������� ���������, �� ������������ � ������ ��������� ���������,
        /// ����������� � �������. �� ����, ���������� ����������� ��������� ���������, ��� 
        /// ������������ �������� ��������� ������������ � ������ ���������.
        ///</summary>
        ///<param name="messagePhantom">������ ���������</param>
        public void Add(ValuePhantom messagePhantom)
        {
            if (messagePhantom != null)
            {
                for (int i = 0; i < messagePhantom.power; i++)
                {
                    if (!Contains(messagePhantom[i]))
                    {
                        Add(messagePhantom[i]);
                    }
                }
            }
        }

        /// <summary>
        /// ��������� ������ � ��������� ���������.
        /// </summary>
        /// <param name="BaseObject">����� ������</param>
        /// <returns>������ ������ ������� ��� -1 ���� ��� �� ������� ��������</returns>
        public override int Add(IBaseObject BaseObject)
        {
            if (BaseObject != null && !BaseObject.Equals(PsevdoValue.Instance()))
            {
                return base.Add(BaseObject);
            }
            return -1;
        }

        public override string ToString()
        {
            return vault[0].ToString();
        }


        /// <summary>
        /// ����� ����������� ���������� ���������
        /// </summary>
        /// <returns>����� �������</returns>
        public new IBaseObject Clone()
        {
            ValuePhantom temp = new ValuePhantom();
            temp.vault = (ArrayList) vault.Clone();
            return temp;
        }
    }

    ///<summary>
    ///</summary>
    public class ValuePhantomBin:AlphabetBin, IBin
    {
        public new IBaseObject GetInstance()
        {
            return new ValuePhantom(this);
        }
    }
}