using System;
using System.Collections.Generic;
using System.Text;

namespace ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional.Threads
{
    ///<summary>
    ///</summary>
    public class FactoryThreads
    {

       ///<summary>
       ///</summary>
       ///<param name="wstype"></param>
       ///<returns></returns>
       ///<exception cref="Exception"></exception>
       public IThread CreateThread(WebServiceType wstype)
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
