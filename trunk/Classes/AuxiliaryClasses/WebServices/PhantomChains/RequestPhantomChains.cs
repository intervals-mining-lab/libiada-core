using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.SOAP;
using ChainAnalises.Classes.Statistics.MarkovChain.Generators;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains
{
    ///<summary>
    /// ��������� � ��������� ������� ��� ��������� ��������� �����.
    ///</summary>
    [Serializable]
    public class RequestPhantomChains:Request
    {
        /// <summary>
        /// ��� ���������� ��������� �������, ������������� � �������� ���������
        /// </summary>
        public GeneratorType Generator;
        /// <summary>
        /// ��������� ���������� ��������� �������
        /// </summary>
        public int GenerateChainsCount;
        /// <summary>
        /// ������� ������� ��� ���������
        /// </summary>
        public SoapChainOfChains Chain;
    }
}