using System;
using System.Diagnostics;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.EventTheory
{
    /// <summary>
    /// ������ ����� ��������� ��������� ������������.
    /// ��������� ���������. 
    /// </summary>
    [Serializable]
    public class Dimension : IBaseObject
    {
        #region <Data>

        private readonly Int64 pmax;
        private readonly Int64 pmin;

        #endregion

        /// <param name="min"> ������������� ����������� ������� �� ������� ���������</param>
        /// <param name="max"> ������������� ������������ ������� �� ������� ���������</param>
        /// <example>
        ///   ���� ��������� ��������� �� ��������� (-100,500)
        ///   <code>
        ///     X = new dimension(-100,500);
        ///   </code> 
        /// </example>
        /// <summary>
        /// �����������
        /// � ������, ���� min>max ������� ������� �� �����������, � ���������� �������������� ������ ��������.
        /// ������ ��� ���� ������������� ��������� � �������.
        /// </summary>
        public Dimension(Int64 min, Int64 max)
        {
            if (min.CompareTo(max) <= 0)
            {
                pmax = max;
                pmin = min;
            }
            else
            {
                Debug.WriteLine("-------------------------------------------------------------------------");
                Debug.WriteLine("Warning: " + (GetType()) + " creating min > max");
                Debug.WriteLine("��������������: " + (GetType()) + " ��� �������� min > max");
                Debug.WriteLine("-------------------------------------------------------------------------");
                pmin = max;
                pmax = min;
            }
        }

        #region <IBaseObject>

        #region <Help>

        ///<summary>
        ///</summary>
        ///<param name="Bin"></param>
        public Dimension(DimensionBin Bin)
        {
            pmin = Bin.Min;
            pmax = Bin.Max;
        }

        ///<summary>
        ///����� ����������� ��������� ���������������
        ///</summary>
        ///<param name="obj">��������� ������ ��������� �� ��������������� ������</param>
        ///<returns>true ���� ������� ��������� �������� ���������, ����� false</returns>
        public bool EqualsAsDimension(Dimension obj)
        {
            if (obj == null || obj.GetType() != typeof (Dimension))
            {
                return false;
            }

            if (obj.pmax == pmax && obj.pmin == pmin)
            {
                return true;
            }
            return false;
        }


        ///<summary>
        ///Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
        ///</summary>
        ///<returns>
        ///A hash code for the current <see cref="T:System.Object"></see>.
        ///</returns>
        ///<filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            int result = pmin.GetHashCode();
            return 29*result + pmax.GetHashCode();
        }

        #endregion

        public IBaseObject Clone()
        {
            return new Dimension(pmin, pmax);
        }

        ///<summary>
        ///Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///<returns>
        ///true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        ///</returns>
        ///<param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return false;
        }

        public IBin GetBin()
        {
            DimensionBin Temp = new DimensionBin();
            Temp.Min = pmin;
            Temp.Max = pmax;
            return Temp;
        }

        #endregion

        #region <Public Propertes>

        /// <summary>
        /// ���� ������ �������� ������������ ������� ������� �� ������� 
        /// ���������� ���������. ������ ��� ������
        /// </summary>        
        public Int64 max
        {
            get { return pmax; }
        }

        /// <summary>
        /// ���� ������ �������� ����������� ������� ������� �� ������� 
        /// ���������� ���������. ������ ��� ������
        /// </summary>
        public Int64 min
        {
            get { return pmin; }
        }

        ///<summary>
        /// ���� ������ �������� ������ ������� �� ������� ���������� ������ ���������
        /// ������ ��� ������
        ///</summary>
        public int Length
        {
            get
            {
                int dt = 0;
                if (pmin <= 0 && pmax >= 0)
                {
                    dt = 1;
                }
                return (int) (pmax - pmin) + dt;
            }
        }

        #endregion
    }

    ///<summary>
    ///</summary>
    public class DimensionBin:IBin
    {
        #region <Data>

        public Int64 Max;
        public Int64 Min;

        #endregion

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public IBaseObject GetInstance()
        {
            return new Dimension(this);
        }
    }
}