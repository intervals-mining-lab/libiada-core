using System.Collections;
using LibiadaCore.Classes.Root;

namespace Clusterizator.Classes
{
    ///<summary>
    ///</summary>
    public class ClustarizationVariants: IBaseObject 
    {
        public ArrayList Variants = new ArrayList();

        public IBaseObject Clone()
        {
            var result = new ClustarizationVariants {Variants = (ArrayList) Variants.Clone()};
            return result;
        }
    }
}