using System;
using System.Collections.Generic;
using System.Text;

namespace MDA.OIP.BorodaDivider
{
    public class FmotivIdentificator
    {
        public FmotivChain GetIdentification(FmotivChain fmotivchain)
        {
            FmotivChain Temp = (FmotivChain)fmotivchain.Clone();

            for(int i=0; i < fmotivchain.FmotivList.Count; i++)
            {
                for (int j=i; j < fmotivchain.FmotivList.Count; j++)
                {
                    if (fmotivchain.FmotivList[i].Equals(fmotivchain.FmotivList[j])) 
                    {
                        fmotivchain.FmotivList[j].Id = fmotivchain.FmotivList[i].Id;
                    }
                }
            }

            return Temp;
        }
    }
}
