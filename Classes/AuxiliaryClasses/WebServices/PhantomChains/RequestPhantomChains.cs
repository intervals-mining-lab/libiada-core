using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains
{
    ///<summary>
    ///  онтейнер с исходными данными дл€ генерации фантомных цепей.
    ///</summary>
    [Serializable]
    public class RequestPhantomChains:Request
    {
        /// <summary>
        /// »м€ генератора случайных величин, используемого в процессе генерации
        /// </summary>
        public GeneratorType Generator;
        /// <summary>
        /// “ребуемое количество фантомных цепочек
        /// </summary>
        public int GenerateChainsCount;
        /// <summary>
        /// Ѕазова€ цепочка дл€ генерации
        /// </summary>
        public SoapChainOfChains Chain;
    }
}