using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Requests;
using ChainAnalises.Classes.Statistics.MarkovChain;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains
{

    ///<summary>
    ///</summary>
    [Serializable]
    public class RequestMarkovChain:Request
    {
        /// <summary>
        /// This is type of random generator (Simple..)
        /// </summary>
        public GeneratorType Generator;
        /// <summary>
        /// This is type of markov chain (Uniform, NotUniform...)
        /// </summary>
        public GeneratingMethod Method;

        /// <summary>
        /// Mehtod pre changing chain
        /// </summary>
        public TeachingMethod PreChanges;
        /// <summary>
        /// Length of generated chain 
        /// </summary>
        public int Length;

        /// <summary>
        /// Generated chains count
        /// </summary>
        public int GenerateChainsCount;

        /// <summary>
        /// Rang of markov chain
        /// </summary>
        public int MarkovChainRang;

        /// <summary>
        /// Chain struct SOAP
        /// </summary>
        public SoapChainOfChains Chain;
    }
}