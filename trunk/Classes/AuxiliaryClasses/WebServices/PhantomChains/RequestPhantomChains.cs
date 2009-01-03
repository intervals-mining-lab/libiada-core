using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.Statistics.MarkovChain;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class RequestPhantomChains
    {
        public GeneratorType Generator;
        public int GenerateChainsCount;
        public SoapChainOfChains Chain;
    }
}