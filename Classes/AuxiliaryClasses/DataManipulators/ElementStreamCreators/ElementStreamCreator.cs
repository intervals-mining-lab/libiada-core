using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators
{
    ///<summary>
    ///</summary>
    public abstract class ElementStreamCreator
    {
        ///<summary>
        ///</summary>
        ///<param name="F"></param>
        ///<returns></returns>
        public abstract ElementStream Create(File F);
    }
}