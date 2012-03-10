using System;
using System.Diagnostics;
using LibiadaCore.Classes.Root;

namespace LibiadaCore.Classes.EventTheory
{
    /// <summary>
    /// ƒанный класс реализует измерение пространства.
    /// »змерение дискретно. 
    /// </summary>
    [Serializable]
    public class Dimension : IBaseObject
    {
        #region <Data>

        private readonly Int64 pmax;
        private readonly Int64 pmin;

        #endregion

        /// <param name="min"> ”станавливает минимальную границу по данному измерению</param>
        /// <param name="max"> ”станавливает максимальную границу по данному измерению</param>
        /// <example>
        ///   ≈сли измерение определно на интервале (-100,500)
        ///   <code>
        ///     X = new dimension(-100,500);
        ///   </code> 
        /// </example>
        /// <summary>
        ///  онструктор
        /// ¬ случае, если min>max внешна€ система не оповещаетс€, а происходит автоматическа€ замена значений.
        /// ќднако при этом сыбрасываетс€ сообщение в дебагер.
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
                Debug.WriteLine("ѕредупреждение: " + (GetType()) + " при создании min > max");
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
        ///ћетод реализующий отношение эквивалентности
        ///</summary>
        ///<param name="obj">»змерение котрое провер€ем на эквивалентность даному</param>
        ///<returns>true если области опрделни€ измерний совпадают, иначе false</returns>
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
        /// ѕоле класса хран€щее максимальную границу области на которой 
        /// определено измерение. “олько дл€ чтени€
        /// </summary>        
        public Int64 max
        {
            get { return pmax; }
        }

        /// <summary>
        /// ѕоле класса хран€щее минимальную границу области на которой 
        /// определено измерение. “олько дл€ чтени€
        /// </summary>
        public Int64 min
        {
            get { return pmin; }
        }

        ///<summary>
        /// ѕоле класса хран€щее длинну области на которой определено данное измерение
        /// “олько дл€ чтени€
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