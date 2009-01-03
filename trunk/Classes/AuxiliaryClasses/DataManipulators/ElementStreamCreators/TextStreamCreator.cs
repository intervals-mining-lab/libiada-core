using System;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.Root.SimpleTypes;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators
{
    ///<summary>
    ///</summary>
    public class TextStreamCreator : ElementStreamCreator
    {
        ///<summary>
        ///</summary>
        ///<param name="F"></param>
        ///<returns></returns>
        public override ElementStream Create(File F)
        {
            ElementStream temp = new ElementStream(F.FileType);
            int i = 0;
            foreach (char ElementValue in F.Data.ToCharArray())
            {
                if (!((ElementValue.Equals('\n') || ElementValue.Equals('\r'))))
                {
                    temp.Add(new ValueString( Convert.ToString(ElementValue)));
                    i++;
                }
                else
                {
                    ;
                }
            }
            return temp;
        }
    }
}