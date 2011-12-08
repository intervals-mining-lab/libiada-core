using System.Text;
using ChainAnalises.Classes.AuxiliaryClasses.WebServices.Additional;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Root.SimpleTypes;

namespace ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.ElementStreamCreators
{
    public class FonemStreamCreator : ElementStreamCreator
    {
        public override ElementStream Create(File F)
        {
            ElementStream temp = new ElementStream(F.FileType);
            int i = 0;
            string TempFonema = "";
            foreach (char ElementValue in F.Data.ToCharArray())
            {
                if(ElementValue.Equals('\r') || ElementValue.Equals('\n'))
                {
                    temp.Add(new ValueString(TempFonema));
                    TempFonema = "";
                }else
                {
                    TempFonema += ElementValue;
                }
            }
            return temp;
        }
    }
}