using System;
using System.Collections;
using System.Diagnostics;
using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.EventTheory
{
    ///<summary>
    /// ����� �����
    ///</summary>
    [Serializable]
    public class Place : IBaseObject
    {
        private readonly ArrayList pDimensions = new ArrayList();
        private readonly ArrayList Values = new ArrayList();

        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="dimensionality">����������� ������������ �������� ����������� ������ �����</param>
        ///<exception cref="Exception">��������� ������</exception>
        public Place(ArrayList dimensionality)
        {
            if (dimensionality == null) throw new ArgumentNullException("dimensionality");
            if (dimensionality.Count <= 0)
            {
                Debug.WriteLine("-------------------------------------------------------------------------");
                Debug.WriteLine("Warning: " + (GetType()) + " place would be empty (wrong space )");
                Debug.WriteLine("��������������: " + (GetType()) + " ���������� ����� (������������� �����������) ");
                Debug.WriteLine("-------------------------------------------------------------------------");
                throw new Exception("Dimention is wrong <0");
            }
            else
            {
                for (int i = 0; i < dimensionality.Count; i++) //TODO
                {
                    if (pDimensions.Contains(dimensionality[i]))
                    {
                        throw  new Exception("������ ������. ����� ������������");
                    }
                    Values.Add(((Dimension) dimensionality[i]).min);
                    pDimensions.Add(((Dimension) dimensionality[i]).Clone());
                }
            }
        }

        ///<summary>
        /// ������������� �������� value �� ��������� ��� ������� index 
        ///</summary>
        ///<param name="value">��������</param>
        ///<param name="index">����� ���������</param>
        ///<exception cref="Exception">��� ������� ���������� �������� �� ������������� ��������� ��� �������� ������� �� ������� ����������� �������� ��������� ����������</exception>
        public virtual void SetValue(Int64 value, Int64 index)
        {
//������ ��� ����� ������ ��� ������... :) ������� ������ ��� ���������....:)
            if (index >= pDimensions.Count || index < 0)
            {
                throw  new Exception("������� ���������� �� ������������ ���������");
            }
//��� ������� ����� ������ �������� :)

            if (value < ((Dimension) pDimensions[(int) index]).min || value > ((Dimension) pDimensions[(int) index]).max)
            {
                throw new Exception("������� ���������� �������� " + value + " ��������� �� ������� ����������� (" +
                                    ((Dimension) pDimensions[(int) index]).min + " , " +
                                    ((Dimension) pDimensions[(int) index]).max + ")  ������� ��������� ");
            }
            Values[(int) index] = value;
        }

/*
        ///<summary>
        /// ������������� �������� value �� ��������� Dimension 
        ///</summary>
        ///<param name="value">��������</param>
        ///<param name="inDimension">��������</param>
        ///<exception cref="Exception">��� ������� ���������� �������� �� ������������� ��������� ��� �������� ������� �� ������� ����������� �������� ��������� ����������</exception>
        public virtual void SetValue(Int64 value, Dimension inDimension)
        {
            SetValue(value,pDimensions.IndexOf(inDimension));
        }
*/

        ///<summary>
        ///������������� �������� �� ���� ���������� �� �������.
        ///</summary>
        ///<param name="value">������ ��������</param>
        ///<exception cref="Exception">� ������ ���� ����������� ������� � ����� �� ��������� � � ������ ���� ���� �� �������� ������� �� ������� ������� ����������� ���������������� �������� ���������� ����������</exception>
        public virtual Place SetValues(Int64[] value)
        {
            if (value.GetLength(0) != pDimensions.Count)
            {
                throw new Exception("����������� �� ���������");
            }

            for (Int64 i = 0; i < pDimensions.Count; i++)
            {
                SetValue(value[i], i);
            }

            return this;
        }

        ///<summary>
        /// ���������� �������� �� ��������� ��� ������� index 
        ///</summary>
        ///<param name="index">����� ���������</param>
        ///<exception cref="Exception">��� ������� �������� �������� �� ��������������� ��������� ��������� ����������</exception>
        public virtual Int64 GetValue(Int64 index)
        {
            if (index >= pDimensions.Count || index < 0)
            {
                throw new Exception("������� �������� �������� �� ������������� ���������");
            }
            return (long) Values[(int) index];
        }

/*
        ///<summary>
        /// ���������� �������� �� ��������� Dimension
        ///</summary>
        ///<param name="inDimension">���������</param>
        ///<exception cref="Exception">��� ������� �������� �������� �� ��������������� ��������� ��������� ����������</exception>
        public virtual Int64 GetValue(Dimension inDimension)
        {
            return GetValue(pDimensions.IndexOf(inDimension));
        }
*/

        ///<summary>
        /// ���������� ������ �������� �� ���� ����������
        ///</summary>
        ///<returns>������ �������� �� ���� ����������</returns>
        public virtual Int64[] GetValues()
        {
            return (long[]) new ArrayList(Values).ToArray(typeof (long));
        }

        ///<summary>
        ///���������� ������ �������� ������������ �������� ����������� ����� 
        ///</summary>
        public IList Dimension
        {
            get { return pDimensions; }
        }

        ///<summary>
        /// ���������� ����������� ������������ �������� ����������� �����.
        ///</summary>
        public Int64 Count
        {
            get
            {
                if (pDimensions.Count != Values.Count)
                {
                    throw new Exception("������ ����������� ������");
                }
                return pDimensions.Count;
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public Boolean CompatibleTo(Place b)
        {
            if (b == null)
            {
                throw new NullReferenceException("����� null");
            }
            if (ReferenceEquals(this, b))
            {
                return true;
            }

            if (b.Count != Count)
            {
                return false;
            }

            for (int i = 0; i < b.Count; i++)
            {
                if (!((Dimension) b.Dimension[i]).EqualsAsDimension((Dimension) pDimensions[i]))
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>
        ///</summary>
        ///<param name="b"></param>
        ///<returns></returns>
        ///<exception cref="Exception"></exception>
        public Boolean Neighbour(Place b)
        {
            if (b == null)
            {
                return false;
            }
            bool result;
            int Distance = 0;

            if (!CompatibleTo(b))
            {
                return false;
            }

            for (int i = 0; i < b.Count; i++)
            {
                if (b.GetValue(i) == GetValue(i))
                {
                    continue;
                }
                Distance = (int) (Distance + Math.Abs(b.GetValue(i) - GetValue(i)));
            }
            result = Distance == 1;
            return result;
        }

        ///<summary>
        /// ���������� ��� ����� ��� �����
        ///</summary>
        ///<param name="after">����� � ������� ����������. ���� null �� ���������� false</param>
        ///<returns>True ���� ����� ����������� ������ ������������ � ����� ���������� �������� ����� false</returns>
        public bool EqualsAsPlace(Place after)
        {
            if (after == null || !CompatibleTo(after))
            {
                return false;
            }

            for (int i = 0; i < Count; i++)
            {
                if (!((Dimension) pDimensions[i]).EqualsAsDimension((Dimension) after.Dimension[i]) ||
                    GetValue(i) != after.GetValue(i))
                {
                    return false;
                }
            }
            return true;
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public IBaseObject Clone()
        {
            Place Temp = new Place((ArrayList) pDimensions.Clone());
            Temp.SetValues((long[]) Values.ToArray(typeof (long)).Clone());
            return Temp;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return EqualsAsPlace(obj as Place);
        }

        public IBin GetBin()
        {
            throw new NotImplementedException();
        }
    }
}