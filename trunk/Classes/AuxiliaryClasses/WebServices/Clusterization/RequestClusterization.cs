using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Requests;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;
using ChainAnalises.Classes.Statistics.MarkovChain;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class RequestClusterization : Request
    {
        public SoapDataTable DataTable = null;
        public MethodClusterization Method;
        public int ClusterCount = 0;


    }
}