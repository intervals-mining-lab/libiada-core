using System;
using System.Collections.Generic;
using System.Text;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    ///<summary>
    /// Фабрика нитей различных сервисов
    ///</summary>
    public static class ThreadsFactory
    {

       ///<summary>
       /// Создёт новую нить заданного вычислительного сервиса.
       ///</summary>
       ///<param name="wstype">Тип сервиса</param>
       ///<returns>Нить</returns>
       ///<exception cref="Exception">Неизвестный тип нити</exception>
       public static IThread CreateThread(WebServiceType wstype)
       {
           switch(wstype)
           {
               case WebServiceType.Calculate:
                   return new CalculatingThread();
               case WebServiceType.Alphabet: 
                   return new AlphabetThread();
               case WebServiceType.MarkovChain:
                   return new MarkovChainThread();
               case WebServiceType.PhantomChain:
                   return new PhantomChainThread();
               case WebServiceType.Clusterization:
                   return new ClusterizationThread();
               case WebServiceType.Segmentation:
                   return new SegmentationThread();
               default:
                   throw new Exception("Wrong action");
           }
       }
    }
}
