using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;

namespace MDA.OIP.ScoreModel
{
    public class UniformScoreTrack : IBaseObject // монофонический (моно) трек
    {
        private string name; // название моно дорожки (по инструменту или партии)
        private  List<Measure> measurelist; // список тактов моно дорожки
        
        public UniformScoreTrack(string name, List<Measure> measurelist) 
        {
            this.measurelist = new List<Measure>();
            for (int i = 0; i < measurelist.Count; i++) // создаем список тактов, по средствам клонирования каждого такта.
            {
                this.measurelist.Add((Measure)measurelist[i].Clone());
            }
            this.name = name;
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public List<Measure> Measurelist
        {
            get
            {
                return measurelist;
            }
        }

        #region IBaseMethods

        private UniformScoreTrack()
        {
            ///<summary>
            /// Stub for GetBin
            ///</summary>  
        }

        public IBaseObject Clone()
        {
            UniformScoreTrack Temp = new UniformScoreTrack(this.name, this.measurelist);
            return Temp;
        }

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
            UniformScoreTrackBin Temp = new UniformScoreTrackBin();
            ///<summary>
            /// Stub
            ///</summary>
            return Temp;
        }

        public class UniformScoreTrackBin : IBin
        {
            public IBaseObject GetInstance()
            {
                ///<summary>
                /// Stub
                ///</summary>
                return new UniformScoreTrack();
            }
        }

        #endregion
    }
}
