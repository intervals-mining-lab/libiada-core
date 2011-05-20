using System;
using System.Collections.Generic;
using System.Text;
using MDA.OIP.ScoreModel;

namespace MDA.OIP.BorodaDivider
{
    public class FmotivDivider
    {
        public FmotivChain GetDivision(UniformScoreTrack unitrack)
        {
            FmotivChain Temp = new FmotivChain();

            Temp.Name = unitrack.Name;


            return Temp;
        }
    }
}
