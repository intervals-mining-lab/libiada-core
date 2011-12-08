using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Calculate;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Clusterization;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.CreateAlphabet;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.GenerateMarkovChains;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.PhantomChains;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Segmentation;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional
{
    ///<summary>
    /// Фабрика контейнеров-ответов для сервисов
    ///</summary>
    public static class AnswerFactory
    {
        ///<summary>
        /// Статический метод создания контейнеров с результатами
        ///</summary>
        ///<param name="type">тип сервиса</param>
        ///<returns>контейнер</returns>
        ///<exception cref="Exception">Неизвестный тип сервиса</exception>
        public static Answer CreateAnswer (WebServiceType type)
        {
            switch (type)
            {
                case WebServiceType.Alphabet:
                    return new AnswerObjects();
                case WebServiceType.Calculate:
                    return new AnswerChain();
                case WebServiceType.Clusterization:
                    return new AnswerClusterization();
                case WebServiceType.MarkovChain:
                    return new AnswerMarkovChain();
                case WebServiceType.PhantomChain:
                    return new AnswerPhantomChains();
                case WebServiceType.Segmentation:
                    return new AnswerSegmentation();
                default:
                    throw new Exception("Неизвестный тип сервиса");
            }
        }
    }
}
