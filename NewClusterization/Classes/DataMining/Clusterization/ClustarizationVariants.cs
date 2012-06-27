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
        ///<param name="bin"></param>
        ///<exception cref="NotImplementedException"></exception>
        public ClustarizationVariants(ClustarizationVariantsBin bin)
        {
            foreach (ClusterizationResultBin variant in bin.Variants)
            {
                Variants.Add(variant.GetInstance());
            }
        }

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

        public IBin GetBin()
        {
            ClustarizationVariantsBin Temp =new ClustarizationVariantsBin();
            foreach (ClusterizationResult result in Variants)
            {
                Temp.Variants.Add(result.GetBin());
            }
            return Temp;
        }
    }

    ///<summary>
    ///</summary>
    public class ClustarizationVariantsBin:IBin
    {
        public ArrayList Variants = new ArrayList();

        public IBaseObject GetInstance()
        {
            return new ClustarizationVariants(this);
        }
    }
}