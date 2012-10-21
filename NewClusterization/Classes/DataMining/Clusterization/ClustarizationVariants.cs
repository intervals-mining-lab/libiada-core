using System;
using System.Collections;
using LibiadaCore.Classes.Root;

namespace NewClusterization.Classes.DataMining.Clusterization
{
    ///<summary>
    ///</summary>
    public class ClustarizationVariants: IBaseObject 
    {
        public ArrayList Variants = new ArrayList();

        ///<summary>
        ///</summary>
        public ClustarizationVariants()
        {
        }


        public IBaseObject Clone()
        {
            ClustarizationVariants Temp = new ClustarizationVariants();
            Temp.Variants = (ArrayList) Variants.Clone();
            return Temp;
        }
    }
}