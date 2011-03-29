using System;
using System.Collections.Generic;
using System.Text;
using ChainAnalises.Classes.Root;

namespace MDA.OIP
{
    public class UniformScoreTrack : IBaseObject
    {
        public UniformScoreTrack() 
        {

        }



        protected void FillClone(IBaseObject temp)
        {
            UniformScoreTrack tempSpace = temp as UniformScoreTrack;
            if (tempSpace != null)
            {

            }
        }

        public IBaseObject Clone()
        {
            UniformScoreTrack Temp = new UniformScoreTrack();
            FillClone(Temp);
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


    }
}
